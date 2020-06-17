# SRSManager

## 简介

- SRSManager用于管理和控制SRS流媒体服务器的配置文件，将配置文件进行结构化处理，使配置文件更容易控制。
- 对SRS进程进行管理，使之可以通过一系列API来实现启动，停止，重启，重新加载配置等操作。
- 提供WEB管理接口，实现WebApi方式下的SRS管理。
- 在SRS之外集成onvif设备的管理，包括onvif设备探测，onvif ptz控制，onvif meidaurl获取等。
- 开设此项目主要原因是在自己的项目中要使用到SRS，为了更方便的使用SRS以满足项目所需而开设此项目，也同时为开
  源社区做些力所能及的贡献。
- 项目采用.net core 3.1 编译，SRSWebApi采用Asp.net Core 3.1 的WebApi工程开发，集成了Swagger接口调试文档，
  Onvif相关功能采用了Mictlanix.DotNet.Onvif控制类库。
- 项目中不包含SRS进程内容，需要你自己编译SRS工程，SRS开源地址为：https://github.com/ossrs/srs     
  本项目基于SRS 4.0+ release版本进行编码。
- 本项目支持linux和macos,需要.net core 3.1运行库支持。
  
## 重要

- 此项目还在开发中，不能用于生产环境。
- 出于对项目的需要，对srs的源码进行了简单修改，使http_hook时带上device_id,device_id来源于心跳中的device_id
- 对于srs源码的修改已在官方git中与官方提出，希望官方可以考虑进。

## 组成部分
- OnvifClient onvif的控制模块，用于发现，ptz探测等
- SRSApis 封装对SRS进程的相关功能API
- SRSConfFile 封装对SRS配置文件的结构化处理，可以读取与重写SRS配置文件 
- SRSManageCommon 项目中用到的相对通用的一些类和方法
- SRSWebApi 将SRSApis项目中的各种接口用WebApi的方式开放出来
- SRSCallBackManager 用于处理SRS的各种回调数据(废弃，移到SRSManageCommon项目中)
- Test_ 开头的项目是针对于以上部分的功能测试项

## 设计考虑
- 由于SRS属于自定义配置文件格式，在其他语言或其他项目中对SRS的配置文件操作较为困难，出于对SRS的管理考虑需要对配置
  文件进行结构化配置，需要实现.conf文件的结构化读入，与结构化实例序列化成SRS的.conf文件。这样会使对SRS管理来得相
  对轻松。
- 考虑一般摄像头没有rtp推流能力，只拥有rtsp流暴露的特性，考虑融入onvif相关功能，自动探测发现摄像头的rtsp流地址，
  ptz云台的控制等功能，使之可以配合srs的ingest进行联动，使一般摄像头通过SRS的ingest实现视频流转rtmp输出。
- OnvifClient,SRSApis,SRSConfFile,SRSManageCommon,SRSWebApi相互依赖的工程组，这一套需要实现完整的Onvif+SRS
  的控制单元，其中SRS进程实例和OnvifClient控制实例为List<Object>的形式存在，因此一台服务器上允许多个SRS进程及多个
  Onvif设备同时存在，SRS进程以uuid来区分彼此，onvif设备以ip地址及profile中的uuid来区分不同设备及不同设备下的不同
  媒体流。
- 我将OnvifClient,SRSApis,SRSConfFile,SRSManageCommon,SRSWebApi工程的集成称之为一个StreamNode，在StreamNode
  中~~我尽可能不采用任何关系型数据库组件~~来实现所有功能，这样可以保证程序最大程度上的自由性，简化其安装部署的难度。
- 打脸了，随着开发深入，发现不使用数据库组件使很多问题变得复杂，因此引入了FreeSql开源数据库组件，来支持相关数据的存储与查询。
- 对SRS原有HTTP API进行封装与转发，实现风格统一，鉴权统一的webapi接口。

## Api接口说明
+ 接口采用HttpWebApi方式提供，提供方式为http://serverip:apiport/接口类型/API方法
+ 接口调用方式：HttpGet、HttpPost
+ 当传输入参数为简单参数时采用HttpGet方式调用，复杂对象参数时采用HttpPost方式调用
+ 接口的输入参数与输出结果均为json封装方式（部份接口输入输出为简单结果时采用基础类型做为输入输出 int,string,bool等）

```
例如调用检测Srs实例是否正在运行时，可以通过CURL发送以下http请求获得状态
curl -X GET "http://192.168.2.42:5800/GlobalSrs/IsRunning?deviceId=22364bc4-5134-494d-8249-51d06777fb7f" -H "accept: */*"
```
## 异常与正常
+ 当接口调用出现异常时，API返回HttpStatusCode为400，同时告知异常原因,返回结构如下：
```json
 {
 	"Code": 0,  //错误代码
 	"Message": "无错误" //错误原因描述
 }
```
+ 当出现系统级异常时，由asp.net core自动捕获（比如传入参数有格式问题等情况）,
asp.net core将返回HttpStatusCode为400，并给出异常原因，返回结构如下：
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "|1e26aa01-4d02465285d0af0c.",
  "errors": {
    "": [
      "A non-empty request body is required."
    ],
    "obj": [
      "The obj field is required."
    ]
  }
}
```
+ 当接口调用正常时,HttpStatusCode为200，返回数据可以根据输出参数要求进行进行接收，并返序列化json到相应的实体类类型

## 接口调用约定
+ 时区:+8区
+ 时间格式: yyyy-MM-dd HH:mm:ss
+ 调用方式:HttpGet|HttpPost
+ 耗时操作:采用http callback的方式进行，当某个操作是耗时操作时（如/DvrPlan/CutOrMergeVideoFile）,接口要求在请求时传入callback地址，在操作完成后通过callback地址来通知接口调用应用相关结果 
+ 所有对Srs配置进行写操作（Set,Delete,Update,Insert|Create）的接口，均不会在操作完成后重写配置文件，需要应用调用/System/RefreshSrsObject接口才会将最新的配置信息写入对应的Srs进程配置文件中，并且自动Reload配置文件来刷新Srs运行参数
## 接口说明
### SRS全局接口-GlobalSrs
+ 提供对srs控制及全局参数修改方面的接口
#### GlobalSrs/IsRunning
+ 调用方式:HttpGet
+ 接口作用:检测Srs实例是否正在运行.
+ 输入参数:deviceId:string
+ 输出参数:true|false:bool|ExceptStruct
#### GlobalSrs/IsInit
+ 调用方式:HttpGet
+ 接口作用:检测Srs实例配置文件是否被加载并且初始化.
+ 输入参数:deviceId:string
+ 输出参数:true|false:bool|ExceptStruct
#### GlobalSrs/StartSrs
+ 调用方式:HttpGet
+ 接口作用:用于启动一个Srs实例进程（启动srs程序   ./srs -c config.conf）
+ 输入参数:deviceId:string
+ 输出参数:true|false:bool|ExceptStruct
#### GlobalSrs/StopSrs
+ 调用方式:HttpGet
+ 接口作用:停止srs进程，结束掉srs的服务
+ 输入参数:deviceId:string
+ 输出参数:true|false:bool|ExceptStruct
#### GlobalSrs/RestartSrs
+ 调用方式:HttpGet
+ 接口作用:重新启动Srs实例进程，内部逻辑先SrsStop,再SrsStart
+ 输入参数:deviceId:string
+ 输出参数:true|false:bool|ExceptStruct
#### GlobalSrs/ReloadSrs
+ 调用方式:HttpGet
+ 接口作用:重新加载Srs配置文件（热加载，不用停止Srs进程服务）向进程发送 SIGHUP信号 kill -s SIGHUP pid
+ 输入参数:deviceId:string
+ 输出参数:true|false:bool|ExceptStruct
#### /GlobalSrs/ChangeGlobalParams
+ 调用方式:Post
+ 接口作用:修改Srs的全局参数
+ 输入参数:
```json
{
  "deviceId": "string", //Srs实例id
  "gm": {
    "heartbeatEnable": true, //是否启用srs心跳
    "heartbeatSummariesEnable": true, //是否在srs心跳时带上系统统计信息
    "heartbeatUrl": "string", //srs心跳发送url地址（应用可以接管这个地址，默认由StreamNode接管）
    "httpApiEnable": true, //是否启用srs的httpapi,这个必须要启用，StreamNode里需要用到它
    "httpApiListen": 0,//srs的httpapi监听接口
    "httpServerEnable": true,//是否启用srs的httpServer，建议启用
    "httpServerListen": 0,//srs的httpserver监听端口
    "httpServerPath": "string",//srs的httpserver发布目录相当于nginx的wwwroot
    "listen": 0,//srs的rtmp监听端口，默认1935
    "maxConnections": 0 //srs的最大连接数量,默认linux系统1000,macos系统 128
  }
}
```
+ 输出参数:true|false:bool|ExceptStruct
+ 注意：别随便乱改这个参数

### 系统接口-System
+ 提供系统及StremNode层面的各类接口
#### /System/RefreshSrsObject
+ 调用方式:HttpGet
+ 接口作用:将内存中的Srs配置信息写入到对应的Srs实例配置文件里，并向Srs发送配置刷新命令，使Srs运行在刷新后配置信息的环境下
+ 输入参数:deviceId:string
+ 输出参数:true|false:bool|ExceptStruct
#### /System/GetAllSrsManagerDeviceId
+ 调用方式:HttpGet
+ 接口作用:获取StreamNode管理下的所有Srs实例设备ID
+ 输入参数:null
+ 输出参数:List<string>|ExceptStruct
```json
[
  "22364bc4-5134-494d-8249-51d06777fb7f"
]
```
#### /System/CreateNewSrsInstance
+ 调用方式:HttpPost
+ 接口作用:创建一个新的Srs实例
+ 输入参数:
<details>
<summary>展开查看</summary>
<pre><code>
{
	"srs": {
		"rtc_server": {
			"enabled": true,
			"listen": 0,
			"candidate": "string",
			"ecdsa": true,
			"sendmmsg": 0,
			"encrypt": true,
			"reuseport": 0,
			"merge_nalus": true,
			"gso": true,
			"padding": 0,
			"perf_stat": true,
			"queue_length": 0,
			"black_hole": {
				"enabled": true,
				"publisher": "string"
			}
		},
		"tcmalloc_release_rate": 0,
		"listen": 0,
		"pid": "string",
		"chunk_size": 0,
		"ff_log_dir": "string",
		"ff_log_level": "string",
		"srs_log_tank": "string",
		"srs_log_level": "string",
		"srs_log_file": "string",
		"max_connections": 0,
		"daemon": true,
		"utc_time": true,
		"pithy_print_ms": 0,
		"work_dir": "string",
		"asprocess": true,
		"empty_ip_ok": true,
		"grace_start_wait": 0,
		"grace_final_wait": 0,
		"force_grace_quit": true,
		"disable_daemon_for_docker": true,
		"inotify_auto_reload": true,
		"auto_reload_for_docker": true,
		"heartbeat": {
			"enabled": true,
			"interval": 0,
			"url": "string",
			"device_id": "string",
			"summaries": true,
			"instanceName": "string"
		},
		"stats": {
			"network": 0,
			"disk": "string"
		},
		"http_api": {
			"enabled": true,
			"listen": 0,
			"crossdomain": true,
			"raw_Api": {
				"enabled": true,
				"allow_reload": true,
				"allow_query": true,
				"allow_update": true
			},
			"instanceName": "string"
		},
		"http_server": {
			"enabled": true,
			"listen": 0,
			"dir": "string",
			"crossdomain": true,
			"instanceName": "string"
		},
		"stream_casters": [{
			"sip": {
				"enabled": true,
				"listen": 0,
				"serial": "string",
				"realm": "string",
				"ack_timeout": 0,
				"keepalive_timeout": 0,
				"auto_play": true,
				"invite_port_fixed": true,
				"query_catalog_interval": 0
			},
			"auto_create_channel": true,
			"enabled": true,
			"caster": "mpegts_over_udp",
			"output": "string",
			"listen": 0,
			"rtp_port_min": 0,
			"rtp_port_max": 0,
			"host": "string",
			"audio_enable": true,
			"wait_keyframe": true,
			"rtp_idle_timeout": 0,
			"instanceName": "string"
		}],
		"srt_server": {
			"default_app": "string",
			"enabled": true,
			"listen": 0,
			"maxbw": 0,
			"connect_timeout": 0,
			"peerlatency": 0,
			"recvlatency": 0,
			"instanceName": "string"
		},
		"kafka": {
			"enabled": true,
			"brokers": "string",
			"topic": "string",
			"instanceName": "string"
		},
		"vhosts": [{
			"vnack": {
				"enabled": true
			},
			"instanceName": "string",
			"vhostDomain": "string",
			"enabled": true,
			"min_latency": true,
			"tcp_nodelay": true,
			"chunk_size": 0,
			"in_ack_size": 0,
			"out_ack_size": 0,
			"rtc": {
				"enabled": true,
				"bframe": "string",
				"acc": "string",
				"stun_timeout": 0,
				"stun_strict_check": true
			},
			"vcluster": {
				"mode": "string",
				"origin": "string",
				"token_traverse": true,
				"vhost": "string",
				"debug_srs_upnode": true,
				"origin_cluster": true,
				"coworkers": "string",
				"instanceName": "string"
			},
			"vforward": {
				"enabled": true,
				"destination": "string"
			},
			"vplay": {
				"mw_msgs": 0,
				"gop_cache": true,
				"queue_length": 0,
				"time_jitter": "full",
				"atc": true,
				"mix_correct": true,
				"atc_auto": true,
				"mw_latency": 0,
				"send_min_interval": 0,
				"reduce_sequence_header": true
			},
			"vpublish": {
				"mr": true,
				"mr_latency": 0,
				"firstpkt_timeout": 0,
				"normal_timeout": 0,
				"parse_sps": true,
				"instanceName": "string"
			},
			"vrefer": {
				"enabled": true,
				"all": "string",
				"publish": "string",
				"play": "string",
				"instanceName": "string"
			},
			"vbandcheck": {
				"enabled": true,
				"key": "string",
				"interval": 0,
				"limit_kbps": 0
			},
			"vsecurity": {
				"enabled": true,
				"seo": [{
					"sem": "allow",
					"set": "publish",
					"rule": "string"
				}]
			},
			"vhttp_static": {
				"enabled": true,
				"mount": "string",
				"dir": "string"
			},
			"vhttp_remux": {
				"enabled": true,
				"fast_cache": 0,
				"mount": "string",
				"hstrs": true
			},
			"vhttp_hooks": {
				"enabled": true,
				"on_connect": "string",
				"on_close": "string",
				"on_publish": "string",
				"on_unpublish": "string",
				"on_play": "string",
				"on_stop": "string",
				"on_dvr": "string",
				"on_hls": "string",
				"on_hls_notify": "string"
			},
			"vexec": {
				"enabled": true,
				"publish": "string"
			},
			"vdash": {
				"enabled": true,
				"dash_fragment": 0,
				"dash_update_period": 0,
				"dash_timeshift": 0,
				"dash_path": "string",
				"dash_mpd_file": "string"
			},
			"vhls": {
				"enabled": true,
				"hls_fragment": 0,
				"hls_td_ratio": 0,
				"hls_aof_ratio": 0,
				"hls_window": 0,
				"hls_on_error": "string",
				"hls_path": "string",
				"hls_m3u8_file": "string",
				"hls_ts_file": "string",
				"hls_ts_floor": true,
				"hls_entry_prefix": "string",
				"hls_acodec": "string",
				"hls_vcodec": "string",
				"hls_cleanup": true,
				"hls_dispose": 0,
				"hls_nb_notify": 0,
				"hls_wait_keyframe": true,
				"hls_keys": true,
				"hls_fragments_per_key": 0,
				"hls_key_file": "string",
				"hls_key_file_path": "string",
				"hls_key_url": "string",
				"hls_dts_directly": true
			},
			"vhds": {
				"enabled": true,
				"hds_fragment": 0,
				"hds_window": 0,
				"hds_path": "string"
			},
			"vdvr": {
				"enabled": true,
				"dvr_apply": "string",
				"dvr_plan": "string",
				"dvr_path": "string",
				"dvr_duration": 0,
				"dvr_wait_keyframe": true,
				"time_Jitter": "full"
			},
			"vingests": [{
				"ingestName": "string",
				"enabled": true,
				"input": {
					"type": "file",
					"url": "string"
				},
				"ffmpeg": "string",
				"engines": [{
					"enabled": true,
					"perfile": {
						"re": "string",
						"rtsp_transport": "string"
					},
					"iformat": "off",
					"vfilter": {
						"i": "string",
						"vf": "string",
						"filter_Complex": "string"
					},
					"vcodec": "string",
					"vbitrate": 0,
					"vfps": 0,
					"vwidth": 0,
					"vheight": 0,
					"vthreads": 0,
					"vprofile": "high",
					"vpreset": "medium",
					"vparams": {
						"t": 0,
						"coder": 0,
						"b_strategy": 0,
						"bf": 0,
						"refs": 0
					},
					"acodec": "string",
					"abitrate": 0,
					"asample_rate": 0,
					"achannels": 0,
					"aparams": {
						"profile_a": "string",
						"bsf_a": "string"
					},
					"oformat": "off",
					"output": "string",
					"engineName": "string",
					"instanceName": "string"
				}],
				"instanceName": "string"
			}],
			"vtranscodes": [{
				"enabled": true,
				"ffmpeg": "string",
				"engines": [{
					"enabled": true,
					"perfile": {
						"re": "string",
						"rtsp_transport": "string"
					},
					"iformat": "off",
					"vfilter": {
						"i": "string",
						"vf": "string",
						"filter_Complex": "string"
					},
					"vcodec": "string",
					"vbitrate": 0,
					"vfps": 0,
					"vwidth": 0,
					"vheight": 0,
					"vthreads": 0,
					"vprofile": "high",
					"vpreset": "medium",
					"vparams": {
						"t": 0,
						"coder": 0,
						"b_strategy": 0,
						"bf": 0,
						"refs": 0
					},
					"acodec": "string",
					"abitrate": 0,
					"asample_rate": 0,
					"achannels": 0,
					"aparams": {
						"profile_a": "string",
						"bsf_a": "string"
					},
					"oformat": "off",
					"output": "string",
					"engineName": "string",
					"instanceName": "string"
				}],
				"instanceName": "string"
			}]
		}],
		"configLines": [
			"string"
		],
		"streamNodeIpAddr": "string",
		"streamNodPort": 0,
		"deviceId": "string",
		"configLinesTrim": [
			"string"
		],
		"confFilePath": "string"
	},
	"srsConfigPath": "string",
	"srsDeviceId": "string",
	"srsWorkPath": "string",
	"srsPidValue": "string",
	"isStopedByUser": true
}
</code></pre>
</details>
+ 输出参数:SrsManage|null|ExceptStruct
+ 注:如果正常新建，则返回SrsManager对象,基本与传入参数一致
#### /System/GetSrsInstanceTemplate
+ 调用方式:HttpGet
+ 接口作用:获取一个SrsManager对象的模板，可以用于新建，在模板里已经做好了基本的设置
+ 输入参数:null
+ 输出参数:object:SrsMansger|ExceptStruct
<details>
<summary>展开查看</summary>
<pre><code>
{
  "srs": {
    "rtc_server": null,
    "tcmalloc_release_rate": null,
    "listen": 1935,
    "pid": "/root/StreamNode/21629eba-3bcf-42b0-b37e-4502896dcbe1/srs.pid",
    "chunk_size": 6000,
    "ff_log_dir": "/root/StreamNode/21629eba-3bcf-42b0-b37e-4502896dcbe1/ffmpegLog/",
    "ff_log_level": "warning",
    "srs_log_tank": "file",
    "srs_log_level": "verbose",
    "srs_log_file": "/root/StreamNode/21629eba-3bcf-42b0-b37e-4502896dcbe1/srs.log",
    "max_connections": 1000,
    "daemon": true,
    "utc_time": false,
    "pithy_print_ms": null,
    "work_dir": "/root/StreamNode/",
    "asprocess": false,
    "empty_ip_ok": null,
    "grace_start_wait": 2300,
    "grace_final_wait": 3200,
    "force_grace_quit": false,
    "disable_daemon_for_docker": null,
    "inotify_auto_reload": false,
    "auto_reload_for_docker": null,
    "heartbeat": {
      "enabled": true,
      "interval": 5,
      "url": "http://127.0.0.1:5000/api/v1/heartbeat",
      "device_id": "\"21629eba-3bcf-42b0-b37e-4502896dcbe1\"", //系统自动生成device_id,所有关于这个srs实例的内容都与device_id有关系.
      "summaries": true,                                       //一个StreamNode里不能存在两个相同的device_id
      "instanceName": null
    },
    "stats": null,
    "http_api": {
      "enabled": true,
      "listen": 8000,
      "crossdomain": true,
      "raw_Api": null,
      "instanceName": ""
    },
    "http_server": {
      "enabled": true,
      "listen": 8001,
      "dir": "/root/StreamNode/21629eba-3bcf-42b0-b37e-4502896dcbe1/wwwroot",
      "crossdomain": true,
      "instanceName": null
    },
    "stream_casters": null,
    "srt_server": null,
    "kafka": null,
    "vhosts": [
      {
        "vnack": null,
        "instanceName": "__defaultVhost__",
        "vhostDomain": "__defaultVhost__",
        "enabled": null,
        "min_latency": null,
        "tcp_nodelay": null,
        "chunk_size": null,
        "in_ack_size": null,
        "out_ack_size": null,
        "rtc": null,
        "vcluster": null,
        "vforward": null,
        "vplay": null,
        "vpublish": null,
        "vrefer": null,
        "vbandcheck": null,
        "vsecurity": null,
        "vhttp_static": null,
        "vhttp_remux": null,
        "vhttp_hooks": null,
        "vexec": null,
        "vdash": null,
        "vhls": null,
        "vhds": null,
        "vdvr": null,
        "vingests": null,
        "vtranscodes": null
      }
    ],
    "configLines": null,
    "streamNodeIpAddr": null,
    "streamNodPort": null,
    "deviceId": null,
    "configLinesTrim": null,
    "confFilePath": null
  },
  "srsConfigPath": "",
  "srsDeviceId": "21629eba-3bcf-42b0-b37e-4502896dcbe1",
  "srsWorkPath": "/root/StreamNode/",
  "srsPidValue": "",
  "isInit": true,
  "isStopedByUser": false,
  "isRunning": false
}
</code></pre>
</details>


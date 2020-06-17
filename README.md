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
```
 {
 	"Code": 0,  //错误代码
 	"Message": "无错误" //错误原因描述
 }
```
+ 当出现系统级异常时，由asp.net core自动捕获（比如传入参数有格式问题等情况）,
asp.net core将返回HttpStatusCode为400，并给出异常原因，返回结构如下：
```
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

### 全局接口-GlobalSrs
#### GlobalSrs/IsRunning
+ 调用方式:HttpGet
+ 接口作用:检测Srs实例是否正在运行.
+ 输入参数:deviceId:string
+ 输出参数:true|false:bool
#### GlobalSrs/IsInit
+ 调用方式:HttpGet
+ 接口作用:检测Srs实例配置文件是否被加载并且初始化.
+ 输入参数:deviceId:string
+ 输出参数:true|false:bool
#### GlobalSrs/StartSrs
+ 调用方式:HttpGet
+ 接口作用:用于启动一个Srs实例进程（启动srs程序   ./srs -c config.conf）.
+ 输入参数:deviceId:string
+ 输出参数:true|false:bool



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

## 组成部分
- OnvifClient onvif的控制模块，用于发现，ptz探测等
- SRSApis 封装对SRS进程的相关功能API
- SRSConfFile 封装对SRS配置文件的结构化处理，可以读取与重写SRS配置文件 
- SRSManageCommon 项目中用到的相对通用的一些类和方法
- SRSWebApi 将SRSApis项目中的各种接口用WebApi的方式开放出来
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
  中我尽可能不采用任何关系型数据库组件来实现所有功能，这样可以保证程序最大程度上的自由性，简化其安装部署的难度。
- 对SRS原有HTTP API进行封装与转发，实现风格统一，鉴权统一的webapi接口。

## 现有接口

{
  "openapi": "3.0.1",
  "info": {
    "title": "SRSWebApi",
    "version": "v1"
  },
  "paths": {
    "/Allow/RefreshSession": {
      "post": {
        "tags": [
          "Allow"
        ],
        "summary": "刷新Session",
        "requestBody": {
          "description": "旧的session",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Session"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Session"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Session"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Allow/GetSession": {
      "post": {
        "tags": [
          "Allow"
        ],
        "summary": "获取一个session用于通讯",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqGetSession"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqGetSession"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ReqGetSession"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Allow/SetAllowByKey": {
      "post": {
        "tags": [
          "Allow"
        ],
        "summary": "修改设置一个allow",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqSetOrAddAllow"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqSetOrAddAllow"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ReqSetOrAddAllow"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Allow/DelAllowByKey": {
      "post": {
        "tags": [
          "Allow"
        ],
        "summary": "删除一条allow",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqDelAllow"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqDelAllow"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ReqDelAllow"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Allow/AddAllow": {
      "post": {
        "tags": [
          "Allow"
        ],
        "summary": "添加一个allow",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqSetOrAddAllow"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqSetOrAddAllow"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ReqSetOrAddAllow"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Allow/GetAllows": {
      "post": {
        "tags": [
          "Allow"
        ],
        "summary": "获取授权列表",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqGetAllows"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqGetAllows"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ReqGetAllows"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/IsRunning": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "srs是否正在运行",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/IsInit": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "srs是否完成初始化",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/StartSrs": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "启动srs",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/StopSrs": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "停止srs",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/RestartSrs": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "重启srs",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/ReloadSrs": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "重新加载srs配置（srs.reload）",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/GlobalChangeChunksize": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "修改全局参数Chunksize",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "chunkSize",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/GlobalChangeHttpApiListen": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "修改全局参数HttpApiListen",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "port",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/GlobalChangeHttpApiEnable": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "修改全局参数HttpApiEnable",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "enable",
            "in": "query",
            "schema": {
              "type": "boolean"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/GlobalChangeMaxConnections": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "修改全局参数Maxconnections",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "max",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/GlobalChangeRtmpListen": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "修改全局参数rtmp listen",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "port",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/GlobalChangeHttpServerListen": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "修改全局参数Httpserver listen",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "port",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/GlobalChangeHttpServerPath": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "修改全局参数HttpserverPath",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "path",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/GlobalChangeHttpServerEnable": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "修改全局参数Httpserver enable",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "enable",
            "in": "query",
            "schema": {
              "type": "boolean"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/GetGlobalParams": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "获取srs实例的全局参数",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/GlobalSrs/ChangeGlobalParams": {
      "post": {
        "tags": [
          "GlobalSrs"
        ],
        "summary": "修改srs实例的全局参数",
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqChangeSrsGlobalParams"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqChangeSrsGlobalParams"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ReqChangeSrsGlobalParams"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Onvif/InitAll": {
      "post": {
        "tags": [
          "Onvif"
        ],
        "summary": "初始化还未初始化的onvif摄像头",
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Onvif/InitByIpAddress": {
      "post": {
        "tags": [
          "Onvif"
        ],
        "summary": "初始化还未初始化的onvif摄像头用ip 地址",
        "parameters": [
          {
            "name": "ipAddress",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Onvif/SetPtzZoom": {
      "post": {
        "tags": [
          "Onvif"
        ],
        "summary": "设置Ptz焦距",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/PtzZoomStruct"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/PtzZoomStruct"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/PtzZoomStruct"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Onvif/GetPtzPosition": {
      "post": {
        "tags": [
          "Onvif"
        ],
        "summary": "获取ptz坐标",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/PtzMoveStruct"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/PtzMoveStruct"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/PtzMoveStruct"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Onvif/PtzKeepMoveStop": {
      "post": {
        "tags": [
          "Onvif"
        ],
        "summary": "停止持续移动",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/PtzMoveStruct"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/PtzMoveStruct"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/PtzMoveStruct"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Onvif/PtzMove": {
      "post": {
        "tags": [
          "Onvif"
        ],
        "summary": "控制ptz移动",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/PtzMoveStruct"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/PtzMoveStruct"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/PtzMoveStruct"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Onvif/InitMonitor": {
      "post": {
        "tags": [
          "Onvif"
        ],
        "summary": "初始化onvif设备并加到管理列表中",
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqInitOnvif"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ReqInitOnvif"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ReqInitOnvif"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Onvif/GetMonitorList": {
      "post": {
        "tags": [
          "Onvif"
        ],
        "summary": "获取onvif摄像头参数列表",
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Onvif/GetMonitor": {
      "post": {
        "tags": [
          "Onvif"
        ],
        "summary": "跟据实例名称/ip地址获取onvif摄像头实例",
        "parameters": [
          {
            "name": "ipAddress",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/RtcServer/GetSrsRtcServer": {
      "post": {
        "tags": [
          "RtcServer"
        ],
        "summary": "获取rtcserver配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/RtcServer/SetRtcServer": {
      "post": {
        "tags": [
          "RtcServer"
        ],
        "summary": "设置或创建rtcserver",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsRtcServerConfClass"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsRtcServerConfClass"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SrsRtcServerConfClass"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/RtcServer/DelRtcServer": {
      "post": {
        "tags": [
          "RtcServer"
        ],
        "summary": "删除rtcserver",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/SrtServer/GetSrtServer": {
      "post": {
        "tags": [
          "SrtServer"
        ],
        "summary": "获取srtserver配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/SrtServer/SetSrtServer": {
      "post": {
        "tags": [
          "SrtServer"
        ],
        "summary": "设置或创建srtserver",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsSrtServerConfClass"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsSrtServerConfClass"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SrsSrtServerConfClass"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/SrtServer/DelSrtServer": {
      "post": {
        "tags": [
          "SrtServer"
        ],
        "summary": "删除srtserver",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Stats/GetSrsStats": {
      "post": {
        "tags": [
          "Stats"
        ],
        "summary": "获取Stats配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Stats/SetSrsStats": {
      "post": {
        "tags": [
          "Stats"
        ],
        "summary": "设置或创建stats",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsStatsConfClass"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsStatsConfClass"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SrsStatsConfClass"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Stats/DelStats": {
      "post": {
        "tags": [
          "Stats"
        ],
        "summary": "删除Stats",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/StreamCaster/GetStreamCasterInstanceNameList": {
      "post": {
        "tags": [
          "StreamCaster"
        ],
        "summary": "获取所有StreamCaster的实例名称",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/StreamCaster/GetStreamCasterInstanceList": {
      "post": {
        "tags": [
          "StreamCaster"
        ],
        "summary": "获取所有StreamCaster的实例",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/StreamCaster/CreateStreamCaster": {
      "post": {
        "tags": [
          "StreamCaster"
        ],
        "summary": "创建StreamCaster的实例",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsStreamCasterConfClass"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsStreamCasterConfClass"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SrsStreamCasterConfClass"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/StreamCaster/GetStreamCasterTemplate": {
      "post": {
        "tags": [
          "StreamCaster"
        ],
        "summary": "获取StreamCaster模板",
        "parameters": [
          {
            "name": "casterType",
            "in": "query",
            "schema": {
              "$ref": "#/components/schemas/CasterEnum"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/StreamCaster/DeleteStreamCasterByInstanceName": {
      "post": {
        "tags": [
          "StreamCaster"
        ],
        "summary": "用实例名称删除一个streamcaster",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "instanceName",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/StreamCaster/ChangeStreamCasterInstanceName": {
      "post": {
        "tags": [
          "StreamCaster"
        ],
        "summary": "修改streamcaster的实例名称",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "instanceName",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "newInstanceName",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/StreamCaster/OnOrOff": {
      "post": {
        "tags": [
          "StreamCaster"
        ],
        "summary": "停止或启动一个StreamCaster",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "instanceName",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          },
          {
            "name": "enable",
            "in": "query",
            "schema": {
              "type": "boolean"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/StreamCaster/SetStreamCaster": {
      "post": {
        "tags": [
          "StreamCaster"
        ],
        "summary": "设置一个StreamCaster",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsStreamCasterConfClass"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsStreamCasterConfClass"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SrsStreamCasterConfClass"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/RefreshSrsObject": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "刷新重新SRS配置文件",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/GetAllSrsManagerDeviceId": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "获取所有Srs管理器中的deviceid",
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/CreateNewSrsInstance": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "创建一个SrsInstance",
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsManager"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsManager"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SrsManager"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/GetSrsInstanceTemplate": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "获取SRS实例模板",
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/DelSrsByDevId": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "删除一个SRS实例",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/GetSrsInstanceByDeviceId": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "删除一个SRS实例",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/LoadOnvifConfig": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "加载onvif配置文件接口",
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/WriteOnvifConfig": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "写入onvif配置文件接口",
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/DelOnvifConfigByIpAddress": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "删除一个onvif摄像头配置",
        "parameters": [
          {
            "name": "ipAddress",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/GetSystemInfo": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "获取系统信息",
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/System/GetSrsInstanceList": {
      "post": {
        "tags": [
          "System"
        ],
        "summary": "获取SRS实例列表",
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Vhost/GetVhostsInstanceName": {
      "get": {
        "tags": [
          "Vhost"
        ],
        "summary": "获取Vhost列表的Instance名称列表",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Vhost/GetVhostByDomain": {
      "get": {
        "tags": [
          "Vhost"
        ],
        "summary": "通过domain获取vhost",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Vhost/GetVhostList": {
      "get": {
        "tags": [
          "Vhost"
        ],
        "summary": "获取Vhost列表",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Vhost/GetVhostTemplate": {
      "get": {
        "tags": [
          "Vhost"
        ],
        "summary": "获取Vhost的各类模板 [0:Stream] [1:File] [2:Device]",
        "parameters": [
          {
            "name": "vtype",
            "in": "query",
            "description": "",
            "schema": {
              "$ref": "#/components/schemas/VhostIngestInputType"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Vhost/SetVhost": {
      "post": {
        "tags": [
          "Vhost"
        ],
        "summary": "设置或创建Vhost的参数",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsvHostConfClass"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SrsvHostConfClass"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SrsvHostConfClass"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Vhost/DeleteVhostByDomain": {
      "post": {
        "tags": [
          "Vhost"
        ],
        "summary": "删除一个vhost,用域名",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "domain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Vhost/ChangeVhostDomain": {
      "post": {
        "tags": [
          "Vhost"
        ],
        "summary": "修改vhost的域名",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "domain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "newdomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostBandcheck/DeleteVhostBandcheck": {
      "post": {
        "tags": [
          "VhostBandcheck"
        ],
        "summary": "删除Bandcheck配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostBandcheck/GetVhostBandcheck": {
      "get": {
        "tags": [
          "VhostBandcheck"
        ],
        "summary": "获取Vhost中的Bandcheck",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostBandcheck/SetVhostBandcheck": {
      "post": {
        "tags": [
          "VhostBandcheck"
        ],
        "summary": "设置或创建Bandcheck",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Bandcheck"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Bandcheck"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Bandcheck"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostCluster/DeleteVhostCluster": {
      "post": {
        "tags": [
          "VhostCluster"
        ],
        "summary": "删除Cluster配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostCluster/GetVhostCluster": {
      "get": {
        "tags": [
          "VhostCluster"
        ],
        "summary": "获取Vhost中的Cluster",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostCluster/SetVhostCluster": {
      "post": {
        "tags": [
          "VhostCluster"
        ],
        "summary": "设置或创建Cluster",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Cluster"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Cluster"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Cluster"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostDash/DeleteVhostDash": {
      "post": {
        "tags": [
          "VhostDash"
        ],
        "summary": "删除Dash配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostDash/GetVhostDash": {
      "get": {
        "tags": [
          "VhostDash"
        ],
        "summary": "获取Vhost中的Dash",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostDash/SetVhostDash": {
      "post": {
        "tags": [
          "VhostDash"
        ],
        "summary": "设置或创建Dash",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Dash"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Dash"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Dash"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostDvr/DeleteVhostDvr": {
      "post": {
        "tags": [
          "VhostDvr"
        ],
        "summary": "删除Dvr配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostDvr/GetVhostDvr": {
      "get": {
        "tags": [
          "VhostDvr"
        ],
        "summary": "获取Vhost中的Dvr",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostDvr/SetVhostDvr": {
      "post": {
        "tags": [
          "VhostDvr"
        ],
        "summary": "设置或创建Dvr",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Dvr"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Dvr"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Dvr"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostExec/DeleteVhostExec": {
      "post": {
        "tags": [
          "VhostExec"
        ],
        "summary": "删除Exec配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostExec/GetVhostExec": {
      "get": {
        "tags": [
          "VhostExec"
        ],
        "summary": "获取Vhost中的Exec",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostExec/SetVhostExec": {
      "post": {
        "tags": [
          "VhostExec"
        ],
        "summary": "设置或创建Exec",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Exec"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Exec"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Exec"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostForward/DeleteVhostForward": {
      "post": {
        "tags": [
          "VhostForward"
        ],
        "summary": "删除Forward配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostForward/GetVhostForward": {
      "get": {
        "tags": [
          "VhostForward"
        ],
        "summary": "获取Vhost中的Forward",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostForward/SetVhostForward": {
      "post": {
        "tags": [
          "VhostForward"
        ],
        "summary": "设置Forward",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Forward"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Forward"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Forward"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHds/DeleteVhostHds": {
      "post": {
        "tags": [
          "VhostHds"
        ],
        "summary": "删除Hds配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHds/GetVhostHds": {
      "get": {
        "tags": [
          "VhostHds"
        ],
        "summary": "获取Vhost中的Hds",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHds/SetVhostHds": {
      "post": {
        "tags": [
          "VhostHds"
        ],
        "summary": "设置或创建Hds",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Hds"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Hds"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Hds"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHls/DeleteVhostHls": {
      "post": {
        "tags": [
          "VhostHls"
        ],
        "summary": "删除Hls配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHls/GetVhostHls": {
      "get": {
        "tags": [
          "VhostHls"
        ],
        "summary": "获取Vhost中的Hls",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHls/SetVhostHls": {
      "post": {
        "tags": [
          "VhostHls"
        ],
        "summary": "设置或创建Hls",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Hls"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Hls"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Hls"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHttpHooks/DeleteVhostHttpHooks": {
      "post": {
        "tags": [
          "VhostHttpHooks"
        ],
        "summary": "删除HttpHooks配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHttpHooks/GetVhostHttpHooks": {
      "get": {
        "tags": [
          "VhostHttpHooks"
        ],
        "summary": "获取Vhost中的HttpHooks",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHttpHooks/SetVhostHttpHooks": {
      "post": {
        "tags": [
          "VhostHttpHooks"
        ],
        "summary": "设置或创建HttpHooks",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/HttpHooks"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/HttpHooks"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/HttpHooks"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHttpRemux/DeleteVhostHttpRemux": {
      "post": {
        "tags": [
          "VhostHttpRemux"
        ],
        "summary": "删除HttpRemux配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHttpRemux/GetVhostHttpRemux": {
      "get": {
        "tags": [
          "VhostHttpRemux"
        ],
        "summary": "获取Vhost中的HttpRemux",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHttpRemux/SetVhostHttpRemux": {
      "post": {
        "tags": [
          "VhostHttpRemux"
        ],
        "summary": "设置或创建HttpRemux",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/HttpRemux"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/HttpRemux"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/HttpRemux"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHttpStatic/DeleteVhostHttpStatic": {
      "post": {
        "tags": [
          "VhostHttpStatic"
        ],
        "summary": "删除HttpStatic配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHttpStatic/GetVhostHttpStatic": {
      "get": {
        "tags": [
          "VhostHttpStatic"
        ],
        "summary": "获取Vhost中的HttpStatic",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostHttpStatic/SetVhostHttpStatic": {
      "post": {
        "tags": [
          "VhostHttpStatic"
        ],
        "summary": "设置或创建HttpStatic",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/HttpStatic"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/HttpStatic"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/HttpStatic"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostIngest/DeleteVhostIngestByIngestInstanceName": {
      "post": {
        "tags": [
          "VhostIngest"
        ],
        "summary": "通过VhostDomain和IngestInstanceName删除一个Ingest",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "ingestInstanceName",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostIngest/GetVhostIngestNameList": {
      "get": {
        "tags": [
          "VhostIngest"
        ],
        "summary": "获取所有或者指定vhost中的ingest实例名称",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "default": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostIngest/GetVhostIngest": {
      "get": {
        "tags": [
          "VhostIngest"
        ],
        "summary": "获取一个Ingest配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "ingestInstanceName",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostIngest/SetVhostIngest": {
      "post": {
        "tags": [
          "VhostIngest"
        ],
        "summary": "设置或创建Ingest",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "ingestInstanceName",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Ingest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Ingest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Ingest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostPlay/DeleteVhostPlay": {
      "post": {
        "tags": [
          "VhostPlay"
        ],
        "summary": "删除Play配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostPlay/GetVhostPlay": {
      "get": {
        "tags": [
          "VhostPlay"
        ],
        "summary": "获取Vhost中的Play",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostPlay/SetVhostPlay": {
      "post": {
        "tags": [
          "VhostPlay"
        ],
        "summary": "设置或创建Play",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Play"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Play"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Play"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostPublish/DeleteVhostPublish": {
      "post": {
        "tags": [
          "VhostPublish"
        ],
        "summary": "删除Publish配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostPublish/GetVhostPublish": {
      "get": {
        "tags": [
          "VhostPublish"
        ],
        "summary": "获取Vhost中的Publish",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostPublish/SetVhostPublish": {
      "post": {
        "tags": [
          "VhostPublish"
        ],
        "summary": "设置或创建Publish",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Publish"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Publish"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Publish"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostRefer/DeleteVhostRefer": {
      "post": {
        "tags": [
          "VhostRefer"
        ],
        "summary": "删除Refer配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostRefer/GetVhostRefer": {
      "get": {
        "tags": [
          "VhostRefer"
        ],
        "summary": "获取Vhost中的Refer",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostRefer/SetVhostRefer": {
      "post": {
        "tags": [
          "VhostRefer"
        ],
        "summary": "设置或创建Refer",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Refer"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Refer"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Refer"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostRtc/DeleteVhostRtc": {
      "post": {
        "tags": [
          "VhostRtc"
        ],
        "summary": "删除Rtc配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostRtc/GetVhostRtc": {
      "get": {
        "tags": [
          "VhostRtc"
        ],
        "summary": "获取Vhost中的Rtc",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostRtc/SetVhostRtc": {
      "post": {
        "tags": [
          "VhostRtc"
        ],
        "summary": "设置或创建Rtc",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Rtc"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Rtc"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Rtc"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostSecurity/DeleteVhostSecurity": {
      "post": {
        "tags": [
          "VhostSecurity"
        ],
        "summary": "删除Security配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostSecurity/GetVhostSecurity": {
      "get": {
        "tags": [
          "VhostSecurity"
        ],
        "summary": "获取Vhost中的Security",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostSecurity/SetVhostSecurity": {
      "post": {
        "tags": [
          "VhostSecurity"
        ],
        "summary": "设置或创建Security",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Security"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Security"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Security"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostTranscode/DeleteVhostTranscodeByTranscodeInstanceName": {
      "post": {
        "tags": [
          "VhostTranscode"
        ],
        "summary": "通过VhostDomain和TranscodeInstanceName删除一个Transcode",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "transcodeInstanceName",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostTranscode/GetVhostTranscodeNameList": {
      "get": {
        "tags": [
          "VhostTranscode"
        ],
        "summary": "获取所有或者指定vhost中的transcode实例名称",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "default": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostTranscode/GetVhostTranscode": {
      "get": {
        "tags": [
          "VhostTranscode"
        ],
        "summary": "获取一个Transcode配置",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "transcodeInstanceName",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/VhostTranscode/SetVhostTranscode": {
      "post": {
        "tags": [
          "VhostTranscode"
        ],
        "summary": "设置或创建Transcode",
        "parameters": [
          {
            "name": "deviceId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "vhostDomain",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          },
          {
            "name": "transcodeInstanceName",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "description": "",
              "nullable": true
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Transcode"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Transcode"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Transcode"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "Session": {
        "type": "object",
        "properties": {
          "allowKey": {
            "type": "string",
            "description": "授权key",
            "nullable": true
          },
          "refreshCode": {
            "type": "string",
            "description": "session刷新code",
            "nullable": true
          },
          "sessionCode": {
            "type": "string",
            "description": "session code",
            "nullable": true
          },
          "expires": {
            "type": "integer",
            "description": "过期时间",
            "format": "int64"
          }
        },
        "additionalProperties": false,
        "description": "session类结构"
      },
      "ReqGetSession": {
        "type": "object",
        "properties": {
          "allowKey": {
            "type": "string",
            "description": "allowkey",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "获取Session的请求结构"
      },
      "AllowKey": {
        "type": "object",
        "properties": {
          "key": {
            "type": "string",
            "description": "key值",
            "nullable": true
          },
          "ipArray": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "description": "ip地址列表",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "allowkey管理类"
      },
      "ReqSetOrAddAllow": {
        "type": "object",
        "properties": {
          "password": {
            "type": "string",
            "description": "密码",
            "nullable": true
          },
          "allowkey": {
            "$ref": "#/components/schemas/AllowKey"
          }
        },
        "additionalProperties": false,
        "description": "设置或添加Allow的请求结构"
      },
      "ReqDelAllow": {
        "type": "object",
        "properties": {
          "password": {
            "type": "string",
            "description": "密码",
            "nullable": true
          },
          "key": {
            "type": "string",
            "description": "uuid",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "删除一个授权访问的请求结构"
      },
      "ReqGetAllows": {
        "type": "object",
        "properties": {
          "password": {
            "type": "string",
            "description": "密码",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "获取授权访问列表的请求结构"
      },
      "GlobalModule": {
        "type": "object",
        "properties": {
          "heartbeatEnable": {
            "type": "boolean",
            "nullable": true
          },
          "heartbeatSummariesEnable": {
            "type": "boolean",
            "nullable": true
          },
          "heartbeatUrl": {
            "type": "string",
            "nullable": true
          },
          "httpApiEnable": {
            "type": "boolean",
            "nullable": true
          },
          "httpApiListen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "httpServerEnable": {
            "type": "boolean",
            "nullable": true
          },
          "httpServerListen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "httpServerPath": {
            "type": "string",
            "nullable": true
          },
          "listen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "maxConnections": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ReqChangeSrsGlobalParams": {
        "type": "object",
        "properties": {
          "deviceId": {
            "type": "string",
            "description": "srsmanager",
            "nullable": true
          },
          "gm": {
            "$ref": "#/components/schemas/GlobalModule"
          }
        },
        "additionalProperties": false,
        "description": "请求修改srs实例全局参数的结构"
      },
      "ZoomDir": {
        "enum": [
          0,
          1
        ],
        "type": "integer",
        "format": "int32"
      },
      "PtzZoomStruct": {
        "type": "object",
        "properties": {
          "ipAddr": {
            "type": "string",
            "nullable": true
          },
          "profileToken": {
            "type": "string",
            "nullable": true
          },
          "zoomDir": {
            "$ref": "#/components/schemas/ZoomDir"
          }
        },
        "additionalProperties": false
      },
      "PtzMoveDir": {
        "enum": [
          0,
          1,
          2,
          3,
          4,
          5,
          6,
          7
        ],
        "type": "integer",
        "format": "int32"
      },
      "PtzMoveType": {
        "enum": [
          0,
          1
        ],
        "type": "integer",
        "format": "int32"
      },
      "PtzMoveStruct": {
        "type": "object",
        "properties": {
          "ipAddr": {
            "type": "string",
            "nullable": true
          },
          "profileToken": {
            "type": "string",
            "nullable": true
          },
          "moveDir": {
            "$ref": "#/components/schemas/PtzMoveDir"
          },
          "moveType": {
            "$ref": "#/components/schemas/PtzMoveType"
          }
        },
        "additionalProperties": false
      },
      "ReqInitOnvif": {
        "type": "object",
        "properties": {
          "ipAddrs": {
            "type": "string",
            "description": "ip 地址串，多个ip 地址用空格隔开",
            "nullable": true
          },
          "username": {
            "type": "string",
            "description": "用户名",
            "nullable": true
          },
          "password": {
            "type": "string",
            "description": "密码",
            "nullable": true
          },
          "ipAddrArray": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "description": "初始化时不用传，此字段为内部使用",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "初始化onvif设备的请求结构"
      },
      "BlackHole": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "publisher": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SrsRtcServerConfClass": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "listen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "candidate": {
            "type": "string",
            "nullable": true
          },
          "ecdsa": {
            "type": "boolean",
            "nullable": true
          },
          "sendmmsg": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "encrypt": {
            "type": "boolean",
            "nullable": true
          },
          "reuseport": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "merge_nalus": {
            "type": "boolean",
            "nullable": true
          },
          "gso": {
            "type": "boolean",
            "nullable": true
          },
          "padding": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "perf_stat": {
            "type": "boolean",
            "nullable": true
          },
          "queue_length": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "black_hole": {
            "$ref": "#/components/schemas/BlackHole"
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SrsSrtServerConfClass": {
        "type": "object",
        "properties": {
          "default_app": {
            "type": "string",
            "nullable": true
          },
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "listen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "maxbw": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "connect_timeout": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "peerlatency": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "recvlatency": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SrsStatsConfClass": {
        "type": "object",
        "properties": {
          "network": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "disk": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Sip": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "listen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "serial": {
            "type": "string",
            "nullable": true
          },
          "realm": {
            "type": "string",
            "nullable": true
          },
          "ack_timeout": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "keepalive_timeout": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "auto_play": {
            "type": "boolean",
            "nullable": true
          },
          "invite_port_fixed": {
            "type": "boolean",
            "nullable": true
          },
          "query_catalog_interval": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "CasterEnum": {
        "enum": [
          0,
          1,
          2,
          3
        ],
        "type": "integer",
        "format": "int32"
      },
      "SrsStreamCasterConfClass": {
        "type": "object",
        "properties": {
          "sip": {
            "$ref": "#/components/schemas/Sip"
          },
          "auto_create_channel": {
            "type": "boolean",
            "nullable": true
          },
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "caster": {
            "$ref": "#/components/schemas/CasterEnum"
          },
          "output": {
            "type": "string",
            "nullable": true
          },
          "listen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "rtp_port_min": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "rtp_port_max": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "host": {
            "type": "string",
            "nullable": true
          },
          "audio_enable": {
            "type": "boolean",
            "nullable": true
          },
          "wait_keyframe": {
            "type": "boolean",
            "nullable": true
          },
          "rtp_idle_timeout": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SrsHeartbeatConfClass": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "interval": {
            "type": "number",
            "format": "float",
            "nullable": true
          },
          "url": {
            "type": "string",
            "nullable": true
          },
          "device_id": {
            "type": "string",
            "nullable": true
          },
          "summaries": {
            "type": "boolean",
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "RawApi": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "allow_reload": {
            "type": "boolean",
            "nullable": true
          },
          "allow_query": {
            "type": "boolean",
            "nullable": true
          },
          "allow_update": {
            "type": "boolean",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SrsHttpApiConfClass": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "listen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "crossdomain": {
            "type": "boolean",
            "nullable": true
          },
          "raw_Api": {
            "$ref": "#/components/schemas/RawApi"
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SrsHttpServerConfClass": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "listen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "dir": {
            "type": "string",
            "nullable": true
          },
          "crossdomain": {
            "type": "boolean",
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SrsKafkaConfClass": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "brokers": {
            "type": "string",
            "nullable": true
          },
          "topic": {
            "type": "string",
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Nack": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Rtc": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "bframe": {
            "type": "string",
            "nullable": true
          },
          "acc": {
            "type": "string",
            "nullable": true
          },
          "stun_timeout": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "stun_strict_check": {
            "type": "boolean",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Cluster": {
        "type": "object",
        "properties": {
          "mode": {
            "type": "string",
            "nullable": true
          },
          "origin": {
            "type": "string",
            "nullable": true
          },
          "token_traverse": {
            "type": "boolean",
            "nullable": true
          },
          "vhost": {
            "type": "string",
            "nullable": true
          },
          "debug_srs_upnode": {
            "type": "boolean",
            "nullable": true
          },
          "origin_cluster": {
            "type": "boolean",
            "nullable": true
          },
          "coworkers": {
            "type": "string",
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Forward": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "destination": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "PlayTimeJitter": {
        "enum": [
          0,
          1,
          2
        ],
        "type": "integer",
        "format": "int32"
      },
      "Play": {
        "type": "object",
        "properties": {
          "mw_msgs": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "gop_cache": {
            "type": "boolean",
            "nullable": true
          },
          "queue_length": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "time_jitter": {
            "$ref": "#/components/schemas/PlayTimeJitter"
          },
          "atc": {
            "type": "boolean",
            "nullable": true
          },
          "mix_correct": {
            "type": "boolean",
            "nullable": true
          },
          "atc_auto": {
            "type": "boolean",
            "nullable": true
          },
          "mw_latency": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "send_min_interval": {
            "type": "number",
            "format": "float",
            "nullable": true
          },
          "reduce_sequence_header": {
            "type": "boolean",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Publish": {
        "type": "object",
        "properties": {
          "mr": {
            "type": "boolean",
            "nullable": true
          },
          "mr_latency": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "firstpkt_timeout": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "normal_timeout": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "parse_sps": {
            "type": "boolean",
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Refer": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "all": {
            "type": "string",
            "nullable": true
          },
          "publish": {
            "type": "string",
            "nullable": true
          },
          "play": {
            "type": "string",
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Bandcheck": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "key": {
            "type": "string",
            "nullable": true
          },
          "interval": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "limit_kbps": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SecurityMethod": {
        "enum": [
          0,
          1
        ],
        "type": "integer",
        "format": "int32"
      },
      "SecurityTarget": {
        "enum": [
          0,
          1
        ],
        "type": "integer",
        "format": "int32"
      },
      "SecurityObj": {
        "type": "object",
        "properties": {
          "sem": {
            "$ref": "#/components/schemas/SecurityMethod"
          },
          "set": {
            "$ref": "#/components/schemas/SecurityTarget"
          },
          "rule": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Security": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "seo": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/SecurityObj"
            },
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "HttpStatic": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "mount": {
            "type": "string",
            "nullable": true
          },
          "dir": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "HttpRemux": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "fast_cache": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "mount": {
            "type": "string",
            "nullable": true
          },
          "hstrs": {
            "type": "boolean",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "HttpHooks": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "on_connect": {
            "type": "string",
            "nullable": true
          },
          "on_close": {
            "type": "string",
            "nullable": true
          },
          "on_publish": {
            "type": "string",
            "nullable": true
          },
          "on_unpublish": {
            "type": "string",
            "nullable": true
          },
          "on_play": {
            "type": "string",
            "nullable": true
          },
          "on_stop": {
            "type": "string",
            "nullable": true
          },
          "on_dvr": {
            "type": "string",
            "nullable": true
          },
          "on_hls": {
            "type": "string",
            "nullable": true
          },
          "on_hls_notify": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Exec": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "publish": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Dash": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "dash_fragment": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "dash_update_period": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "dash_timeshift": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "dash_path": {
            "type": "string",
            "nullable": true
          },
          "dash_mpd_file": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Hls": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "hls_fragment": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "hls_td_ratio": {
            "type": "number",
            "format": "float",
            "nullable": true
          },
          "hls_aof_ratio": {
            "type": "number",
            "format": "float",
            "nullable": true
          },
          "hls_window": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "hls_on_error": {
            "type": "string",
            "nullable": true
          },
          "hls_path": {
            "type": "string",
            "nullable": true
          },
          "hls_m3u8_file": {
            "type": "string",
            "nullable": true
          },
          "hls_ts_file": {
            "type": "string",
            "nullable": true
          },
          "hls_ts_floor": {
            "type": "boolean",
            "nullable": true
          },
          "hls_entry_prefix": {
            "type": "string",
            "nullable": true
          },
          "hls_acodec": {
            "type": "string",
            "nullable": true
          },
          "hls_vcodec": {
            "type": "string",
            "nullable": true
          },
          "hls_cleanup": {
            "type": "boolean",
            "nullable": true
          },
          "hls_dispose": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "hls_nb_notify": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "hls_wait_keyframe": {
            "type": "boolean",
            "nullable": true
          },
          "hls_keys": {
            "type": "boolean",
            "nullable": true
          },
          "hls_fragments_per_key": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "hls_key_file": {
            "type": "string",
            "nullable": true
          },
          "hls_key_file_path": {
            "type": "string",
            "nullable": true
          },
          "hls_key_url": {
            "type": "string",
            "nullable": true
          },
          "hls_dts_directly": {
            "type": "boolean",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Hds": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "hds_fragment": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "hds_window": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "hds_path": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Dvr": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "dvr_apply": {
            "type": "string",
            "nullable": true
          },
          "dvr_plan": {
            "type": "string",
            "nullable": true
          },
          "dvr_path": {
            "type": "string",
            "nullable": true
          },
          "dvr_duration": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "dvr_wait_keyframe": {
            "type": "boolean",
            "nullable": true
          },
          "time_Jitter": {
            "$ref": "#/components/schemas/PlayTimeJitter"
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "IngestInputType": {
        "enum": [
          0,
          1,
          2
        ],
        "type": "integer",
        "format": "int32"
      },
      "IngestInput": {
        "type": "object",
        "properties": {
          "type": {
            "$ref": "#/components/schemas/IngestInputType"
          },
          "url": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "IngestEnginePerfile": {
        "type": "object",
        "properties": {
          "re": {
            "type": "string",
            "nullable": true
          },
          "rtsp_transport": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "IngestEngineIoformat": {
        "enum": [
          0,
          1
        ],
        "type": "integer",
        "format": "int32"
      },
      "IngestEngineVfilter": {
        "type": "object",
        "properties": {
          "i": {
            "type": "string",
            "nullable": true
          },
          "vf": {
            "type": "string",
            "nullable": true
          },
          "filter_Complex": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "IngestEngineVprofile": {
        "enum": [
          0,
          1,
          2
        ],
        "type": "integer",
        "format": "int32"
      },
      "IngestEngineVpreset": {
        "enum": [
          0,
          1,
          2,
          3,
          4,
          5,
          6
        ],
        "type": "integer",
        "format": "int32"
      },
      "IngestEngineVparams": {
        "type": "object",
        "properties": {
          "t": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "coder": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "b_strategy": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "bf": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "refs": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "IngestEngineAparams": {
        "type": "object",
        "properties": {
          "profile_a": {
            "type": "string",
            "nullable": true
          },
          "bsf_a": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "IngestTranscodeEngine": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "perfile": {
            "$ref": "#/components/schemas/IngestEnginePerfile"
          },
          "iformat": {
            "$ref": "#/components/schemas/IngestEngineIoformat"
          },
          "vfilter": {
            "$ref": "#/components/schemas/IngestEngineVfilter"
          },
          "vcodec": {
            "type": "string",
            "nullable": true
          },
          "vbitrate": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "vfps": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "vwidth": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "vheight": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "vthreads": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "vprofile": {
            "$ref": "#/components/schemas/IngestEngineVprofile"
          },
          "vpreset": {
            "$ref": "#/components/schemas/IngestEngineVpreset"
          },
          "vparams": {
            "$ref": "#/components/schemas/IngestEngineVparams"
          },
          "acodec": {
            "type": "string",
            "nullable": true
          },
          "abitrate": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "asample_rate": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "achannels": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "aparams": {
            "$ref": "#/components/schemas/IngestEngineAparams"
          },
          "oformat": {
            "$ref": "#/components/schemas/IngestEngineIoformat"
          },
          "output": {
            "type": "string",
            "nullable": true
          },
          "engineName": {
            "type": "string",
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Ingest": {
        "type": "object",
        "properties": {
          "ingestName": {
            "type": "string",
            "nullable": true
          },
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "input": {
            "$ref": "#/components/schemas/IngestInput"
          },
          "ffmpeg": {
            "type": "string",
            "nullable": true
          },
          "engines": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/IngestTranscodeEngine"
            },
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Transcode": {
        "type": "object",
        "properties": {
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "ffmpeg": {
            "type": "string",
            "nullable": true
          },
          "engines": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/IngestTranscodeEngine"
            },
            "nullable": true
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SrsvHostConfClass": {
        "type": "object",
        "properties": {
          "vnack": {
            "$ref": "#/components/schemas/Nack"
          },
          "instanceName": {
            "type": "string",
            "nullable": true
          },
          "vhostDomain": {
            "type": "string",
            "nullable": true
          },
          "enabled": {
            "type": "boolean",
            "nullable": true
          },
          "min_latency": {
            "type": "boolean",
            "nullable": true
          },
          "tcp_nodelay": {
            "type": "boolean",
            "nullable": true
          },
          "chunk_size": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "in_ack_size": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "out_ack_size": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "rtc": {
            "$ref": "#/components/schemas/Rtc"
          },
          "vcluster": {
            "$ref": "#/components/schemas/Cluster"
          },
          "vforward": {
            "$ref": "#/components/schemas/Forward"
          },
          "vplay": {
            "$ref": "#/components/schemas/Play"
          },
          "vpublish": {
            "$ref": "#/components/schemas/Publish"
          },
          "vrefer": {
            "$ref": "#/components/schemas/Refer"
          },
          "vbandcheck": {
            "$ref": "#/components/schemas/Bandcheck"
          },
          "vsecurity": {
            "$ref": "#/components/schemas/Security"
          },
          "vhttp_static": {
            "$ref": "#/components/schemas/HttpStatic"
          },
          "vhttp_remux": {
            "$ref": "#/components/schemas/HttpRemux"
          },
          "vhttp_hooks": {
            "$ref": "#/components/schemas/HttpHooks"
          },
          "vexec": {
            "$ref": "#/components/schemas/Exec"
          },
          "vdash": {
            "$ref": "#/components/schemas/Dash"
          },
          "vhls": {
            "$ref": "#/components/schemas/Hls"
          },
          "vhds": {
            "$ref": "#/components/schemas/Hds"
          },
          "vdvr": {
            "$ref": "#/components/schemas/Dvr"
          },
          "vingests": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Ingest"
            },
            "nullable": true
          },
          "vtranscodes": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Transcode"
            },
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SrsSystemConfClass": {
        "type": "object",
        "properties": {
          "rtc_server": {
            "$ref": "#/components/schemas/SrsRtcServerConfClass"
          },
          "tcmalloc_release_rate": {
            "type": "number",
            "format": "float",
            "nullable": true
          },
          "listen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "pid": {
            "type": "string",
            "nullable": true
          },
          "chunk_size": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "ff_log_dir": {
            "type": "string",
            "nullable": true
          },
          "ff_log_level": {
            "type": "string",
            "nullable": true
          },
          "srs_log_tank": {
            "type": "string",
            "nullable": true
          },
          "srs_log_level": {
            "type": "string",
            "nullable": true
          },
          "srs_log_file": {
            "type": "string",
            "nullable": true
          },
          "max_connections": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "daemon": {
            "type": "boolean",
            "nullable": true
          },
          "utc_time": {
            "type": "boolean",
            "nullable": true
          },
          "pithy_print_ms": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "work_dir": {
            "type": "string",
            "nullable": true
          },
          "asprocess": {
            "type": "boolean",
            "nullable": true
          },
          "empty_ip_ok": {
            "type": "boolean",
            "nullable": true
          },
          "grace_start_wait": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "grace_final_wait": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "force_grace_quit": {
            "type": "boolean",
            "nullable": true
          },
          "disable_daemon_for_docker": {
            "type": "boolean",
            "nullable": true
          },
          "inotify_auto_reload": {
            "type": "boolean",
            "nullable": true
          },
          "auto_reload_for_docker": {
            "type": "boolean",
            "nullable": true
          },
          "heartbeat": {
            "$ref": "#/components/schemas/SrsHeartbeatConfClass"
          },
          "stats": {
            "$ref": "#/components/schemas/SrsStatsConfClass"
          },
          "http_api": {
            "$ref": "#/components/schemas/SrsHttpApiConfClass"
          },
          "http_server": {
            "$ref": "#/components/schemas/SrsHttpServerConfClass"
          },
          "stream_casters": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/SrsStreamCasterConfClass"
            },
            "nullable": true
          },
          "srt_server": {
            "$ref": "#/components/schemas/SrsSrtServerConfClass"
          },
          "kafka": {
            "$ref": "#/components/schemas/SrsKafkaConfClass"
          },
          "vhosts": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/SrsvHostConfClass"
            },
            "nullable": true
          },
          "configLines": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          },
          "streamNodeIpAddr": {
            "type": "string",
            "nullable": true
          },
          "streamNodPort": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "deviceId": {
            "type": "string",
            "nullable": true
          },
          "configLinesTrim": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          },
          "confFilePath": {
            "type": "string",
            "nullable": true
          },
          "sectionsName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SrsManager": {
        "type": "object",
        "properties": {
          "srs": {
            "$ref": "#/components/schemas/SrsSystemConfClass"
          },
          "srsConfigPath": {
            "type": "string",
            "nullable": true
          },
          "srsDeviceId": {
            "type": "string",
            "nullable": true
          },
          "srsWorkPath": {
            "type": "string",
            "nullable": true
          },
          "srsPidValue": {
            "type": "string",
            "nullable": true
          },
          "isInit": {
            "type": "boolean",
            "readOnly": true
          },
          "isRunning": {
            "type": "boolean",
            "readOnly": true
          }
        },
        "additionalProperties": false
      },
      "VhostIngestInputType": {
        "enum": [
          0,
          1,
          2
        ],
        "type": "integer",
        "format": "int32"
      }
    }
  }
}

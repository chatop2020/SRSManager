# SRSManager

## 简介

- SRSManager用于管理和控制SRS流媒体服务器的配置文件，将配置文件进行结构化处理，使配置文件更容易控制。
- 对SRS进程进行管理，使之可以通过一系列API来实现启动，停止，重启，重新加载配置等操作。
- 提供WEB管理接口，实现WebApi方式下的SRS管理。
- 在SRS之外集成onvif设备的管理，包括onvif设备探测，onvif ptz控制，onvif meidaurl获取等。
- 开设此项目主要原因是在自己的项目中要使用到SRS，为了更方便的使用SRS以满足项目所需而开设此项目，也同时为开
  源社区做些力所能及的贡献。

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


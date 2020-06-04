#nullable enable
using System;
using System.Collections.Generic;

namespace SrsManageCommon
{
    /// <summary>
    /// 错误代码
    /// </summary>
    [Serializable]
    public enum ErrorNumber : int
    {
        None = 0, //成功
        InitSystem = -5000, //初始化系统出错
        ConfigFile = -5001, //配置文件没有找到
        LicenseFileNotFind = -5002, //lic文件未找到
        LicenseFileReadFail = -5003, //lic文件格式错误
        HardSerialError = -5004, //硬件码校验失败
        TimeExpiration = -5005, //lic授权时间到期
        NotSet = -5006, //系统未设置，可能是初次安装
        DatabaseError = -5007, //数据库错误
        StorageDiskSettingFail = -5008, //存储盘设置错误
        StorageSpaceNotEnough = -5009, //存储空间不足
        GetVersionError = -5010, //获取版本信息错误
        StopSrsError = -5011, //结束SRS错误
        StartRuningSrsError = -5012, //启动一个已经启动的SRS异常
        StartSrsError = -5013, //SRS启动异常
        SrsTerminated = -5014, //SRS没有运行
        SrsReloadError = -5015, //SRS realod 失败
        SrsCreateError = -5016, //创建SRS 实例失败
        SrsNotFound = -5017, //SRS可执行文件没找到
        SrsObjectNotInit = -5018, //SRS对象没有创建
        FunctionInputParamsError = -5019, //函数传参有误
        SrsSubInstanceAlreadyExists = -5020, //SRS配置子实例已经存在
        SrsSubInstanceNotFound = -5021, //SRS配置子实例没有找到
        SrsConfigFunctionUnsupported = -5022, //功能还未支持
        SystemCheckPasswordFail = -5023, //检测密码失败
        SystemCheckAllowKeyFail = -5024, //访问控制检测失败
        SystemSessionExcept = -5025, //session异常
        SystemCheckAllowKeyOrSessionFail = -5026, //访问控制检测失败
        OnvifMonitorNotInit = -5027, //非onvif设备
        OnvifPtzKeepMoveOnlyUpdownleftright = -5028,
        OnvifPtzMoveExcept = -5029,
        SystemSessionItWorks = -5029, //session没有过期
        OnvifMonitorListIsNull = -5030, //onvif设备列表为空
        OnvifConfigLoadExcept = -5031, //onvif配置文件读取失败
        OnvifConfigWriteExcept = -5032, // Onvif配置文件写入失败
        SrsInstanceExists = -5033, //SRS实例已存在
        SrsInstanceConfigPathExists = -5034, //SRS配置文件路径重复
        SrsInstanceListenExists = -5035, //SRS的监听端口已经冲突
        SrsInstanceHttpApiListenExists = -5035, //SRS的HttpApi监听端口已经冲突
        SrsInstanceHttpServerListenExists = -5036, //SRS的HttpServer监听端口已经冲突
        SrsInstanceRtcServerListenExists = -5037, //SRS的RtcServer监听端口已经冲突
        SrsInstanceStreamCasterListenExists = -5038, //SRS的StreamCaster监听端口已经冲突
        SrsInstanceStreamCasterSipListenExists = -5039, //SRS的StreamCaster[Sip]监听端口已经冲突
        SrsInstanceSrtServerListenExists = -5040, //SRS的SrtServer监听端口已经冲突
        SystemWebApiException =-5041,
        SrsClientNotGB28181=-5041, //不是gb28181设备
        SrsStreamNotExists=-5042,
        SrsDvrPlanNotExists=-5043,
        SrsDvrPlanTimeLimitExcept=-5044,
        SrsGb28181IsDisabled6000=6000,
        SrsGb28181SessionOrMediaChannelExists6001 =6001,
        SrsGb28181SessionOrMediaChannelNotExists6002 =6002,
        SrsGb28181RtpOutOfPort6003 =6003,
        SrsGb28181RtpPortModeInvalid6004 =6004,
        SrsGb28181InputParamsError6005 =6005,
        SrsGb28181FuncationUnsupported6006 =6006,
        SrsGb28181SipNotStarted6007 =6007,
        SrsGb28181SipInviteFailed6008 =6008,
        SrsGb28181SipByeFailed6009 =6009,
        SrsGb28181SipInviteSucceeded6010 =6010,
        SrsGb28181CreateRtmpRemuxFailed6011 =6011,
        SrsGb28181SipChannelOffline6012 =6012,
        SrsGb28181SipChannelNotExists6013 =6013,
        SrsGb28181SipSendSipRawDataFailed6014 =6014,
        SrsGb28181SipParseMessageFailed6015 =6015,
        SrsGb28181SipPtzControlFailed6016 =6016,
        SrsGb28181SipPtzControlButNotInvite6017 =6017,
        SrsGb28181SipPtzCmdError6018 =6018,
        Other = -6000
    }

    /// <summary>
    /// 错误代码描述
    /// </summary>
    [Serializable]
    public static class ErrorMessage
    {
        public static Dictionary<ErrorNumber, string>? ErrorDic;

        public static void Init()
        {
            ErrorDic = new Dictionary<ErrorNumber, string>();
            ErrorDic[ErrorNumber.None] = "无错误";
            ErrorDic[ErrorNumber.ConfigFile] = "配置文件没有找到";
            ErrorDic[ErrorNumber.InitSystem] = "初始化系统出错";
            ErrorDic[ErrorNumber.DatabaseError] = "数据库错误";
            ErrorDic[ErrorNumber.HardSerialError] = "license验证失败";
            ErrorDic[ErrorNumber.LicenseFileNotFind] = "license文件未找到";
            ErrorDic[ErrorNumber.LicenseFileReadFail] = "读取license文件失败";
            ErrorDic[ErrorNumber.Other] = "未知错误";
            ErrorDic[ErrorNumber.TimeExpiration] = "license授权时间到期";
            ErrorDic[ErrorNumber.NotSet] = "服务器信息未设置，请登录设置页面";
            ErrorDic[ErrorNumber.StorageDiskSettingFail] = "存储盘设置错误";
            ErrorDic[ErrorNumber.StorageSpaceNotEnough] = "存储空间不足";
            ErrorDic[ErrorNumber.GetVersionError] = "获取版本信息错误";
            ErrorDic[ErrorNumber.StopSrsError] = "结束SRS进程时异常";
            ErrorDic[ErrorNumber.StartRuningSrsError] = "此SRS进程已经运行";
            ErrorDic[ErrorNumber.StartSrsError] = "启动SRS进程异常";
            ErrorDic[ErrorNumber.SrsTerminated] = "SRS没有运行";
            ErrorDic[ErrorNumber.SrsReloadError] = "SRS配置刷新失败";
            ErrorDic[ErrorNumber.SrsCreateError] = "创建SRS实例失败";
            ErrorDic[ErrorNumber.SrsNotFound] = "SRS可执行文件不存在";
            ErrorDic[ErrorNumber.SrsObjectNotInit] = "SRS控制对象未创建";
            ErrorDic[ErrorNumber.FunctionInputParamsError] = "函数参数有误";
            ErrorDic[ErrorNumber.SrsSubInstanceAlreadyExists] = "该配置子实例已存在";
            ErrorDic[ErrorNumber.SrsSubInstanceNotFound] = "该配置子实例不存在";
            ErrorDic[ErrorNumber.SrsConfigFunctionUnsupported] = "所需功能还不支持";
            ErrorDic[ErrorNumber.OnvifMonitorNotInit] = "非onvif设备，初始化失败";
            ErrorDic[ErrorNumber.OnvifPtzKeepMoveOnlyUpdownleftright] = "持续PTZ移动模式下只支持上、下、左、右";
            ErrorDic[ErrorNumber.OnvifPtzMoveExcept] = "PTZ移动控制异常";
            ErrorDic[ErrorNumber.SystemCheckPasswordFail] = "鉴权失败";
            ErrorDic[ErrorNumber.SystemCheckAllowKeyFail] = "访问控制检测失败";
            ErrorDic[ErrorNumber.SystemSessionExcept] = "Session异常";
            ErrorDic[ErrorNumber.SystemCheckAllowKeyOrSessionFail] = "访问控制或Session过期异常";
            ErrorDic[ErrorNumber.SystemSessionItWorks] = "当前Session没有过期无需刷新";
            ErrorDic[ErrorNumber.OnvifMonitorListIsNull] = "Onvif设备列表为空";
            ErrorDic[ErrorNumber.OnvifConfigLoadExcept] = "Onvif配置文件读取失败";
            ErrorDic[ErrorNumber.OnvifConfigWriteExcept] = "Onvif配置文件写入失败";
            ErrorDic[ErrorNumber.SrsInstanceExists] = "SRS实例已经存在";
            ErrorDic[ErrorNumber.SrsInstanceConfigPathExists] = "SRS配置文件路径重复";
            ErrorDic[ErrorNumber.SrsInstanceListenExists] = "SRS的监听端口已经冲突";
            ErrorDic[ErrorNumber.SrsInstanceHttpApiListenExists] = "SRS的HttpApi监听端口已经冲突";
            ErrorDic[ErrorNumber.SrsInstanceHttpServerListenExists] = "SRS的HttpServer监听端口已经冲突";
            ErrorDic[ErrorNumber.SrsInstanceRtcServerListenExists] = "SRS的RtcServer监听端口已经冲突";
            ErrorDic[ErrorNumber.SrsInstanceStreamCasterListenExists] = "SRS的StreamCaster监听端口已经冲突";
            ErrorDic[ErrorNumber.SrsInstanceStreamCasterSipListenExists] = "SRS的StreamCaster[Sip]监听端口已经冲突";
            ErrorDic[ErrorNumber.SrsInstanceSrtServerListenExists] = "SRS的SrtServer监听端口已经冲突";
            ErrorDic[ErrorNumber.SrsClientNotGB28181] = "此设备不是GB28181设备";
            ErrorDic[ErrorNumber.SrsGb28181IsDisabled6000] = "GB28181服务没有启用";
            ErrorDic[ErrorNumber.SrsGb28181SessionOrMediaChannelExists6001] = "SIP会话或媒体通道已存在";
            ErrorDic[ErrorNumber.SrsGb28181SessionOrMediaChannelNotExists6002] = "SIP会话或媒体通道不存在";
            ErrorDic[ErrorNumber.SrsGb28181RtpOutOfPort6003] = "RTP端口数量已经用完";
            ErrorDic[ErrorNumber.SrsGb28181RtpPortModeInvalid6004] = "无效的端口分配方式";
            ErrorDic[ErrorNumber.SrsGb28181InputParamsError6005] = "输入参数错误，参数不能为空";
            ErrorDic[ErrorNumber.SrsGb28181FuncationUnsupported6006] = "此API未被支持";
            ErrorDic[ErrorNumber.SrsGb28181SipNotStarted6007] = "SIP服务没有启用";
            ErrorDic[ErrorNumber.SrsGb28181SipInviteFailed6008] = "SIP INVITE 失败"; 
            ErrorDic[ErrorNumber.SrsGb28181SipByeFailed6009] = "SIP BYE 失败";
            ErrorDic[ErrorNumber.SrsGb28181SipInviteSucceeded6010] = "INVITE 已调用成功";
            ErrorDic[ErrorNumber.SrsGb28181CreateRtmpRemuxFailed6011] = "创建媒体通道RTMP复合器失败";
            ErrorDic[ErrorNumber.SrsGb28181SipChannelOffline6012] = "SIP设备不在线";
            ErrorDic[ErrorNumber.SrsGb28181SipChannelNotExists6013] = "SIP设备不存在";
            ErrorDic[ErrorNumber.SrsGb28181SipSendSipRawDataFailed6014] = "发送SIP_RAW_DATA失败";
            ErrorDic[ErrorNumber.SrsGb28181SipParseMessageFailed6015] = "SIP消息解析失败";
            ErrorDic[ErrorNumber.SrsGb28181SipPtzControlFailed6016] = "云台控制失败";
            ErrorDic[ErrorNumber.SrsGb28181SipPtzControlButNotInvite6017] = "通道不是INVITE状态，无法控制云台";
            ErrorDic[ErrorNumber.SrsGb28181SipPtzCmdError6018] = "无效的云台命令";
            ErrorDic[ErrorNumber.SystemWebApiException] = "WebApi系统级异常";
            ErrorDic[ErrorNumber.SrsStreamNotExists] = "媒体流信息不存在";
            ErrorDic[ErrorNumber.SrsDvrPlanNotExists] = "该录制方案不存在";
            ErrorDic[ErrorNumber.SrsDvrPlanTimeLimitExcept] = "该录制方案中周录制开始时间与结束时间需要大于120秒";
            
            

        }
    }
}
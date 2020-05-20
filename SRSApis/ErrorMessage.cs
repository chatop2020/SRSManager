using System.Collections.Generic;

namespace SRSApis
{
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
        StopSRSError = -5011, //结束SRS错误
        StartRuningSRSError = -5012, //启动一个已经启动的SRS异常
        StartSRSError = -5013, //SRS启动异常
        SRSTerminated = -5014, //SRS没有运行
        SRSReloadError = -5015, //SRS realod 失败
        SRSCreateError = -5016, //创建SRS 实例失败
        SRSNotFound = -5017, //SRS可执行文件没找到
        SRSObjectNotInit = -5018, //SRS对象没有创建
        FunctionInputParamsError = -5019, //函数传参有误
        SRSSubInstanceAlreadyExists = -5020, //SRS配置子实例已经存在
        SRSSubInstanceNotFound = -5021, //SRS配置子实例没有找到
        SRSConfigFunctionUnsupported = -5022, //功能还未支持
        OnvifMonitorNotInit=-5023,//非onvif设备
        OnvifPtzKeepMoveOnlyUPDOWNLEFTRIGHT=-5024,
        OnvifPtzMoveExcept=-5025,
       
        Other = -6000
    }

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
            ErrorDic[ErrorNumber.StopSRSError] = "结束SRS进程时异常";
            ErrorDic[ErrorNumber.StartRuningSRSError] = "此SRS进程已经运行";
            ErrorDic[ErrorNumber.StartSRSError] = "启动SRS进程异常";
            ErrorDic[ErrorNumber.SRSTerminated] = "SRS没有运行";
            ErrorDic[ErrorNumber.SRSReloadError] = "SRS配置刷新失败";
            ErrorDic[ErrorNumber.SRSCreateError] = "创建SRS实例失败";
            ErrorDic[ErrorNumber.SRSNotFound] = "SRS可执行文件不存在";
            ErrorDic[ErrorNumber.SRSObjectNotInit] = "SRS控制对象未创建";
            ErrorDic[ErrorNumber.FunctionInputParamsError] = "函数参数有误";
            ErrorDic[ErrorNumber.SRSSubInstanceAlreadyExists] = "该配置子实例已存在";
            ErrorDic[ErrorNumber.SRSSubInstanceNotFound] = "该配置子实例不存在";
            ErrorDic[ErrorNumber.SRSConfigFunctionUnsupported] = "所需功能还不支持";
            ErrorDic[ErrorNumber.OnvifMonitorNotInit] = "非onvif设备，初始化失败";
            ErrorDic[ErrorNumber.OnvifPtzKeepMoveOnlyUPDOWNLEFTRIGHT] = "持续PTZ移动模式下只支持上、下、左、右";
            ErrorDic[ErrorNumber.OnvifPtzMoveExcept] = "PTZ移动控制异常";
        }
    }
}
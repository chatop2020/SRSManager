using System.Collections.Generic;
using System.Linq;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;
using Common = SRSApis.Common;

namespace SrsApis.SrsManager.Apis
{
    public static class StreamCasterApis
    {
        /// <summary>
        /// 获取StreamCasterInstenceName 列表
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<string> GetStreamCastersInstanceName(string deviceId, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                if (ret.Srs == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsObjectNotInit,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                    };
                    return null!;
                }

                if (ret.Srs.Stream_casters == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return null!;
                }

                List<string> slist = ret.Srs.Stream_casters.Select(i => i.InstanceName).ToList()!;
                return slist!;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return null!;
        }

        /// <summary>
        /// 获取SrsManager实例中的StreamCaster列表
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<SrsStreamCasterConfClass> GetStreamCasterList(string deviceId, out ResponseStruct rs)
        {
            
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                if (ret.Srs == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsObjectNotInit,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                    };
                    return null!;
                }

                if (ret.Srs.Stream_casters == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return null!;
                }

                return ret.Srs.Stream_casters!;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return null!;
        }

        /// <summary>
        /// 在当前SrsManager实例中创建一个StreamCaster
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="streamCaster"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateStreamCaster(string deviceId, SrsStreamCasterConfClass streamCaster,
            out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                if (ret.Srs == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsObjectNotInit,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                    };
                    return false!;
                }
                if (ret.Srs.Stream_casters == null)
                {
                    ret.Srs.Stream_casters= new List<SrsStreamCasterConfClass>();
                    ret.Srs.Stream_casters.Add(streamCaster);
                    return true;
                }

                var retStreamCaster = ret.Srs.Stream_casters.FindLast(x =>
                    x.InstanceName!.Trim().ToUpper().Equals(streamCaster.InstanceName!.Trim().ToUpper()));
                if (retStreamCaster == null)
                {
                    ret.Srs.Stream_casters.Add(streamCaster);
                    return true;
                }

                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceAlreadyExists,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceAlreadyExists],
                };
                return false;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 获取StreamCaster的各类型模板
        /// </summary>
        /// <param name="casterType"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static SrsStreamCasterConfClass GetStreamCasterTemplate(CasterEnum casterType, out ResponseStruct rs)
        {
            SrsStreamCasterConfClass result = new SrsStreamCasterConfClass();
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + JsonHelper.ToJson(casterType),
            };
            switch (casterType)
            {
                case CasterEnum.flv:
                    result.InstanceName = "streamcaster-flv-template";
                    result.SectionsName = "stream_caster";
                    result.sip = null;
                    result.Enabled = true;
                    result.Caster = CasterEnum.flv;
                    result.Listen = 8936;
                    result.Output = "rtmp://127.0.0.1/[vhost]/[app]/[stream]";
                    return result;
                case CasterEnum.gb28181:
                    result.InstanceName = "streamcaster-gb28181-template";
                    result.SectionsName = "stream_caster";
                    result.sip = new Sip();
                    result.sip.SectionsName = "sip";
                    result.sip.Enabled = true;
                    result.sip.Listen = 5060;
                    result.sip.Serial = "34020000002000000001"; //服务器id
                    result.sip.Realm = "3402000000"; //服务器域
                    result.sip.Ack_timeout = 30;
                    result.sip.Keepalive_timeout = 120;
                    result.sip.Auto_play = true;
                    result.sip.Invite_port_fixed = true;
                    result.sip.Query_catalog_interval = 60;
                    result.Enabled = true;
                    result.Caster = CasterEnum.gb28181;
                    result.Output = "rtmp://127.0.0.1/[vhost]/[app]/[stream]";
                    result.Listen = 9000;
                    result.Rtp_port_max = 58300;
                    result.Rtp_port_min = 58200;
                    result.Wait_keyframe = false;
                    result.Rtp_idle_timeout = 30;
                    result.Audio_enable = true; //仅支持acc格式音频流
                    result.Host = "*";
                    result.Auto_create_channel = false;
                    return result;
                case CasterEnum.mpegts_over_udp:
                    result.InstanceName = "streamcaster-mpegts_over_udp-template";
                    result.SectionsName = "stream_caster";
                    result.sip = null;
                    result.Enabled = true;
                    result.Caster = CasterEnum.mpegts_over_udp;
                    result.Listen = 1935;
                    result.Output = "rtmp://127.0.0.1/[vhost]/[app]/[stream]";
                    return result;
                case CasterEnum.rtsp:
                    result.InstanceName = "streamcaster-rtsp-template";
                    result.SectionsName = "stream_caster";
                    result.sip = null;
                    result.Enabled = true;
                    result.Caster = CasterEnum.rtsp;
                    result.Listen = 554;
                    result.Output = "rtmp://127.0.0.1/[vhost]/[app]/[stream]";
                    result.Rtp_port_min = 57200;
                    result.Rtp_port_max = 57300;
                    return result;
                default:
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.FunctionInputParamsError,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError] + "\r\n" +
                                  JsonHelper.ToJson(casterType),
                    };
                    return null!;
            }
        }

        /// <summary>
        /// 使用InstanceName来删除StreamCaster
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="instanceName"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteStreamCasterByInstanceName(string deviceId, string instanceName, out ResponseStruct rs)
        {
            
              rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                if (ret.Srs == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsObjectNotInit,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                    };
                    return false;
                }
                if (ret.Srs.Stream_casters == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return false;
                }

                var retStreamCaster = ret.Srs.Stream_casters.FindLast(x =>
                    x.InstanceName!.Trim().ToUpper().Equals(instanceName!.Trim().ToUpper()));
                if (retStreamCaster == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return false;
                }

                ret.Srs.Stream_casters.Remove(retStreamCaster);
                return true;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 修改StreamCaster的实例名称
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="instanceName"></param>
        /// <param name="newInstanceName"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool ChangeStreamCasterInstanceName(string  deviceId, string instanceName, string newInstanceName,
            out ResponseStruct rs)
        {
            
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                if (ret.Srs == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsObjectNotInit,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                    };
                    return false;
                }
                if (ret.Srs.Stream_casters == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return false;
                }

                var retStreamCaster = ret.Srs.Stream_casters.FindLast(x =>
                    x.InstanceName!.Trim().ToUpper().Equals(instanceName!.Trim().ToUpper()));
                if (retStreamCaster == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return false;
                }
                var retStreamCasterNew= ret.Srs.Stream_casters.FindLast(x =>
                    x.InstanceName!.Trim().ToUpper().Equals(newInstanceName!.Trim().ToUpper()));
                if (retStreamCasterNew != null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceAlreadyExists,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceAlreadyExists],
                    };
                    return false; 
                }
                retStreamCaster.InstanceName = newInstanceName;
                return true;
            }
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 修改streamcaster的启动会停止
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="instanceName"></param>
        /// <param name="enabled"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnOrOffStreamCaster(string deviceId, string instanceName, bool enabled, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                if (ret.Srs != null && ret.Srs.Stream_casters != null)
                {
                    var retStreamCaster = ret.Srs.Stream_casters.FindLast(x =>
                        x.InstanceName!.Trim().ToUpper().Equals(instanceName.Trim().ToUpper()));
                    if (retStreamCaster != null)
                    {
                        retStreamCaster.Enabled = enabled;
                        if (retStreamCaster.sip != null)
                        {
                            retStreamCaster.sip.Enabled = enabled;
                        }
                        return true;
                    }
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return false;
                }
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                };
                return false;
            }
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 配置SrsManager实例中某个StreamCaster的参数
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="streamCaster"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool SetStreamCaster(string deviceId, SrsStreamCasterConfClass streamCaster, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                if (ret.Srs != null && ret.Srs.Stream_casters != null)
                {
                    var retStreamCaster = ret.Srs.Stream_casters.FindLast(x =>
                        x.InstanceName!.Trim().ToUpper().Equals(streamCaster.InstanceName!.Trim().ToUpper()));
                    if (retStreamCaster != null)//修改
                    {
                        retStreamCaster = streamCaster;
                        return true;
                    }

                    ret.Srs.Stream_casters.Add(streamCaster);
                    return true;
                }
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                };
                return false;
            }
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }
    }
}
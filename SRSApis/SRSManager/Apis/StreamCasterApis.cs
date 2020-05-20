using System.Collections.Generic;
using System.Linq;
using SRSConfFile.SRSConfClass;

namespace SRSApis.SRSManager.Apis
{
    public static class StreamCasterApis
    {
        /// <summary>
        /// 获取StreamCasterInstenceName 列表
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<string> GetStreamCastersInstanceName(SrsManager sm, out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Stream_casters == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return null!;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (sm.Srs.Stream_casters.Count > 0)
            {
                List<string> slist = sm.Srs.Stream_casters.Select(i => i.InstanceName).ToList()!;
                return slist!;
            }
            else
            {
                return null!;
            }
        }

        /// <summary>
        /// 获取SrsManager实例中的StreamCaster列表
        /// </summary>
        /// <param name="sm">SrsManager实例</param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<SrsStreamCasterConfClass> GetStreamCasterList(SrsManager sm, out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return null!;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (sm.Srs.Stream_casters != null && sm.Srs.Stream_casters.Count > 0)
            {
                List<SrsStreamCasterConfClass> result = sm.Srs.Stream_casters;
                return result;
            }
            else
            {
                return null!;
            }
        }

        /// <summary>
        /// 在当前SrsManager实例中创建一个StreamCaster
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="streamCaster"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateStreamCaster(SrsManager sm, SrsStreamCasterConfClass streamCaster,
            out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return false;
            }

            if (sm.Srs.Stream_casters == null) sm.Srs.Stream_casters = new List<SrsStreamCasterConfClass>();
            var obj = sm.Srs.Stream_casters.FindLast(x =>
                x.InstanceName!.Trim().ToLower().Equals(streamCaster.InstanceName!.Trim().ToLower()));
            if (obj != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceAlreadyExists,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceAlreadyExists],
                };
                return false;
            }

            /*for (int i = 0; i <= sm.Srs.Stream_casters.Count - 1; i++)
            {
                if (sm.Srs.Stream_casters[i].InstanceName!.Trim().ToLower()
                    .Equals(streamCaster.InstanceName!.Trim().ToLower()))
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SRSSubInstanceAlreadyExists,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SRSSubInstanceAlreadyExists],
                    };
                    return false;
                }
            }*/

            if (string.IsNullOrEmpty(streamCaster.InstanceName))
            {
                streamCaster.InstanceName = SRSConfFile.Common.CreateUUID();
            }

            if (string.IsNullOrEmpty(streamCaster.SectionsName))
            {
                streamCaster.SectionsName = "stream_caster";
            }

            sm.Srs.Stream_casters.Add(Common.ObjectClone(streamCaster));
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + "StreamCaster创建到SRS实例中\r\n" +
                          JsonHelper.ToJson(streamCaster),
            };
            return true;
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
        /// <param name="sm"></param>
        /// <param name="instanceName"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteStreamCasterByInstanceName(SrsManager sm, string instanceName, out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Stream_casters == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return false;
            }

            bool ret = false;
            for (int i = 0; i <= sm.Srs.Stream_casters.Count - 1; i++)
            {
                if (sm.Srs.Stream_casters[i].InstanceName!.Trim().ToLower().Equals(instanceName.Trim().ToLower()))
                {
                    sm.Srs.Stream_casters[i] = null!;
                    ret = true;
                    break;
                }
            }

            if (ret)
            {
                Common.RemoveNull(sm.Srs.Stream_casters);
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                return ret;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                };
                return ret;
            }
        }

        public static bool ChangeStreamCasterInstanceName(SrsManager sm, string instanceName, string newInstanceName,
            out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Stream_casters == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return false;
            }

            bool ret = false;
            foreach (var caster in sm.Srs.Stream_casters)
            {
                if (caster.InstanceName!.Trim().ToLower().Equals(instanceName.Trim().ToLower()))
                {
                    caster.InstanceName = newInstanceName;
                    ret = true;
                    break;
                }
            }


            if (ret)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                return ret;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                };
                return ret;
            }
        }

        /// <summary>
        /// 修改streamcaster的启动会停止
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="instanceName"></param>
        /// <param name="enabled"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnOrOffStreamCaster(SrsManager sm, string instanceName, bool enabled, out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Stream_casters == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return false;
            }

            bool ret = false;
            foreach (var caster in sm.Srs.Stream_casters)
            {
                if (caster.InstanceName!.Trim().ToLower().Equals(instanceName.Trim().ToLower()))
                {
                    if (caster.Caster == CasterEnum.gb28181 && caster.sip != null) //同时把sip网关的开关也设置掉
                    {
                        caster.sip.Enabled = enabled;
                    }

                    caster.Enabled = enabled;
                    ret = true;
                    break;
                }
            }

            if (ret)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                return ret;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                };
                return ret;
            }
        }

        /// <summary>
        /// 配置SrsManager实例中某个StreamCaster的参数
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="streamCaster"></param>
        /// <param name="rs"></param>
        /// <param name="createIfNotFound">default false</param>
        /// <returns></returns>
        public static bool SetStreamCaster(SrsManager sm, SrsStreamCasterConfClass streamCaster, out ResponseStruct rs,
            bool createIfNotFound = false)
        {
            if (sm == null || sm.Srs == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return false;
            }

            if (streamCaster == null || string.IsNullOrEmpty(streamCaster.InstanceName))
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            if ((sm.Srs.Stream_casters == null || sm.Srs.Stream_casters.Count == 0) && createIfNotFound)
            {
                if (CreateStreamCaster(sm, streamCaster, out rs))
                {
                    rs.Message += "\r\n" + "SRS实例中未有StreamCaster内容，系统已经将传入StreamCaster创建到SRS实例中";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if ((sm.Srs.Stream_casters == null || sm.Srs.Stream_casters.Count == 0) && !createIfNotFound)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound] + "\r\n" +
                              JsonHelper.ToJson(streamCaster),
                };
                return false;
            }
            else
            {
                if (sm.Srs.Stream_casters != null)
                    for (int i = 0; i <= sm.Srs.Stream_casters.Count - 1;)
                    {
                        if (sm.Srs.Stream_casters[i].InstanceName!.Trim().ToLower()
                            .Equals(streamCaster.InstanceName!.Trim().ToLower()))
                        {
                            sm.Srs.Stream_casters[i] = Common.ObjectClone(streamCaster);
                        }

                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + "StreamCaster配置更新成功\r\n" +
                                      JsonHelper.ToJson(streamCaster),
                        };

                        return true;
                    }
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.Other,
                Message = ErrorMessage.ErrorDic![ErrorNumber.Other] + "\r\n" + "StreamCaster配置更新失败，未知异常\r\n" +
                          JsonHelper.ToJson(streamCaster),
            };
            return false;
        }
    }
}
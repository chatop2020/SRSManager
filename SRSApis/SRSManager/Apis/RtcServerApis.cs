using SRSManageCommon;
using SRSConfFile.SRSConfClass;

namespace SRSApis.SRSManager.Apis
{
    public static class RtcServerApis
    {
        /// <summary>
        /// 删除RTCServer段
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteRtcServer(SrsManager sm, out ResponseStruct rs)
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

            sm.Srs.Rtc_server = null;
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return true;
        }

        public static SrsRtcServerConfClass GetRtcServerTemplate(out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return new SrsRtcServerConfClass()
            {
                Enabled = true,
                Listen = 8000,
                Candidate = "*",
                SectionsName = "rtc_server",
                Black_hole = new BlackHole()
                {
                    Enabled = false,
                    Publisher = "127.0.0.1:10000",
                    SectionsName = "black_hole",
                }
            };
        }

        /// <summary>
        /// 启动或停止RtcServer
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="enabled"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnOrOffRtcServer(SrsManager sm, bool enabled, out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Rtc_server == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return false;
            }

            sm.Srs.Rtc_server.Enabled = enabled;
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return true;
        }


        public static bool SetRtcServer(SrsManager sm, SrsRtcServerConfClass rtc, out ResponseStruct rs,
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

            if (rtc == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            if (sm.Srs.Rtc_server == null && createIfNotFound)
            {
                if (CreateRtcServer(sm, rtc, out rs))
                {
                    rs.Message += "\r\n" + "SRS实例中未有RtcServer内容，系统已经将传入RtcServer创建到SRS实例中";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (sm.Srs.Rtc_server == null && !createIfNotFound)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound] + "\r\n" +
                              JsonHelper.ToJson(rtc),
                };
                return false;
            }
            else if (sm.Srs.Rtc_server != null)
            {
                if (rtc.Enabled != null) sm.Srs.Rtc_server.Enabled = rtc.Enabled;
                if (rtc.Listen != null) sm.Srs.Rtc_server.Listen = rtc.Listen;
                if (rtc.Candidate != null) sm.Srs.Rtc_server.Candidate = rtc.Candidate;
                if (rtc.Sendmmsg != null) sm.Srs.Rtc_server.Sendmmsg = rtc.Sendmmsg;
                if (rtc.Encrypt != null) sm.Srs.Rtc_server.Encrypt = rtc.Encrypt;
                if (rtc.Reuseport != null) sm.Srs.Rtc_server.Reuseport = rtc.Reuseport;
                if (rtc.Merge_nalus != null) sm.Srs.Rtc_server.Merge_nalus = rtc.Merge_nalus;
                if (rtc.Gso != null) sm.Srs.Rtc_server.Gso = rtc.Gso;
                if (rtc.Padding != null) sm.Srs.Rtc_server.Padding = rtc.Padding;
                if (rtc.Perf_stat != null) sm.Srs.Rtc_server.Perf_stat = rtc.Perf_stat;
                if (rtc.Queue_length != null) sm.Srs.Rtc_server.Queue_length = rtc.Queue_length;
                rtc.SectionsName = "rtc_server";
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + "RtcServer配置更新成功\r\n" +
                              JsonHelper.ToJson(rtc),
                };

                return true;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.Other,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.Other] + "\r\n" + "RtcServer配置更新失败，未知异常\r\n" +
                              JsonHelper.ToJson(rtc),
                };
                return false;
            }
        }

        /// <summary>
        /// 创建一个RtcServer
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rtc"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateRtcServer(SrsManager sm, SrsRtcServerConfClass rtc,
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

            if (sm.Srs.Rtc_server == null)
            {
                sm.Srs.Rtc_server = new SrsRtcServerConfClass();
                sm.Srs.Rtc_server = Common.ObjectClone(rtc);
                sm.Srs.Rtc_server.SectionsName = "rtc_server";
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + "RtcServer创建到SRS实例中\r\n" +
                              JsonHelper.ToJson(rtc),
                };
                return true;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceAlreadyExists,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceAlreadyExists],
                };
                return false;
            }
        }

        /// <summary>
        /// 获取RTCServer
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static SrsRtcServerConfClass GetRtcServer(SrsManager sm, out ResponseStruct rs)
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
            if (sm.Srs.Rtc_server != null)
            {
                SrsRtcServerConfClass result = Common.ObjectClone(sm.Srs.Rtc_server);
                return result;
            }
            else
            {
                return null!;
            }
        }
    }
}
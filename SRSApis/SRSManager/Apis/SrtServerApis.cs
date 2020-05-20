using Common;
using SRSConfFile.SRSConfClass;

namespace SRSApis.SRSManager.Apis
{
    public static class SrtServerApis
    {
        /// <summary>
        /// 删除SRTServer段
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteSrtServer(SrsManager sm, out ResponseStruct rs)
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

            sm.Srs.Srt_server = null;
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return true;
        }

        /// <summary>
        /// 获取SrtSever模板
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static SrsSrtServerConfClass GetSrtServerTemplate(out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return new SrsSrtServerConfClass()
            {
                Enabled = true,
                Listen = 10080,
                Maxbw = 1000000000,
                Connect_timeout = 4000,
                Peerlatency = 300,
                Recvlatency = 300,
            };
        }

        /// <summary>
        /// 启动或停止SrtServer
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="enabled"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnOrOffSrtServer(SrsManager sm, bool enabled, out ResponseStruct rs)
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

            sm.Srs.Srt_server!.Enabled = enabled;
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return true;
        }

        /// <summary>
        /// 设置srtServer配置
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="srt"></param>
        /// <param name="rs"></param>
        /// <param name="createIfNotFound"></param>
        /// <returns></returns>
        public static bool SetSrtServer(SrsManager sm, SrsSrtServerConfClass srt, out ResponseStruct rs,
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

            if (srt == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }


            if (sm.Srs.Srt_server == null && createIfNotFound)
            {
                if (CreateSrtServer(sm, srt, out rs))
                {
                    rs.Message += "\r\n" + "SRS实例中未有SrtServer内容，系统已经将传入SrtServer创建到SRS实例中";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (sm.Srs.Srt_server == null && !createIfNotFound)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound] + "\r\n" +
                              JsonHelper.ToJson(srt),
                };
                return false;
            }
            else if (sm.Srs.Srt_server != null)
            {
                if (srt.Enabled != null) sm.Srs.Srt_server.Enabled = srt.Enabled;
                if (srt.Listen != null) sm.Srs.Srt_server.Listen = srt.Listen;
                if (srt.Maxbw != null) sm.Srs.Srt_server.Maxbw = srt.Maxbw;
                if (srt.Connect_timeout != null) sm.Srs.Srt_server.Connect_timeout = srt.Connect_timeout;
                if (srt.Peerlatency != null) sm.Srs.Srt_server.Peerlatency = srt.Peerlatency;
                if (srt.Recvlatency != null) sm.Srs.Srt_server.Recvlatency = srt.Recvlatency;
                if (srt.Default_app != null) sm.Srs.Srt_server.Default_app = srt.Default_app;

                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + "SrtServer配置更新成功\r\n" +
                              JsonHelper.ToJson(srt),
                };

                return true;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.Other,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.Other] + "\r\n" + "SrtServer配置更新失败，未知异常\r\n" +
                              JsonHelper.ToJson(srt),
                };
                return false;
            }
        }

        /// <summary>
        /// 创建一个SrtServer
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="srt"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateSrtServer(SrsManager sm, SrsSrtServerConfClass srt,
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

            if (sm.Srs.Srt_server == null)
            {
                sm.Srs.Srt_server = new SrsSrtServerConfClass();
                srt.SectionsName = "srt_server";
                sm.Srs.Srt_server = Common.ObjectClone(srt);
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + "SrtServer创建到SRS实例中\r\n" +
                              JsonHelper.ToJson(srt),
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
        /// 获取SrtServer
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static SrsSrtServerConfClass GetSrtServer(SrsManager sm, out ResponseStruct rs)
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
                SrsSrtServerConfClass result = Common.ObjectClone(sm.Srs.Srt_server)!;
                return result!;
            }
            else
            {
                return null!;
            }
        }
    }
}
using SrsApis.SrsManager.Apis.ApiModules;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;
using Common = SRSApis.Common;

namespace SrsApis.SrsManager.Apis
{
    public static class GlobalSrsApis
    {
        /// <summary>
        /// 检测SRS实例是否正在运行
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool IsRunning(string deviceId, out ResponseStruct rs)
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
                return ret.IsRunning;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 检查SrsManager是否被初始化
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool IsInit(string deviceId, out ResponseStruct rs)
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
                return ret.IsInit;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 启动SRS实例
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool StartSrs(string deviceId, out ResponseStruct rs)
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
                if (ret.IsRunning)
                {
                    return true;
                }

                return ret.Start(out rs);
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 停止SRS实例
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool StopSrs(string deviceId, out ResponseStruct rs)
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
                return ret.Stop(out rs);
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 重启SRS实例
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool RestartSrs(string deviceId, out ResponseStruct rs)
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
                return ret.Restart(out rs);
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 重新加载SRS实例中的配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool ReloadSrs(string deviceId, out ResponseStruct rs)
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
                return ret.Reload(out rs);
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }


        /// <summary>
        /// 修改全局Chunksize
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="size"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeChunksize(string deviceId, ushort size, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null && ret.Srs != null)
            {
                ret.Srs.Chunk_size = size;
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
        /// 修改HttpApi的Listen端口
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="port"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeHttpApipListen(string deviceId, ushort port, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null && ret.Srs.Http_api != null)
            {
                ret.Srs.Http_api.Listen = port;
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
        /// 修改Http_Api是否可用
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="enable"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeHttpApiEnable(string deviceId, bool enable, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null && ret.Srs.Http_api != null)
            {
                ret.Srs.Http_api.Enabled = enable;
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
        /// 修改MaxConnections值
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="maxconnections"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeMaxConnections(string deviceId, ushort maxconnections, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null && ret.Srs != null)
            {
                ret.Srs.Max_connections = maxconnections;
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
        /// 修改全局rtmp端口
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="port"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeRtmpListen(string deviceId, ushort port, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null && ret.Srs != null)
            {
                ret.Srs.Listen = port;
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
        /// 修改Httpserver的端口
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="port"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeHttpServerListen(string deviceId, ushort port, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null && ret.Srs.Http_server != null)
            {
                ret.Srs.Http_server.Listen = port;
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
        /// 修改httpserver的webroot
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="path"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeHttpServerPath(string deviceId, string path, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null && ret.Srs.Http_server != null)
            {
                ret.Srs.Http_server.Dir = path;
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
        /// 修改httpserver是否可用
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="enable"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeHttpServerEnable(string deviceId, bool enable, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null && ret.Srs.Http_server != null)
            {
                ret.Srs.Http_server.Enabled = enable;
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
        /// 获取SRS实例的全局可改参数对象
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static GlobalModule GetGlobalParams(string deviceId, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null && ret.Srs.Http_server != null)
            {
                GlobalModule result = new GlobalModule()
                {
                    Listen = ret.Srs.Listen,
                    HttpApiListen = ret.Srs.Http_api!.Listen,
                    MaxConnections = ret.Srs.Max_connections,
                    HttpApiEnable = ret.Srs.Http_api!.Enabled,
                    HttpServerEnable = ret.Srs.Http_server!.Enabled,
                    HttpServerPath = ret.Srs.Http_server!.Dir,
                    HttpServerListen = ret.Srs.Http_server!.Listen,
                    HeartbeatEnable = ret.Srs.Heartbeat!.Enabled,
                    HeartbeatUrl = ret.Srs.Heartbeat!.Url,
                    HeartbeatSummariesEnable = ret.Srs.Heartbeat!.Summaries,
                };
                return result;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return null!;
        }

        /// <summary>
        /// 整体性修改全局可变参数
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="bm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool ChangeGlobalParams(string deviceId, GlobalModule bm, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            var ret = Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null && ret.Srs.Http_server != null)
            {
                if (bm.Listen != null) ret.Srs.Listen = bm.Listen;
                if (bm.MaxConnections != null) ret.Srs.Max_connections = bm.MaxConnections;
                if (bm.HttpApiEnable != null) ret.Srs.Http_api!.Enabled = bm.HttpApiEnable;
                if (bm.HttpApiListen != null) ret.Srs.Http_api!.Listen = bm.HttpApiListen;
                if (bm.HttpServerPath != null) ret.Srs.Http_server!.Dir = bm.HttpServerPath;
                if (bm.HttpServerEnable != null) ret.Srs.Http_server!.Enabled = bm.HttpServerEnable;
                if (bm.HttpServerListen != null) ret.Srs.Http_server!.Listen = bm.HttpServerListen;
                if (bm.HeartbeatEnable != null) ret.Srs.Heartbeat!.Enabled = bm.HeartbeatEnable;
                if (bm.HeartbeatUrl != null) ret.Srs.Heartbeat!.Url = bm.HeartbeatUrl;
                if (bm.HeartbeatSummariesEnable != null) ret.Srs.Heartbeat!.Summaries = bm.HeartbeatSummariesEnable;
                return true;
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
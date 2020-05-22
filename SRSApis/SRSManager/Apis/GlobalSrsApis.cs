using SRSManageCommon;
using SRSApis.SRSManager.Apis.ApiModules;

namespace SRSApis.SRSManager.Apis
{
    public static class GlobalSrsApis
    {
        /// <summary>
        /// 检测SRS实例是否正在运行
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool ISRunning(SrsManager sm, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return sm.IsRunning;
        }

        /// <summary>
        /// 检查SrsManager是否被初始化
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool ISInit(SrsManager sm, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return sm.Is_Init;
        }

        /// <summary>
        /// 启动SRS实例
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool StartSRS(SrsManager sm, out ResponseStruct rs)
        {
            return sm.Start(out rs);
        }

        /// <summary>
        /// 停止SRS实例
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool StopSRS(SrsManager sm, out ResponseStruct rs)
        {
            return sm.Stop(out rs);
        }

        /// <summary>
        /// 重启SRS实例
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool RestartSRS(SrsManager sm, out ResponseStruct rs)
        {
            return sm.Restart(out rs);
        }

        /// <summary>
        /// 重新加载SRS实例中的配置
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool ReloadSRS(SrsManager sm, out ResponseStruct rs)
        {
            return sm.Reload(out rs);
        }


        /// <summary>
        /// 修改全局Chunksize
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="size"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeChunksize(SrsManager sm, ushort size, out ResponseStruct rs)
        {
            if (sm.Srs != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                sm.Srs.Chunk_size = size;
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
        /// <param name="sm"></param>
        /// <param name="port"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeHttpApipListen(SrsManager sm, ushort port, out ResponseStruct rs)
        {
            if (sm.Srs != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                if (sm.Srs.Http_api != null) sm.Srs.Http_api.Listen = port;
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
        /// <param name="sm"></param>
        /// <param name="enable"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeHttpApiEnable(SrsManager sm, bool enable, out ResponseStruct rs)
        {
            if (sm.Srs != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                if (sm.Srs.Http_api != null) sm.Srs.Http_api.Enabled = enable;
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
        /// <param name="sm"></param>
        /// <param name="maxconnections"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeMaxConnections(SrsManager sm, ushort maxconnections, out ResponseStruct rs)
        {
            if (sm.Srs != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                sm.Srs.Max_connections = maxconnections;
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
        /// <param name="sm"></param>
        /// <param name="port"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeRtmpListen(SrsManager sm, ushort port, out ResponseStruct rs)
        {
            if (sm.Srs != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                sm.Srs.Listen = port;
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
        /// <param name="sm"></param>
        /// <param name="port"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeHttpServerListen(SrsManager sm, ushort port, out ResponseStruct rs)
        {
            if (sm.Srs != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                sm.Srs.Http_server!.Listen = port;
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
        /// <param name="sm"></param>
        /// <param name="path"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeHttpServerPath(SrsManager sm, string path, out ResponseStruct rs)
        {
            if (sm.Srs != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                sm.Srs.Http_server!.Dir = path;
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
        /// <param name="sm"></param>
        /// <param name="enable"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool GlobalChangeHttpServerEnable(SrsManager sm, bool enable, out ResponseStruct rs)
        {
            if (sm.Srs != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                if (sm.Srs.Http_server != null) sm.Srs.Http_server.Enabled = enable;
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
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static GlobalModule GetGlobalParams(SrsManager sm, out ResponseStruct rs)
        {
            GlobalModule result = null!;
            if (sm.Srs != null)
            {
                result = new GlobalModule()
                {
                    Listen = sm.Srs.Listen,
                    HttpApiListen = sm.Srs.Http_api!.Listen,
                    MaxConnections = sm.Srs.Max_connections,
                    HttpApiEnable = sm.Srs.Http_api!.Enabled,
                    HttpServerEnable = sm.Srs.Http_server!.Enabled,
                    HttpServerPath = sm.Srs.Http_server!.Dir,
                    HttpServerListen = sm.Srs.Http_server!.Listen,
                    HeartbeatEnable = sm.Srs.Heartbeat!.Enabled,
                    HeartbeatUrl = sm.Srs.Heartbeat!.Url,
                    HeartbeatSummariesEnable = sm.Srs.Heartbeat!.Summaries,
                };
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                return result;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return result;
        }

        /// <summary>
        /// 整体性修改全局可变参数
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="bm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool ChangeGlobalParams(SrsManager sm, GlobalModule bm, out ResponseStruct rs)
        {
            if (sm.Srs != null)
            {
                if (bm.Listen != null) sm.Srs.Listen = bm.Listen;
                if (bm.MaxConnections != null) sm.Srs.Max_connections = bm.MaxConnections;
                if (bm.HttpApiEnable != null) sm.Srs.Http_api!.Enabled = bm.HttpApiEnable;
                if (bm.HttpApiListen != null) sm.Srs.Http_api!.Listen = bm.HttpApiListen;
                if (bm.HttpServerPath != null) sm.Srs.Http_server!.Dir = bm.HttpServerPath;
                if (bm.HttpServerEnable != null) sm.Srs.Http_server!.Enabled = bm.HttpServerEnable;
                if (bm.HttpServerListen != null) sm.Srs.Http_server!.Listen = bm.HttpServerListen;
                if (bm.HeartbeatEnable != null) sm.Srs.Heartbeat!.Enabled = bm.HeartbeatEnable;
                if (bm.HeartbeatUrl != null) sm.Srs.Heartbeat!.Url = bm.HeartbeatUrl;
                if (bm.HeartbeatSummariesEnable != null) sm.Srs.Heartbeat!.Summaries = bm.HeartbeatSummariesEnable;

                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
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
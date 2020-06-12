using System;
using SrsManageCommon;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;

namespace SrsApis.SrsManager.Apis
{
    /// <summary>
    /// SRSHookApis
    /// </summary>
    public static class SrsHooksApis
    {
        /// <summary>
        /// 处理Dvr信息
        /// </summary>
        /// <param name="dvrVideo"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnDvr(DvrVideo dvrVideo)
        {
            try
            {
                dvrVideo.Deleted = false;
                dvrVideo.UpdateTime = DateTime.Now;
                var onPublishList =
                    FastUsefulApis.GetOnPublishMonitorListByDeviceId(dvrVideo.Device_Id!, out ResponseStruct rs);
                var ret = onPublishList.FindLast(x => x.Client_Id == dvrVideo.Client_Id);
                if (ret != null)
                {
                    dvrVideo.ClientIp = ret.MonitorIp;
                    dvrVideo.MonitorType = ret.MonitorType;
                    dvrVideo.RecordDate = DateTime.Now.ToString("yyyy-MM-dd");
                }

                lock (Common.LockDbObjForDvrVideo)
                {
                    OrmService.Db.Insert(dvrVideo).ExecuteAffrows();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("存DVR错误：" + ex.Message);
            }

            return true;
        }


        /// <summary>
        /// 处理srs心跳信息
        /// </summary>
        /// <param name="heartbeat"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnHeartbeat(ReqSrsHeartbeat heartbeat, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            string jsonStr = JsonHelper.ToJson(heartbeat);
            jsonStr = JsonHelper.ConvertJsonString(jsonStr);
            lock (Common.LockDbObjForHeartbeat)
            {
                return true;
            }
        }

        /// <summary>
        /// 连接关闭时
        /// </summary>
        /// <param name="onlineClient"></param>
        /// <returns></returns>
        public static bool OnClose(OnlineClient onlineClient)
        {
            if (onlineClient != null && !string.IsNullOrEmpty(onlineClient.ClientIp) && onlineClient.Client_Id != null)
            {
                try
                {
                    lock (Common.LockDbObjForOnlineClient)
                    {
                        OrmService.Db.Delete<OnlineClient>()
                            .Where(x => x.Client_Id == onlineClient.Client_Id && x.ClientIp == onlineClient.ClientIp)
                            .ExecuteAffrows();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

                return true;
            }

            return false;
        }


        /// <summary>
        /// 通过stream获取monitorip地址
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static string getMonitorIpAddressFromStream(string stream)
        {
            lock (Common.LockDbObjForOnlineClient)
            {
                var ret = OrmService.Db.Select<OnlineClient>()
                    .Where(x => x.Stream!.Trim().Equals(stream.Trim()) && x.ClientType == ClientType.Monitor).First();

                if (ret != null)
                {
                    return ret.MonitorIp!;
                }
            }


            return "unknow";
        }

        /// <summary>
        /// 客户端播放时
        /// </summary>
        /// <param name="onlineClient"></param>
        /// <returns></returns>
        public static bool OnPlay(OnlineClient onlineClient)
        {
            if (onlineClient != null && onlineClient.Client_Id != null &&
                !string.IsNullOrEmpty(onlineClient.Device_Id))
            {
                try
                {
                    lock (Common.LockDbObjForOnlineClient)
                    {
                        var ret = OrmService.Db.Update<OnlineClient>().Set(x => x.ClientType, ClientType.User)
                            .Set(x => x.IsOnline, true).Set(x => x.IsPlay, true)
                            .Set(x => x.Param, onlineClient.Param)
                            .Set(x => x.Stream, onlineClient.Stream).Set(x => x.UpdateTime, onlineClient.UpdateTime)
                            .Set(x => x.PageUrl, onlineClient.PageUrl).Set(x => x.MonitorIp,
                                getMonitorIpAddressFromStream(onlineClient.Stream!))
                            .Where(x => x.Client_Id == onlineClient.Client_Id &&
                                        x.Device_Id!.Trim() == onlineClient.Device_Id.Trim())
                            .ExecuteAffrows();
                        if (ret <= 0)
                        {
                            onlineClient.ClientType = ClientType.User;
                            onlineClient.IsOnline = true;
                            onlineClient.IsPlay = true;
                            onlineClient.MonitorIp = getMonitorIpAddressFromStream(onlineClient.Stream!);
                            var retInsert = OrmService.Db.Insert(onlineClient).ExecuteAffrows();
                            if (retInsert > 0)
                            {
                                return true;
                            }

                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return false;
        }


        /// <summary>
        /// 客户端停止播放时
        /// </summary>
        /// <param name="onlineClient"></param>
        /// <returns></returns>
        public static bool OnStop(OnlineClient onlineClient)
        {
            if (onlineClient != null && !string.IsNullOrEmpty(onlineClient.Device_Id) &&
                onlineClient.Client_Id != null)
            {
                try
                {
                    lock (Common.LockDbObjForOnlineClient)
                    {
                        var ret = OrmService.Db.Update<OnlineClient>().Set(x => x.ClientType, ClientType.User)
                            .Set(x => x.IsOnline, true).Set(x => x.IsPlay, false)
                            .Set(x => x.UpdateTime, onlineClient.UpdateTime)
                            .Where(x => x.Client_Id == onlineClient.Client_Id &&
                                        x.Device_Id!.Trim() == onlineClient.Device_Id.Trim())
                            .ExecuteAffrows();
                        if (ret <= 0)
                        {
                            onlineClient.ClientType = ClientType.User;
                            onlineClient.IsOnline = true;
                            onlineClient.IsPlay = false;
                            var retInsert = OrmService.Db.Insert(onlineClient).ExecuteAffrows();
                            if (retInsert > 0)
                            {
                                return true;
                            }

                            return false;
                        }
                    }


                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return false;
        }


        /// <summary>
        /// 摄像头推流的时候
        /// </summary>
        /// <param name="onlineClient"></param>
        /// <returns></returns>
        public static bool OnPublish(OnlineClient onlineClient)
        {
            if (onlineClient != null && !string.IsNullOrEmpty(onlineClient.Device_Id) &&
                onlineClient.Client_Id != null)
            {
                try
                {
                    lock (Common.LockDbObjForOnlineClient)
                    {
                        var ret = OrmService.Db.Update<OnlineClient>().Set(x => x.ClientType, ClientType.Monitor)
                            .Set(x => x.IsOnline, true).Set(x => x.HttpUrl, onlineClient.HttpUrl)
                            .Set(x => x.Param, onlineClient.Param)
                            .Set(x => x.Stream, onlineClient.Stream).Set(x => x.UpdateTime, onlineClient.UpdateTime)
                            .Set(x => x.ClientType, ClientType.Monitor)
                            .Where(x => x.Client_Id == onlineClient.Client_Id &&
                                        x.Device_Id!.Trim() == onlineClient.Device_Id.Trim())
                            .ExecuteAffrows();
                        if (ret <= 0)
                        {
                            onlineClient.ClientType = ClientType.Monitor;
                            onlineClient.MonitorType = MonitorType.Unknow;
                            onlineClient.IsOnline = true;
                            var retInsert = OrmService.Db.Insert(onlineClient).ExecuteAffrows();
                            if (retInsert > 0)
                            {
                                return true;
                            }

                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return false;
        }


        /// <summary>
        /// 摄像头停止推流的时候
        /// </summary>
        /// <param name="onlineClient"></param>
        /// <returns></returns>
        public static bool OnUnPublish(OnlineClient onlineClient)
        {
            if (onlineClient != null && !string.IsNullOrEmpty(onlineClient.Device_Id) &&
                onlineClient.Client_Id != null)
            {
                try
                {
                    lock (Common.LockDbObjForOnlineClient)
                    {
                        var ret = OrmService.Db.Update<OnlineClient>()
                            .Set(x => x.IsOnline, false).Set(x => x.UpdateTime, onlineClient.UpdateTime)
                            .Where(x => x.Client_Id == onlineClient.Client_Id &&
                                        x.Device_Id!.Trim() == onlineClient.Device_Id.Trim())
                            .ExecuteAffrows();
                        if (ret <= 0)
                        {
                            onlineClient.ClientType = ClientType.Monitor;
                            onlineClient.IsOnline = false;
                            var retInsert = OrmService.Db.Insert(onlineClient).ExecuteAffrows();
                            if (retInsert > 0)
                            {
                                return true;
                            }

                            return false;
                        }
                    }


                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return false;
        }


        /// <summary>
        /// 当有设备连接时
        /// </summary>
        /// <param name="onlineClient"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnConnect(OnlineClient onlineClient)
        {
            if (onlineClient != null && !string.IsNullOrEmpty(onlineClient.Device_Id) &&
                onlineClient.Client_Id != null)
            {
                try
                {
                    lock (Common.LockDbObjForOnlineClient)
                    {
                        var ret = OrmService.Db.Update<OnlineClient>().Set(x => x.ClientType, ClientType.Monitor)
                            .Set(x => x.IsOnline, true).Set(x => x.HttpUrl, onlineClient.HttpUrl)
                            .Set(x => x.Param, onlineClient.Param)
                            .Set(x => x.Stream, onlineClient.Stream).Set(x => x.UpdateTime, onlineClient.UpdateTime)
                            .Set(x => x.MonitorIp, onlineClient.ClientIp)
                            .Where(x => x.Client_Id == onlineClient.Client_Id &&
                                        x.Device_Id!.Trim() == onlineClient.Device_Id.Trim())
                            .ExecuteAffrows();
                        if (ret <= 0)
                        {
                            onlineClient.ClientType = ClientType.Monitor;
                            onlineClient.IsOnline = true;
                            onlineClient.MonitorIp = onlineClient.ClientIp;
                            onlineClient.MonitorType = MonitorType.Unknow;
                            var retInsert = OrmService.Db.Insert(onlineClient).ExecuteAffrows();
                            if (retInsert > 0)
                            {
                                return true;
                            }

                            return false;
                        }
                    }


                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return false;
        }
    }
}
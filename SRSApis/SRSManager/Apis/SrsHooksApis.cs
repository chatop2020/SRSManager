using System;
using SrsManageCommon;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;
using Common = SRSApis.Common;

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
        /// <param name="dvr"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnDvr(Dvr dvr)
        {
            try
            {
                OrmService.Db.Insert(dvr).ExecuteAffrows();
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
            Console.WriteLine(jsonStr);
            return true;
        }

        /// <summary>
        /// 连接关闭时
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnClose(Client client)
        {
            if (client != null && !string.IsNullOrEmpty(client.ClientIp) && client.Client_Id != null)
            {
                try
                {
                    OrmService.Db.Delete<Client>()
                        .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp).ExecuteAffrows();
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
            var ret = OrmService.Db.Select<Client>()
                .Where(x => x.Stream!.Trim().Equals(stream.Trim()) && x.ClientType == ClientType.Monitor).First();
            if (ret != null)
            {
                return ret.MonitorIp!;
            }

            return "unknow";
        }

        /// <summary>
        /// 客户端播放时
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnPlay(Client client)
        {
            lock (Common.LockObj)
            {
                if (client != null && client.Client_Id != null && !string.IsNullOrEmpty(client.Device_Id))
                {
                    try
                    {
                        var ret = OrmService.Db.Update<Client>().Set(x => x.ClientType, ClientType.User)
                            .Set(x => x.IsOnline, true).Set(x => x.IsPlay, true).Set(x => x.Param, client.Param)
                            .Set(x => x.Stream, client.Stream).Set(x => x.UpdateTime, client.UpdateTime)
                            .Set(x => x.PageUrl, client.PageUrl).Set(x => x.MonitorIp,
                                getMonitorIpAddressFromStream(client.Stream!))
                            .Where(x => x.Client_Id == client.Client_Id &&
                                        x.Device_Id!.Trim() == client.Device_Id.Trim())
                            .ExecuteAffrows();
                        if (ret <= 0)
                        {
                            client.ClientType = ClientType.User;
                            client.IsOnline = true;
                            client.IsPlay = true;
                            client.MonitorIp = getMonitorIpAddressFromStream(client.Stream!);
                            var retInsert = OrmService.Db.Insert(client).ExecuteAffrows();
                            if (retInsert > 0)
                            {
                                return true;
                            }

                            return false;
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

        /*/// <summary>
        /// 客户端播放时
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnPlay(Client client)
        {
            lock (Common.LockObj)
            {
                if (client != null && !string.IsNullOrEmpty(client.ClientIp) && client.Client_Id != null)
                {
                    try
                    {
                        Client tmpClient = OrmService.Db.Select<Client>()
                            .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp).First();
                        if (tmpClient != null)
                        {
                            var ret = OrmService.Db.Update<Client>().Set(x => x.ClientType, ClientType.User)
                                .Set(x => x.IsOnline, true).Set(x => x.IsPlay, true).Set(x => x.Param, client.Param)
                                .Set(x => x.Stream, client.Stream).Set(x => x.UpdateTime, client.UpdateTime)
                                .Set(x => x.PageUrl, client.PageUrl).Set(x=>x.MonitorIp,getMonitorIpAddressFromStream(client.Stream!))
                                .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp)
                                .ExecuteAffrows();
                            if (ret > 0)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            client.ClientType = ClientType.User;
                            client.IsOnline = true;
                            client.IsPlay = true;
                            var ret = OrmService.Db.Insert(client).ExecuteAffrows();
                            if (ret > 0)
                            {
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }

                return false;
            }
        }*/

        /// <summary>
        /// 客户端停止播放时
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnStop(Client client)
        {
            lock (Common.LockObj)
            {
                if (client != null && !string.IsNullOrEmpty(client.Device_Id) && client.Client_Id != null)
                {
                    try
                    {
                        var ret = OrmService.Db.Update<Client>().Set(x => x.ClientType, ClientType.User)
                            .Set(x => x.IsOnline, true).Set(x => x.IsPlay, false)
                            .Set(x => x.UpdateTime, client.UpdateTime)
                            .Where(x => x.Client_Id == client.Client_Id &&
                                        x.Device_Id!.Trim() == client.Device_Id.Trim())
                            .ExecuteAffrows();
                        if (ret <= 0)
                        {
                            client.ClientType = ClientType.User;
                            client.IsOnline = true;
                            client.IsPlay = false;
                            var retInsert = OrmService.Db.Insert(client).ExecuteAffrows();
                            if (retInsert > 0)
                            {
                                return true;
                            }

                            return false;
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

        /*/// <summary>
        /// 客户端停止播放时
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnStop(Client client)
        {
            lock (Common.LockObj)
            {
                if (client != null && !string.IsNullOrEmpty(client.ClientIp) && client.Client_Id != null)
                {
                    try
                    {
                        Client tmpClient = OrmService.Db.Select<Client>()
                            .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp).First();
                        if (tmpClient != null)
                        {
                            var ret = OrmService.Db.Update<Client>().Set(x => x.ClientType, ClientType.User)
                                .Set(x => x.IsOnline, true).Set(x => x.IsPlay, false)
                                .Set(x => x.UpdateTime, client.UpdateTime)
                                .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp)
                                .ExecuteAffrows();
                            if (ret > 0)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            client.ClientType = ClientType.User;
                            client.IsOnline = true;
                            client.IsPlay = false;
                            var ret = OrmService.Db.Insert(client).ExecuteAffrows();
                            if (ret > 0)
                            {
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }

                return false;
            }
        }*/

        /// <summary>
        /// 摄像头推流的时候
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnPublish(Client client)
        {
            lock (Common.LockObj)
            {
                if (client != null && !string.IsNullOrEmpty(client.Device_Id) && client.Client_Id != null)
                {
                    try
                    {
                        var ret = OrmService.Db.Update<Client>().Set(x => x.ClientType, ClientType.Monitor)
                            .Set(x => x.IsOnline, true).Set(x => x.HttpUrl, client.HttpUrl)
                            .Set(x => x.Param, client.Param)
                            .Set(x => x.Stream, client.Stream).Set(x => x.UpdateTime, client.UpdateTime)
                            .Set(x => x.ClientType, ClientType.Monitor)
                            .Where(x => x.Client_Id == client.Client_Id &&
                                        x.Device_Id!.Trim() == client.Device_Id.Trim())
                            .ExecuteAffrows();
                        if (ret <= 0)
                        {
                            client.ClientType = ClientType.Monitor;
                            client.MonitorType = MonitorType.Unknow;
                            client.IsOnline = true;
                            var retInsert = OrmService.Db.Insert(client).ExecuteAffrows();
                            if (retInsert > 0)
                            {
                                return true;
                            }

                            return false;
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

        /*/// <summary>
        /// 摄像头推流的时候
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnPublish(Client client)
        {
            lock (Common.LockObj)
            {
                if (client != null && !string.IsNullOrEmpty(client.ClientIp) && client.Client_Id != null)
                {
                    try
                    {
                        Client tmpClient = OrmService.Db.Select<Client>()
                            .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp).First();
                        if (tmpClient != null)
                        {
                            var ret = OrmService.Db.Update<Client>().Set(x => x.ClientType, ClientType.Monitor)
                                .Set(x => x.IsOnline, true).Set(x => x.HttpUrl, client.HttpUrl)
                                .Set(x => x.Param, client.Param)
                                .Set(x => x.Stream, client.Stream).Set(x => x.UpdateTime, client.UpdateTime)
                                .Set(x => x.ClientType, ClientType.Monitor)
                                .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp)
                                .ExecuteAffrows();
                            if (ret > 0)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            client.ClientType = ClientType.Monitor;
                            client.MonitorType=MonitorType.Unknow;
                            client.IsOnline = true;
                            var ret = OrmService.Db.Insert(client).ExecuteAffrows();
                            if (ret > 0)
                            {
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }

                return false;
            }
        }*/

        /// <summary>
        /// 摄像头停止推流的时候
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnUnPublish(Client client)
        {
            lock (Common.LockObj)
            {
                if (client != null && !string.IsNullOrEmpty(client.Device_Id) && client.Client_Id != null)
                {
                    try
                    {
                        var ret = OrmService.Db.Update<Client>()
                            .Set(x => x.IsOnline, false).Set(x => x.UpdateTime, client.UpdateTime)
                            .Where(x => x.Client_Id == client.Client_Id &&
                                        x.Device_Id!.Trim() == client.Device_Id.Trim())
                            .ExecuteAffrows();

                        if (ret <= 0)
                        {
                            client.ClientType = ClientType.Monitor;
                            client.IsOnline = false;
                            var retInsert = OrmService.Db.Insert(client).ExecuteAffrows();
                            if (retInsert > 0)
                            {
                                return true;
                            }

                            return false;
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

        /*/// <summary>
        /// 摄像头停止推流的时候
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnUnPublish(Client client)
        {
            lock (Common.LockObj)
            {
                if (client != null && !string.IsNullOrEmpty(client.ClientIp) && client.Client_Id != null)
                {
                    try
                    {
                        Client tmpClient = OrmService.Db.Select<Client>()
                            .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp).First();
                        if (tmpClient != null)
                        {
                            var ret = OrmService.Db.Update<Client>()
                                .Set(x => x.IsOnline, false).Set(x => x.UpdateTime, client.UpdateTime)
                                .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp)
                                .ExecuteAffrows();
                            if (ret > 0)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            client.ClientType = ClientType.Monitor;
                            client.IsOnline = false;
                            var ret = OrmService.Db.Insert(client).ExecuteAffrows();
                            if (ret > 0)
                            {
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }

                return false;
            }
        }*/


        /// <summary>
        /// 当有设备连接时
        /// </summary>
        /// <param name="client"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnConnect(Client client)
        {
            lock (Common.LockObj)
            {
                if (client != null && !string.IsNullOrEmpty(client.Device_Id) && client.Client_Id != null)
                {
                    try
                    {
                        var ret = OrmService.Db.Update<Client>().Set(x => x.ClientType, ClientType.Monitor)
                            .Set(x => x.IsOnline, true).Set(x => x.HttpUrl, client.HttpUrl)
                            .Set(x => x.Param, client.Param)
                            .Set(x => x.Stream, client.Stream).Set(x => x.UpdateTime, client.UpdateTime)
                            .Set(x => x.MonitorIp, client.ClientIp)
                            .Where(x => x.Client_Id == client.Client_Id &&
                                        x.Device_Id!.Trim() == client.Device_Id.Trim())
                            .ExecuteAffrows();
                        if (ret <= 0)
                        {
                            client.ClientType = ClientType.Monitor;
                            client.IsOnline = true;
                            client.MonitorIp = client.ClientIp;
                            client.MonitorType = MonitorType.Unknow;
                            var retInsert = OrmService.Db.Insert(client).ExecuteAffrows();
                            if (retInsert > 0)
                            {
                                return true;
                            }

                            return false;
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

        /*
        /// <summary>
        /// 当有设备连接时
        /// </summary>
        /// <param name="client"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnConnect(Client client)
        {
            lock (Common.LockObj)
            {
                if (client != null && !string.IsNullOrEmpty(client.ClientIp) && client.Client_Id != null)
                {
                    try
                    {
                        Client tmpClient = OrmService.Db.Select<Client>()
                            .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp).First();
                        if (tmpClient != null)
                        {
                            var ret = OrmService.Db.Update<Client>().Set(x => x.ClientType, ClientType.Monitor)
                                .Set(x => x.IsOnline, true).Set(x => x.HttpUrl, client.HttpUrl)
                                .Set(x => x.Param, client.Param)
                                .Set(x => x.Stream, client.Stream).Set(x => x.UpdateTime, client.UpdateTime)
                                .Set(x => x.MonitorIp, client.ClientIp)
                                .Where(x => x.Client_Id == client.Client_Id && x.ClientIp == client.ClientIp)
                                .ExecuteAffrows();
                            if (ret > 0)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            client.ClientType = ClientType.Monitor;
                            client.IsOnline = true;
                            client.MonitorIp = client.ClientIp;
                            client.MonitorType = MonitorType.Unknow;
                            var ret = OrmService.Db.Insert(client).ExecuteAffrows();
                            if (ret > 0)
                            {
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }

                return false;
            }
        }*/
    }
}
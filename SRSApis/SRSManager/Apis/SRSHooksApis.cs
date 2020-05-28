using System;
using System.IO;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSCallBackManager.Structs;
using SRSManageCommon;

namespace SRSApis.SRSManager.Apis
{
    /// <summary>
    /// SRSHookApis
    /// </summary>
    public static class SrsHooksApis
    {
        
        /// <summary>
        /// 写入ClientList
        /// </summary>
        private static void reWriteClientList()
        {
            lock (SRSManageCommon.Common.LockObj)
            { 
                string jsonStr = JsonHelper.ToJson(Common.RemoteClientManager.ClientList);
                jsonStr = JsonHelper.ConvertJsonString(jsonStr);
                File.WriteAllText(Common.WorkPath+"ClientList.json",jsonStr);
            }
           
        }
        
        /// <summary>
        /// 写入DvrList
        /// </summary>
        private static void reWriteDvrList(DvrMessage dvr)
        {
            lock (SRSManageCommon.Common.LockObj)
            {
                if (!Directory.Exists(Common.WorkPath + "RecordDvr/" + dvr.Stream))
                {
                    Directory.CreateDirectory(Common.WorkPath + "RecordDvr/" + dvr.Stream);
                }

                string fileName = Common.WorkPath + "RecordDvr/" + dvr.Stream + "/DvrList.json";
                string jsonStr = JsonHelper.ToJson(Common.DvrListManager.DvrList.FindAll(x=>x.Stream==dvr.Stream &&x.Vhost==dvr.Vhost && x.App==dvr.App));
                jsonStr = JsonHelper.ConvertJsonString(jsonStr);
                File.WriteAllText(fileName,jsonStr);
            }
           
        }


        /// <summary>
        /// 处理Dvr信息
        /// </summary>
        /// <param name="dvr"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnDvr( DvrMessage dvr)
        {
            Common.DvrListManager.DvrList.Add(dvr);
            reWriteDvrList(dvr);
            return true;
        }
        

        /// <summary>
        /// 处理srs心跳信息
        /// </summary>
        /// <param name="heartbeat"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnHeartbeat(ReqSrsHeartbeat heartbeat ,out ResponseStruct rs)
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
           
            if (client != null)
            {
                var ret= Common.RemoteClientManager.ClientList.FindLast(x =>
                    x.RemoteClient!.ClientId == client.RemoteClient!.ClientId &&
                    x.RemoteClient.ClientIp == client.RemoteClient.ClientIp &&
                    x.Vhost == client.Vhost && x.App==client.App);
                if (ret != null)
                {
                    Common.RemoteClientManager.ClientList.Remove(ret);
                    return true;
                }
               
            }
            return false;

        }


        
        /// <summary>
        /// 客户端播放时
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnPlay(Client client)
        {
            if (client != null)
            {
                var ret= Common.RemoteClientManager.ClientList.FindLast(x =>
                    x.RemoteClient!.ClientId == client.RemoteClient!.ClientId &&
                    x.RemoteClient.ClientIp == client.RemoteClient.ClientIp);
                if (ret != null)
                {
                    ret.RemoteClient!.ClientType = ClientType.User;
                    ret.IsOnline = true;
                    ret.IsPlay = true;
                    ret.Param = client.Param;
                    ret.Stream = client.Stream;
                    ret.UpdateTime = client.UpdateTime;
                    ret.PageUrl = client.PageUrl;
                }
                else
                {
                    client.RemoteClient!.ClientType = ClientType.User;
                    client.IsOnline = true;
                    client.IsPlay = true;
                    Common.RemoteClientManager.ClientList.Add(client);
                }
                reWriteClientList(); 
                return true;
            }

            return false;
        }
        
         
        /// <summary>
        /// 客户端停止播放时
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnStop(Client client)
        {
            if (client != null)
            {
                var ret= Common.RemoteClientManager.ClientList.FindLast(x =>
                    x.RemoteClient!.ClientId == client.RemoteClient!.ClientId &&
                    x.RemoteClient.ClientIp == client.RemoteClient.ClientIp);
                if (ret != null)
                {
                   
                    ret.IsOnline = true;
                    ret.IsPlay = false;
                    ret.UpdateTime = client.UpdateTime;
                    ret.RemoteClient!.ClientType = ClientType.Monitor;
                }
                else
                {
                    client.RemoteClient!.ClientType = ClientType.Monitor;
                    client.IsOnline = true;
                    client.IsPlay = false;
                    Common.RemoteClientManager.ClientList.Add(client);
                }
                reWriteClientList(); 
                return true;
            }

            return false;
        }
        
        
        /// <summary>
        /// 摄像头推流的时候
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnPublish(Client client)
        {
            if (client != null)
            {
                var ret= Common.RemoteClientManager.ClientList.FindLast(x =>
                    x.RemoteClient!.ClientId == client.RemoteClient!.ClientId &&
                    x.RemoteClient.ClientIp == client.RemoteClient.ClientIp);
                if (ret != null)
                {
                    ret.Param = client.Param;
                    ret.HttpUrl = client.HttpUrl;
                    ret.Stream = client.Stream;
                    ret.IsOnline = true;
                    ret.UpdateTime = client.UpdateTime;
                    ret.RemoteClient!.ClientType = ClientType.Monitor;
                }
                else
                {
                    client.RemoteClient!.ClientType = ClientType.Monitor;
                    client.IsOnline = true;
                    Common.RemoteClientManager.ClientList.Add(client);
                }
                reWriteClientList(); 
                return true;
            }

            return false;
        }
        
        
        
        /// <summary>
        /// 摄像头停止推流的时候
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool OnUnPublish(Client client)
        {
            if (client != null)
            {
                var ret= Common.RemoteClientManager.ClientList.FindLast(x =>
                    x.RemoteClient!.ClientId == client.RemoteClient!.ClientId &&
                    x.RemoteClient.ClientIp == client.RemoteClient.ClientIp);
                if (ret != null)
                {
                    ret.IsOnline = false;
                    ret.UpdateTime = client.UpdateTime;
                    reWriteClientList(); 
                    return true;
                }
            }
            return false;
        }
        
        
        
        /// <summary>
        /// 当有设备连接时
        /// </summary>
        /// <param name="client"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnConnect(Client client)
        {
            var ret= Common.RemoteClientManager.ClientList.FindLast(x =>
                x.RemoteClient!.ClientId == client.RemoteClient!.ClientId &&
                x.RemoteClient.ClientIp == client.RemoteClient.ClientIp);
           if (ret!=null)
           {
               ret.UpdateTime=DateTime.Now;
               ret.IsOnline = true;
               ret.App = client.App;
               ret.Param = client.Param;
               ret.Stream = client.Stream;
               ret.Vhost = client.Vhost;
               ret.HttpUrl = client.HttpUrl;
               ret.RtmpUrl = client.RtmpUrl;
               reWriteClientList();
               return true;
           }
           else
           {
               Common.RemoteClientManager.ClientList.Add(client);
               reWriteClientList();
               return true;
           }
        }
    }
}
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using SRSApis.SRSManager.Apis;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSCallBackManager.Structs;
using SRSManageCommon;
using SRSWebApi.Attributes;
using SRSWebApi.RequestModules;
using Common = SRSApis.Common;

namespace SRSWebApi.Controllers
{
    /// <summary>
    /// SRSHooks控制类
    /// </summary>
    [ApiController]
    [Route("")]
    public class SrsHooksController:ControllerBase
    {

        /// <summary>
        /// 处理心跳信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [LogSrsCallBack]
        [Route("/SrsHooks/Test")]
        public int Test(Object obj)
        {
          //  Console.WriteLine("Test:"+SRSApis.JsonHelper.ToJson(obj));
            return 0;

        }
        
        /// <summary>
        /// 处理心跳信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [LogSrsCallBack]
        [Route("/SrsHooks/OnHeartbeat")]
        public int OnHeartbeat(ReqSrsHeartbeat heartbeat)
        {
            var rt = SrsHooksApis.OnHeartbeat(heartbeat, out ResponseStruct rs);
            if (rt)
            {
                return 0;
            }
            return -1;
        }
        
        
        
        
        
        
        /// <summary>
        /// 有客户端或摄像头关闭时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [LogSrsCallBack]
        [Route("/SrsHooks/OnClose")]
        public int OnClose(ReqSrsClientOnClose client)
        {
            RemoteClient rc= new RemoteClient();
            rc.ClientId =(ushort) client.Client_Id!;
            rc.ClientIp = client.Ip;
            Client tmpClient = new Client()
            {
                RemoteClient = rc,
                App = client.App,
                Vhost = client.Vhost,
            };
            var rt = SrsHooksApis.OnClose(tmpClient);
            if (rt) return 0;
            return -1;
        }

        /// <summary>
        /// 有摄像头停止推流时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [LogSrsCallBack]
        [Route("/SrsHooks/OnUnPublish")]
        public int OnUnPublish(ReqSrsClientOnOrUnPublish client)
        {
            RemoteClient rc= new RemoteClient();
            rc.ClientId =(ushort) client.Client_Id!;
            rc.ClientIp = client.Ip;
            rc.ClientType = ClientType.Monitor;
            Client tmpClient = new Client()
            {
                RemoteClient = rc,
                App = client.App,
                HttpUrl ="",
                IsOnline = true,
                Param = client.Param,
                RtmpUrl = client.TcUrl,
                Stream = client.Stream,
                UpdateTime = DateTime.Now,
                Vhost = client.Vhost,
            }; 
            var rt = SrsHooksApis.OnPublish(tmpClient);
            if (rt) return 0;
            return -1;
        }
        
        
        /// <summary>
        /// 录制文件完成时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [LogSrsCallBack]
        [Route("/SrsHooks/OnDvr")]
        public int OnDvr(ReqSrsDvr dvr)
        {

            DateTime currentTime = DateTime.Now;   
            RemoteClient rc= new RemoteClient();
            rc.ClientId =dvr.Client_Id!;
            rc.ClientIp = dvr.Ip;
            rc.ClientType = ClientType.Monitor;
            DvrMessage tmpDvr = new DvrMessage()
            {
                RemoteClient = rc,
                VideoPath = dvr.File,
                App = dvr.App,
                Stream = dvr.Stream,
                Param = dvr.Param,
                Vhost = dvr.Vhost,
                Dir = Path.GetDirectoryName(dvr.File),
            };

            if (FFmpegGetDuration.GetDuration(Program.CommonFunctions.FFmpegBinPath, dvr.File, out long duration))
            {
                tmpDvr.Duration = duration;
                tmpDvr.StartTime = currentTime.AddMilliseconds(duration * (-1));
                tmpDvr.EndTime = currentTime;
            }
            else
            {
                tmpDvr.Duration = -1;
                tmpDvr.StartTime = currentTime;
                tmpDvr.EndTime = currentTime;
            }
            SrsHooksApis.OnDvr(tmpDvr);
            return 0;
        }
        

        /// <summary>
        /// 有客户端播放时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [LogSrsCallBack]
        [Route("/SrsHooks/OnPlay")]
        public int OnPlay(ReqSrsClientOnPlayOnStop client)
        {
            RemoteClient rc= new RemoteClient();
            rc.ClientId =(ushort) client.Client_Id!;
            rc.ClientIp = client.Ip;
            rc.ClientType = ClientType.Monitor;
            Client tmpClient = new Client()
            {
                RemoteClient = rc,
                App = client.App,
                HttpUrl ="",
                IsOnline = true,
                IsPlay = true,
                Stream = client.Stream,
                UpdateTime = DateTime.Now,
                Vhost = client.Vhost,
                PageUrl = client.PageUrl,
            }; 
            var rt = SrsHooksApis.OnPlay(tmpClient);
            if (rt) return 0;
            return -1;
        }
        
        /// <summary>
        /// 客户端停止播放时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [LogSrsCallBack]
        [Route("/SrsHooks/OnStop")]
        public int OnStop(ReqSrsClientOnPlayOnStop client)
        {
            RemoteClient rc= new RemoteClient();
            rc.ClientId =(ushort) client.Client_Id!;
            rc.ClientIp = client.Ip;
            rc.ClientType = ClientType.Monitor;
            Client tmpClient = new Client()
            {
                RemoteClient = rc,
                App = client.App,
                HttpUrl ="",
                IsOnline = true,
                IsPlay = false,
                Stream = client.Stream,
                UpdateTime = DateTime.Now,
                Vhost = client.Vhost,
                PageUrl = client.PageUrl,
            }; 
            var rt = SrsHooksApis.OnStop(tmpClient);
            if (rt) return 0;
            return -1;
        }
        
        
        /// <summary>
        /// 有摄像头进行推流时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [LogSrsCallBack]
        [Route("/SrsHooks/OnPublish")]
        public int OnPublish(ReqSrsClientOnOrUnPublish client)
        {
            RemoteClient rc= new RemoteClient();
            rc.ClientId =(ushort) client.Client_Id!;
            rc.ClientIp = client.Ip;
            rc.ClientType = ClientType.Monitor;
            Client tmpClient = new Client()
            {
                RemoteClient = rc,
                App = client.App,
                HttpUrl ="",
                IsOnline = true,
                Param = client.Param,
                RtmpUrl = client.TcUrl,
                Stream = client.Stream,
                UpdateTime = DateTime.Now,
                Vhost = client.Vhost,
            }; 
            var rt = SrsHooksApis.OnPublish(tmpClient);
            if (rt) return 0;
            return -1;
        }
        
        /// <summary>
        /// 有客户端或摄像头连接时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [LogSrsCallBack]
        [Route("/SrsHooks/OnConnect")]
        public int OnConnect(ReqSrsClientOnConnect client)
        {
            RemoteClient rc= new RemoteClient();
            rc.ClientId =(ushort) client.Client_Id!;
            rc.ClientIp = client.Ip;
            rc.ClientType = ClientType.User;
            Client tmpClient = new Client()
            {
                RemoteClient = rc,
                App = client.App,
                HttpUrl = client.PageUrl,
                IsOnline = true,
                Param = "",
                RtmpUrl = client.TcUrl,
                Stream = "",
                UpdateTime = DateTime.Now,
                Vhost = client.Vhost,
            };
            var rt = SrsHooksApis.OnConnect(tmpClient);
            if (rt) return 0;
            return -1;
        }
    }
}
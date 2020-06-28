using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager.Apis;
using SrsManageCommon;
using SRSManageCommon.ControllerStructs.RequestModules;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// SRSHooks控制类
    /// </summary>
    [ApiController]
    [Route("")]
    public class SrsHooksController : ControllerBase
    {
       
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
            OnlineClient tmpOnlineClient = new OnlineClient()
            {
                Device_Id = client.Device_Id,
                Client_Id = client.Client_Id,
                ClientIp = client.Ip,
                App = client.App,
                Vhost = client.Vhost,
            };
            var rt = SrsHooksApis.OnClose(tmpOnlineClient);
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
            OnlineClient tmpOnlineClient = new OnlineClient()
            {
                Device_Id = client.Device_Id,
                Client_Id = client.Client_Id,
                ClientIp = client.Ip,
                ClientType = ClientType.Monitor,
                App = client.App,
                HttpUrl = "",
                IsOnline = true,
                Param = client.Param,
                RtmpUrl = client.TcUrl,
                Stream = client.Stream,
                UpdateTime = DateTime.Now,
                Vhost = client.Vhost,
            };
            var rt = SrsHooksApis.OnUnPublish(tmpOnlineClient);
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

            DvrVideo tmpDvrVideo = new DvrVideo()
            {
                Device_Id = dvr.Device_Id,
                Client_Id = dvr.Client_Id,
                ClientIp = dvr.Ip,
                ClientType = ClientType.Monitor,
                VideoPath = dvr.File,
                App = dvr.App,
                Stream = dvr.Stream,
                Param = dvr.Param,
                Vhost = dvr.Vhost,
                Dir = Path.GetDirectoryName(dvr.File),
            };

            FileInfo dvrFile = new FileInfo(dvr.File);
            tmpDvrVideo.FileSize = dvrFile.Length;
            if (FFmpegGetDuration.GetDuration(Common.FFmpegBinPath, dvr.File!, out long duration,out string newPath))
            {
                tmpDvrVideo.VideoPath = newPath;
                tmpDvrVideo.Duration = duration;
                tmpDvrVideo.StartTime = currentTime.AddMilliseconds(duration * (-1));
                tmpDvrVideo.EndTime = currentTime;
            }
            else
            {
                tmpDvrVideo.Duration = -1;
                tmpDvrVideo.StartTime = currentTime;
                tmpDvrVideo.EndTime = currentTime;
            }

            SrsHooksApis.OnDvr(tmpDvrVideo);
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
            OnlineClient tmpOnlineClient = new OnlineClient()
            {
                Device_Id = client.Device_Id,
                Client_Id = client.Client_Id,
                ClientIp = client.Ip,
                ClientType = ClientType.Monitor,
                App = client.App,
                HttpUrl = "",
                IsOnline = true,
                IsPlay = true,
                Stream = client.Stream,
                UpdateTime = DateTime.Now,
                Vhost = client.Vhost,
                PageUrl = client.PageUrl,
            };
            var rt = SrsHooksApis.OnPlay(tmpOnlineClient);
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
            OnlineClient tmpOnlineClient = new OnlineClient()
            {
                Device_Id = client.Device_Id,
                Client_Id = client.Client_Id,
                ClientIp = client.Ip,
                ClientType = ClientType.Monitor,
                App = client.App,
                HttpUrl = "",
                IsOnline = true,
                IsPlay = false,
                Stream = client.Stream,
                UpdateTime = DateTime.Now,
                Vhost = client.Vhost,
                PageUrl = client.PageUrl,
            };
            var rt = SrsHooksApis.OnStop(tmpOnlineClient);
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
            OnlineClient tmpOnlineClient = new OnlineClient()
            {
                Device_Id = client.Device_Id,
                Client_Id = client.Client_Id,
                ClientIp = client.Ip,
                ClientType = ClientType.Monitor,
                MonitorType = MonitorType.Onvif,
                App = client.App,
                HttpUrl = "",
                IsOnline = true,
                Param = client.Param,
                RtmpUrl = client.TcUrl,
                Stream = client.Stream,
                UpdateTime = DateTime.Now,
                Vhost = client.Vhost,
            };
            var rt = SrsHooksApis.OnPublish(tmpOnlineClient);
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
            OnlineClient tmpOnlineClient = new OnlineClient()
            {
                MonitorType = MonitorType.Unknow,
                Device_Id = client.Device_Id,
                Client_Id = client.Client_Id,
                ClientIp = client.Ip,
                ClientType = ClientType.User,
                App = client.App,
                HttpUrl = client.PageUrl,
                IsOnline = true,
                Param = "",
                RtmpUrl = client.TcUrl,
                Stream = "",
                UpdateTime = DateTime.Now,
                Vhost = client.Vhost,
            };
            var rt = SrsHooksApis.OnConnect(tmpOnlineClient);
            if (rt) return 0;
            return -1;
        }
    }
}
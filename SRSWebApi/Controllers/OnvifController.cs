using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SRSApis.SRSManager.Apis;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSManageCommon;
using SRSWebApi.Attributes;
using SRSWebApi.RequestModules;

namespace SRSWebApi.Controllers
{
    /// <summary>
    /// onvif设备接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class OnvifController : ControllerBase
    {
        /// <summary>
        /// 初始化还未初始化的onvif摄像头
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Onvif/InitAll")]
        public JsonResult InitAll()
        {
            var rt = OnvifMonitorApis.InitOnvifMonitorListWhenNotInit(out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 初始化还未初始化的onvif摄像头用ip 地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Onvif/InitByIpAddress")]
        public JsonResult InitByIpAddress(string ipAddress)
        {
            var rt = OnvifMonitorApis.InitOnvifMonitorByIpAddrWhenNotInit(ipAddress, out ResponseStruct rs);
            if (rt == null)
            {
                return Program.CommonFunctions.DelApisResult(null!, rs);
            }

            OnvifMonitorStruct ovm = new OnvifMonitorStruct();
            ovm.OnvifProfileLimitList = new List<ProfileLimit>();
            ovm.MediaSourceInfoList = new List<MediaSourceInfo>();
            ovm.Host = rt.Host;
            ovm.Password = rt.Password;
            ovm.Username = rt.Username;
            ovm.IsInited = rt.IsInited;
            if (rt.OnvifProfileList != null)
                foreach (var p in rt.OnvifProfileList)
                {
                    ProfileLimit pl = new ProfileLimit();
                    pl.AbsoluteMove = p.AbsoluteMove;
                    pl.ContinuousMove = p.ContinuousMove;
                    pl.RelativeMove = p.RelativeMove;
                    pl.MediaUrl = p.MediaUrl;
                    pl.ProfileToken = p.ProfileToken;
                    pl.PtzMoveSupport = p.PtzMoveSupport;
                    ovm.OnvifProfileLimitList.Add(pl);
                }

            if (rt.MediaSourceInfoList != null)
                ovm.MediaSourceInfoList = rt.MediaSourceInfoList;
            return Program.CommonFunctions.DelApisResult(ovm, rs);
        }

        /// <summary>
        /// 设置Ptz焦距
        /// </summary>
        /// <param name="ptzZoomStruct"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Onvif/SetPtzZoom")]
        public JsonResult SetPtzZoom(PtzZoomStruct ptzZoomStruct)
        {
            int v = 0;
            v = (ptzZoomStruct.ZoomDir == ZoomDir.MORE) ? 1 : -1; //放大时值大于0,缩小时值小于0
            var rt = OnvifMonitorApis.SetPtzZoom(ptzZoomStruct.IpAddr, ptzZoomStruct.ProfileToken, v,
                out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取ptz坐标
        /// </summary>
        /// <param name="ptzMove"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Onvif/GetPtzPosition")]
        public JsonResult GetPtzPosition(PtzMoveStruct ptzMove)
        {
            var rt = OnvifMonitorApis.GetPtzPosition(ptzMove.IpAddr, ptzMove.ProfileToken, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 停止持续移动
        /// </summary>
        /// <param name="ptzMove"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Onvif/PtzKeepMoveStop")]
        public JsonResult PtzKeepMoveStop(PtzMoveStruct ptzMove)
        {
            var rt = OnvifMonitorApis.PtzKeepMoveStop(ptzMove.IpAddr, ptzMove.ProfileToken, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 控制ptz移动
        /// </summary>
        /// <param name="ptzMove"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Onvif/PtzMove")]
        public JsonResult PtzMove(PtzMoveStruct ptzMove)
        {
            var rt = OnvifMonitorApis.PtzMove(ptzMove.IpAddr, ptzMove.ProfileToken, (PtzMoveType) ptzMove.MoveType,
                ptzMove.MoveDir, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 初始化onvif设备并加到管理列表中
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Onvif/InitMonitor")]
        public JsonResult InitMonitor(ReqInitOnvif request)
        {
            DiscoveryOnvifMonitors req = new DiscoveryOnvifMonitors()
            {
                Username = request.Username,
                Password = request.Password,
                IpAddrs = request.IpAddrs,
            };
            var rt = OnvifMonitorApis.InitMonitors(req, out ResponseStruct rs, true);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 获取onvif摄像头参数列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Onvif/GetMonitorList")]
        public JsonResult GetMonitorList()
        {
            var rt = OnvifMonitorApis.GetOnvifMonitorList(out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 跟据实例名称/ip地址获取onvif摄像头实例
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Onvif/GetMonitor")]
        public JsonResult GetMonitor(string ipAddress)
        {
            var rt = OnvifMonitorApis.GetOnvifMonitor(ipAddress, out ResponseStruct rs);
            if (rt == null)
            {
                return Program.CommonFunctions.DelApisResult(null!, rs);
            }

            OnvifMonitorStruct ovm = new OnvifMonitorStruct();
            ovm.OnvifProfileLimitList = new List<ProfileLimit>();
            ovm.MediaSourceInfoList = new List<MediaSourceInfo>();
            ovm.Host = rt.Host;
            ovm.Password = rt.Password;
            ovm.Username = rt.Username;
            ovm.IsInited = rt.IsInited;
            if (rt.OnvifProfileList != null)
                foreach (var p in rt.OnvifProfileList)
                {
                    ProfileLimit pl = new ProfileLimit();
                    pl.AbsoluteMove = p.AbsoluteMove;
                    pl.ContinuousMove = p.ContinuousMove;
                    pl.RelativeMove = p.RelativeMove;
                    pl.MediaUrl = p.MediaUrl;
                    pl.ProfileToken = p.ProfileToken;
                    pl.PtzMoveSupport = p.PtzMoveSupport;
                    ovm.OnvifProfileLimitList.Add(pl);
                }

            if (rt.MediaSourceInfoList != null)
                ovm.MediaSourceInfoList = rt.MediaSourceInfoList;
            return Program.CommonFunctions.DelApisResult(ovm, rs);
        }
    }
}
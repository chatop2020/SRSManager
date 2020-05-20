using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnvifManager;
using SRSApis;
using SRSApis.SRSManager.Apis;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSWebApi.Attributes;
using SRSWebApi.RequestModules;
using SRSWebApi.ResponseModules;
using PtzMoveDir = OnvifManager.PtzMoveDir;

namespace SRSWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class Onvif: ControllerBase
    {
        /// <summary>
        /// 设置Ptz焦距
        /// </summary>
        /// <param name="setZoom"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/Onvif/SetPtzZoom")]
        public JsonResult SetPtzZoom(ReqSetZoom setZoom)
        {
            int v = 0;
            v = (setZoom.ZoomDir == ZoomDir.MORE) ? 1 : -1;//放大时值大于0,缩小时值小于0
            var rt=OnvifMonitorApis.SetPtzZoom( setZoom.IpAddr,setZoom.ProfileToken,v, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
        /// <summary>
        /// 获取ptz坐标
        /// </summary>
        /// <param name="ptzMove"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/Onvif/GetPtzPosition")]
        public JsonResult GetPtzPosition(ReqPtzMove ptzMove)
        {
            var rt=OnvifMonitorApis.GetPtzPosition( ptzMove.IpAddr,ptzMove.ProfileToken, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        
        /// <summary>
        /// 停止持续移动
        /// </summary>
        /// <param name="ptzMove"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/Onvif/PtzKeepMoveStop")]
        public JsonResult PtzKeepMoveStop(ReqPtzMove ptzMove)
        {
            var rt=OnvifMonitorApis.PtzKeepMoveStop( ptzMove.IpAddr,ptzMove.ProfileToken, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        
        /// <summary>
        /// 控制ptz移动
        /// </summary>
        /// <param name="ptzMove"></param>
        /// <returns></returns>
        [HttpPost] 
        [AuthVerify]
        [Route("/Onvif/PtzMove")]
        public JsonResult PtzMove(ReqPtzMove ptzMove)
        {
            var rt=OnvifMonitorApis.PtzMove( ptzMove.IpAddr,ptzMove.ProfileToken,(PtzMoveType)ptzMove.MoveType,(PtzMoveDir)ptzMove.MoveDir, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
        
        
        /// <summary>
        /// 初始化onvif设备并加到管理列表中
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/Onvif/InitMonitor")]
        public JsonResult InitMonitor(ReqInitOnvif request)
        {
            DiscoveryOnvifMonitors req = new DiscoveryOnvifMonitors()
            {
                Username = request.Username,
                Password = request.Password,
                IpAddrs = request.IpAddrs,
            };
            var rt=OnvifMonitorApis.InitMonitors(req, out ResponseStruct rs, true);
            return Program.common.DelApisResult(rt, rs);
        }
        /// <summary>
        /// 获取onvif摄像头实例名称列表(ip地址)
        /// </summary>
        /// <returns></returns>
        [HttpPost] 
        [AuthVerify]
        [Route("/Onvif/GetMonitorList")]
        public JsonResult GetMonitorList()
        {
            var rt=OnvifMonitorApis.GetOnvifMonitorsIpAddress( out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
        /// <summary>
        /// 跟据实例名称/ip地址获取onvif摄像头实例
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/Onvif/GetMonitor")]
        public JsonResult GetMonitor(string ipAddress)
        {
            var rt=OnvifMonitorApis.GetOnvifMonitor(ipAddress, out ResponseStruct rs);
            OnvifMonitorModule ovm = new OnvifMonitorModule();
            ovm.OnvifProfileLimitList = new List<ProfileLimit>();
            ovm.MediaSourceInfoList= new List<MediaSourceInfo>();
            ovm.Host = rt.Host;
            ovm.Password = rt.Password;
            ovm.Username = rt.Username;
            ovm.IsInited = rt.IsInited;
            foreach (var p in rt.OnvifProfileList)
            {
                ProfileLimit pl= new ProfileLimit();
                pl.AbsoluteMove = p.AbsoluteMove;
                pl.ContinuousMove = p.ContinuousMove;
                pl.RelativeMove = p.RelativeMove;
                pl.MediaUrl = p.MediaUrl;
                pl.ProfileToken = p.ProfileToken;
                pl.PtzMoveSupport = p.PtzMoveSupport;
                ovm.OnvifProfileLimitList.Add(pl);
            }
         
            ovm.MediaSourceInfoList = rt.MediaSourceInfoList;
            return Program.common.DelApisResult(ovm, rs);
        }
    }
}
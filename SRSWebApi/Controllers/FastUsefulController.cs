using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager.Apis;
using SrsApis.SrsManager.Apis.ApiModules;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    
    /// <summary>
    /// 快速使用接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class FastUsefulController : ControllerBase
    {   /// <summary>
        /// 修改录制计划ById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/SetDvrPlanById")]
        public JsonResult SetDvrPlanById(StreamDvrPlan sdp)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{sdp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.SetDvrPlanById(sdp,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        /// <summary>
        /// 修改或创建一个录制计划
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/SetDvrPlan")]
        public JsonResult SetDvrPlan(StreamDvrPlan sdp)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{sdp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.SetDvrPlan(sdp,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 获取录制计划ById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetDvrPlanById")]
        public JsonResult GetDvrPlanById(long id)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{id});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.GetDvrPlanById(id,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 获取录制计划
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetDvrPlan")]
        public JsonResult GetDvrPlan(ReqDvrPlan rdp)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{rdp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.GetDvrPlan(rdp,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        
        /// <summary>
        /// 对某个vhost设置成低时延模式/正常模式
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/OnOrOffVhostMinDelay")]
        public JsonResult OnOrOffVhostMinDelay(string deviceId,string vhostDomain,bool enable)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhostDomain,enable});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.OnOrOffVhostMinDelay(deviceId,vhostDomain,enable,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        
        /// <summary>
        /// 用于gb28181的云台镜头缩放控制
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/PtzZoomForGb28181")]
        public JsonResult PtzZommForGb28181(SrsGBT28181PtzZoomModule obj)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{obj});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.PtzZoomForGb28181(obj.DeviceId!,obj,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 用于gb28181的云台移动控制
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/PtzMoveForGb28181")]
        public JsonResult PtzMoveForGb28181(SrsGBT28181PtzMoveModule obj)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{obj});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.PtzMoveForGb28181(obj.DeviceId!,obj,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 通过stream的值获取摄像头连接信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetClientInfoByStreamValue")]
        public JsonResult GetClientInfoByStreamValue(string stream)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{stream});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.GetClientInfoByStreamValue(stream,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 获取所有运行中srs实例的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetRunningSrsInfoList")]
        public JsonResult GetRunningSrsInfoList()
        {
            var rt = FastUsefulApis.GetRunningSrsInfoList(out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 停止所有运行中的srs实例
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/StopAllSrs")]
        public JsonResult StopAllSrs()
        {
            var rt = FastUsefulApis.StopAllSrs(out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 启动所有未启动的srs实例
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/InitAndStartAllSrs")]
        public JsonResult InitAndStartAllSrs()
        {
            var rt = FastUsefulApis.InitAndStartAllSrs(out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 从Client列表中踢掉一个摄像头或一个播放者
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/KickoffClient")]
        public JsonResult KickoffClient(string deviceId, string streamId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,streamId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.KickoffClient(deviceId, streamId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 获取SRS中Stream的状态信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetStreamStatusById")]
        public JsonResult GetStreamStatusById(string deviceId, string streamId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,streamId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.GetStreamStatusByDeviceIdAndStreamId(deviceId, streamId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 获取SRS中StreamList的状态信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetStreamListStatusByDeviceId")]
        public JsonResult GetStreamListStatusByDeviceId(string deviceId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.GetStreamListStatusByDeviceId(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取SRS中Vhost的状态信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetVhostStatusById")]
        public JsonResult GetVhostStatusById(string deviceId, string vhostId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{vhostId,deviceId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.GetVhostStatusByDeviceIdAndVhostId(deviceId, vhostId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 获取SRS中VhostList的状态信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetVhostListStatusByDeviceId")]
        public JsonResult GetVhostListStatusByDeviceId(string deviceId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.GetVhostListStatusByDeviceId(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 获取在线播放客户端通过srs实例id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetOnOnlinePlayerByDeviceId")]
        public JsonResult GetOnOnlinePlayerByDeviceId(string deviceId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.GetOnlinePlayerByDeviceId(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 获取在线播放客户端
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetOnOnlinePlayer")]
        public JsonResult GetOnOnlinePlayer()
        {
            var rt = FastUsefulApis.GetOnlinePlayer(out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取在线摄像头列表通过srs实例id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetOnPublishMonitorListById")]
        public JsonResult GetOnPublishMonitorListById(string deviceId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.GetOnPublishMonitorListByDeviceId(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取在线摄像头列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetOnPublishMonitorList")]
        public JsonResult GetOnPublishMonitorList()
        {
            var rt = FastUsefulApis.GetOnPublishMonitorList(out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取一个用于rtsp拉流的ingest配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetOnvifMonitorIngestTemplate")]
        public JsonResult GetOnvifMonitorIngestTemplate(string rtspUrl)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{rtspUrl});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = FastUsefulApis.GetOnvifMonitorIngestTemplate(rtspUrl, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
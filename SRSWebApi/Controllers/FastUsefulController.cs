using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager.Apis;
using SrsManageCommon.ApisStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// 快速使用接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class FastUsefulController: ControllerBase
    {
        
        /// <summary>
        /// 从Client列表中踢掉一个摄像头或一个播放者
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/KickoffClient")]
        public JsonResult KickoffClient(string deviceId,string streamId)
        {
            var rt = FastUsefulApis.KickoffClient(deviceId,streamId,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        
        /// <summary>
        /// 获取SRS中Stream的状态信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetStreamStatusById")]
        public JsonResult GetStreamStatusById(string deviceId,string streamId)
        {
            var rt = FastUsefulApis.GetStreamStatusByDeviceIdAndStreamId(deviceId,streamId,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        
        /// <summary>
        /// 获取SRS中StreamList的状态信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetStreamListStatusByDeviceId")]
        public JsonResult GetStreamListStatusByDeviceId(string deviceId)
        {
            var rt = FastUsefulApis.GetStreamListStatusByDeviceId(deviceId,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 获取SRS中Vhost的状态信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetVhostStatusById")]
        public JsonResult GetVhostStatusById(string deviceId,string vhostId)
        {
            var rt = FastUsefulApis.GetVhostStatusByDeviceIdAndVhostId(deviceId,vhostId,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        
        /// <summary>
        /// 获取SRS中VhostList的状态信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetVhostListStatusByDeviceId")]
        public JsonResult GetVhostListStatusByDeviceId(string deviceId)
        {
            var rt = FastUsefulApis.GetVhostListStatusByDeviceId(deviceId,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        
        /// <summary>
        /// 获取在线播放客户端通过srs实例id
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetOnOnlinePlayerByDeviceId")]
        public JsonResult GetOnOnlinePlayerByDeviceId(string deviceId)
        {
            var rt = FastUsefulApis.GetOnlinePlayerByDeviceId(deviceId,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        
        /// <summary>
        /// 获取在线播放客户端
        /// </summary>
        /// <returns></returns>
        [HttpPost]
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
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetOnPublishMonitorListById")]
        public JsonResult GetOnPublishMonitorListById(string deviceId)
        {
            var rt = FastUsefulApis.GetOnPublishMonitorListByDeviceId(deviceId,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 获取在线摄像头列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
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
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/FastUseful/GetOnvifMonitorIngestTemplate")]
        public JsonResult GetOnvifMonitorIngestTemplate(string rtspUrl)
        {
            var rt = FastUsefulApis.GetOnvifMonitorIngestTemplate(rtspUrl,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
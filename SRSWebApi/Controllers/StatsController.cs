using Microsoft.AspNetCore.Mvc;
using SRSApis.SRSManager.Apis;
using SRSConfFile.SRSConfClass;
using SRSManageCommon;
using SRSWebApi.Attributes;

namespace SRSWebApi.Controllers
{
    /// <summary>
    /// SRSRtcServer设备接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class StatsController:ControllerBase
    {
        /// <summary>
        /// 获取Stats配置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Stats/GetSrsStats")]
        public JsonResult GetSrsStats(string deviceId)
        {
            var rt = StatsApis.GetStats(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs); 
        }

        /// <summary>
        /// 设置或创建stats
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Stats/SetSrsStats")]
        public JsonResult SetSrsStats(string deviceId,SrsStatsConfClass stats)
        {
            var rt = StatsApis.SetStatsServer(deviceId,stats,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs); 
        }
        
        /// <summary>
        /// 删除Stats
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Stats/DelStats")]
        public JsonResult DelStats(string deviceId)
        {
            var rt = StatsApis.DeleteStats(deviceId,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs); 
        }
        
    }
}
using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager.Apis;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SRSManageCommon.ManageStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// SRSRtcServer设备接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class StatsController : ControllerBase
    {
        /// <summary>
        /// 获取Stats配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/Stats/GetSrsStats")]
        public JsonResult GetSrsStats(string deviceId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

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
        public JsonResult SetSrsStats(string deviceId, SrsStatsConfClass stats)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId, stats});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = StatsApis.SetStatsServer(deviceId, stats, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 删除Stats
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/Stats/DelStats")]
        public JsonResult DelStats(string deviceId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = StatsApis.DeleteStats(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager.Apis;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SRSManageCommon.ManageStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// vhostforward接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostForwardController
    {
        /// <summary>
        /// 删除Forward配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostForward/DeleteVhostForward")]
        public JsonResult DeleteVhostForward(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId, vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = VhostForwardApis.DeleteVhostForward(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Forward
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostForward/GetVhostForward")]
        public JsonResult GetVhostForward(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId, vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = VhostForwardApis.GetVhostForward(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Forward
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="forward"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostForward/SetVhostForward")]
        public JsonResult SetVhostForward(string deviceId, string vhostDomain, Forward forward)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId, vhostDomain, forward});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = VhostForwardApis.SetVhostForward(deviceId, vhostDomain, forward, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
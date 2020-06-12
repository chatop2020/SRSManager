using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager.Apis;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SRSManageCommon.ManageStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// vhosthttpremux接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostHttpRemux
    {
        /// <summary>
        /// 删除HttpRemux配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostHttpRemux/DeleteVhostHttpRemux")]
        public JsonResult DeleteVhostHttpRemux(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId, vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = VhostHttpRemuxApis.DeleteVhostHttpRemux(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的HttpRemux
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostHttpRemux/GetVhostHttpRemux")]
        public JsonResult GetVhostHttpRemux(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId, vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = VhostHttpRemuxApis.GetVhostHttpRemux(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建HttpRemux
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="httpRemux"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostHttpRemux/SetVhostHttpRemux")]
        public JsonResult SetVhostHttpRemux(string deviceId, string vhostDomain, HttpRemux httpRemux)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId, vhostDomain, httpRemux});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = VhostHttpRemuxApis.SetVhostHttpRemux(deviceId, vhostDomain, httpRemux, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
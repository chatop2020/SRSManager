using System.Net;
using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager;
using SrsApis.SrsManager.Apis;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// vhostsecurity接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostSecurityController
    {
        /// <summary>
        /// 删除Security配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostSecurity/DeleteVhostSecurity")]
        public JsonResult DeleteVhostSecurity(string deviceId, string vhostDomain)
        {
            var rt = VhostSecurityApis.DeleteVhostSecurity(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Security
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostSecurity/GetVhostSecurity")]
        public JsonResult GetVhostSecurity(string deviceId, string vhostDomain)
        {
            var rt = VhostSecurityApis.GetVhostSecurity(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Security
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="security"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostSecurity/SetVhostSecurity")]
        public JsonResult SetVhostSecurity(string deviceId, string vhostDomain, Security security)
        {
            var rt = VhostSecurityApis.SetVhostSecurity(deviceId, vhostDomain, security, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
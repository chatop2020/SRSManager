using Microsoft.AspNetCore.Mvc;
using SRSApis;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSConfFile.SRSConfClass;
using SRSWebApi.Attributes;
using System.Net;

namespace SRSWebApi.Controllers
{
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
        [HttpPost]
        [AuthVerify]
        [Route("/VhostForward/DeleteVhostForward")]
        public JsonResult DeleteVhostForward(string deviceId, string vhostDomain)
        {
            var rt = VhostForwardApis.DeleteVhostForward(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Forward
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostForward/GetVhostForward")]
        public JsonResult GetVhostForward(string deviceId, string vhostDomain)
        {
            var rt = VhostForwardApis.GetVhostForward(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Forward
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostForward/SetVhostForward")]
        public JsonResult SetVhostForward(string deviceId, string vhostDomain, Forward forward, bool createIfNotFound = false)
        {
            var rt = VhostForwardApis.SetVhostForward(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, forward, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Forward
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostForward/CreateVhostForward")]
        public JsonResult CreateVhostForward(string deviceId, string vhostDomain, Forward forward)
        {
            var rt = VhostForwardApis.CreateVhostForward(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, forward, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

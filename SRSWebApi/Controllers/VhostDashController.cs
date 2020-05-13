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
    public class VhostDashController
    {
        /// <summary>
        /// 删除Dash配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostDash/DeleteVhostDash")]
        public JsonResult DeleteVhostDash(string deviceId, string vhostDomain)
        {
            var rt = VhostDashApis.DeleteVhostDash(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Dash
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostDash/GetVhostDash")]
        public JsonResult GetVhostDash(string deviceId, string vhostDomain)
        {
            var rt = VhostDashApis.GetVhostDash(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Dash
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostDash/SetVhostDash")]
        public JsonResult SetVhostDash(string deviceId, string vhostDomain, Dash dash, bool createIfNotFound = false)
        {
            var rt = VhostDashApis.SetVhostDash(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, dash, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Dash
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostDash/CreateVhostDash")]
        public JsonResult CreateVhostDash(string deviceId, string vhostDomain, Dash dash)
        {
            var rt = VhostDashApis.CreateVhostDash(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, dash, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

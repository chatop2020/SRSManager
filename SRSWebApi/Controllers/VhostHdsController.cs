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
    public class VhostHdsController
    {
        /// <summary>
        /// 删除Hds配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHds/DeleteVhostHds")]
        public JsonResult DeleteVhostHds(string deviceId, string vhostDomain)
        {
            var rt = VhostHdsApis.DeleteVhostHds(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Hds
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostHds/GetVhostHds")]
        public JsonResult GetVhostHds(string deviceId, string vhostDomain)
        {
            var rt = VhostHdsApis.GetVhostHds(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Hds
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHds/SetVhostHds")]
        public JsonResult SetVhostHds(string deviceId, string vhostDomain, Hds dds, bool createIfNotFound = false)
        {
            var rt = VhostHdsApis.SetVhostHds(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, dds, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Hds
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHds/CreateVhostHds")]
        public JsonResult CreateVhostHds(string deviceId, string vhostDomain, Hds dds)
        {
            var rt = VhostHdsApis.CreateVhostHds(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, dds, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

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
    public class VhostReferController
    {
        /// <summary>
        /// 删除Refer配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostRefer/DeleteVhostRefer")]
        public JsonResult DeleteVhostRefer(string deviceId, string vhostDomain)
        {
            var rt = VhostReferApis.DeleteVhostRefer(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Refer
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostRefer/GetVhostRefer")]
        public JsonResult GetVhostRefer(string deviceId, string vhostDomain)
        {
            var rt = VhostReferApis.GetVhostRefer(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Refer
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostRefer/SetVhostRefer")]
        public JsonResult SetVhostRefer(string deviceId, string vhostDomain, Refer refer, bool createIfNotFound = false)
        {
            var rt = VhostReferApis.SetVhostRefer(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, refer, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Refer
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostRefer/CreateVhostRefer")]
        public JsonResult CreateVhostRefer(string deviceId, string vhostDomain, Refer refer)
        {
            var rt = VhostReferApis.CreateVhostRefer(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, refer, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

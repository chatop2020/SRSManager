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
    public class VhostDvrController
    {
        /// <summary>
        /// 删除Dvr配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostDvr/DeleteVhostDvr")]
        public JsonResult DeleteVhostDvr(string deviceId, string vhostDomain)
        {
            var rt = VhostDvrApis.DeleteVhostDvr(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Dvr
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostDvr/GetVhostRtc")]
        public JsonResult GetVhostRtc(string deviceId, string vhostDomain)
        {
            var rt = VhostDvrApis.GetVhostRtc(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Dvr
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostDvr/SetVhostRtc")]
        public JsonResult SetVhostRtc(string deviceId, string vhostDomain, Dvr dvr, bool createIfNotFound = false)
        {
            var rt = VhostDvrApis.SetVhostRtc(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, dvr, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Dvr
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostDvr/CreateVhostDvr")]
        public JsonResult CreateVhostDvr(string deviceId, string vhostDomain, Dvr dvr)
        {
            var rt = VhostDvrApis.CreateVhostDvr(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, dvr, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

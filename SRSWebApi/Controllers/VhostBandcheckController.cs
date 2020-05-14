using Microsoft.AspNetCore.Mvc;
using SRSApis;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSConfFile.SRSConfClass;
using SRSWebApi.Attributes;
using SRSWebApi.RequestModules;
using System.Net;

namespace SRSWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class VhostBandcheckController
    {
        /// <summary>
        /// 删除Bandcheck配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostBandcheck/DeleteVhostBandcheck")]
        public JsonResult DeleteVhostBandcheck(string deviceId, string vhostDomain)
        {
            var rt = VhostBandcheckApis.DeleteVhostBandcheck(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Bandcheck
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostBandcheck/GetVhostBandcheck")]
        public JsonResult GetVhostBandcheck(string deviceId, string vhostDomain)
        {
            var rt = VhostBandcheckApis.GetVhostBandcheck(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Bandcheck
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostBandcheck/SetVhostBandcheck")]
        public JsonResult SetVhostBandcheck(string deviceId, string vhostDomain, Bandcheck bandcheck, bool createIfNotFound = false)
        {
            var rt = VhostBandcheckApis.SetVhostBandcheck(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, bandcheck, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Bandcheck
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostBandcheck/CreateVhostBandcheck")]
        public JsonResult CreateVhostBandcheck(string deviceId, string vhostDomain, Bandcheck bandcheck)
        {
            var rt = VhostBandcheckApis.CreateVhostBandcheck(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, bandcheck, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

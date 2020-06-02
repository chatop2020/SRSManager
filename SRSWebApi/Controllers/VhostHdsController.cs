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
    /// vhosthds接口类
    /// </summary>
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
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostHds/DeleteVhostHds")]
        public JsonResult DeleteVhostHds(string deviceId, string vhostDomain)
        {
            var rt = VhostHdsApis.DeleteVhostHds(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Hds
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostHds/GetVhostHds")]
        public JsonResult GetVhostHds(string deviceId, string vhostDomain)
        {
            var rt = VhostHdsApis.GetVhostHds(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Hds
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="dhs"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostHds/SetVhostHds")]
        public JsonResult SetVhostHds(string deviceId, string vhostDomain, Hds dhs)
        {
            var rt = VhostHdsApis.SetVhostHds(deviceId, vhostDomain, dhs, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
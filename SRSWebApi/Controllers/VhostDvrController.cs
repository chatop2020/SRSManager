using System.Net;
using Microsoft.AspNetCore.Mvc;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSConfFile.SRSConfClass;
using SRSManageCommon;
using SRSWebApi.Attributes;

namespace SRSWebApi.Controllers
{
    /// <summary>
    /// vhost dvr接口类
    /// </summary>
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
            var rt = VhostDvrApis.DeleteVhostDvr(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Dvr
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostDvr/GetVhostDvr")]
        public JsonResult GetVhostDvr(string deviceId, string vhostDomain)
        {
            var rt = VhostDvrApis.GetVhostDvr(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Dvr
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="dvr"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostDvr/SetVhostDvr")]
        public JsonResult SetVhostDvr(string deviceId, string vhostDomain, Dvr dvr)
        {
            var rt = VhostDvrApis.SetVhostDvr(deviceId, vhostDomain, dvr, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        
    }
}
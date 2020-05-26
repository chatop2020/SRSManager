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
    /// vhosthls接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostHlsController
    {
        /// <summary>
        /// 删除Hls配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostHls/DeleteVhostHls")]
        public JsonResult DeleteVhostHls(string deviceId, string vhostDomain)
        {
            var rt = VhostHlsApis.DeleteVhostHls(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Hls
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostHls/GetVhostHls")]
        public JsonResult GetVhostHls(string deviceId, string vhostDomain)
        {
            var rt = VhostHlsApis.GetVhostHls(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Hls
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="hls"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostHls/SetVhostHls")]
        public JsonResult SetVhostHls(string deviceId, string vhostDomain, Hls hls)
        {
            var rt = VhostHlsApis.SetVhostHls(deviceId, vhostDomain, hls, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        
    }
}
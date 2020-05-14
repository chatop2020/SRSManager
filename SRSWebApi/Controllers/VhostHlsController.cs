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
        [Route("/VhostHls/DeleteVhostHls")]
        public JsonResult DeleteVhostHls(string deviceId, string vhostDomain)
        {
            var rt = VhostHlsApis.DeleteVhostHls(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Hls
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostHls/GetVhostHls")]
        public JsonResult GetVhostHls(string deviceId, string vhostDomain)
        {
            var rt = VhostHlsApis.GetVhostHls(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Hls
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHls/SetVhostHls")]
        public JsonResult SetVhostHls(string deviceId, string vhostDomain, Hls hls, bool createIfNotFound = false)
        {
            var rt = VhostHlsApis.SetVhostHls(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, hls, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Hls
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHls/CreateVhostHls")]
        public JsonResult CreateVhostHls(string deviceId, string vhostDomain, Hls hls)
        {
            var rt = VhostHlsApis.CreateVhostHls(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, hls, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

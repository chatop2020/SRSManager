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
    public class VhostPlayController
    {
        /// <summary>
        /// 删除Play配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostPlay/DeleteVhostPlay")]
        public JsonResult DeleteVhostPlay(string deviceId, string vhostDomain)
        {
            var rt = VhostPlayApis.DeleteVhostPlay(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Play
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostPlay/GetVhostPlay")]
        public JsonResult GetVhostPlay(string deviceId, string vhostDomain)
        {
            var rt = VhostPlayApis.GetVhostPlay(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Play
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostPlay/SetVhostPlay")]
        public JsonResult SetVhostPlay(string deviceId, string vhostDomain, Play play, bool createIfNotFound = false)
        {
            var rt = VhostPlayApis.SetVhostPlay(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, play, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Play
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostPlay/CreateVhostPlay")]
        public JsonResult CreateVhostPlay(string deviceId, string vhostDomain, Play play)
        {
            var rt = VhostPlayApis.CreateVhostPlay(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, play, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

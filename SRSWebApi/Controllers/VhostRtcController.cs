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
    public class VhostRtcController
    {
        /// <summary>
        /// 删除Rtc配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostRtc/DeleteVhostRtc")]
        public JsonResult DeleteVhostRtc(string deviceId, string vhostDomain)
        {
            var rt = VhostRtcApis.DeleteVhostRtc(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Rtc
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostRtc/GetVhostRtc")]
        public JsonResult GetVhostRtc(string deviceId, string vhostDomain)
        {
            var rt = VhostRtcApis.GetVhostRtc(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Rtc
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostRtc/SetVhostRtc")]
        public JsonResult SetVhostRtc(string deviceId, string vhostDomain, Rtc rtc, bool createIfNotFound = false)
        {
            var rt = VhostRtcApis.SetVhostRtc(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, rtc, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Rtc
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostRtc/CreateVhostRtc")]
        public JsonResult CreateVhostRtc(string deviceId, string vhostDomain, Rtc rtc)
        {
            var rt = VhostRtcApis.CreateVhostRtc(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, rtc, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

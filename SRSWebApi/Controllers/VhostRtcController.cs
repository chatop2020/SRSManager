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
    /// vhostrtc接口类
    /// </summary>
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
        [Log]
        [Route("/VhostRtc/DeleteVhostRtc")]
        public JsonResult DeleteVhostRtc(string deviceId, string vhostDomain)
        {
            var rt = VhostRtcApis.DeleteVhostRtc(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Rtc
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostRtc/GetVhostRtc")]
        public JsonResult GetVhostRtc(string deviceId, string vhostDomain)
        {
            var rt = VhostRtcApis.GetVhostRtc(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Rtc
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="rtc"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostRtc/SetVhostRtc")]
        public JsonResult SetVhostRtc(string deviceId, string vhostDomain, Rtc rtc)
        {
            var rt = VhostRtcApis.SetVhostRtc(deviceId, vhostDomain, rtc, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        
    }
}
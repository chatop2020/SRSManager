using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager.Apis;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// SRSRtcServer设备接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class RtcServerController : ControllerBase
    {
        /// <summary>
        /// 获取rtcserver配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/RtcServer/GetSrsRtcServer")]
        public JsonResult GetSrsRtcServer(string deviceId)
        {
            var rt = RtcServerApis.GetRtcServer(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建rtcserver
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/RtcServer/SetRtcServer")]
        public JsonResult SetSrsRtcServer(string deviceId, SrsRtcServerConfClass rtc)
        {
            var rt = RtcServerApis.SetRtcServer(deviceId, rtc, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 删除rtcserver
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/RtcServer/DelRtcServer")]
        public JsonResult DelSrsRtcServer(string deviceId)
        {
            var rt = RtcServerApis.DeleteRtcServer(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
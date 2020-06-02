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
    public class SrtServerController : ControllerBase
    {
        /// <summary>
        /// 获取srtserver配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/SrtServer/GetSrtServer")]
        public JsonResult GetSrtServer(string deviceId)
        {
            var rt = SrtServerApis.GetSrtServer(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建srtserver
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/SrtServer/SetSrtServer")]
        public JsonResult SetSrsSrtServer(string deviceId, SrsSrtServerConfClass srt)
        {
            var rt = SrtServerApis.SetSrtServer(deviceId, srt, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 删除srtserver
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/SrtServer/DelSrtServer")]
        public JsonResult DelSrsSrtServer(string deviceId)
        {
            var rt = SrtServerApis.DeleteSrtServer(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
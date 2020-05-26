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
    /// vhosttranscode接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostTranscodeController
    {
        /// <summary>
        /// 通过VhostDomain和TranscodeInstanceName删除一个Transcode
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="transcodeInstanceName"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostTranscode/DeleteVhostTranscodeByTranscodeInstanceName")]
        public JsonResult DeleteVhostTranscodeByTranscodeInstanceName(string deviceId, string vhostDomain,
            string transcodeInstanceName)
        {
            var rt = VhostTranscodeApis.DeleteVhostTranscodeByTranscodeInstanceName(deviceId, vhostDomain,
                transcodeInstanceName, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取所有或者指定vhost中的transcode实例名称
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostTranscode/GetVhostTranscodeNameList")]
        public JsonResult GetVhostTranscodeNameList(string deviceId, string vhostDomain = "")
        {
            var rt = VhostTranscodeApis.GetVhostTranscodeNameList(deviceId, out ResponseStruct rs, vhostDomain);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取一个Transcode配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="transcodeInstanceName"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostTranscode/GetVhostTranscode")]
        public JsonResult GetVhostTranscode(string deviceId, string vhostDomain, string transcodeInstanceName)
        {
            var rt = VhostTranscodeApis.GetVhostTranscode(deviceId, vhostDomain, transcodeInstanceName,
                out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Transcode
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="transcodeInstanceName"></param>
        /// <param name="transcode"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostTranscode/SetVhostTranscode")]
        public JsonResult SetVhostTranscode(string deviceId, string vhostDomain, string transcodeInstanceName,
            Transcode transcode)
        {
            var rt = VhostTranscodeApis.SetVhostTranscode(deviceId, vhostDomain, transcodeInstanceName, transcode,
                out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
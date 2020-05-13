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
    public class VhostTranscodeController
    {
        /// <summary>
        /// 通过VhostDomain和TranscodeInstanceName删除一个Transcode
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostTranscode/DeleteVhostTranscodeByTranscodeInstanceName")]
        public JsonResult DeleteVhostTranscodeByTranscodeInstanceName(string deviceId, string vhostDomain, string transcodeInstanceName)
        {
            var rt = VhostTranscodeApis.DeleteVhostTranscodeByTranscodeInstanceName(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, transcodeInstanceName, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取所有或者指定vhost中的transcode实例名称
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostTranscode/GetVhostTranscodeNameList")]
        public JsonResult GetVhostTranscodeNameList(string deviceId, string vhostDomain = "")
        {
            var rt = VhostTranscodeApis.GetVhostTranscodeNameList(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), out ResponseStruct rs, vhostDomain);
            return Program.common.DelApisResult(rt, rs);
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
        [Route("/VhostTranscode/GetVhostTranscode")]
        public JsonResult GetVhostTranscode(string deviceId, string vhostDomain, string transcodeInstanceName)
        {
            var rt = VhostTranscodeApis.GetVhostTranscode(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, transcodeInstanceName, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Transcode
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostTranscode/SetVhostTranscode")]
        public JsonResult SetVhostTranscode(string deviceId, string vhostDomain, string transcodeInstanceName, Transcode transcode, bool createIfNotFound = false)
        {
            var rt = VhostTranscodeApis.SetVhostTranscode(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, transcodeInstanceName, transcode, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Transcode
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostTranscode/CreateVhostTranscode")]
        public JsonResult CreateVhostTranscode(string deviceId, string vhostDomain, Transcode transcode)
        {
            var rt = VhostTranscodeApis.CreateVhostTranscode(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, transcode, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

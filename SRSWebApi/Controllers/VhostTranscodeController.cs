using Microsoft.AspNetCore.Mvc;
using SRSApis;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSConfFile.SRSConfClass;
using SRSWebApi.Attributes;
using System.Net;
using SRSManageCommon;

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
        [Log]
        [Route("/VhostTranscode/DeleteVhostTranscodeByTranscodeInstanceName")]
        public JsonResult DeleteVhostTranscodeByTranscodeInstanceName(string deviceId, string vhostDomain, string transcodeInstanceName)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostTranscodeApis.DeleteVhostTranscodeByTranscodeInstanceName(srsManager, vhostDomain, transcodeInstanceName, out ResponseStruct rs);
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
        [Log]
        [Route("/VhostTranscode/GetVhostTranscodeNameList")]
        public JsonResult GetVhostTranscodeNameList(string deviceId, string vhostDomain = "")
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostTranscodeApis.GetVhostTranscodeNameList(srsManager, out ResponseStruct rs, vhostDomain);
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
        [Log]
        [Route("/VhostTranscode/GetVhostTranscode")]
        public JsonResult GetVhostTranscode(string deviceId, string vhostDomain, string transcodeInstanceName)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostTranscodeApis.GetVhostTranscode(srsManager, vhostDomain, transcodeInstanceName, out ResponseStruct rs);
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
        [Log]
        [Route("/VhostTranscode/SetVhostTranscode")]
        public JsonResult SetVhostTranscode(string deviceId, string vhostDomain, string transcodeInstanceName, Transcode transcode, bool createIfNotFound = false)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostTranscodeApis.SetVhostTranscode(srsManager, vhostDomain, transcodeInstanceName, transcode, out ResponseStruct rs, createIfNotFound);
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
        [Log]
        [Route("/VhostTranscode/CreateVhostTranscode")]
        public JsonResult CreateVhostTranscode(string deviceId, string vhostDomain, Transcode transcode)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostTranscodeApis.CreateVhostTranscode(srsManager, vhostDomain, transcode, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

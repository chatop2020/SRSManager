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
    /// vhostplay接口类
    /// </summary>
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
        [Log]
        [Route("/VhostPlay/DeleteVhostPlay")]
        public JsonResult DeleteVhostPlay(string deviceId, string vhostDomain)
        {
            var rt = VhostPlayApis.DeleteVhostPlay(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Play
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostPlay/GetVhostPlay")]
        public JsonResult GetVhostPlay(string deviceId, string vhostDomain)
        {
            var rt = VhostPlayApis.GetVhostPlay(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Play
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="play"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostPlay/SetVhostPlay")]
        public JsonResult SetVhostPlay(string deviceId, string vhostDomain, Play play)
        {
            var rt = VhostPlayApis.SetVhostPlay(deviceId, vhostDomain, play, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        
    }
}
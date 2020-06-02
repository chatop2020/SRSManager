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
    /// vhostpublish接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostPublishController
    {
        /// <summary>
        /// 删除Publish配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostPublish/DeleteVhostPublish")]
        public JsonResult DeleteVhostPublish(string deviceId, string vhostDomain)
        {
            var rt = VhostPublishApis.DeleteVhostPublish(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Publish
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostPublish/GetVhostPublish")]
        public JsonResult GetVhostPublish(string deviceId, string vhostDomain)
        {
            var rt = VhostPublishApis.GetVhostPublish(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Publish
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="publish"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostPublish/SetVhostPublish")]
        public JsonResult SetVhostPublish(string deviceId, string vhostDomain, Publish publish)
        {
            var rt = VhostPublishApis.SetVhostPublish(deviceId, vhostDomain, publish, out ResponseStruct rs );
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        
    }
}
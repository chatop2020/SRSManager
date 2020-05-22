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
    public class VhostHttpHooksController
    {
        /// <summary>
        /// 删除HttpHooks配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHttpHooks/DeleteVhostHttpHooks")]
        public JsonResult DeleteVhostHttpHooks(string deviceId, string vhostDomain)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostHttpHooksApis.DeleteVhostHttpHooks(srsManager, vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的HttpHooks
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostHttpHooks/GetVhostHttpHooks")]
        public JsonResult GetVhostHttpHooks(string deviceId, string vhostDomain)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostHttpHooksApis.GetVhostHttpHooks(srsManager, vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置HttpHooks
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHttpHooks/SetVhostHttpHooks")]
        public JsonResult SetVhostHttpHooks(string deviceId, string vhostDomain, HttpHooks httpHooks, bool createIfNotFound = false)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostHttpHooksApis.SetVhostHttpHooks(srsManager, vhostDomain, httpHooks, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建HttpHooks
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHttpHooks/CreateVhostHttpHooks")]
        public JsonResult CreateVhostHttpHooks(string deviceId, string vhostDomain, HttpHooks httpHooks)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostHttpHooksApis.CreateVhostHttpHooks(srsManager, vhostDomain, httpHooks, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

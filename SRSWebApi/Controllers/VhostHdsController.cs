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
    public class VhostHdsController
    {
        /// <summary>
        /// 删除Hds配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHds/DeleteVhostHds")]
        public JsonResult DeleteVhostHds(string deviceId, string vhostDomain)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostHdsApis.DeleteVhostHds(srsManager, vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Hds
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostHds/GetVhostHds")]
        public JsonResult GetVhostHds(string deviceId, string vhostDomain)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostHdsApis.GetVhostHds(srsManager, vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Hds
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHds/SetVhostHds")]
        public JsonResult SetVhostHds(string deviceId, string vhostDomain, Hds dds, bool createIfNotFound = false)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostHdsApis.SetVhostHds(srsManager, vhostDomain, dds, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Hds
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHds/CreateVhostHds")]
        public JsonResult CreateVhostHds(string deviceId, string vhostDomain, Hds dds)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostHdsApis.CreateVhostHds(srsManager, vhostDomain, dds, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

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
    public class VhostHttpStaticController
    {
        /// <summary>
        /// 删除HttpStatic配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHttpStatic/DeleteVhostHttpStatic")]
        public JsonResult DeleteVhostHttpStatic(string deviceId, string vhostDomain)
        {
            var rt = VhostHttpStaticApis.DeleteVhostHttpStatic(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的HttpStatic
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostHttpStatic/GetVhostHttpStatic")]
        public JsonResult GetVhostHttpStatic(string deviceId, string vhostDomain)
        {
            var rt = VhostHttpStaticApis.GetVhostHttpStatic(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置HttpStatic
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHttpStatic/SetVhostHttpStatic")]
        public JsonResult SetVhostHttpStatic(string deviceId, string vhostDomain, HttpStatic httpStatic, bool createIfNotFound = false)
        {
            var rt = VhostHttpStaticApis.SetVhostHttpStatic(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, httpStatic, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建HttpStatic
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHttpStatic/CreateVhostHttpStatic")]
        public JsonResult CreateVhostHttpStatic(string deviceId, string vhostDomain, HttpStatic httpStatic)
        {
            var rt = VhostHttpStaticApis.CreateVhostHttpStatic(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, httpStatic, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

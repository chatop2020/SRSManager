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
    public class VhostHttpRemux
    {
        /// <summary>
        /// 删除HttpRemux配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHttpRemux/DeleteVhostHttpRemux")]
        public JsonResult DeleteVhostHttpRemux(string deviceId, string vhostDomain)
        {
            var rt = VhostHttpRemuxApis.DeleteVhostHttpRemux(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的HttpRemux
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostHttpRemux/GetVhostHttpRemux")]
        public JsonResult GetVhostHttpRemux(string deviceId, string vhostDomain)
        {
            var rt = VhostHttpRemuxApis.GetVhostHttpRemux(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置HttpRemux
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHttpRemux/SetVhostHttpRemux")]
        public JsonResult SetVhostHttpRemux(string deviceId, string vhostDomain, HttpRemux httpRemux, bool createIfNotFound = false)
        {
            var rt = VhostHttpRemuxApis.SetVhostHttpRemux(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, httpRemux, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建HttpRemux
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostHttpRemux/CreateVhostHttpRemux")]
        public JsonResult CreateVhostHttpRemux(string deviceId, string vhostDomain, HttpRemux httpRemux)
        {
            var rt = VhostHttpRemuxApis.CreateVhostHttpRemux(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, httpRemux, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

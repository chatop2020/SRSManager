using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class VhostController
    {
        /// <summary>
        /// 获取Vhost列表的Instance名称列表
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/Vhost/GetVhostsInstanceName")]
        public JsonResult GetVhostsInstanceName(string deviceId)
        {
            var rt = VhostApis.GetVhostsInstanceName(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 通过domain获取vhost
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/Vhost/GetVhostByDomain")]
        public JsonResult GetVhostByDomain(string deviceId, string vhostDomain)
        {
            var rt = VhostApis.GetVhostByDomain(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost列表
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/Vhost/GetVhostList")]
        public JsonResult GetVhostList(string deviceId)
        {
            var rt = VhostApis.GetVhostList(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost的各类模板
        /// </summary>
        /// <param name="vtype"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/Vhost/GetVhostTemplate")]
        public JsonResult GetVhostTemplate(VhostIngestInputType vtype)
        {
            var rt = VhostApis.GetVhostTemplate(vtype, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建一个vhost
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhost"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/Vhost/CreateVhost")]
        public JsonResult CreateVhost(string deviceId, SrsvHostConfClass vhost)
        {
            var rt = VhostApis.CreateVhost(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhost, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置一个Vhost的参数
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhost"></param>
        /// <param name="createIfNotFound"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/Vhost/SetVhost")]
        public JsonResult SetVhost(string deviceId, SrsvHostConfClass vhost, bool createIfNotFound = false)
        {
            var rt = VhostApis.SetVhost(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhost, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 删除一个vhost,用域名
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/Vhost/DeleteVhostByDomain")]
        public JsonResult DeleteVhostByDomain(string deviceId, string domain)
        {
            var rt = VhostApis.DeleteVhostByDomain(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), domain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改vhost的域名
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="domain"></param>
        /// <param name="newdomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/Vhost/ChangeVhostDomain")]
        public JsonResult ChangeVhostDomain(string deviceId, string domain, string newdomain)
        {
            var rt = VhostApis.ChangeVhostDomain(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), domain, newdomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

using System.Net;
using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager;
using SrsApis.SrsManager.Apis;
using SrsApis.SrsManager.Apis.ApiModules;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// vhost控制类
    /// </summary>
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
        [Log]
        [Route("/Vhost/GetVhostsInstanceName")]
        public JsonResult GetVhostsInstanceName(string deviceId)
        {
            var rt = VhostApis.GetVhostsInstanceName(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 通过domain获取vhost
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/Vhost/GetVhostByDomain")]
        public JsonResult GetVhostByDomain(string deviceId, string vhostDomain)
        {
            var rt = VhostApis.GetVhostByDomain(deviceId, vhostDomain,  out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost列表
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/Vhost/GetVhostList")]
        public JsonResult GetVhostList(string deviceId)
        {
            var rt = VhostApis.GetVhostList(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost的各类模板 [0:Stream] [1:File] [2:Device]
        /// </summary>
        /// <param name="vtype"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/Vhost/GetVhostTemplate")]
        public JsonResult GetVhostTemplate(VhostIngestInputType vtype)
        {
            var rt = VhostApis.GetVhostTemplate(vtype, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

     

        /// <summary>
        /// 设置或创建Vhost的参数
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhost"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Vhost/SetVhost")]
        public JsonResult SetVhost(string deviceId, SrsvHostConfClass vhost)
        {
            var rt = VhostApis.SetVhost(deviceId, vhost, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 删除一个vhost,用域名
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Vhost/DeleteVhostByDomain")]
        public JsonResult DeleteVhostByDomain(string deviceId, string domain)
        {
            var rt = VhostApis.DeleteVhostByDomain(deviceId, domain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
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
        [Log]
        [Route("/Vhost/ChangeVhostDomain")]
        public JsonResult ChangeVhostDomain(string deviceId, string domain, string newdomain)
        {
            var rt = VhostApis.ChangeVhostDomain(deviceId, domain, newdomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
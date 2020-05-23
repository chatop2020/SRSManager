using System.Net;
using Microsoft.AspNetCore.Mvc;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSConfFile.SRSConfClass;
using SRSManageCommon;
using SRSWebApi.Attributes;

namespace SRSWebApi.Controllers
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
        [Route("/Vhost/TestGet")]
        public JsonResult TestGet(string deviceId)
        {
            Bandcheck rt = deviceId == "1" ? new Bandcheck() {Enabled = true, Key = "123"} : new Bandcheck();
            ResponseStruct rs = deviceId == "1"
                ? new ResponseStruct() {Code = ErrorNumber.None, Message = "test succeed"}
                : new ResponseStruct() {Code = ErrorNumber.Other, Message = "test error"};
            var a = Program.CommonFunctions.DelApisResult(rt, rs);
            return a;
        }

        /// <summary>
        /// 测试post方法
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpPost]
        [Log]
        [Route("/Vhost/TestPost")]
        public JsonResult TestPost(string deviceId)
        {
            bool rt = deviceId == "1";
            ResponseStruct rs = rt
                ? new ResponseStruct() {Code = ErrorNumber.None, Message = "test succeed"}
                : new ResponseStruct() {Code = ErrorNumber.Other, Message = "test error"};
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

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
            var rt = VhostApis.GetVhostsInstanceName(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId),
                out ResponseStruct rs);
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
            var rt = VhostApis.GetVhostByDomain(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain,
                out ResponseStruct rs);
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
            var rt = VhostApis.GetVhostList(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId),
                out ResponseStruct rs);
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
        /// 创建一个vhost
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vtype"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Vhost/CreateVhost")]
        public JsonResult CreateVhost(string deviceId, VhostIngestInputType vtype)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null)
                return new JsonResult("无法找到deviceId对应的SrsManager实例") {StatusCode = (int) HttpStatusCode.NotFound};
            //获取一个SrsvHostConfClass模板
            SrsvHostConfClass vhost = VhostApis.GetVhostTemplate(vtype, out ResponseStruct tmpRs);
            if (tmpRs.Code != (int) ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(vhost, tmpRs);
            }

            var rt = VhostApis.CreateVhost(srsManager, vhost, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
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
        [Log]
        [Route("/Vhost/SetVhost")]
        public JsonResult SetVhost(string deviceId, SrsvHostConfClass vhost, bool createIfNotFound = false)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null)
                return new JsonResult("无法找到deviceId对应的SrsManager实例") {StatusCode = (int) HttpStatusCode.NotFound};
            var rt = VhostApis.SetVhost(srsManager, vhost, out ResponseStruct rs, createIfNotFound);
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
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null)
                return new JsonResult("无法找到deviceId对应的SrsManager实例") {StatusCode = (int) HttpStatusCode.NotFound};
            var rt = VhostApis.DeleteVhostByDomain(srsManager, domain, out ResponseStruct rs);
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
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null)
                return new JsonResult("无法找到deviceId对应的SrsManager实例") {StatusCode = (int) HttpStatusCode.NotFound};
            var rt = VhostApis.ChangeVhostDomain(srsManager, domain, newdomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
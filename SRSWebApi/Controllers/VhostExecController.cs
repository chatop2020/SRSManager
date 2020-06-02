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
    /// vhostexec接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostExecController
    {
        /// <summary>
        /// 删除Exec配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostExec/DeleteVhostExec")]
        public JsonResult DeleteVhostExec(string deviceId, string vhostDomain)
        {
            var rt = VhostExecApis.DeleteVhostExec(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Exec
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostExec/GetVhostExec")]
        public JsonResult GetVhostExec(string deviceId, string vhostDomain)
        {
            var rt = VhostExecApis.GetVhostExec(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Exec
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="exec"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostExec/SetVhostExec")]
        public JsonResult SetVhostExec(string deviceId, string vhostDomain, Exec exec)
        {
            var rt = VhostExecApis.SetVhostExec(deviceId, vhostDomain, exec, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
    }
}
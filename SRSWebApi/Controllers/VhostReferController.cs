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
    /// vhostrefer接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostReferController
    {
        /// <summary>
        /// 删除Refer配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostRefer/DeleteVhostRefer")]
        public JsonResult DeleteVhostRefer(string deviceId, string vhostDomain)
        {
            var rt = VhostReferApis.DeleteVhostRefer(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Refer
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostRefer/GetVhostRefer")]
        public JsonResult GetVhostRefer(string deviceId, string vhostDomain)
        {
            var rt = VhostReferApis.GetVhostRefer(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Refer
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="refer"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostRefer/SetVhostRefer")]
        public JsonResult SetVhostRefer(string deviceId, string vhostDomain, Refer refer)
        {
            var rt = VhostReferApis.SetVhostRefer(deviceId, vhostDomain, refer, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

       
    }
}
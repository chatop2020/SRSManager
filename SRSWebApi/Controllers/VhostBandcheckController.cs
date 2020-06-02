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
    /// vhostbandcheck接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostBandcheckController
    {
        /// <summary>
        /// 删除Bandcheck配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostBandcheck/DeleteVhostBandcheck")]
        public JsonResult DeleteVhostBandcheck(string deviceId, string vhostDomain)
        {
            var rt = VhostBandcheckApis.DeleteVhostBandcheck(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Bandcheck
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostBandcheck/GetVhostBandcheck")]
        public JsonResult GetVhostBandcheck(string deviceId, string vhostDomain)
        {
            var rt = VhostBandcheckApis.GetVhostBandcheck(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Bandcheck
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="bandcheck"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostBandcheck/SetVhostBandcheck")]
        public JsonResult SetVhostBandcheck(string deviceId, string vhostDomain, Bandcheck bandcheck)
        {
            var rt = VhostBandcheckApis.SetVhostBandcheck(deviceId, vhostDomain, bandcheck, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

       
    }
}
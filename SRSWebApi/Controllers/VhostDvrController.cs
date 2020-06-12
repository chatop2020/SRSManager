using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager.Apis;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SRSManageCommon.ManageStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// vhost dvr接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostDvrController
    {
        /// <summary>
        /// 删除Dvr配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostDvr/DeleteVhostDvr")]
        public JsonResult DeleteVhostDvr(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId, vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = VhostDvrApis.DeleteVhostDvr(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Dvr
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostDvr/GetVhostDvr")]
        public JsonResult GetVhostDvr(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId, vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = VhostDvrApis.GetVhostDvr(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Dvr
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="dvr"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostDvr/SetVhostDvr")]
        public JsonResult SetVhostDvr(string deviceId, string vhostDomain, Dvr dvr)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {deviceId, vhostDomain, dvr});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = VhostDvrApis.SetVhostDvr(deviceId, vhostDomain, dvr, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
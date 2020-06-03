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
    /// vhosthls接口类
    /// </summary>
    
    [Route("")]
    public class VhostHlsController
    {
        /// <summary>
        /// 删除Hls配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostHls/DeleteVhostHls")]
        public JsonResult DeleteVhostHls(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = VhostHlsApis.DeleteVhostHls(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Hls
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostHls/GetVhostHls")]
        public JsonResult GetVhostHls(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = VhostHlsApis.GetVhostHls(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Hls
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="hls"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostHls/SetVhostHls")]
        public JsonResult SetVhostHls(string deviceId, string vhostDomain, Hls hls)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhostDomain,hls});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = VhostHlsApis.SetVhostHls(deviceId, vhostDomain, hls, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
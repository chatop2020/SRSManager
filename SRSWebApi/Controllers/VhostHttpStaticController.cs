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
    /// vhosthttpstatic接口类
    /// </summary>
    
    [Route("")]
    public class VhostHttpStaticController
    {
        /// <summary>
        /// 删除HttpStatic配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostHttpStatic/DeleteVhostHttpStatic")]
        public JsonResult DeleteVhostHttpStatic(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = VhostHttpStaticApis.DeleteVhostHttpStatic(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的HttpStatic
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostHttpStatic/GetVhostHttpStatic")]
        public JsonResult GetVhostHttpStatic(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = VhostHttpStaticApis.GetVhostHttpStatic(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建HttpStatic
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="httpStatic"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostHttpStatic/SetVhostHttpStatic")]
        public JsonResult SetVhostHttpStatic(string deviceId, string vhostDomain, HttpStatic httpStatic)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhostDomain,httpStatic});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = VhostHttpStaticApis.SetVhostHttpStatic(deviceId, vhostDomain, httpStatic, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
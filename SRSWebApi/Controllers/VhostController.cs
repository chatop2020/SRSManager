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
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
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
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = VhostApis.GetVhostByDomain(deviceId, vhostDomain, out ResponseStruct rs);
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
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
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
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{vtype});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
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
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhost});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = VhostApis.SetVhost(deviceId, vhost, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 删除一个vhost,用域名
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/Vhost/DeleteVhostByDomain")]
        public JsonResult DeleteVhostByDomain(string deviceId, string vhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = VhostApis.DeleteVhostByDomain(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改vhost的域名
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="newVhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/Vhost/ChangeVhostDomain")]
        public JsonResult ChangeVhostDomain(string deviceId, string vhostDomain, string newVhostDomain)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{deviceId,vhostDomain,newVhostDomain});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = VhostApis.ChangeVhostDomain(deviceId, vhostDomain, newVhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
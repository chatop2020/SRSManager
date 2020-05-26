using System.Net;
using Microsoft.AspNetCore.Mvc;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSConfFile.SRSConfClass;
using SRSManageCommon;
using SRSWebApi.Attributes;

namespace SRSWebApi.Controllers
{
    /// <summary>
    /// vhostcluster接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostClusterController
    {
        /// <summary>
        /// 删除Cluster配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostCluster/DeleteVhostCluster")]
        public JsonResult DeleteVhostCluster(string deviceId, string vhostDomain)
        {
            var rt = VhostClusterApis.DeleteVhostCluster(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Cluster
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostCluster/GetVhostCluster")]
        public JsonResult GetVhostCluster(string deviceId, string vhostDomain)
        {
            var rt = VhostClusterApis.GetVhostCluster(deviceId, vhostDomain, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Cluster
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="cluster"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostCluster/SetVhostCluster")]
        public JsonResult SetVhostCluster(string deviceId, string vhostDomain, Cluster cluster)
        {
            var rt = VhostClusterApis.SetVhostCluster(deviceId, vhostDomain, cluster, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
    }
}
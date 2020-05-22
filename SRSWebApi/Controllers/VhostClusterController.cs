using Microsoft.AspNetCore.Mvc;
using SRSApis;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSConfFile.SRSConfClass;
using SRSWebApi.Attributes;
using System.Net;

namespace SRSWebApi.Controllers
{
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
        [Route("/VhostCluster/DeleteVhostCluster")]
        public JsonResult DeleteVhostCluster(string deviceId, string vhostDomain)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound };
            var rt = VhostClusterApis.DeleteVhostCluster(srsManager, vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取Vhost中的Cluster
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostCluster/GetVhostCluster")]
        public JsonResult GetVhostCluster(string deviceId, string vhostDomain)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound }; var rt = VhostClusterApis.GetVhostCluster(srsManager, vhostDomain, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Cluster
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostCluster/SetVhostCluster")]
        public JsonResult SetVhostCluster(string deviceId, string vhostDomain, Cluster cluster, bool createIfNotFound = false)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound }; var rt = VhostClusterApis.SetVhostCluster(srsManager, vhostDomain, cluster, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Cluster
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostCluster/CreateVhostCluster")]
        public JsonResult CreateVhostCluster(string deviceId, string vhostDomain, Cluster cluster)
        {
            //获取一个SRSManager实例
            SrsManager srsManager = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srsManager == null) return new JsonResult("无法找到deviceId对应的SrsManager实例") { StatusCode = (int)HttpStatusCode.NotFound }; var rt = VhostClusterApis.CreateVhostCluster(srsManager, vhostDomain, cluster, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

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
    public class VhostIngestController
    {
        /// <summary>
        /// 通过VhostDomain和IngestInstanceName删除一个Ingest
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostIngest/DeleteVhostIngestByIngestInstanceName")]
        public JsonResult DeleteVhostIngestByIngestInstanceName(string deviceId, string vhostDomain, string ingestInstanceName)
        {
            var rt = VhostIngestApis.DeleteVhostIngestByIngestInstanceName(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, ingestInstanceName, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取所有或者指定vhost中的ingest实例名称
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostIngest/GetVhostIngestNameList")]
        public JsonResult GetVhostIngestNameList(string deviceId, string vhostDomain = "")
        {
            var rt = VhostIngestApis.GetVhostIngestNameList(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), out ResponseStruct rs, vhostDomain);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取一个Ingest配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="ingestInstanceName"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Route("/VhostIngest/GetVhostIngest")]
        public JsonResult GetVhostIngest(string deviceId, string vhostDomain, string ingestInstanceName)
        {
            var rt = VhostIngestApis.GetVhostIngest(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, ingestInstanceName, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置Ingest
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostIngest/SetVhostIngest")]
        public JsonResult SetVhostIngest(string deviceId, string vhostDomain, string ingestInstanceName, Ingest ingest, bool createIfNotFound = false)
        {
            var rt = VhostIngestApis.SetVhostIngest(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, ingestInstanceName, ingest, out ResponseStruct rs, createIfNotFound);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 创建Ingest
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/VhostIngest/CreateVhostIngest")]
        public JsonResult CreateVhostIngest(string deviceId, string vhostDomain, Ingest ingest)
        {
            var rt = VhostIngestApis.CreateVhostIngest(SystemApis.GetSrsManagerInstanceByDeviceId(deviceId), vhostDomain, ingest, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
    }
}

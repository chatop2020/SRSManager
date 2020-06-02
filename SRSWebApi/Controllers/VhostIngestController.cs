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
    /// vhostingest接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class VhostIngestController
    {
        /// <summary>
        /// 通过VhostDomain和IngestInstanceName删除一个Ingest
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="ingestInstanceName"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostIngest/DeleteVhostIngestByIngestInstanceName")]
        public JsonResult DeleteVhostIngestByIngestInstanceName(string deviceId, string vhostDomain,
            string ingestInstanceName)
        {
            var rt = VhostIngestApis.DeleteVhostIngestByIngestInstanceName(deviceId, vhostDomain, ingestInstanceName,
                out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取所有或者指定vhost中的ingest实例名称
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/VhostIngest/GetVhostIngestNameList")]
        public JsonResult GetVhostIngestNameList(string deviceId, string vhostDomain = "")
        {
            var rt = VhostIngestApis.GetVhostIngestNameList(deviceId, out ResponseStruct rs, vhostDomain);
            return Program.CommonFunctions.DelApisResult(rt, rs);
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
        [Log]
        [Route("/VhostIngest/GetVhostIngest")]
        public JsonResult GetVhostIngest(string deviceId, string vhostDomain, string ingestInstanceName)
        {
            var rt = VhostIngestApis.GetVhostIngest(deviceId, vhostDomain, ingestInstanceName, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 设置或创建Ingest
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="ingest"></param>
        /// <param name="ingestInstanceName"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/VhostIngest/SetVhostIngest")]
        public JsonResult SetVhostIngest(string deviceId, string vhostDomain, string ingestInstanceName, Ingest ingest)
        {
            var rt = VhostIngestApis.SetVhostIngest(deviceId, vhostDomain, ingestInstanceName, ingest, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

       
    }
}
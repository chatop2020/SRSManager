using System.Collections.Generic;
using System.Net;
using SRSManageCommon;
using Microsoft.AspNetCore.Mvc;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSWebApi.Attributes;
using SRSWebApi.ResponseModules;

namespace SRSWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class SystemController : ControllerBase
    {
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/System/LoadOnvifConfig")]
        public JsonResult LoadOnvifConfig()
        {
            var rt = SystemApis.LoadOnvifConfig(out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/System/WriteOnvifConfig")]
        public JsonResult WriteOnvifConfig()
        {
            var rt = SystemApis.WriteOnvifConfig(out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }


        /// <summary>
        /// 删除一个onvif摄像头配置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/System/DelOnvifConfigByIpAddress")]
        public JsonResult DelOnvifConfigByIpAddress(string ipAddress)
        {
            var rt = SystemApis.DelOnvifConfigByIpAddress(ipAddress, out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取系统信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/System/GetSystemInfo")]
        public JsonResult GetSystemInfo()
        {
            var result = new JsonResult(SystemApis.GetSystemInfo());
            result.StatusCode = (int) HttpStatusCode.OK;
            return result;
        }

        /// <summary>
        /// 获取SRS实例列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/System/GetSrsInstanceList")]
        public JsonResult GetSrsInstanceList()
        {
            List<string> devs = SystemApis.GetAllSrsManagerDeviceId();
            List<SrsInstanceModule> simlist = new List<SrsInstanceModule>();
            foreach (var dev in devs)
            {
                SrsManager srs = SystemApis.GetSrsManagerInstanceByDeviceId(dev);
                if (srs != null)
                {
                    SrsInstanceModule sim = new SrsInstanceModule()
                    {
                        ConfigPath = srs.srs_ConfigPath,
                        DeviceId = srs.srs_deviceId,
                        IsInit = srs.Is_Init,
                        IsRunning = srs.IsRunning,
                        PidValue = srs.SrsPidValue,
                        SrsInstanceWorkPath = srs.SrsWorkPath,
                        SrsProcessWorkPath = srs.SrsWorkPath + "srs",
                    };
                    simlist.Add(sim);
                }
            }

            var result = new JsonResult(simlist);
            result.StatusCode = (int) HttpStatusCode.OK;
            return result;
        }
    }
}
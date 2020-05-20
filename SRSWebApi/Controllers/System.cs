using System.Collections.Generic;
using System.Net;
using Common;
using Microsoft.AspNetCore.Mvc;
using SRSApis;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSWebApi.Attributes;
using SRSWebApi.ResponseModules;

namespace SRSWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class System: ControllerBase
    {
        /// <summary>
        /// 重写onvif配置文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/System/ReWriteOnvifConfig")]
        public JsonResult ReWriteOnvifConfig()
        {
            ResponseStruct rs;
            var rt=SystemApis.ReWriteOnvifConfig();
            if (rt)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.Other,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.Other],
                };
            }
            return Program.common.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 重新加载onvif配置文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/System/ReloadOnvifConfig")]
        public JsonResult ReloadOnvifConfig()
        {
            ResponseStruct rs;
            var rt=SystemApis.ReloadOnvifConfig();
            if (rt)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.Other,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.Other],
                };
            }
            return Program.common.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 获取onvif摄像头实例名称列表(ip地址)
        /// </summary>
        /// <returns></returns>
        [HttpPost] 
        [AuthVerify]
        [Route("/System/GetOnvifMonitorList")]
        public JsonResult GetOnvifMonitorList()
        {
            var rt=OnvifMonitorApis.GetOnvifMonitorsIpAddress( out ResponseStruct rs);
            return Program.common.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 获取系统信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/System/GetSystemInfo")]
        public JsonResult GetSystemInfo()
        {
            var result= new JsonResult(SystemApis.GetSystemInfo());
            result.StatusCode = (int)HttpStatusCode.OK;
            return result;
        }
        /// <summary>
        /// 获取SRS实例列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Route("/System/GetSrsInstanceList")]
        public JsonResult GetSrsInstanceList()
        {
            List<string> devs = SystemApis.GetAllSrsManagerDeviceId();
            List<SrsInstanceModule> simlist= new List<SrsInstanceModule>();
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
            var result= new JsonResult(simlist);
            result.StatusCode = (int)HttpStatusCode.OK;
            return result;
        }
    }
    
}
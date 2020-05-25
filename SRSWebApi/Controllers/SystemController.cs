using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSManageCommon;
using SRSWebApi.Attributes;
using SRSWebApi.ResponseModules;

namespace SRSWebApi.Controllers
{
    /// <summary>
    /// 系统信息接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class SystemController : ControllerBase
    {
        /// <summary>
        /// 创建一个SrsInstance
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/System/CreateNewSrsInstance")]
        public JsonResult CreateNewSrsInstance(SrsManager sm)
        {
            var rt = SystemApis.CreateNewSrsInstance(sm ,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs); 
        }
        
        
        /// <summary>
        /// 获取SRS实例模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/System/GetSrsInstanceTemplate")]
        public JsonResult GetSrsInstanceTemplate()
        {
            var rt = SystemApis.GetSrsInstanceTemplate( out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs); 
        }

        
        /// <summary>
        /// 删除一个SRS实例
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/System/DelSrsByDevId")]
        public JsonResult DelSrsInstanceByDeviceId(string deviceId)
        {
            var rt = SystemApis.DelSrsInstanceByDeviceId( deviceId,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs); 
        }
        
        
        /// <summary>
        /// 加载onvif配置文件接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/System/LoadOnvifConfig")]
        public JsonResult LoadOnvifConfig()
        {
            var rt = SystemApis.LoadOnvifConfig(out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 写入onvif配置文件接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/System/WriteOnvifConfig")]
        public JsonResult WriteOnvifConfig()
        {
            var rt = SystemApis.WriteOnvifConfig(out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
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
            return Program.CommonFunctions.DelApisResult(rt, rs);
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
                        ConfigPath = srs.SrsConfigPath,
                        DeviceId = srs.SrsDeviceId,
                        IsInit = srs.IsInit,
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
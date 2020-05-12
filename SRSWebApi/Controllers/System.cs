using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSWebApi.Attributes;
using SRSWebApi.ResponseModules;

namespace SRSWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class System
    {
        [HttpPost]
        [AuthVerify]
        [Route("/System/GetSystemInfo")]
        public JsonResult GetSystemInfo()
        {
            var result= new JsonResult(SystemApis.GetSystemInfo());
            result.StatusCode = (int)HttpStatusCode.OK;
            return result;
        }
        
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
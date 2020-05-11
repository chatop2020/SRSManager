using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRSApis.SRSManager.Apis;
using SRSWebApi.Attributes;
using SRSWebApi.ResponseModules;

namespace SRSWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class System
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public System(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [AuthVerify]
        [Route("/System/GetSystemInfo")]
        public JsonResult GetSystemInfo()
        {
            var result= new JsonResult(SystemApis.GetSystemInfo());
            result.StatusCode = (int)HttpStatusCode.OK;
            return result;
        }
    }
}
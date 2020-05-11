using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SRSWebApi.ResponseModules
{
    [Serializable]
    public class BaseResponseModule
    {
        private HttpStatusCode code;
        private JsonResult msg;

        public HttpStatusCode Code
        {
            get => code;
            set => code = value;
        }

        public JsonResult Msg
        {
            get => msg;
            set => msg = value;
        }
    }
}
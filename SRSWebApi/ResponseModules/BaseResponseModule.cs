using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SRSWebApi.ResponseModules
{
    /// <summary>
    ///webapi返回结构
    /// </summary>
    [Serializable]
    public class BaseResponseModule
    {
        private HttpStatusCode _code;
        private JsonResult _msg = null!;

        /// <summary>
        /// 返回http status code
        /// </summary>
        public HttpStatusCode Code
        {
            get => _code;
            set => _code = value;
        }

        /// <summary>
        /// 返回的message
        /// </summary>
        public JsonResult Msg
        {
            get => _msg;
            set => _msg = value;
        }
    }
}
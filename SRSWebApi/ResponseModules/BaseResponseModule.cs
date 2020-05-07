using System;
using System.Net;

namespace SRSWebApi.ResponseModules
{
    [Serializable]
    public class BaseResponseModule
    {
        private HttpStatusCode code;
        private string msg;

        public HttpStatusCode Code
        {
            get => code;
            set => code = value;
        }

        public string Msg
        {
            get => msg;
            set => msg = value;
        }
    }
}
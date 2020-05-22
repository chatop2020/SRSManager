using System;

namespace SRSWebApi.RequestModules
{
    [Serializable]
    public class ReqGetAllows
    {
        private string password;

        public string Password
        {
            get => password;
            set => password = value;
        }
    }
}
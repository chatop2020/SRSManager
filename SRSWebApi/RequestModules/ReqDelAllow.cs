using System;

namespace SRSWebApi.RequestModules
{
    [Serializable]
    public class ReqDelAllow
    {
        private string key; //app key值
        private string password;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get => password;
            set => password = value;
        }
/// <summary>
/// guid
/// </summary>
        public string Key
        {
            get => key;
            set => key = value;
        }
    }
}
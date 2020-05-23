using System;

namespace SRSWebApi.RequestModules
{
    /// <summary>
    /// 删除一个授权访问的请求结构 
    /// </summary>
    [Serializable]
    public class ReqDelAllow
    {
        private string _key = null!; //app key值
        private string _password = null!;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        /// <summary>
        /// uuid
        /// </summary>
        public string Key
        {
            get => _key;
            set => _key = value;
        }
    }
}
namespace SRSWebApi.RequestModules
{
    /// <summary>
    /// 设置或添加Allow的请求结构
    /// </summary>
    public class ReqSetOrAddAllow
    {
        private string _password = null!;
        private AllowKey _allowkey = null!;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        /// <summary>
        /// 授权反问key
        /// </summary>
        public AllowKey Allowkey
        {
            get => _allowkey;
            set => _allowkey = value;
        }
    }
}
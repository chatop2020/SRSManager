namespace SRSWebApi.RequestModules
{
    /// <summary>
    /// 获取Session的请求结构 
    /// </summary>
    public class ReqGetSession
    {
        private string _allowKey = null!;

        /// <summary>
        /// allowkey
        /// </summary>
        public string AllowKey
        {
            get => _allowKey;
            set => _allowKey = value;
        }
    }
}
using System;

namespace SRSWebApi.RequestModules
{
    
    /// <summary>
    ///SRS onconnect时的结构 
    /// </summary>
    [Serializable]
    public class ReqSrsClientOnConnect
    {

        private string? _action;
        private ushort? _clientId;
        private string? _ip;
        private string? _vhost;
        private string? _app;
        private string? _tcUrl;
        private string? _pageUrl;

        /// <summary>
        /// 动作，on_connect|on_close
        /// </summary>
        public string? Action
        {
            get => _action;
            set => _action = value;
        }

        /// <summary>
        /// 客户端的ID
        /// </summary>
        public ushort? Client_Id
        {
            get => _clientId;
            set => _clientId = value;
        }

        /// <summary>
        /// 客户端ip地址
        /// </summary>
        public string? Ip
        {
            get => _ip;
            set => _ip = value;
        }

        /// <summary>
        /// Vhost
        /// </summary>
        public string? Vhost
        {
            get => _vhost;
            set => _vhost = value;
        }
        /// <summary>
        /// app
        /// </summary>

        public string? App
        {
            get => _app;
            set => _app = value;
        }

        /// <summary>
        /// rtmp地址
        /// </summary>
        public string? TcUrl
        {
            get => _tcUrl;
            set => _tcUrl = value;
        }

        /// <summary>
        /// http地址
        /// </summary>
        public string? PageUrl
        {
            get => _pageUrl;
            set => _pageUrl = value;
        }
    }
}
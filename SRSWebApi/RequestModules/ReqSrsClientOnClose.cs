using System;

namespace SRSWebApi.RequestModules
{
    
    /// <summary>
    ///SRS onClose时的结构 
    /// </summary>
    [Serializable]
    public class ReqSrsClientOnClose
    {
        private string? _action;
        private string? _device_id;
        private ushort? _clientId;
        private string? _ip;
        private string? _vhost;
        private string? _app;

        /// <summary>
        /// 动作
        /// </summary>
        public string? Action
        {
            get => _action;
            set => _action = value;
        }

        public string? Device_Id
        {
            get => _device_id;
            set => _device_id = value;
        }

        /// <summary>
        /// 客户端id
        /// </summary>
        public ushort? Client_Id
        {
            get => _clientId;
            set => _clientId = value;
        }

        /// <summary>
        /// 客户端ip
        /// </summary>
        public string? Ip
        {
            get => _ip;
            set => _ip = value;
        }

        /// <summary>
        /// vhost
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
    }
}
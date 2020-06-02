using System;

namespace SrsWebApi.RequestModules
{
    /// <summary>
    ///SRS onpublish时的结构 
    /// </summary>
    [Serializable]
    public class ReqSrsClientOnOrUnPublish
    {
        private string? _action;
        private string? _device_id;
        private ushort? _clientId;
        private string? _ip;
        private string? _vhost;
        private string? _app;
        private string? _tcUrl;
        private string? _stream;
        private string? _param;

        /// <summary>
        /// 动作，on_connect|on_close
        /// </summary>
        public string? Action
        {
            get => _action;
            set => _action = value;
        }

        /// <summary>
        /// srs实例id
        /// </summary>
        public string? Device_Id
        {
            get => _device_id;
            set => _device_id = value;
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
        /// 流地址
        /// </summary>
        public string? Stream
        {
            get => _stream;
            set => _stream = value;
        }

        /// <summary>
        /// 参数
        /// </summary>
        public string? Param
        {
            get => _param;
            set => _param = value;
        }
    }
}
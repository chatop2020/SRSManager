using System;

#nullable enable
namespace SRSManageCommon.ManageStructs
{
    [Serializable]
    public class GlobalModule
    {
        private bool? _heartbeatEnable; //heartbeat is enable?
        private bool? _heartbeatSummariesEnable; //heartbeat post with summaries?
        private string? _heartbeatUrl; //heartbeat post url
        private bool? _httpApiEnable; //http api is enabled?
        private ushort? _httpApiListen; //httpapi listen;
        private bool? _httpServerEnable; //http server is enabled?
        private ushort? _httpServerListen; //http server listen port
        private string? _httpServerPath; //http server webroot path
        private ushort? _listen; //rtmp listen
        private ushort? _maxConnections; //maxConnections

        public bool? HeartbeatEnable
        {
            get => _heartbeatEnable;
            set => _heartbeatEnable = value;
        }

        public bool? HeartbeatSummariesEnable
        {
            get => _heartbeatSummariesEnable;
            set => _heartbeatSummariesEnable = value;
        }

        public string? HeartbeatUrl
        {
            get => _heartbeatUrl;
            set => _heartbeatUrl = value;
        }

        public bool? HttpApiEnable
        {
            get => _httpApiEnable;
            set => _httpApiEnable = value;
        }

        public ushort? HttpApiListen
        {
            get => _httpApiListen;
            set => _httpApiListen = value;
        }

        public bool? HttpServerEnable
        {
            get => _httpServerEnable;
            set => _httpServerEnable = value;
        }

        public ushort? HttpServerListen
        {
            get => _httpServerListen;
            set => _httpServerListen = value;
        }

        public string? HttpServerPath
        {
            get => _httpServerPath;
            set => _httpServerPath = value;
        }

        public ushort? Listen
        {
            get => _listen;
            set => _listen = value;
        }

        public ushort? MaxConnections
        {
            get => _maxConnections;
            set => _maxConnections = value;
        }
    }
}
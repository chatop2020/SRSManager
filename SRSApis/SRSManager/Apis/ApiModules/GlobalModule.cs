#nullable enable
namespace SRSApis.SRSManager.Apis.ApiModules
{
    public class GlobalModule
    {
        private bool? heartbeatEnable; //heartbeat is enable?
        private bool? heartbeatSummariesEnable; //heartbeat post with summaries?
        private string? heartbeatUrl; //heartbeat post url
        private bool? httpApiEnable; //http api is enabled?
        private ushort? httpApiListen; //httpapi listen;
        private bool? httpServerEnable; //http server is enabled?
        private ushort? httpServerListen; //http server listen port
        private string? httpServerPath; //http server webroot path
        private ushort? listen; //rtmp listen
        private ushort? maxConnections; //maxConnections

        public ushort? Listen
        {
            get => listen;
            set => listen = value;
        }

        public ushort? HttpApiListen
        {
            get => httpApiListen;
            set => httpApiListen = value;
        }

        public ushort? MaxConnections
        {
            get => maxConnections;
            set => maxConnections = value;
        }

        public bool? HttpApiEnable
        {
            get => httpApiEnable;
            set => httpApiEnable = value;
        }

        public bool? HttpServerEnable
        {
            get => httpServerEnable;
            set => httpServerEnable = value;
        }

        public string? HttpServerPath
        {
            get => httpServerPath;
            set => httpServerPath = value;
        }

        public ushort? HttpServerListen
        {
            get => httpServerListen;
            set => httpServerListen = value;
        }

        public bool? HeartbeatEnable
        {
            get => heartbeatEnable;
            set => heartbeatEnable = value;
        }

        public string? HeartbeatUrl
        {
            get => heartbeatUrl;
            set => heartbeatUrl = value;
        }

        public bool? HeartbeatSummariesEnable
        {
            get => heartbeatSummariesEnable;
            set => heartbeatSummariesEnable = value;
        }
    }
}
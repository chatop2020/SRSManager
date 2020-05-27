using System;

namespace SRSCallBackManager.Structs
{
    [Serializable]
    public class OnlineClient
    {
        private RemoteClient _client;
        private string _rtmpUrl;
        private string _httpUrl;
        private string _vhost;
        private string _app;
        private string _stream;
        private string _param;

        public RemoteClient Client
        {
            get => _client;
            set => _client = value;
        }

        public string RtmpUrl
        {
            get => _rtmpUrl;
            set => _rtmpUrl = value;
        }

        public string HttpUrl
        {
            get => _httpUrl;
            set => _httpUrl = value;
        }

        public string Vhost
        {
            get => _vhost;
            set => _vhost = value;
        }

        public string App
        {
            get => _app;
            set => _app = value;
        }

        public string Stream
        {
            get => _stream;
            set => _stream = value;
        }

        public string Param
        {
            get => _param;
            set => _param = value;
        }
    }
}
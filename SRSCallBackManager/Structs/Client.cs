#nullable enable
using System;

namespace SRSCallBackManager.Structs
{
    [Serializable]
    public class Client
    {
        private RemoteClient? _remoteClient;
        private string? _rtmpUrl;
        private string? _httpUrl;
        private string? _vhost;
        private string? _app;
        private string? _stream;
        private string? _param;
        private bool? _isOnline;
        private bool? _isPlay=false;
        private string? _pageUrl;
        private DateTime? _updateTime;

        public RemoteClient? RemoteClient
        {
            get => _remoteClient;
            set => _remoteClient = value;
        }

        public string? RtmpUrl
        {
            get => _rtmpUrl;
            set => _rtmpUrl = value;
        }

        public string? HttpUrl
        {
            get => _httpUrl;
            set => _httpUrl = value;
        }

        public string? Vhost
        {
            get => _vhost;
            set => _vhost = value;
        }

        public string? App
        {
            get => _app;
            set => _app = value;
        }

        public string? Stream
        {
            get => _stream;
            set => _stream = value;
        }

        public string? Param
        {
            get => _param;
            set => _param = value;
        }

        public bool? IsOnline
        {
            get => _isOnline;
            set => _isOnline = value;
        }

        public DateTime? UpdateTime
        {
            get => _updateTime;
            set => _updateTime = value;
        }

        public bool? IsPlay
        {
            get => _isPlay;
            set => _isPlay = value;
        }

        public string? PageUrl
        {
            get => _pageUrl;
            set => _pageUrl = value;
        }
    }
}
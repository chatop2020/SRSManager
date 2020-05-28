using System;

#nullable enable
namespace SRSCallBackManager.Structs
{
    public class DvrMessage
    {
        private RemoteClient? _remoteClient;
        private string? _videoPath;
        private string? _vhost;
        private string? _stream;
        private string? _param;
        private string? _app;
        private string? _dir;
        private long? _duration;
        private DateTime? _startTime;
        private DateTime? _endTime;

        public RemoteClient? RemoteClient
        {
            get => _remoteClient;
            set => _remoteClient = value;
        }

        public string? VideoPath
        {
            get => _videoPath;
            set => _videoPath = value;
        }

        public string? Vhost
        {
            get => _vhost;
            set => _vhost = value;
        }

        public string? Dir
        {
            get => _dir;
            set => _dir = value;
        }

        public string? Stream
        {
            get => _stream;
            set => _stream = value;
        }

        public string? App
        {
            get => _app;
            set => _app = value;
        }

        public long? Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public DateTime? StartTime
        {
            get => _startTime;
            set => _startTime = value;
        }

        public DateTime? EndTime
        {
            get => _endTime;
            set => _endTime = value;
        }

        public string? Param
        {
            get => _param;
            set => _param = value;
        }
    }
}
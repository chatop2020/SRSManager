using System;
using FreeSql.DataAnnotations;
using SrsManageCommon;

namespace SRSManageCommon.DBMoudle
{
    [Serializable]
    public enum EventMethod
    {
        Connect,
        Close,
        Publish,
        UnPublish,
        Play,
        Stop
    }

    [Serializable]
    [Index("uk_CL_DeviceId", "Device_Id", false)]
    [Index("uk_CL_VhostDomain", "VhostDomain", false)]
    [Index("uk_CL_EventMethod", "EventMethod", false)]
    [Table(Name = "ClientLog")]
    public class ClientLog
    {
        private long _id;
        private string? _device_id;
        private string? _monitorIp;
        private ushort? _clientId;
        private string? _clientIp;
        private ClientType? _clientType;
        private MonitorType? _monitorType;
        private string? _rtmpUrl;
        private string? _httpUrl;
        private string? _rtspUrl;
        private string? _vhost;
        private string? _app;
        private string? _stream;
        private string? _param;
        private bool? _isOnline;
        private bool? _isPlay = false;
        private string? _pageUrl;
        private DateTime? _updateTime;
        private EventMethod _eventMethod;

        [Column(IsPrimary = true, IsIdentity = true)]
        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public string? Device_Id
        {
            get => _device_id;
            set => _device_id = value;
        }

        public string? MonitorIp
        {
            get => _monitorIp;
            set => _monitorIp = value;
        }

        public ushort? Client_Id
        {
            get => _clientId;
            set => _clientId = value;
        }

        public string? ClientIp
        {
            get => _clientIp;
            set => _clientIp = value;
        }

        [Column(MapType = typeof(string))]
        public ClientType? ClientType
        {
            get => _clientType;
            set => _clientType = value;
        }

        [Column(MapType = typeof(string))]
        public MonitorType? MonitorType
        {
            get => _monitorType;
            set => _monitorType = value;
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

        public string? RtspUrl
        {
            get => _rtspUrl;
            set => _rtspUrl = value;
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

        public DateTime? UpdateTime
        {
            get => _updateTime;
            set => _updateTime = value;
        }

        [Column(MapType = typeof(string))]
        public EventMethod EventMethod
        {
            get => _eventMethod;
            set => _eventMethod = value;
        }
    }
}
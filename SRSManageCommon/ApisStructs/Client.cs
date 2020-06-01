#nullable enable
using System;
using FreeSql.DataAnnotations;
using SRSManageCommon;

namespace SRSManageCommon.Structs
{
    
    [Index("uk_clientId", "ClientId", false)]
    [Index("uk_stream", "Stream", false)]
    [Index("uk_isonline", "IsOnline", false)]
    [Index("uk_updateTime", "UpdateTime", false)]
    [Index("uk_deviceId", "StartTime, EndTime", false)]
    [Serializable]
    public class Client
    {
        private long _id;
        private string? _device_id;
        private string? _monitorIp;
        private ushort? _clientId;
        private string? _clientIp;
        private ClientType _clientType;
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

        [Column(IsIdentity = true)]
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
        public ClientType ClientType
        {
            get => _clientType;
            set => _clientType = value;
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
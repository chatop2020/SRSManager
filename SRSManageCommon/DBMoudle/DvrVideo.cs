using System;
using FreeSql.DataAnnotations;
using SrsManageCommon;

#nullable enable
namespace SRSManageCommon.DBMoudle
{
    [Table(Name = "DvrVideo")]
    [Index("uk_dvr_stream", "Stream", false)]
    [Index("uk_dvr_groupTime", "StartTime, EndTime", false)]
    [Index("uk_dvr_groupFind", "Device_Id, Vhost, Stream, App", false)]
    [Index("uk_dvr_recordDate", "RecordDate", false)]
    [Serializable]
    public class DvrVideo
    {
        private long _id;
        private string? _device_id;
        private ushort? _clientId;
        private string? _clientIp;
        private ClientType? _clientType;
        private MonitorType? _monitorType;
        private string? _videoPath;
        private long? _fileSize;
        private string? _vhost;
        private string? _stream;
        private string? _param;
        private string? _app;
        private string? _dir;
        private long? _duration;
        private bool? _deleted;
        private DateTime? _startTime;
        private DateTime? _endTime;
        private DateTime? _updateTime;
        private string? _recordDate;
        private string? _url;
        private bool? _undo;

        [Column(IsPrimary = true, IsIdentity = true )]
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

        public string? VideoPath
        {
            get => _videoPath;
            set => _videoPath = value;
        }

        public long? FileSize
        {
            get => _fileSize;
            set => _fileSize = value;
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

        public bool? Deleted
        {
            get => _deleted;
            set => _deleted = value;
        }

        public DateTime? UpdateTime
        {
            get => _updateTime;
            set => _updateTime = value;
        }

        public string? RecordDate
        {
            get => _recordDate;
            set => _recordDate = value;
        }

      
        public string? Url
        {
            get => _url;
            set => _url = value;
        }

        public bool? Undo
        {
            get => _undo;
            set => _undo = value;
        }
    }
}
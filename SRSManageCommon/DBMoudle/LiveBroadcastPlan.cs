using System;
using FreeSql.DataAnnotations;

namespace SRSManageCommon.DBMoudle
{
    [Serializable]
    public enum LiveBroadcastPlanStatus
    {
        WaitForExec,
        Living,
        Finished,
    }
    [Table(Name = "LiveBroadcastPlan")]
    [Index("uk_live_stream", "Stream", false)]
    [Index("uk_live_groupTime", "StartTime, EndTime", false)]
    [Index("uk_live_groupFind", "DeviceId, Vhost, Stream, App", true)]
    [Serializable]
    public class LiveBroadcastPlan
    {
        private long _id;
        private bool? _enable;
        private string? _deviceId;
        private string? _app;
        private string? _stream;
        private string? _vhost;
        private DateTime? _startTime;
        private DateTime? _endTime;
        private LiveBroadcastPlanStatus? _planStatus;
        private DateTime? _updateTime;
        private string? _publishIpAddr;

        [Column(IsIdentity = true)]
        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public bool? Enable
        {
            get => _enable;
            set => _enable = value;
        }

        public string? DeviceId
        {
            get => _deviceId;
            set => _deviceId = value;
        }

        public string? App
        {
            get => _app;
            set => _app = value;
        }

        public string? Vhost
        {
            get => _vhost;
            set => _vhost = value;
        }

        public string? Stream
        {
            get => _stream;
            set => _stream = value;
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

        [Column(MapType = typeof(string))]
        public LiveBroadcastPlanStatus? PlanStatus
        {
            get => _planStatus;
            set => _planStatus = value;
        }

        public DateTime? UpdateTime
        {
            get => _updateTime;
            set => _updateTime = value;
        }

        public string? PublishIpAddr
        {
            get => _publishIpAddr;
            set => _publishIpAddr = value;
        }
    }
}
using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace SRSManageCommon.DBMoudle
{
    [Table(Name = "StreamDvrPlan")]
    [Index("uk_dvrPlan_DeviceId", "DeviceId", false)]
    [Index("uk_dvrPlan_VhostDomain", "VhostDomain", false)]
    [Index("uk_dvrPlan_Stream", "Stream", false)]
    [Serializable]
    /// <summary>
    /// 录制计划
    /// </summary>
    public class StreamDvrPlan
    {
        private long _id;
        private bool _enable;
        private string? _deviceId;
        private string? _vhostDomain;
        private string? _app;
        private string? _stream;
        private long? _limitSpace;
        private ushort? _limitDays;
        private OverStepPlan? _overStepPlan;
        private List<DvrDayTimeRange>? _timeRange;

      
        [Column(IsPrimary = true,IsIdentity = true)]

        [JsonIgnore]
        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public bool Enable
        {
            get => _enable;
            set => _enable = value;
        }

        public string? DeviceId
        {
            get => _deviceId;
            set => _deviceId = value;
        }
        

        public string? VhostDomain
        {
            get => _vhostDomain;
            set => _vhostDomain = value;
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

        public long? LimitSpace
        {
            get => _limitSpace;
            set => _limitSpace = value;
        }

        public ushort? LimitDays
        {
            get => _limitDays;
            set => _limitDays = value;
        }
        [Column(MapType = typeof(string))]
        public OverStepPlan? OverStepPlan
        {
            get => _overStepPlan;
            set => _overStepPlan = value;
        }

        public List<DvrDayTimeRange>? TimeRange
        {
            get => _timeRange;
            set => _timeRange = value;
        }
    }
}
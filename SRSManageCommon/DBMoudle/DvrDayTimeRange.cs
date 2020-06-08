using System;
using System.Text.Json.Serialization;
using FreeSql.DataAnnotations;

namespace SRSManageCommon.DBMoudle
{
    [Serializable]
    [Table(Name = "DvrDayTimeRange")]
    /// <summary>
    /// 用于每周的记录时间
    /// </summary>
    public class DvrDayTimeRange
    {
        private long _id;
        private long _dvrDayTimeRangeStreamDvrPlanId;
        private DayOfWeek _weekday;
        private DateTime _startTime;
        private DateTime _endTime;
        
        [Column(IsPrimary = true,IsIdentity = true)]
        
        [JsonIgnore]
        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public long DvrDayTimeRangeStreamDvrPlanId
        {
            get => _dvrDayTimeRangeStreamDvrPlanId;
            set => _dvrDayTimeRangeStreamDvrPlanId = value;
        }

        [Column(MapType = typeof(string))]
        public DayOfWeek WeekDay
        {
            get => _weekday;
            set => _weekday = value;
        }

        public DateTime StartTime
        {
            get => _startTime;
            set => _startTime = value;
        }

        public DateTime EndTime
        {
            get => _endTime;
            set => _endTime = value;
        }
    }
    

    [Serializable]
    /// <summary>
    /// 超过限制时怎么处理
    /// </summary>
    public enum OverStepPlan
    {
        StopDvr,
        DeleteFile,
    }
}
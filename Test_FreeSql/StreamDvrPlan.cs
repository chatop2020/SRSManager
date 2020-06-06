using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace SrsManageCommon.ApisStructs
{
    [Serializable]
    [Table(Name = "DvrDayTimeRange")]
    /// <summary>
    /// 用于每周的记录时间
    /// </summary>
    public class DvrDayTimeRange
    {
      
        
        [Column(IsPrimary = true,IsIdentity = true)]
        
        [JsonIgnore]
        public int Id
        {
            get;
            set;
        }

        public int StreamDvrPlanId
        {
            get;
            set;
        }

        [Column(MapType = typeof(string))]
        public DayOfWeek WeekDay
        {
            get;
            set;
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public DateTime EndTime
        {
            get;
            set;
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
      

      
        [Column(IsPrimary = true,IsIdentity = true)]

        [JsonIgnore]
        public int Id
        {
            get;
            set;
        }

        public bool Enable
        {
            get;
            set;
        }

        public string DeviceId
        {
            get;
            set;
        }
        

        public string VhostDomain
        {  get;
            set;
        }

        public string App
        {
            get;
            set;
        }

        public string Stream
        {
            get;
            set;
        }

        public long? LimitSpace
        {
            get;
            set;
        }

        public int? LimitDays
        {
            get;
            set;
        }
        [Column(MapType = typeof(string))]
        public OverStepPlan? OverStepPlan
        {
            get;
            set;
        }
        [Navigate(nameof(DvrDayTimeRange.StreamDvrPlanId))]
        public List<DvrDayTimeRange> TimeRange
        {
            get;
            set;
        }
    }
}
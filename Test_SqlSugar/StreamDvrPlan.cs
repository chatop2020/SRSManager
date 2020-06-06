using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SqlSugar;

namespace Test_SqlSugar
{
    [SugarTable("DvrDayTimeRange")]
    
    [Serializable]
    public class DvrDayTimeRange
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        
        [JsonIgnore]
        public int Id
        {
            get ;
            set;
        }

        public int StreamDvrPlanId
        {
            get ;
            set ;
        }
        [SugarColumn(ColumnDataType="string")]
        public DayOfWeek WeekDay
        {
            get;
            set ;
        }

        public DateTime StartTime
        {
            get ;
            set;
        }

        public DateTime EndTime
        {
            get;
            set ;
        }
    }
    

    [Serializable]
    public enum OverStepPlan
    {
        StopDvr,
        DeleteFile,
    }

    [Serializable]
    public class StreamDvrPlan
    {

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]

        [JsonIgnore]
        public int Id
        {
            get;
            set;
        }

        public bool Enable
        {
            get ;
            set ;
        }

        public string DeviceId
        {
            get ;
            set ;
        }
        

        public string VhostDomain
        {
            get ;
            set ;
        }

        public string App
        {
            get ;
            set ;
        }

        public string Stream
        {
            get ;
            set ;
        }

        public long? LimitSpace
        {
            get ;
            set ;
        }

        public int? LimitDays
        {
            get ;
            set;
        }
        [SugarColumn(ColumnDataType="string")]
        public OverStepPlan? OverStepPlan
        {
            get;
            set;
        }
        [SugarColumn(IsIgnore = true)]
        public List<DvrDayTimeRange> TimeRange
        {
            get ;
            set ;
        }
    }
}
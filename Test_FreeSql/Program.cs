#nullable enable
using System;
using System.Collections.Generic;
using SrsManageCommon.ApisStructs;

namespace Test_FreeSql
{
    class Program
    {
        static long Insert(Module obj)
        {
            return DBManager.fsql.Insert(obj).ExecuteIdentity();
        }

        static int Update(Module obj)
        {
            return DBManager.fsql.Update<Module>()
                .Set(b => b.Str, obj.Str)
                .Where(b => b.Id == obj.Id)
                .ExecuteAffrows();
        }

        static int Delete(Module obj)
        {
            return DBManager.fsql.Delete<Module>().Where(b => b.Id == obj.Id).ExecuteAffrows();
        }

        static Module Select(long id)
        {
            return DBManager.fsql.Select<Module>().Where(b => b.Id == id).First();
        }

        static List<Module> SelectAll()
        {
            return DBManager.fsql.Select<Module>().ToList();
        }

        public static string? GetIngestRtspMonitorUrlIpAddress(string url)
        {
            try
            {
                Uri link = new Uri(url);
                return link.Host;
            }
            catch
            {
                return "";
            }
        }

        static void Main(string[] args)
        {
            StreamDvrPlan sdp= new StreamDvrPlan();
            sdp.App = "live";
            sdp.Stream = "stream_123";
            sdp.DeviceId = "deviceid_123";
            sdp.LimitDays = 10;
            sdp.LimitSpace = 640000;
            sdp.VhostDomain = "__defaultvhost__";
            sdp.OverStepPlan = OverStepPlan.DeleteFile;
            DvrDayTimeRange w1= new DvrDayTimeRange();
            w1.WeekDay = WeekdayEnum.Monday;
            w1.StartTime=DateTime.Parse("08:00:00");
            w1.EndTime = DateTime.Parse("17:30:00");
            DvrDayTimeRange w2= new DvrDayTimeRange();
            w2.WeekDay = WeekdayEnum.Tuesday;
            w2.StartTime=DateTime.Parse("08:00:00");
            w2.EndTime = DateTime.Parse("17:30:00");
            DvrDayTimeRange w3= new DvrDayTimeRange();
            w3.WeekDay = WeekdayEnum.Thursday;
            w3.StartTime=DateTime.Parse("08:00:00");
            w3.EndTime = DateTime.Parse("17:30:00");
            DvrDayTimeRange w4= new DvrDayTimeRange();
            w4.WeekDay = WeekdayEnum.Friday;
            w4.StartTime=DateTime.Parse("08:00:00");
            w4.EndTime = DateTime.Parse("17:30:00");
            sdp.DvrDayTimeRange=  new List<DvrDayTimeRange>();
            sdp.DvrDayTimeRange.Add(w1);
            sdp.DvrDayTimeRange.Add(w2);
            sdp.DvrDayTimeRange.Add(w3);
            sdp.DvrDayTimeRange.Add(w4);
            
            /*
            var repo = DBManager.fsql.GetRepository<StreamDvrPlan>();
            repo.Insert(sdp);
            repo.SaveMany(sdp, "DvrDayTimeRange");
            */
            
            
            var repo = DBManager.fsql.GetRepository<StreamDvrPlan>();
            repo.Insert(sdp);
            repo.SaveMany(sdp, "DvrDayTimeRange");

            var ret=DBManager.fsql.Select<StreamDvrPlan>().Where(x => x.Id == 1).ToList();
            if (ret != null)
            {
                foreach (var r in ret)
                {
                    if (r != null)
                    {
                       var rr= DBManager.fsql.Select<DvrDayTimeRange>().Where(x => x.DvrDayTimeRangeStreamDvrPlanId == r.Id).ToList();
                       if (rr != null)
                       {
                           r.DvrDayTimeRange = rr;
                       }
                    }
                }
            }
            
            /*var ret = repo.Select.Where(x => x.Id == 1).ToList();
            var ret1=DBManager.fsql.Select<StreamDvrPlan>().ToTreeList();*/
            
           // var ret = DBManager.fsql.Select<StreamDvrPlan>().Where(x => x.Id == 1).ToList();
            
            /*var ret=DBManager.fsql.Insert<StreamDvrPlan>(sdp).ExecuteInserted();
            Console.WriteLine(ret);*/
            return;
            Module a = new Module()
            {
                End = DateTime.Now,
                Start = DateTime.Now.AddDays(1),
                Str = "这是测试",
                Type = Strtype.str1,
            };

            a.Id = Insert(a);
            a.Str = "this is a test";
            Console.WriteLine(Update(a));
            Console.WriteLine(Delete(a));
            Console.WriteLine(a.ToString());
            Console.WriteLine(Select(1).ToString());
            var list = SelectAll();
            if (list != null)
            {
                foreach (var obj in list)
                {
                    Console.WriteLine(obj.ToString());
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
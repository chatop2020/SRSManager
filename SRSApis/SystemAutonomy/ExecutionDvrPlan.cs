using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using SrsApis.SrsManager;
using SrsApis.SrsManager.Apis;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SRSManageCommon.ControllerStructs.RequestModules;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;

namespace SRSApis.SystemAutonomy
{
    /// <summary>
    /// 自定义sql返回结构 
    /// </summary>
    public class FileDataLisSqlResponse
    {
        private string? _endTime;

        public string? EndTime
        {
            get => _endTime;
            set => _endTime = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    public class ExecutionDvrPlan
    {
        private List<StreamDvrPlan> getStreamDvrPlan()
        {
            ReqGetDvrPlan rgdp = new ReqGetDvrPlan()
            {
                DeviceId = "",
                Stream = "",
                VhostDomain = "",
            };
            var result = DvrPlanApis.GetDvrPlanList(rgdp, out ResponseStruct rs);
            if (rs.Code == ErrorNumber.None)
            {
                return result;
            }

            return null!;
        }

        /// <summary>
        /// 获取当前Dvr中的录制流信息
        /// </summary>
        /// <param name="plan"></param>
        /// <returns></returns>
        private List<string> currDvrApplySetting(StreamDvrPlan plan)
        {
            SrsManager srs = SystemApis.GetSrsManagerInstanceByDeviceId(plan.DeviceId!);
            if (srs == null) return null!;
            SrsvHostConfClass vhost = VhostApis.GetVhostByDomain(srs.SrsDeviceId, plan.VhostDomain!,
                out ResponseStruct rs);
            if (vhost == null || rs.Code != ErrorNumber.None) return null!;
            if (vhost.Vdvr == null || vhost.Vdvr.Enabled == false) return null!;
            string? dvrApply = vhost.Vdvr.Dvr_apply!;
            List<string> dvrStreams = new List<string>();
            if (!string.IsNullOrEmpty(dvrApply))
            {
                dvrStreams = Regex.Split(dvrApply, @"[\s]+").ToList();
               
            }
            else
            {
                dvrStreams.Add("all");
            }

            if (dvrStreams.Count == 1 && dvrStreams[0].Trim().ToLower().Equals("all"))
            {
                dvrStreams[0] = "";
            }

            return dvrStreams;
        }

        private decimal getDvrFileSize(StreamDvrPlan plan)
        {
            return OrmService.Db.Select<DvrVideo>().Where(x =>
                x.App!.Trim().ToLower().Equals(plan.App!.Trim().ToLower())
                && x.Stream!.Trim().ToLower().Equals(plan.Stream!.Trim().ToLower())
                && x.Device_Id!.Trim().ToLower().Equals(plan.DeviceId!.Trim().ToLower())).Sum(x => x.FileSize);
        }


        private List<FileDataLisSqlResponse> getDvrFileDataList(StreamDvrPlan plan)
        {
            string sql =
                "select  date(Endtime) as endtime from Dvr  where  Device_Id=\"{0}\" and Vhost = \"{1}\"and App=\"{2}\" and Stream=\"{3}\" group by date(Endtime) order by date(endtime) asc";

            sql = string.Format(sql, plan.DeviceId, plan.VhostDomain, plan.App, plan.Stream);

            var ret = OrmService.Db.Select<FileDataLisSqlResponse>().WithSql(sql).ToList();
            if (ret == null || ret.Count == 0)
            {
                return null!;
            }

            return ret;
        }


        private void updateDBAfterDeleteFile(List<DvrVideo> dvrList)
        {
            if (dvrList == null || dvrList.Count == 0) return;
            foreach (var d in dvrList)
            {
                if (d == null) continue;
                OrmService.Db.Delete<DvrVideo>().Where(x => x.Id == d.Id).ExecuteAffrows();
                Thread.Sleep(10);
            }
        }


        private void deleteDvrFilesByDays(StreamDvrPlan plan, List<FileDataLisSqlResponse> dvrFileDateList)
        {
            List<string> deleteDatetime = new List<string>();
            if (plan != null && dvrFileDateList != null && dvrFileDateList.Count > 0)
            {
                int? loopCount = dvrFileDateList.Count - plan.LimitDays;
                for (int i = 0; i < loopCount; i++)
                {
                    deleteDatetime.Add(dvrFileDateList[i].EndTime!);
                }
            }

            foreach (var d in deleteDatetime)
            {
                string sql =
                    "select * from Dvr where Device_Id=\"{0}\" and App=\"{1}\" and Stream=\"{2}\" and date(endtime)=\"{3}\"";
                sql = string.Format(sql, plan!.DeviceId, plan.App, plan.Stream, d);
                var retDvrList = OrmService.Db.Select<DvrVideo>().WithSql(sql).ToList();
                if (retDvrList != null && retDvrList.Count > 0)
                {
                    for (int i = 0; i <= retDvrList.Count - 1; i++)
                    {
                        if (File.Exists(retDvrList[i].VideoPath))
                        {
                            File.Delete(retDvrList[i].VideoPath);
                            Thread.Sleep(30);
                        }
                    }

                    updateDBAfterDeleteFile(retDvrList);
                }
            }
        }

        private void deleteDvrfilesBySpace(StreamDvrPlan plan, decimal exitsFileSize)
        {
            List<string> deleteFileList = new List<string>();
            List<DvrVideo> dvrList = OrmService.Db.Select<DvrVideo>()
                .Where(x => x.Device_Id!.Trim().ToLower().Equals(plan.DeviceId!.Trim().ToLower())
                            && x.App!.Trim().ToLower().Equals(plan.App!.Trim().ToLower())
                            && x.Stream!.Trim().ToLower().Equals(plan.Stream!.Trim().ToLower()))
                .OrderBy(x => x.EndTime).Limit(100).ToList();
            if (dvrList != null && dvrList.Count > 0)
            {
                long? size = 0;
                for (int i = 0; i <= dvrList.Count - 1; i++)
                {
                    if (File.Exists(dvrList[i].VideoPath))
                    {
                        size += dvrList[i].FileSize;
                        if (exitsFileSize - size >= plan.LimitSpace)
                        {
                            deleteFileList.Add(dvrList[i].VideoPath!);
                        }
                        else
                        {
                            dvrList[i] = null!;
                        }
                    }
                }
            }

            if (deleteFileList.Count > 0)
            {
                foreach (var filePath in deleteFileList)
                {
                    File.Delete(filePath);
                    Thread.Sleep(30);
                }
            }

            updateDBAfterDeleteFile(dvrList!);
        }

        private SrsConfFile.SRSConfClass.Dvr getOrCreateDvr(StreamDvrPlan plan)
        {
            SrsConfFile.SRSConfClass.Dvr dvr = VhostDvrApis.GetVhostDvr(plan.DeviceId!, plan.VhostDomain!,
                out ResponseStruct rs);
            SrsManager sm = SystemApis.GetSrsManagerInstanceByDeviceId(plan.DeviceId!);
            if (dvr == null)
            {
                dvr = new SrsConfFile.SRSConfClass.Dvr();
                dvr.Enabled = false;
                dvr.Dvr_apply += "all;";
                dvr.Dvr_path = sm.SrsWorkPath + sm.SrsDeviceId +
                               "/wwwroot/dvr/[2006][01][02]/[vhost]/[app]/[stream]/[15]/[2006][01][02][15][04][05].mp4";
                dvr.Dvr_duration = 300;
                dvr.Dvr_plan = "segment";
                dvr.Dvr_wait_keyframe = true;
                dvr.Time_Jitter = PlayTimeJitter.full;
            }

            return dvr;
        }

        private bool isTimeRange(DvrDayTimeRange d)
        {
            //获取当前系统时间并判断是否为服务时间
            TimeSpan nowDt = DateTime.Now.TimeOfDay;

            TimeSpan workStartDT = DateTime.Parse(d.StartTime.ToString("HH:mm:ss")).AddMinutes(-1).TimeOfDay;
            TimeSpan workEndDT = DateTime.Parse(d.EndTime.ToString("HH:mm:ss")).AddMinutes(1).TimeOfDay;
            Console.WriteLine("start"+workStartDT.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("end"+workEndDT.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("nowDt"+nowDt.ToString("yyyy-MM-dd HH:mm:ss"));
            if (nowDt > workStartDT && nowDt < workEndDT)
            {
                return true;
            }
            return false;
        }

        private void Run()
        {
            while (true)
            {
                bool needwriteConfig = false;
                List<StreamDvrPlan> dvrPlans = getStreamDvrPlan(); //获取所有录制计划
                if (dvrPlans != null && dvrPlans.Count > 0)
                {
                    foreach (var plan in dvrPlans)
                    {
                        List<string> retStream = currDvrApplySetting(plan); //获取录制计划对应的dvr实例
                        if (retStream == null) //如果是为，说明dvr不存在
                        {
                            SrsConfFile.SRSConfClass.Dvr dvr = getOrCreateDvr(plan); //创建一个Dvr
                            if (dvr != null)
                            {
                                VhostDvrApis.SetVhostDvr(plan.DeviceId!, plan.VhostDomain!, dvr,
                                    out ResponseStruct rs); //写入对应vhost
                                if (SystemApis.RefreshSrsObject(plan.DeviceId!, out rs)) //重写srsconf文件
                                {
                                    GlobalSrsApis.ReloadSrs(plan.DeviceId!, out rs); //重新加载srsconf配置
                                }
                            }
                            
                            retStream = currDvrApplySetting(plan); //再获取一次，保证dvr的存在
                        }

                        if (retStream.Contains(plan.App+"/"+plan.Stream) && plan.Enable) //如果dvr实例中已经存在本plan的情况，并且plan的enable为true
                        {
                            if (plan.TimeRangeList != null && plan.TimeRangeList.Count > 0)
                            {
                                foreach (DvrDayTimeRange t in plan.TimeRangeList)
                                {
                                    if (t != null)
                                    {
                                        if (t.WeekDay == DateTime.Now.DayOfWeek && !isTimeRange(t))
                                        {
                                            retStream.Remove(plan.App+"/"+plan.Stream);
                                            needwriteConfig = true; //要重写配置
                                        }
                                    }
                                }
                            }
                            if (plan.LimitSpace != null && plan.LimitSpace > 0) //如果有磁盘限制
                            {
                                decimal planFileSize = getDvrFileSize(plan);

                                if (planFileSize > plan.LimitSpace && plan.OverStepPlan == OverStepPlan.DeleteFile)
                                {
                                    deleteDvrfilesBySpace(plan, planFileSize);
                                    //删除文件
                                }
                                else if (planFileSize > plan.LimitSpace && plan.OverStepPlan == OverStepPlan.StopDvr)
                                {
                                    //停止dvr
                                    retStream.Remove(plan.App+"/"+plan.Stream);
                                    needwriteConfig = true; //要重写配置
                                }
                            }

                            if (plan.LimitDays != null && plan.LimitDays > 0) //如果有保存天数限制
                            {

                                var listDays = getDvrFileDataList(plan);

                                if (listDays != null && listDays.Count > plan.LimitDays)
                                {

                                    if (plan.OverStepPlan == OverStepPlan.DeleteFile)
                                    {

                                        deleteDvrFilesByDays(plan, listDays);
                                        //删除文件
                                    }
                                    else if (plan.OverStepPlan == OverStepPlan.StopDvr)
                                    {
                   
                                        //停止dvr
                                        retStream.Remove(plan.App+"/"+plan.Stream);
                                        needwriteConfig = true; //要重写配置
                                    }
                                }
                            }
                        }
                        else if (plan.Enable && !retStream.Contains(plan.App+"/"+plan.Stream)
                        ) //如果plan的enable为true,但是dvr实例中没有stream存在
                        {

                            if (plan.TimeRangeList != null && plan.TimeRangeList.Count > 0)
                            {
                                foreach (DvrDayTimeRange t in plan.TimeRangeList)
                                {
                                    if (t != null)
                                    {
                                        if (t.WeekDay == DateTime.Now.DayOfWeek && isTimeRange(t))
                                        {
                                            retStream.Add(plan.App + "/" + plan.Stream); //把自己加入进去
                                            needwriteConfig = true; //要重写配置
                                        }
                                    }
                                }
                            }
                            else
                            {

                                retStream.Add(plan.App + "/" + plan.Stream); //把自己加入进去
                                needwriteConfig = true; //要重写配置
                            }
                        }
                        else if (!plan.Enable && retStream.Contains(plan.App+"/"+plan.Stream)
                        ) //如果plan的enable为false,并且存在于dvr实例中，要删除掉自己
                        {

                            retStream.Remove(plan.App+"/"+plan.Stream);
                            needwriteConfig = true; //要重写配置
                        }


                        if (needwriteConfig) //重写配置
                        {

                            needwriteConfig = false;
                            SrsConfFile.SRSConfClass.Dvr dvr = VhostDvrApis.GetVhostDvr(plan.DeviceId!, plan.VhostDomain!,
                                out ResponseStruct rs);
                            SrsManager sm = SystemApis.GetSrsManagerInstanceByDeviceId(plan.DeviceId!);
                            if (dvr == null)
                            {
                                dvr = new SrsConfFile.SRSConfClass.Dvr();
                                dvr.Enabled = false;
                                foreach (var s in retStream)
                                {
                                    dvr.Dvr_apply += s + "\t";
                                }
                                dvr.Dvr_apply = dvr.Dvr_apply!.Trim();
                                dvr.Dvr_apply += ";";
                                dvr.Dvr_path = sm.SrsWorkPath + sm.SrsDeviceId +
                                               "/wwwroot/dvr/[2006][01][02]/[vhost]/[app]/[stream]/[15]/[2006][01][02][15][04][05].mp4";
                                dvr.Dvr_duration = 300;
                                dvr.Dvr_plan = "segment";
                                dvr.Dvr_wait_keyframe = true;
                                dvr.Time_Jitter = PlayTimeJitter.full;
                                VhostDvrApis.SetVhostDvr(plan.DeviceId!, plan.VhostDomain!, dvr, out rs);
                            }
                            else
                            {
     
                                dvr.Dvr_apply = "";
                                foreach (var s in retStream)
                                {
                                    
                                    if (string.IsNullOrEmpty(dvr.Dvr_apply))
                                    {
                                        dvr.Dvr_apply += s + "\t";
                                    }
                                    else
                                    {
                                        if (dvr.Dvr_apply.EndsWith('\t'))
                                        {
                                            dvr.Dvr_apply +=s+"\t";
                                        }
                                        else
                                        {
                                            dvr.Dvr_apply += "\t"+s+"\t";
                                        }
                                       
                                    }

                                    dvr.Dvr_apply = dvr.Dvr_apply.Trim();
                                }
                                VhostDvrApis.SetVhostDvr(plan.DeviceId!, plan.VhostDomain!, dvr, out rs);
                            }

                            if (SystemApis.RefreshSrsObject(plan.DeviceId!, out rs)) //重写srsconf文件
                            {
                                GlobalSrsApis.ReloadSrs(plan.DeviceId!, out rs); //重新加载srsconf配置
                            }
                        }
                    }
                }

                Thread.Sleep(5000);
            }
        }

        public ExecutionDvrPlan()
        {
            new Thread(new ThreadStart(delegate

            {
                try
                {
                    Run();
                }
                catch (Exception ex)
                {
                    // ignored
                    Console.WriteLine(ex.Message);
                }
            })).Start();
        }
    }
}
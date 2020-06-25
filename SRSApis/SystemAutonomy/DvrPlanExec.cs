using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using SrsApis.SrsManager.Apis;
using SrsManageCommon;
using SRSManageCommon.ControllerStructs.RequestModules;
using SRSManageCommon.ControllerStructs.ResponseModules;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;

namespace SRSApis.SystemAutonomy
{
    public class DvrPlanExec
    {
        private int interval = SrsManageCommon.Common.SystemConfig.DvrPlanExecServiceinterval;

        private List<string> getDvrPlanFileDataList(StreamDvrPlan plan)
        {
            List<string?> ret = null!;
            lock (SrsManageCommon.Common.LockDbObjForDvrVideo)
            {
                ret = OrmService.Db.Select<DvrVideo>()
                    .WhereIf(!string.IsNullOrEmpty(plan.DeviceId), x =>
                        x.App!.Trim().ToLower().Equals(plan.App!.Trim().ToLower()))
                    .WhereIf(!string.IsNullOrEmpty(plan.VhostDomain), x =>
                        x.Vhost!.Trim().ToLower().Equals(plan.VhostDomain!.Trim().ToLower()))
                    .WhereIf(!string.IsNullOrEmpty(plan.DeviceId), x =>
                        x.Device_Id!.Trim().ToLower().Equals(plan.DeviceId!.Trim().ToLower()))
                    .WhereIf(!string.IsNullOrEmpty(plan.Stream), x =>
                        x.Stream!.Trim().ToLower().Equals(plan.Stream!.Trim().ToLower()))
                    .Where(x => x.Deleted == false)
                    .GroupBy(x => x.RecordDate)
                    .OrderBy(x => x.Value.RecordDate)
                    .ToList(a => a.Value.RecordDate);
                
            }

            if (ret != null && ret.Count > 0)
            {
                return ret!;
            }

            return null!;
        }

        private decimal getDvrPlanFileSize(StreamDvrPlan sdp)
        {
            try
            {
                lock (SrsManageCommon.Common.LockDbObjForDvrVideo)
                {
                    return OrmService.Db.Select<DvrVideo>()
                        .WhereIf(!string.IsNullOrEmpty(sdp.DeviceId), x =>
                            x.App!.Trim().ToLower().Equals(sdp.App!.Trim().ToLower()))
                        .WhereIf(!string.IsNullOrEmpty(sdp.VhostDomain), x =>
                            x.Vhost!.Trim().ToLower().Equals(sdp.VhostDomain!.Trim().ToLower()))
                        .WhereIf(!string.IsNullOrEmpty(sdp.DeviceId), x =>
                            x.Device_Id!.Trim().ToLower().Equals(sdp.DeviceId!.Trim().ToLower()))
                        .WhereIf(!string.IsNullOrEmpty(sdp.Stream), x =>
                            x.Stream!.Trim().ToLower().Equals(sdp.Stream!.Trim().ToLower()))
                        .Where(x => x.Deleted == false)
                        .Sum(x => x.FileSize);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        
        /// <summary>
        /// 清除24小时前软删除的文件
        /// </summary>
        /// <param name="sdp"></param>
        private void doDeleteFor24HourAgo(StreamDvrPlan sdp)
        {
            List<DvrVideo> retList = null!;
            lock (SrsManageCommon.Common.LockDbObjForDvrVideo)
            {
                retList = OrmService.Db.Select<DvrVideo>()
                    .WhereIf(!string.IsNullOrEmpty(sdp.DeviceId), x =>
                        x.App!.Trim().ToLower().Equals(sdp.App!.Trim().ToLower()))
                    .WhereIf(!string.IsNullOrEmpty(sdp.VhostDomain), x =>
                        x.Vhost!.Trim().ToLower().Equals(sdp.VhostDomain!.Trim().ToLower()))
                    .WhereIf(!string.IsNullOrEmpty(sdp.DeviceId), x =>
                        x.Device_Id!.Trim().ToLower().Equals(sdp.DeviceId!.Trim().ToLower()))
                    .WhereIf(!string.IsNullOrEmpty(sdp.Stream), x =>
                        x.Stream!.Trim().ToLower().Equals(sdp.Stream!.Trim().ToLower()))
                    .Where(x => x.Deleted == true)
                    .Where(x => ((DateTime) x.UpdateTime!).AddHours(24) <= DateTime.Now)
                    .ToList();
            }

            if (retList != null && retList.Count > 0)
            {
                lock (SrsManageCommon.Common.LockDbObjForDvrVideo)
                {
                    OrmService.Db.Transaction(() =>
                    {
                        foreach (var ret in retList)
                        {
                            if (ret != null)
                            {
                                if (ret.UpdateTime >= DateTime.Now)
                                {
                                    if (File.Exists(ret.VideoPath))
                                    {
                                        File.Delete(ret.VideoPath);
                                        LogWriter.WriteLog("删除被软删除的录制文件（24小时）", ret.VideoPath!);
                                        Thread.Sleep(20);
                                    }

                                    OrmService.Db.Update<DvrVideo>().Set(x => x.UpdateTime, DateTime.Now)
                                        .Set(x => x.Undo, false)
                                        .Where(x => x.Id == ret!.Id).ExecuteAffrows();
                                }
                            }
                        }
                    });
                }
            }
        }

        private bool getDvrOnorOff(StreamDvrPlan sdp)
        {
            var dvr = VhostDvrApis.GetVhostDvr(sdp.DeviceId, sdp.VhostDomain, out ResponseStruct rs);
            if (dvr == null) return false;
            string? dvrApply = dvr.Dvr_apply!;
            dvrApply = dvrApply.Replace(";", "");
            List<string> dvrStreams = new List<string>();
            if (dvrApply.Trim().ToLower().Equals("all"))
            {
                dvrApply = "";
            }
            if (!string.IsNullOrEmpty(dvrApply))
            {
                dvrStreams = Regex.Split(dvrApply, @"[\s]+").ToList();
                if (!dvrStreams.Contains((sdp.App + "/" + sdp.Stream).Trim()))
                {
                    return false;
                }

                return true;
            }

           
            return false;
        }

        private void setDvrOnorOff(StreamDvrPlan sdp, bool eanble)
        {
            var dvr = VhostDvrApis.GetVhostDvr(sdp.DeviceId, sdp.VhostDomain, out ResponseStruct rs);
            if (dvr != null)
            {
                string? dvrApply = dvr.Dvr_apply!;
                List<string> dvrStreams = new List<string>();
                if (!string.IsNullOrEmpty(dvrApply))
                {
                    dvrStreams = Regex.Split(dvrApply, @"[\s]+").ToList();
                }


                if (dvrStreams.Count == 0)
                {
                    dvrStreams.Add("");
                }

                for (int i = 0; i <= dvrStreams.Count - 1; i++)
                {
                    dvrStreams[i] = dvrStreams[i].TrimEnd(';').Trim();
                }

                bool needWrite = false;
                switch (eanble)
                {
                    case true:
                        if (!dvrStreams.Contains((sdp.App + "/" + sdp.Stream).Trim()))
                        {
                            dvrStreams.Add((sdp.App + "/" + sdp.Stream).Trim());
                            needWrite = true;
                        }

                        break;
                    case false:
                        if (dvrStreams.Contains((sdp.App + "/" + sdp.Stream).Trim()))
                        {
                            dvrStreams.Remove((sdp.App + "/" + sdp.Stream).Trim());
                            needWrite = true;
                        }

                        break;
                }

                if (needWrite)
                {
                    dvr.Dvr_apply = "";
                    foreach (var str in dvrStreams)
                    {
                        dvr.Dvr_apply += str + "\t";
                    }

                    if (dvr.Dvr_apply.Trim().Equals(";"))
                    {
                        dvr.Dvr_apply = "N;";
                    }

                    dvr.Dvr_apply = dvr.Dvr_apply.TrimEnd('\t');
                    VhostDvrApis.SetVhostDvr(sdp.DeviceId, sdp.VhostDomain, dvr, out rs);
                    SystemApis.RefreshSrsObject(sdp.DeviceId, out rs);
                }
            }
        }


        private void deleteFileOneByOne(decimal videoSize, StreamDvrPlan sdp)
        {
            long deleteSize = 0;
            List<OrderByStruct> orderBy = new List<OrderByStruct>();
            orderBy.Add(new OrderByStruct()
            {
                FieldName = "starttime",
                OrderByDir = OrderByDir.ASC,
            });
            ReqGetDvrVideo rgdv = new ReqGetDvrVideo()
            {
                App = sdp.App,
                DeviceId = sdp.DeviceId,
                EndTime = null,
                IncludeDeleted = false,
                OrderBy = orderBy,
                PageIndex = 1,
                PageSize = 10,
                StartTime = null,
                Stream = sdp.Stream,
                VhostDomain = sdp.VhostDomain,
            };
            while (videoSize - deleteSize > sdp.LimitSpace)
            {
                DvrVideoResponseList videoList = DvrPlanApis.GetDvrVideoList(rgdv, out ResponseStruct rs);
                if (videoList != null && videoList.DvrVideoList != null && videoList.DvrVideoList.Count > 0)
                {
                    lock (SrsManageCommon.Common.LockDbObjForDvrVideo)
                    {
                        OrmService.Db.Transaction(() =>
                        {
                            foreach (var ret in videoList.DvrVideoList)
                            {
                                if (ret != null)
                                {
                                    if (File.Exists(ret.VideoPath))
                                    {
                                        File.Delete(ret.VideoPath); 
                                        deleteSize += (long) ret.FileSize!;
                                        LogWriter.WriteLog("删除录制文件", ret.VideoPath!);
                                        
                                        Thread.Sleep(20);
                                    }

                                    OrmService.Db.Update<DvrVideo>().Set(x => x.UpdateTime, DateTime.Now)
                                        .Set(x => x.Deleted, true)
                                        .Where(x => x.Id == ret!.Id).ExecuteAffrows();
                                }
                                if ((videoSize - deleteSize) < sdp.LimitSpace)
                                {
                                    break;
                                }
                            }
                        });
                    }
                }
            }
        }

        private void deleteFileByDay(List<string> days)
        {
            foreach (var day in days)
            {
                List<DvrVideo> deleteList = null!;
                lock (SrsManageCommon.Common.LockDbObjForDvrVideo)
                {
                    deleteList = OrmService.Db.Select<DvrVideo>().Where(x => x.RecordDate == day).ToList();
                    OrmService.Db.Update<DvrVideo>().Set(x => x.UpdateTime, DateTime.Now)
                        .Set(x => x.Deleted, true)
                        .Where(x => x.RecordDate == day).ExecuteAffrows();
                    LogWriter.WriteLog("要删除除一天的文件，数据库标记为删除", day!);
                }

                if (deleteList != null && deleteList.Count > 0)
                {
                    foreach (var del in deleteList)
                    {
                        if (del != null)
                        {
                            if (File.Exists(del.VideoPath))
                            {
                                File.Delete(del.VideoPath);
                                LogWriter.WriteLog("删除录制文件", del.VideoPath!);
                                Thread.Sleep(20);
                            }
                        }
                    }
                }
            }
        }


        private void execOnOrOff(StreamDvrPlan sdp)
        {
            bool isEnable = true;
            int dateCount = 0;
            decimal videoSize = 0;
            List<string?> dateList = null!;
            videoSize = getDvrPlanFileSize(sdp)!;
            dateList = getDvrPlanFileDataList(sdp)!;
            if (sdp.OverStepPlan == OverStepPlan.StopDvr)
            {
              
                if (sdp.LimitDays > 0) //处理有天数限制的情况
                {
                  
                    dateCount = dateList.Count;
                    if (dateList != null && sdp.LimitDays < dateList.Count)
                    {
                      
                        //停掉
                        isEnable = false;
                    }
                }

                if (sdp.LimitSpace > 0) //处理有天数限制的情况
                {
                    
                    if (videoSize > sdp.LimitSpace)
                    {
                        //停掉
                        isEnable = false;
                    }
                }
            }
            bool isTime = checkTimeRange(sdp);
            isEnable = isEnable && sdp.Enable; //要处理计划停用的状态

     
            if (isTime && isEnable)
            {
                if (!getDvrOnorOff(sdp))
                {
                    LogWriter.WriteLog("录制计划即将启动录制,因为视频流没有达到受限条件，已经进入计划规定时间内并且录制程序处于关闭状态", sdp.DeviceId + "->" +
                                                                                           sdp.VhostDomain + "->" +
                                                                                           sdp.App + "->" + sdp.Stream +
                                                                                           "\t" + "空间限制：" +
                                                                                           sdp.LimitSpace.ToString() +
                                                                                           "字节::实际空间占用：" +
                                                                                           videoSize.ToString() +
                                                                                           "字节 \t时间限制：" +
                                                                                           sdp.LimitDays.ToString() +
                                                                                           "天::实际录制天数：" +
                                                                                           dateCount.ToString() +
                                                                                           "\t录制计划启用状态:" +
                                                                                           sdp.Enable.ToString());
                    setDvrOnorOff(sdp, true);
                }
               
            }
            else
            {
                if (getDvrOnorOff(sdp))
                {
                    LogWriter.WriteLog("录制计划即将关闭录制,因为视频流可能达到受限条件或者已经离开计划规定时间内并且录制程序处于启动状态", sdp.DeviceId + "->" +
                                                                                            sdp.VhostDomain + "->" +
                                                                                            sdp.App + "->" +
                                                                                            sdp.Stream +
                                                                                            "\t" + "空间限制：" +
                                                                                            sdp.LimitSpace.ToString() +
                                                                                            "字节::实际空间占用：" +
                                                                                            videoSize.ToString() +
                                                                                            "字节 \t时间限制：" +
                                                                                            sdp.LimitDays.ToString() +
                                                                                            "天::实际录制天数：" +
                                                                                            dateCount.ToString() +
                                                                                            "\t录制计划启用状态:" +
                                                                                            sdp.Enable.ToString());
                    setDvrOnorOff(sdp, false);
                }
              
            }
        }

        private void execDelete(StreamDvrPlan sdp)
        {
            doDeleteFor24HourAgo(sdp); //处理24小时后要删除的文件
            if (sdp.OverStepPlan == OverStepPlan.DeleteFile)
            {
                if (sdp.LimitDays > 0) //处理有时间限制的
                {
                    List<string?> dateList = null!;
                    dateList = getDvrPlanFileDataList(sdp)!;
                    if (dateList != null)
                    {
                        SrsManageCommon.Common.RemoveNull(dateList);
                    }

                    if (dateList != null && dateList.Count > sdp.LimitDays)
                    {
                        //执行一天一天删除
                        int? loopCount = dateList.Count - sdp.LimitDays;

                        List<string> willDeleteDays = new List<string>();
                        for (int i = 0; i < loopCount; i++)
                        {
                            willDeleteDays.Add(dateList[i]!);
                        }

                        deleteFileByDay(willDeleteDays);
                    }
                }

                if (sdp.LimitSpace > 0) //处理有容量限制的情况
                {
                    decimal videoSize = getDvrPlanFileSize(sdp);

                    if (videoSize > sdp.LimitSpace)
                    {
                        //一个一个删除文件
                        deleteFileOneByOne(videoSize, sdp);
                    }
                }
            }
        }
     
        

        protected bool getTimeSpan(string timeStr)
        { 
            //判断当前时间是否在工作时间段内
            string _strWorkingDayAM = "08:30";//工作时间上午08:30
            string _strWorkingDayPM = "17:30";
            TimeSpan dspWorkingDayAM = DateTime.Parse(_strWorkingDayAM).TimeOfDay;
            TimeSpan dspWorkingDayPM = DateTime.Parse(_strWorkingDayPM).TimeOfDay;

            //string time1 = "2017-2-17 8:10:00";
            DateTime t1 = Convert.ToDateTime(timeStr);

            TimeSpan dspNow = t1.TimeOfDay;
            if (dspNow > dspWorkingDayAM && dspNow < dspWorkingDayPM)
            {
                return true;
            }
            return false;
        }
        
        private bool isTimeRange(DvrDayTimeRange d)
        {
            TimeSpan nowDt = DateTime.Now.TimeOfDay;
            string start = d.StartTime.ToString("HH:mm:ss");
            string end = d.EndTime.ToString("HH:mm:ss");
            TimeSpan workStartDT = DateTime.Parse(start).TimeOfDay;
            TimeSpan workEndDT = DateTime.Parse(end).TimeOfDay;
            if (nowDt > workStartDT && nowDt < workEndDT)
            {
                return true;
            }

            return false;
          
        }
        
        

        private bool checkTimeRange(StreamDvrPlan sdp)
        {
            if (sdp.TimeRangeList != null && sdp.TimeRangeList.Count > 0)
            {
                var t = sdp.TimeRangeList.FindLast(x => x.WeekDay == DateTime.Now.DayOfWeek);
                if (t != null && isTimeRange(t))//有当天计划并在时间反问内返回true
                {
                    
                    return true;
                }

                if (t != null && !isTimeRange(t))//只有设置当天计划并且不在当天计划时间内，返回false
                {
                    return false;
                }

                return true;//如果没有设置当天计划也返回true
            }

            return true; //如果是空的，就直接返回可运行
        }

     
        //删除所有空的目录，用于dvr目录
        private void clearNofileDir(string deviceId)
        {
            var srs = SystemApis.GetSrsManagerInstanceByDeviceId(deviceId);
            if (srs != null)
            {
                string dvrPath = srs.SrsWorkPath + srs.SrsDeviceId + "/wwwroot/dvr";
                if (Directory.Exists(dvrPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(dvrPath);
                    DirectoryInfo[] subdirs = dir.GetDirectories("*.*", SearchOption.AllDirectories);
                    foreach (DirectoryInfo subdir in subdirs)
                    {
                        FileSystemInfo[] subFiles = subdir.GetFileSystemInfos();
                        if (subFiles.Length == 0)
                        {
                            LogWriter.WriteLog("监控发现有空目录需要删除...",subdir.FullName);
                            subdir.Delete();
                        }
                    }
                }   
            }
        }
        private void Run()
        {
            while (true)
            {
                var srsDeviceIdList = SystemApis.GetAllSrsManagerDeviceId();
                if (srsDeviceIdList == null || srsDeviceIdList.Count == 0)
                {
                    Thread.Sleep(interval);
                    continue;
                }

                foreach (var deviceId in srsDeviceIdList)
                {
                    clearNofileDir(deviceId);//清除空的目录
                    ReqGetDvrPlan rgdp = new ReqGetDvrPlan();
                    rgdp.DeviceId = deviceId;

                    var dvrPlanList = DvrPlanApis.GetDvrPlanList(rgdp, out ResponseStruct rs);

                    if (dvrPlanList == null || dvrPlanList.Count == 0) continue;
                    foreach (var dvrPlan in dvrPlanList)
                    {
                        if (dvrPlan == null)
                        {
                            continue;
                        }
                        
                        execDelete(dvrPlan);
                        execOnOrOff(dvrPlan);
                        Thread.Sleep(2000);
                    }
                }

                Thread.Sleep(interval);
            }
        }

        public DvrPlanExec()
        {
            new Thread(new ThreadStart(delegate

            {
                try
                {
                    LogWriter.WriteLog("启动自动录制计划服务...(循环间隔：" + interval + "ms)");
                    Run();
                }
                catch (Exception ex)
                {
                    LogWriter.WriteLog("启动自动录制计划服务失败...", ex.Message + "\r\n" + ex.StackTrace, ConsoleColor.Yellow);
                }
            })).Start();
        }
    }
}
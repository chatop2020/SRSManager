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
                                    }

                                    OrmService.Db.Update<DvrVideo>().Set(x => x.UpdateTime, DateTime.Now)
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
            List<string> dvrStreams = new List<string>();
            if (!string.IsNullOrEmpty(dvrApply))
            {
                dvrStreams = Regex.Split(dvrApply, @"[\s]+").ToList();
            }

            if (!dvrStreams.Contains((sdp.App + "/" + sdp.Stream).Trim()))
            {

                return false;
            }

            return true;
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
                                    }

                                    OrmService.Db.Update<DvrVideo>().Set(x => x.UpdateTime, DateTime.Now)
                                        .Set(x => x.Deleted, true)
                                        .Where(x => x.Id == ret!.Id).ExecuteAffrows();
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
                                Thread.Sleep(20);
                            }
                        }
                    }
                }
            }
        }

        private void execDvrDeletePlan(StreamDvrPlan sdp)
        {
            doDeleteFor24HourAgo(sdp); //处理24小时后要删除的文件
            if (sdp.OverStepPlan == OverStepPlan.StopDvr)
            {
                bool isEnable = true;
                List<string?> dateList = null!;
                //停止录制操作
                if (sdp.LimitDays != null && sdp.LimitDays > 0)
                {
                    //有日期限制
                     dateList = getDvrPlanFileDataList(sdp)!;
                    if (dateList != null && dateList.Count > sdp.LimitDays)
                    {
                        isEnable = false;
                    }
                    else
                    {
                        isEnable = true;
                    }
                }

                decimal videoSize = 0;
                if (sdp.LimitSpace != null && sdp.LimitSpace > 0)
                {
                     videoSize = getDvrPlanFileSize(sdp);
                    if (videoSize > sdp.LimitSpace)
                    {
                        isEnable = false;
                    }
                    else
                    {
                        if(isEnable)isEnable = true;
                    }
                }

                isEnable = checkTimeRange(sdp) && isEnable && sdp.Enable;
                if (isEnable != getDvrOnorOff(sdp))
                {
                    LogWriter.WriteLog("录制计划需要"+(isEnable==true?"启用":"停用")+sdp.App+"/"+sdp.Stream+"的录制计划,"+
                                       " VideoSize:"+videoSize+"::LimitSpace:"+sdp.LimitSpace+" 天数："+dateList!.Count+
                                       "::LimitDays:"+sdp.LimitDays);
                    setDvrOnorOff(sdp, isEnable); //启用或停用录制
                }
            }
            else
            {
                if (sdp.Enable && !getDvrOnorOff(sdp) && checkTimeRange(sdp)) //sdp的enable为真，并且没在运行，同时还需要在时间范围内（或者时间范围为空）
                {
                    LogWriter.WriteLog("录制计划需要" + (true ? "启用" : "停用") + sdp.App + "/" + sdp.Stream + "的录制计划状态为启用，同时因为录制计划超限是文件删除模式");
                    setDvrOnorOff(sdp, true); //启用或停用录制
                }
                else if(!sdp.Enable && getDvrOnorOff(sdp))
                {
                    LogWriter.WriteLog("录制计划需要" + (false ? "启用" : "停用") + sdp.App + "/" + sdp.Stream + "的录制计划,录制计划状态为停用");
                    setDvrOnorOff(sdp, false); //启用或停用录制  
                }
                //文件删除操作
                //停止录制操作
                
                if (sdp.LimitDays != null && sdp.LimitDays > 0)
                {
                    //有日期限制
                    List<string?> dateList = getDvrPlanFileDataList(sdp)!;
                    if (dateList != null && dateList.Count > sdp.LimitDays)
                    {
                        //一天一天删除文件
                        int? loopCount = dateList.Count - sdp.LimitDays;
                        List<string> willDeleteDays = new List<string>();
                        for (int i = 0; i < loopCount; i++)
                        {
                            willDeleteDays.Add(dateList[i]!);
                        }

                        deleteFileByDay(willDeleteDays);
                    }
                }

                if (sdp.LimitSpace != null && sdp.LimitSpace > 0)
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

        private bool isTimeRange(DvrDayTimeRange d)
        {
            //获取当前系统时间并判断是否为服务时间
            TimeSpan nowDt = DateTime.Now.TimeOfDay;
            TimeSpan workStartDT = DateTime.Parse(d.StartTime.ToString("HH:mm:ss")).AddMinutes(-1).TimeOfDay;
            TimeSpan workEndDT = DateTime.Parse(d.EndTime.ToString("HH:mm:ss")).AddMinutes(1).TimeOfDay;
          
            if (nowDt >= workStartDT && nowDt < workEndDT)
            {
               
                return true;
            }
          
            return false;
        }

        private bool checkTimeRange(StreamDvrPlan sdp)
        {
            if (sdp.Enable)
            {
                if (sdp.TimeRangeList != null && sdp.TimeRangeList.Count > 0)
                {
                    var t=sdp.TimeRangeList.FindLast(x => x.WeekDay == DateTime.Now.DayOfWeek);
                    if (t != null && isTimeRange(t))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }

                return true; //如果是空的，就直接返回可运行
            }

            return false;
        }
        
        private void execDvrOnOrOffPlan(StreamDvrPlan sdp)
        {
            if (sdp.Enable)
            {
                if (sdp.TimeRangeList != null && sdp.TimeRangeList.Count > 0)
                {
                    var t=sdp.TimeRangeList.FindLast(x => x.WeekDay == DateTime.Now.DayOfWeek);
                    if (t != null && isTimeRange(t))
                    {
                        if (sdp.LimitSpace != null && sdp.LimitSpace > 0 &&
                            sdp.LimitDays != null && sdp.LimitDays > 0 && !getDvrOnorOff(sdp))
                        {

                            var videoSize = getDvrPlanFileSize(sdp);
                            var dateList = getDvrPlanFileDataList(sdp);
                            if (videoSize < sdp.LimitSpace && dateList.Count < sdp.LimitDays)
                            {
                                LogWriter.WriteLog("录制计划需要"+(true?"启用":"停用")+sdp.App+"/"+sdp.Stream+"的录制计划,"+
                                                   " VideoSize:"+videoSize+"::LimitSpace:"+sdp.LimitSpace+" 天数："+dateList!.Count+
                                                   "::LimitDays:"+sdp.LimitDays);
                                setDvrOnorOff(sdp, true); //录制时间在范围内，开始录制 
                            }
                        }else if (!getDvrOnorOff(sdp))
                        {
                            LogWriter.WriteLog("录制计划需要启用"+sdp.App+"/"+sdp.Stream+"录制计划,因为已经到了录制时间范围");
                            setDvrOnorOff(sdp, true); //录制时间在范围内，开始录制  
                        }
                    }
                    else
                    {
                        if (getDvrOnorOff(sdp))
                        {
                            LogWriter.WriteLog("录制计划需要停用" + sdp.App + "/" + sdp.Stream + "录制计划,因为不在录制的时间范围内");
                            setDvrOnorOff(sdp, false); //不在录制时间范围内，停止录制
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
                if (srsDeviceIdList == null || srsDeviceIdList.Count == 0) continue;
                foreach (var deviceId in srsDeviceIdList)
                {
                    ReqGetDvrPlan rgdp = new ReqGetDvrPlan();
                    rgdp.DeviceId = deviceId;

                    var dvrPlanList = DvrPlanApis.GetDvrPlanList(rgdp, out ResponseStruct rs);
                    if (dvrPlanList == null || dvrPlanList.Count == 0) continue;
                    foreach (var dvrPlan in dvrPlanList)
                    {
                        if (dvrPlan == null) continue;
                        execDvrDeletePlan(dvrPlan);
                        execDvrOnOrOffPlan(dvrPlan);
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
                    // ignored
                    Console.WriteLine(ex.Message);
                }
            })).Start();
        }
    }
}
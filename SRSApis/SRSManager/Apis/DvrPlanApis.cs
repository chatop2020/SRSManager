using System;
using System.Collections.Generic;
using System.IO;
using SrsManageCommon;
using SRSManageCommon.ControllerStructs.RequestModules;
using SRSManageCommon.ControllerStructs.ResponseModules;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;

namespace SrsApis.SrsManager.Apis
{
    public static class DvrPlanApis
    {
        /// <summary>
        /// 恢复被软删除的录制文件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool UndoSoftDelete(long id, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            DvrVideo retSelect = null!;
            lock (Common.LockDbObjForDvrVideo)
            {
                retSelect = OrmService.Db.Select<DvrVideo>().Where(x => x.Id == id).First();
                if (retSelect == null)
                {
                    rs.Code = ErrorNumber.SystemDataBaseRecordNotExists;
                    rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SystemDataBaseRecordNotExists];
                    return false;
                }
            }

            if (!File.Exists(retSelect.VideoPath))
            {
                rs.Code = ErrorNumber.DvrVideoFileNotExists;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.DvrVideoFileNotExists];
                return false;
            }

            lock (Common.LockDbObjForDvrVideo)
            {
                var retUpdate = OrmService.Db.Update<DvrVideo>().Set(x => x.Deleted, false)
                    .Set(x => x.UpdateTime, DateTime.Now).Where(x => x.Id == (long) id).ExecuteAffrows();
                if (retUpdate > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 删除一个录像文件（硬删除，立即删除文件，数据库置Delete）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool HardDeleteDvrVideoById(long id, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            List<DvrVideo> retSelect = null!;
            int retUpdate = -1;
            lock (Common.LockDbObjForDvrVideo)
            {
                retSelect = OrmService.Db.Select<DvrVideo>().Where(x => x.Id == id).ToList();
                retUpdate = OrmService.Db.Update<DvrVideo>().Set(x => x.Deleted, true)
                    .Set(x => x.UpdateTime, DateTime.Now).Where(x => x.Id == (long) id).ExecuteAffrows();
            }

            if (retUpdate > 0)
            {
                foreach (var select in retSelect)
                {
                    try
                    {
                        File.Delete(select.VideoPath);
                    }
                    catch
                    {
                        // ignored
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// 删除一个录像文件（软删除，只做标记不删除文件，文件保留24小时后删除）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool SoftDeleteDvrVideoById(long id, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            lock (Common.LockDbObjForDvrVideo)
            {
                var retUpdate = OrmService.Db.Update<DvrVideo>().Set(x => x.Deleted, true)
                    .Set(x => x.UpdateTime, DateTime.Now).Where(x => x.Id == (long) id).ExecuteAffrows();
                if (retUpdate > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取录像文件列表
        /// </summary>
        /// <param name="rgdv"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static DvrVideoResponseList GetDvrVideoList(ReqGetDvrVideo rgdv, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            bool idFound = !string.IsNullOrEmpty(rgdv.DeviceId);
            bool vhostFound = !string.IsNullOrEmpty(rgdv.VhostDomain);
            bool streamFound = !string.IsNullOrEmpty(rgdv.Stream);
            bool appFound = !string.IsNullOrEmpty(rgdv.App);
            bool isPageQuery = (rgdv.PageIndex != null && rgdv.PageIndex >= 1);
            bool haveOrderBy = rgdv.OrderBy != null;
            if (isPageQuery)
            {
                if (rgdv.PageSize > 10000)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SystemDataBaseLimited,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SystemDataBaseLimited],
                    };
                    return null!;
                }

                if (rgdv.PageIndex <= 0)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SystemDataBaseLimited,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SystemDataBaseLimited],
                    };
                    return null!;
                }
            }

            string orderBy = "";
            if (haveOrderBy)
            {
                foreach (var order in rgdv.OrderBy!)
                {
                    if (order != null)
                    {
                        orderBy += order.FieldName + " " + Enum.GetName(typeof(OrderByDir), order.OrderByDir) + ",";
                    }
                }

                orderBy = orderBy.TrimEnd(',');
            }

            long total = -1;
            List<DvrVideo> retList = null!;

            if (!isPageQuery)
            {
                lock (Common.LockDbObjForDvrVideo)
                {
                    retList = OrmService.Db.Select<DvrVideo>().Where("1=1")
                        .WhereIf(idFound, x => x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower()))
                        .WhereIf(vhostFound, x => x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower()))
                        .WhereIf(streamFound, x => x.Stream!.Trim().ToLower().Equals(rgdv.Stream!.Trim().ToLower()))
                        .WhereIf(rgdv.StartTime != null, x => x.StartTime >= rgdv.StartTime)
                        .WhereIf(rgdv.EndTime != null, x => x.EndTime <= rgdv.EndTime)
                        .WhereIf(appFound, x => x.App!.Trim().ToLower().Equals(rgdv.App!.Trim().ToLower()))
                        .WhereIf(!(bool) rgdv.IncludeDeleted!, x => x.Deleted == false)
                        .OrderBy(orderBy)
                        .ToList();
                }
            }
            else
            {
                lock (Common.LockDbObjForDvrVideo)
                {
                    retList = OrmService.Db.Select<DvrVideo>().Where("1=1")
                        .WhereIf(idFound, x => x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower()))
                        .WhereIf(vhostFound, x => x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower()))
                        .WhereIf(streamFound, x => x.Stream!.Trim().ToLower().Equals(rgdv.Stream!.Trim().ToLower()))
                        .WhereIf(rgdv.StartTime != null, x => x.StartTime >= rgdv.StartTime)
                        .WhereIf(rgdv.EndTime != null, x => x.EndTime <= rgdv.EndTime)
                        .WhereIf(appFound, x => x.App!.Trim().ToLower().Equals(rgdv.App!.Trim().ToLower()))
                        .WhereIf(!(bool) rgdv.IncludeDeleted!, x => x.Deleted == false).OrderBy(orderBy)
                        .Count(out total)
                        .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!)
                        .ToList();
                }
            }

            DvrVideoResponseList result = new DvrVideoResponseList();
            result.DvrVideoList = retList;
            if (!isPageQuery)
            {
                if (retList != null)
                {
                    total = retList.Count;
                }
                else
                {
                    total = 0;
                }
            }

            result.Total = total;
            result.Request = rgdv;
            return result;
        }


        /// <summary>
        /// 通过id删除一个录制计划
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteDvrPlanById(long id, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };


            if (id <= 0)
            {
                rs.Code = ErrorNumber.FunctionInputParamsError;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError];
                return false;
            }

            List<StreamDvrPlan> retSelect = null!;
            int retDelete = -1;
            lock (Common.LockDbObjForStreamDvrPlan)
            {
                retSelect = OrmService.Db.Select<StreamDvrPlan>().Where(x => x.Id == id).ToList();
                retDelete = OrmService.Db.Delete<StreamDvrPlan>().Where(x => x.Id == id).ExecuteAffrows();
            }

            if (retDelete > 0)
            {
                lock (Common.LockDbObjForStreamDvrPlan)
                {
                    foreach (var select in retSelect)
                    {
                        OrmService.Db.Delete<DvrDayTimeRange>().Where(x => x.StreamDvrPlanId == select.Id)
                            .ExecuteAffrows();
                    }
                }

                return true;
            }


            rs.Code = ErrorNumber.SrsDvrPlanNotExists;
            rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanNotExists];
            return false;
        }

        /// <summary>
        /// 启用或停止一个录制计划
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enable"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnOrOffDvrPlanById(long id, bool enable, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };


            if (id <= 0)
            {
                rs.Code = ErrorNumber.FunctionInputParamsError;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError];
                return false;
            }

            lock (Common.LockDbObjForStreamDvrPlan)
            {
                var retUpdate = OrmService.Db.Update<StreamDvrPlan>().Set(x => x.Enable, enable)
                    .Where(x => x.Id == id)
                    .ExecuteAffrows();
                if (retUpdate > 0)
                    return true;
            }

            rs.Code = ErrorNumber.SrsDvrPlanNotExists;
            rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanNotExists];
            return false;
        }


        public static List<StreamDvrPlan> GetDvrPlanList(ReqGetDvrPlan rgdp, out ResponseStruct rs)
        {
            bool idFound = !string.IsNullOrEmpty(rgdp.DeviceId);
            bool vhostFound = !string.IsNullOrEmpty(rgdp.VhostDomain);
            bool streamFound = !string.IsNullOrEmpty(rgdp.Stream);
            bool appFound = !string.IsNullOrEmpty(rgdp.App);
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };

            lock (Common.LockDbObjForStreamDvrPlan)
            {
                /*联同子类一起查出*/
                return OrmService.Db.Select<StreamDvrPlan>().IncludeMany(a => a.TimeRangeList)
                    .WhereIf(idFound == true, x => x.DeviceId.Trim().ToLower().Equals(rgdp.DeviceId!.Trim().ToLower()))
                    .WhereIf(vhostFound == true,
                        x => x.VhostDomain.Trim().ToLower().Equals(rgdp.VhostDomain!.Trim().ToLower()))
                    .WhereIf(appFound == true, x => x.App.Trim().ToLower().Equals(rgdp.App!.Trim().ToLower()))
                    .WhereIf(streamFound == true, x => x.Stream.Trim().ToLower().Equals(rgdp.Stream!.Trim().ToLower()))
                    .ToList();
                /*联同子类一起查出*/
            }
        }


        /// <summary>
        /// 修改dvrplan
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sdp"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool SetDvrPlanById(int id,ReqStreamDvrPlan sdp, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (SRSApis.Common.SrsManagers == null || SRSApis.Common.SrsManagers.Count == 0)
            {
                rs.Code = ErrorNumber.SrsObjectNotInit;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                
                return false;
            }

            var retSrs = SystemApis.GetSrsManagerInstanceByDeviceId(sdp.DeviceId!);
            if (retSrs == null)
            {
                rs.Code = ErrorNumber.SrsObjectNotInit;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                return false;
            }

            var retVhost = VhostApis.GetVhostByDomain(sdp.DeviceId!, sdp.VhostDomain!, out rs);
            if (retVhost == null)
            {
                rs.Code = ErrorNumber.SrsSubInstanceNotFound;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound];
                return false;
            }

            if (sdp.TimeRangeList != null && sdp.TimeRangeList.Count > 0)
            {
                foreach (var timeRange in sdp.TimeRangeList)
                {
                    if (timeRange.StartTime >= timeRange.EndTime)
                    {
                        rs.Code = ErrorNumber.FunctionInputParamsError;
                        rs.Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError];
                        return false;
                    }

                    if ((timeRange.EndTime - timeRange.StartTime).TotalSeconds <= 120)
                    {
                        rs.Code = ErrorNumber.SrsDvrPlanTimeLimitExcept;
                        rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanTimeLimitExcept];

                        return false;
                    }
                }
            }

            try
            {
                StreamDvrPlan retSelect = null!;
                int retDelete = -1;
                lock (Common.LockDbObjForStreamDvrPlan)
                {
                    retSelect = OrmService.Db.Select<StreamDvrPlan>().Where(x => x.Id==id).First();
                    retDelete = OrmService.Db.Delete<StreamDvrPlan>().Where(x => x.Id==id).ExecuteAffrows();
                }


                if (retDelete > 0)
                {
                    lock (Common.LockDbObjForStreamDvrPlan)
                    {
                       
                            OrmService.Db.Delete<DvrDayTimeRange>()
                                .Where(x => x.StreamDvrPlanId == retSelect.Id).ExecuteAffrows();
                        
                    }
                    
                    var retCreate = CreateDvrPlan(sdp, out rs); //创建新的dvr
                    if (retCreate)
                    {
                        return true;
                    }

                    return false;
                }

                rs.Code = ErrorNumber.SrsDvrPlanNotExists;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanNotExists];
                return false;
            }
            catch (Exception ex)
            {
                rs.Code = ErrorNumber.SystemDataBaseExcept;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SystemDataBaseExcept] + "\r\n" + ex.Message;

                return false;
            }
        }


        /// <summary>
        /// 创建一个录制计划
        /// </summary>
        /// <param name="sdp"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateDvrPlan(ReqStreamDvrPlan sdp, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (SRSApis.Common.SrsManagers == null || SRSApis.Common.SrsManagers.Count == 0)
            {
                rs.Code = ErrorNumber.SrsObjectNotInit;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                return false;
            }

            var retSrs = SystemApis.GetSrsManagerInstanceByDeviceId(sdp.DeviceId!);
            if (retSrs == null)
            {
                rs.Code = ErrorNumber.SrsObjectNotInit;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                return false;
            }

            var retVhost = VhostApis.GetVhostByDomain(sdp.DeviceId!, sdp.VhostDomain!, out rs);
            if (retVhost == null)
            {
                rs.Code = ErrorNumber.SrsSubInstanceNotFound;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound];
                return false;
            }

            if (sdp.TimeRangeList != null && sdp.TimeRangeList.Count > 0)
            {
                foreach (var timeRange in sdp.TimeRangeList)
                {
                    if (timeRange.StartTime >= timeRange.EndTime)
                    {
                        rs.Code = ErrorNumber.FunctionInputParamsError;
                        rs.Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError];
                        return false;
                    }

                    if ((timeRange.EndTime - timeRange.StartTime).TotalSeconds <= 120)
                    {
                        rs.Code = ErrorNumber.SrsDvrPlanTimeLimitExcept;
                        rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanTimeLimitExcept];

                        return false;
                    }
                }
            }

            StreamDvrPlan retSelect = null!;
            lock (Common.LockDbObjForStreamDvrPlan)
            {
                retSelect = OrmService.Db.Select<StreamDvrPlan>().Where(x =>
                    x.DeviceId!.Trim().ToLower().Equals(sdp.DeviceId!.Trim().ToLower())
                    && x.VhostDomain!.Trim().ToLower().Equals(sdp.VhostDomain!.Trim().ToLower())
                    && x.App!.Trim().ToLower().Equals(sdp.App!.Trim().ToLower())
                    && x.Stream!.Trim().ToLower().Equals(sdp.Stream!.Trim().ToLower())).First();
            }

            if (retSelect != null)
            {
                rs.Code = ErrorNumber.SrsDvrPlanAlreadyExists;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanAlreadyExists];

                return false;
            }

            try
            {
                lock (Common.LockDbObjForStreamDvrPlan)
                {
                   StreamDvrPlan tmpStream =new StreamDvrPlan();
                   tmpStream.App = sdp.App;
                   tmpStream.Enable = sdp.Enable;
                   tmpStream.Stream = sdp.Stream;
                   tmpStream.DeviceId = sdp.DeviceId;
                   tmpStream.LimitDays = sdp.LimitDays;
                   tmpStream.LimitSpace = sdp.LimitSpace;
                   tmpStream.VhostDomain = sdp.VhostDomain;
                   tmpStream.OverStepPlan = sdp.OverStepPlan;
                   tmpStream.TimeRangeList=new List<DvrDayTimeRange>();
                   if (sdp.TimeRangeList != null && sdp.TimeRangeList.Count > 0)
                   {
                       foreach (var tmp in sdp.TimeRangeList)
                       {
                           tmpStream.TimeRangeList.Add(new DvrDayTimeRange()
                           {
                               EndTime = tmp.EndTime,
                               StartTime = tmp.StartTime,
                               WeekDay = tmp.WeekDay,
                           });
                       }
                   }
                    /*联同子类一起插入*/
                    var repo = OrmService.Db.GetRepository<StreamDvrPlan>();
                    repo.DbContextOptions.EnableAddOrUpdateNavigateList = true; //需要手工开启
                    var ret = repo.Insert(tmpStream);
                    /*联同子类一起插入*/
                    if (ret != null)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                rs.Code = ErrorNumber.SystemDataBaseExcept;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SystemDataBaseExcept] + "\r\n" + ex.Message;

                return false;
            }
        }
    }
}
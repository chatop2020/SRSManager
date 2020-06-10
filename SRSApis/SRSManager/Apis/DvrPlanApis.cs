using System;
using System.Collections.Generic;
using System.Xml.Schema;
using SrsManageCommon;
using SRSManageCommon.ControllerStructs.RequestModules;
using SRSManageCommon.ControllerStructs.ResponseModules;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;
using Common = SRSApis.Common;

namespace SrsApis.SrsManager.Apis
{
    public static class DvrPlanApis
    {
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
            bool isTimeRangeQuery = (rgdv.StartTime != null && rgdv.EndTime != null);
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

            long total = -1;
            List<DvrVideo> retList = null!;
            if (idFound && vhostFound && streamFound && appFound)
            {
                if (!isPageQuery)
                {
                    if (!isTimeRangeQuery)
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                            x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                            && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())
                            && x.Stream!.Trim().ToLower().Equals(rgdv.Stream!.Trim().ToLower())
                            && x.App!.Trim().ToLower().Equals(rgdv.App!.Trim().ToLower())).ToList();
                    }
                    else
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                            x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                            && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())
                            && x.Stream!.Trim().ToLower().Equals(rgdv.Stream!.Trim().ToLower())
                            && x.App!.Trim().ToLower().Equals(rgdv.App!.Trim().ToLower())
                            && x.StartTime >= rgdv.StartTime && x.EndTime <= rgdv.EndTime).ToList();
                    }
                }
                else
                {
                    if (!isTimeRangeQuery)
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                                x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                                && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())
                                && x.Stream!.Trim().ToLower().Equals(rgdv.Stream!.Trim().ToLower())
                                && x.App!.Trim().ToLower().Equals(rgdv.App!.Trim().ToLower())).Count(out total)
                            .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!).ToList();
                    }
                    else
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                                x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                                && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())
                                && x.Stream!.Trim().ToLower().Equals(rgdv.Stream!.Trim().ToLower())
                                && x.App!.Trim().ToLower().Equals(rgdv.App!.Trim().ToLower())
                                && x.StartTime >= rgdv.StartTime && x.EndTime <= rgdv.EndTime).Count(out total)
                            .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!).ToList();
                    }
                }
            }

            if (idFound && vhostFound && streamFound && !appFound)
            {
                if (!isPageQuery)
                {
                    if (!isTimeRangeQuery)
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                            x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                            && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())
                            && x.Stream!.Trim().ToLower().Equals(rgdv.Stream!.Trim().ToLower())).ToList();
                    }
                    else
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                            x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                            && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())
                            && x.Stream!.Trim().ToLower().Equals(rgdv.Stream!.Trim().ToLower())
                            && x.StartTime >= rgdv.StartTime && x.EndTime <= rgdv.EndTime).ToList();
                    }
                }
                else
                {
                    if (!isTimeRangeQuery)
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                                x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                                && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())
                                && x.Stream!.Trim().ToLower().Equals(rgdv.Stream!.Trim().ToLower()))
                            .Count(out total)
                            .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!).ToList();
                    }
                    else
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                                x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                                && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())
                                && x.Stream!.Trim().ToLower().Equals(rgdv.Stream!.Trim().ToLower())
                                && x.StartTime >= rgdv.StartTime && x.EndTime <= rgdv.EndTime)
                            .Count(out total)
                            .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!).ToList();
                    }
                }
            }

            if (idFound && vhostFound && !streamFound && !appFound)
            {
                if (!isPageQuery)
                {
                    if (!isTimeRangeQuery)
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                            x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                            && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())).ToList();
                    }
                    else
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                            x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                            && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())
                            && x.StartTime >= rgdv.StartTime && x.EndTime <= rgdv.EndTime).ToList();
                    }
                }
                else
                {
                    if (!isTimeRangeQuery)
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                                x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                                && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower()))
                            .Count(out total)
                            .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!).ToList();
                    }
                    else
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                                x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                                && x.Vhost!.Trim().ToLower().Equals(rgdv.VhostDomain!.Trim().ToLower())
                                && x.StartTime >= rgdv.StartTime && x.EndTime <= rgdv.EndTime)
                            .Count(out total)
                            .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!).ToList();
                    }
                }
            }

            if (idFound && !vhostFound && !streamFound && !appFound)
            {
                if (!isPageQuery)
                {
                    if (!isTimeRangeQuery)
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                            x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())).ToList();
                    }
                    else
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                            x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                            && x.StartTime >= rgdv.StartTime && x.EndTime <= rgdv.EndTime).ToList();
                    }
                }
                else
                {
                    if (!isTimeRangeQuery)
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                                x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower()))
                            .Count(out total)
                            .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!).ToList();
                    }
                    else
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where(x =>
                                x.Device_Id!.Trim().ToLower().Equals(rgdv.DeviceId!.Trim().ToLower())
                                && x.StartTime >= rgdv.StartTime && x.EndTime <= rgdv.EndTime)
                            .Count(out total)
                            .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!).ToList();
                    }
                }
            }

            if (!idFound && !vhostFound && !streamFound && !appFound)
            {
                if (!isPageQuery)
                {
                    if (!isTimeRangeQuery)
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where("1=1").ToList();
                    }
                    else
                    {
                        retList = OrmService.Db.Select<DvrVideo>()
                            .Where(x => x.StartTime >= rgdv.StartTime && x.EndTime <= rgdv.EndTime).ToList();
                    }
                }
                else
                {
                    if (!isTimeRangeQuery)
                    {
                        retList = OrmService.Db.Select<DvrVideo>().Where("1=1").Count(out total)
                            .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!).ToList();
                    }
                    else
                    {
                        retList = OrmService.Db.Select<DvrVideo>()
                            .Where(x => x.StartTime >= rgdv.StartTime && x.EndTime <= rgdv.EndTime).Count(out total)
                            .Page((int) rgdv.PageIndex!, (int) rgdv.PageSize!).ToList();
                    }
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
        /*/// <summary>
        /// 返回Dvr列表BydeviceId
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<Dvr> GetDvrList(string deviceId, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (Common.SrsManagers == null || Common.SrsManagers.Count == 0)
            {
                rs.Code = ErrorNumber.SrsObjectNotInit;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                return null!;
            }

            return OrmService.Db.Select<Dvr>()
                .Where(x => x.Device_Id!.Trim().ToLower().Equals(deviceId.Trim().ToLower()))
                .ToList();
        }*/

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

            var retDeleteList = OrmService.Db.Delete<StreamDvrPlan>().Where(x => x.Id == id).ExecuteDeleted();
            if (retDeleteList != null && retDeleteList.Count > 0)
            {
                foreach (var del in retDeleteList)
                {
                    OrmService.Db.Delete<DvrDayTimeRange>().Where(x => x.StreamDvrPlanId == del.Id)
                        .ExecuteAffrows();
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

            var retUpdate = OrmService.Db.Update<StreamDvrPlan>().Set(x => x.Enable, enable)
                .Where(x => x.Id == id)
                .ExecuteAffrows();
            if (retUpdate > 0)
                return true;
            rs.Code = ErrorNumber.SrsDvrPlanNotExists;
            rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanNotExists];
            return false;
        }

        /*/// <summary>
        /// 获取一个录制计划Byid
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static StreamDvrPlan GetDvrPlanById(long id, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (Common.SrsManagers == null || Common.SrsManagers.Count == 0)
            {
                rs.Code = ErrorNumber.SrsObjectNotInit;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                return null!;
            }

            if (id <= 0)
            {
                rs.Code = ErrorNumber.FunctionInputParamsError;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError];
                return null!;
            }

            var retSdp = OrmService.Db.Select<StreamDvrPlan>().Where(
                x => x.Id == id).First();
            if (retSdp == null)
            {
                rs.Code = ErrorNumber.SrsDvrPlanNotExists;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanNotExists];
                return null!;
            }

            var rr = OrmService.Db.Select<DvrDayTimeRange>()
                .Where(x => x.DvrDayTimeRangeStreamDvrPlanId == retSdp.Id).ToList();
            if (rr != null)
            {
                retSdp.TimeRange = rr;
            }

            return retSdp;
        }*/

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
            if (idFound)
            {
                var retSrs = SystemApis.GetSrsManagerInstanceByDeviceId(rgdp.DeviceId!);
                if (retSrs == null)
                {
                    rs.Code = ErrorNumber.SrsObjectNotInit;
                    rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                    return null!;
                }
            }

            if (vhostFound)
            {
                var retVhost = VhostApis.GetVhostByDomain(rgdp.DeviceId!, rgdp.VhostDomain!, out rs);
                if (retVhost == null)
                {
                    rs.Code = ErrorNumber.SrsSubInstanceNotFound;
                    rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound];
                    return null!;
                }
            }

            if (streamFound)
            {
                var onPublishList = FastUsefulApis.GetOnPublishMonitorList(out rs);
                if (onPublishList == null || onPublishList.Count == 0)
                {
                    rs.Code = ErrorNumber.SrsStreamNotExists;
                    rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsStreamNotExists];
                    return null!;
                }

                var retPub = onPublishList.FindLast(x =>
                    x.Device_Id!.Trim().ToLower().Equals(rgdp.DeviceId!.Trim().ToLower()) &&
                    x.Vhost!.Trim().ToLower().Equals(rgdp.VhostDomain!.Trim().ToLower()) &&
                    x.Stream!.Trim().ToLower().Equals(rgdp.Stream!.ToLower().Trim()));
                if (retPub == null)
                {
                    rs.Code = ErrorNumber.SrsStreamNotExists;
                    rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsStreamNotExists];
                    return null!;
                }
            }

            if (idFound && streamFound && vhostFound && appFound)
            {
                /*联同子类一起查出*/
                return OrmService.Db.Select<StreamDvrPlan>().IncludeMany(a => a.TimeRangeList).Where(x =>
                        x.DeviceId.Trim().ToLower().Equals(rgdp.DeviceId!.Trim().ToLower())
                        && x.VhostDomain.Trim().ToLower().Equals(rgdp.VhostDomain!.Trim().ToLower())
                        && x.Stream.Trim().ToLower().Equals(rgdp.Stream!.Trim().ToLower())
                        && x.App.Trim().ToLower().Equals(rgdp.App!.Trim().ToLower()))
                    .ToList();
                /*联同子类一起查出*/
            }

            if (idFound && !streamFound && vhostFound && appFound)
            {
                /*联同子类一起查出*/
                return OrmService.Db.Select<StreamDvrPlan>().IncludeMany(a => a.TimeRangeList).Where(x =>
                        x.DeviceId.Trim().ToLower().Equals(rgdp.DeviceId!.Trim().ToLower())
                        && x.VhostDomain.Trim().ToLower().Equals(rgdp.VhostDomain!.Trim().ToLower())
                        && x.App.Trim().ToLower().Equals(rgdp.App!.Trim().ToLower()))
                    .ToList();
                /*联同子类一起查出*/
            }

            if (idFound && !streamFound && !vhostFound && appFound)
            {
                /*联同子类一起查出*/
                return OrmService.Db.Select<StreamDvrPlan>().IncludeMany(a => a.TimeRangeList).Where(x =>
                        x.DeviceId.Trim().ToLower().Equals(rgdp.DeviceId!.Trim().ToLower())
                        && x.App.Trim().ToLower().Equals(rgdp.App!.Trim().ToLower()))
                    .ToList();
                /*联同子类一起查出*/
            }

            if (!idFound && !streamFound && !vhostFound && appFound)
            {
                /*联同子类一起查出*/
                return OrmService.Db.Select<StreamDvrPlan>().IncludeMany(a => a.TimeRangeList).Where(
                    x => x.App.Trim().ToLower().Equals(rgdp.App!.Trim().ToLower())).ToList();
                /*联同子类一起查出*/
            }

            if (!idFound && !streamFound && !vhostFound && !appFound)
            {
                /*联同子类一起查出*/
                return OrmService.Db.Select<StreamDvrPlan>().IncludeMany(a => a.TimeRangeList).Where("1=1").ToList();
                /*联同子类一起查出*/
            }

            return null!;
        }

        /*/// <summary>
        /// 获取录制计划
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<StreamDvrPlan> GetDvrPlan(ReqGetDvrPlan obj, out ResponseStruct rs)
        {
            bool idFound = !string.IsNullOrEmpty(obj.DeviceId);
            bool vhostFound = !string.IsNullOrEmpty(obj.VhostDomain);
            bool streamFound = !string.IsNullOrEmpty(obj.Stream);
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (Common.SrsManagers == null || Common.SrsManagers.Count == 0)
            {
                rs.Code = ErrorNumber.SrsObjectNotInit;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                return null!;
            }

            if (!string.IsNullOrEmpty(obj.DeviceId))
            {
                var retSrs = SystemApis.GetSrsManagerInstanceByDeviceId(obj.DeviceId);
                if (retSrs == null || retSrs.Srs == null)
                {
                    rs.Code = ErrorNumber.SrsObjectNotInit;
                    rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                    return null!;
                }

                if (!string.IsNullOrEmpty(obj.VhostDomain))
                {
                    if (retSrs.Srs.Vhosts == null || retSrs.Srs.Vhosts.Count == 0)
                    {
                        rs.Code = ErrorNumber.SrsObjectNotInit;
                        rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                        return null!;
                    }

                    var retVhost = VhostApis.GetVhostByDomain(obj.DeviceId, obj.VhostDomain, out rs);
                    if (retVhost == null)
                    {
                        return null!;
                    }

                    if (!string.IsNullOrEmpty(obj.Stream))
                    {
                        var onPublishList = FastUsefulApis.GetOnPublishMonitorList(out rs);
                        if (onPublishList == null || onPublishList.Count == 0)
                        {
                            rs.Code = ErrorNumber.SrsStreamNotExists;
                            rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsStreamNotExists];
                            return null!;
                        }
                    }
                }
            }

            List<StreamDvrPlan> tmpList;
            if (idFound && !vhostFound && !streamFound)
            {
                tmpList = OrmService.Db.Select<StreamDvrPlan>().Where(
                    x => x.DeviceId!.Trim().ToLower().Equals(obj.DeviceId!.Trim().ToLower())).ToList();
            }
            else if (idFound && vhostFound && !streamFound)
            {
                tmpList = OrmService.Db.Select<StreamDvrPlan>().Where(
                    x => x.DeviceId!.Trim().ToLower().Equals(obj.DeviceId!.Trim().ToLower())
                         && x.VhostDomain!.Trim().ToLower().Equals(obj.VhostDomain!.Trim().ToLower())).ToList();
            }
            else if (idFound && vhostFound && streamFound)
            {
                tmpList = OrmService.Db.Select<StreamDvrPlan>().Where(
                    x => x.DeviceId!.Trim().ToLower().Equals(obj.DeviceId!.Trim().ToLower())
                         && x.VhostDomain!.Trim().ToLower().Equals(obj.VhostDomain!.Trim().ToLower())
                         && x.Stream!.Trim().ToLower().Equals(obj.Stream!.Trim().ToLower())).ToList();
            }
            else
            {
                tmpList = OrmService.Db.Select<StreamDvrPlan>().Where("1=1").ToList();
            }

            if (tmpList != null)
            {
                foreach (var r in tmpList)
                {
                    if (r != null)
                    {
                        var rr = OrmService.Db.Select<DvrDayTimeRange>()
                            .Where(x => x.DvrDayTimeRangeStreamDvrPlanId == r.Id).ToList();
                        if (rr != null)
                        {
                            r.TimeRange = rr;
                        }
                    }
                }

                return tmpList;
            }

            return null!;
        }*/


        /// <summary>
        /// 修改dvrplan
        /// </summary>
        /// <param name="sdp"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool SetDvrPlan(StreamDvrPlan sdp, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (Common.SrsManagers == null || Common.SrsManagers.Count == 0)
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
                var retDelete = OrmService.Db.Delete<StreamDvrPlan>().Where(x =>
                    x.DeviceId!.Trim().ToLower().Equals(sdp.DeviceId!.Trim().ToLower())
                    && x.VhostDomain!.Trim().ToLower().Equals(sdp.VhostDomain!.Trim().ToLower())
                    && x.App!.Trim().ToLower().Equals(sdp.App!.Trim().ToLower())
                    && x.Stream!.Trim().ToLower().Equals(sdp.Stream!.Trim().ToLower())).ExecuteDeleted();
                if (retDelete != null && retDelete.Count > 0)
                {
                    foreach (var del in retDelete) //删除子类数据
                    {
                        OrmService.Db.Delete<DvrDayTimeRange>()
                            .Where(x => x.StreamDvrPlanId == del.Id).ExecuteAffrows();
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

        /*/// <summary>
        /// 修改一个录制计划ByID
        /// </summary>
        /// <param name="sdp"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool SetDvrPlanById(StreamDvrPlan sdp, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (Common.SrsManagers == null || Common.SrsManagers.Count == 0)
            {
                rs.Code = ErrorNumber.SrsObjectNotInit;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                return false;
            }

            if (sdp.Id <= 0)
            {
                rs.Code = ErrorNumber.FunctionInputParamsError;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError];
                return false;
            }

            if (sdp.TimeRange != null)
            {
                foreach (var s in sdp.TimeRange)
                {
                    if (s.StartTime >= s.EndTime)
                    {
                        rs.Code = ErrorNumber.FunctionInputParamsError;
                        rs.Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError];
                        return false;
                    }

                    if ((s.EndTime - s.StartTime).TotalSeconds <= 120)
                    {
                        rs.Code = ErrorNumber.SrsDvrPlanTimeLimitExcept;
                        rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanTimeLimitExcept];

                        return false;
                    }
                }
            }

            var retSdp = OrmService.Db.Select<StreamDvrPlan>()
                .Where(x => x.Id == sdp.Id)
                .First();
            if (retSdp != null)
            {
                var retUpdate = OrmService.Db.Update<StreamDvrPlan>(sdp).Set(x => x.LimitDays, sdp.LimitDays)
                    .Set(x => x.LimitSpace != sdp.LimitSpace).Set(x => x.OverStepPlan != sdp.OverStepPlan)
                    .Set(x => x.Enable != sdp.Enable).Where(x => x.Id == retSdp.Id).ExecuteAffrows();
                if (retUpdate > 0)
                {
                    if (sdp.TimeRange != null)
                    {
                        var retDelete = OrmService.Db.Delete<DvrDayTimeRange>()
                            .Where(x => x.DvrDayTimeRangeStreamDvrPlanId == retSdp.Id)
                            .ExecuteAffrows();
                        for (int i = 0; i <= sdp.TimeRange!.Count - 1; i++)
                        {
                            sdp.TimeRange[i].DvrDayTimeRangeStreamDvrPlanId = retSdp.Id;
                        }

                        var retInsert = OrmService.Db.Insert<List<DvrDayTimeRange>>(sdp.TimeRange)
                            .ExecuteAffrows();
                        if (retInsert > 0)
                            return true;
                    }
                    else
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }

            rs.Code = ErrorNumber.SrsDvrPlanNotExists;
            rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanNotExists];

            return false;
        }*/

        /// <summary>
        /// 创建一个录制计划
        /// </summary>
        /// <param name="sdp"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateDvrPlan(StreamDvrPlan sdp, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (Common.SrsManagers == null || Common.SrsManagers.Count == 0)
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

            var retSelect = OrmService.Db.Select<StreamDvrPlan>().Where(x =>
                x.DeviceId!.Trim().ToLower().Equals(sdp.DeviceId!.Trim().ToLower())
                && x.VhostDomain!.Trim().ToLower().Equals(sdp.VhostDomain!.Trim().ToLower())
                && x.App!.Trim().ToLower().Equals(sdp.App!.Trim().ToLower())
                && x.Stream!.Trim().ToLower().Equals(sdp.Stream!.Trim().ToLower())).First();
            if (retSelect != null)
            {
                rs.Code = ErrorNumber.SrsDvrPlanAlreadyExists;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanAlreadyExists];

                return false;
            }

            try
            {
                /*联同子类一起插入*/
                var repo = OrmService.Db.GetRepository<StreamDvrPlan>();
                repo.DbContextOptions.EnableAddOrUpdateNavigateList = true; //需要手工开启
                var ret = repo.Insert(sdp);
                /*联同子类一起插入*/
                if (ret != null)
                {
                    return true;
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

        /*/// <summary>
        /// 修改或新建一个录制计划
        /// </summary>
        /// <param name="sdp"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool SetDvrPlan(StreamDvrPlan sdp, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (Common.SrsManagers == null || Common.SrsManagers.Count == 0)
            {
                rs.Code = ErrorNumber.SrsObjectNotInit;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                return false;
            }

            var ret = Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToLower().Equals(sdp.DeviceId!.Trim().ToLower()));
            if (ret == null)
            {
                rs.Code = ErrorNumber.SrsObjectNotInit;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit];
                return false;
            }

            if (ret.Srs.Vhosts == null || ret.Srs.Vhosts.Count == 0)
            {
                rs.Code = ErrorNumber.SrsSubInstanceNotFound;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound];
                return false;
            }

            if (sdp.TimeRange != null)
            {
                foreach (var s in sdp.TimeRange)
                {
                    if (s.StartTime >= s.EndTime)
                    {
                        rs.Code = ErrorNumber.FunctionInputParamsError;
                        rs.Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError];
                        return false;
                    }

                    if ((s.EndTime - s.StartTime).TotalSeconds <= 120)
                    {
                        rs.Code = ErrorNumber.SrsDvrPlanTimeLimitExcept;
                        rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsDvrPlanTimeLimitExcept];

                        return false;
                    }
                }
            }

            var retVhost =
                ret.Srs.Vhosts.FindLast(x => x.VhostDomain!.Trim().ToLower().Equals(sdp.VhostDomain!.Trim().ToLower()));
            if (retVhost == null)
            {
                rs.Code = ErrorNumber.SrsSubInstanceNotFound;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound];
                return false;
            }

            var retSdp = OrmService.Db.Select<StreamDvrPlan>()
                .Where(x => x.Stream == sdp.Stream && x.App == sdp.App && x.DeviceId == sdp.DeviceId &&
                            x.VhostDomain == sdp.VhostDomain)
                .First();
            if (retSdp != null)
            {
                var retUpdate = OrmService.Db.Update<StreamDvrPlan>(sdp).Set(x => x.LimitDays, sdp.LimitDays)
                    .Set(x => x.LimitSpace != sdp.LimitSpace).Set(x => x.OverStepPlan != sdp.OverStepPlan)
                    .Set(x => x.Enable != sdp.Enable).Where(x => x.Id == retSdp.Id).ExecuteAffrows();
                if (retUpdate > 0)
                {
                    if (sdp.TimeRange != null)
                    {
                        var retDelete = OrmService.Db.Delete<DvrDayTimeRange>()
                            .Where(x => x.DvrDayTimeRangeStreamDvrPlanId == retSdp.Id)
                            .ExecuteAffrows();
                        for (int i = 0; i <= sdp.TimeRange!.Count - 1; i++)
                        {
                            sdp.TimeRange[i].DvrDayTimeRangeStreamDvrPlanId = retSdp.Id;
                        }

                        var retInsert = OrmService.Db.Insert<List<DvrDayTimeRange>>(sdp.TimeRange)
                            .ExecuteAffrows();
                        if (retInsert > 0)
                            return true;
                    }
                    else
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }

            var repo = OrmService.Db.GetRepository<StreamDvrPlan>();
            repo.Insert(sdp);
            repo.SaveMany(sdp, "DvrDayTimeRange");
            return true;
        }*/
    }
}
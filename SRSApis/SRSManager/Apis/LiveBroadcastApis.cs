using System;
using System.Collections.Generic;
using SrsManageCommon;
using SrsManageCommon.ControllerStructs;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;

namespace SrsApis.SrsManager.Apis
{
    public static class LiveBroadcastApis
    {
        /// <summary>
        /// 是否为直播通道的连接
        /// </summary>
        /// <param name="onlineClient"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static LiveBroadcastPlan CheckIsLiveCh(OnlineClient onlineClient, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            lock (Common.LockDbObjForLivePlan)
            {
                try
                {
                    return OrmService.Db.Select<LiveBroadcastPlan>()
                        .Where(x => x.DeviceId!.Trim().ToLower().Equals(onlineClient.Device_Id!.Trim().ToLower())
                                    && x.App!.Trim().ToLower().Equals(onlineClient.App!.Trim().ToLower())
                                    && x.Vhost!.Trim().ToLower().Equals(onlineClient.Vhost!.Trim().ToLower())
                                    && x.Stream!.Trim().ToLower().Equals(onlineClient.Stream!.Trim().ToLower()))
                        .First();
                }
                catch
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SystemDataBaseExcept,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SystemDataBaseExcept],
                    };
                    return null!;
                }
            }
        }

        /// <summary>
        /// 检查是否为直播计划内的连接
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CheckLivePlan(LiveBroadcastPlan plan, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (plan != null)
            {
                if (plan.StartTime <= DateTime.Now && plan.EndTime >= DateTime.Now) //时间不在范围内也要踢掉
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 删除一个录制计划ById
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteLivePlanById(long id, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            try
            {
                lock (Common.LockDbObjForLivePlan)
                {
                    var ret = OrmService.Db.Delete<LiveBroadcastPlan>().Where(x => x.Id == id).ExecuteAffrows();
                    if (ret > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SystemDataBaseExcept,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SystemDataBaseExcept],
                };
                return false;
            }
        }

        /// <summary>
        /// 获取直播计划
        /// </summary>
        /// <param name="req"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<LiveBroadcastPlan> GetLivePlanList(LiveBroadcastPlan req, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            try
            {
                lock (Common.LockDbObjForLivePlan)
                {
                    return OrmService.Db.Select<LiveBroadcastPlan>()
                        .WhereIf(!string.IsNullOrEmpty(req.App), x => x.App!.Equals(req.App))
                        .WhereIf(!string.IsNullOrEmpty(req.Stream), x => x.Stream!.Equals(req.Stream))
                        .WhereIf(!string.IsNullOrEmpty(req.Vhost), x => x.Vhost!.Equals(req.Vhost))
                        .WhereIf(!string.IsNullOrEmpty(req.DeviceId), x => x.DeviceId!.Equals(req.DeviceId))
                        .WhereIf(!string.IsNullOrEmpty(req.PublishIpAddr),
                            x => x.PublishIpAddr!.Equals(req.PublishIpAddr))
                        .WhereIf(req.Enable != null, x => x.Enable == req.Enable)
                        .WhereIf(req.PlanStatus != null, x => x.PlanStatus == req.PlanStatus)
                        .WhereIf(req.StartTime != null, x => x.StartTime >= req.StartTime)
                        .WhereIf(req.EndTime != null, x => x.EndTime <= req.EndTime)
                        .ToList();
                }
            }
            catch
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SystemDataBaseExcept,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SystemDataBaseExcept],
                };
                return null!;
            }
        }


        /// <summary>
        /// 设置或创建一个直播计划
        /// </summary>
        /// <param name="rlbp"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool SetLivePlan(ReqLiveBroadcastPlan rlbp, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (rlbp.StartTime >= rlbp.EndTime || rlbp.StartTime >= DateTime.Now)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            try
            {
                lock (Common.LockDbObjForLivePlan)
                {
                    var ret = OrmService.Db.Update<LiveBroadcastPlan>()
                        .Set(x => x.Enable, rlbp.Enable)
                        .Set(x => x.App, rlbp.App)
                        .Set(x => x.Stream, rlbp.Stream)
                        .Set(x => x.Vhost, rlbp.Vhost)
                        .Set(x => x.DeviceId, rlbp.DeviceId)
                        .Set(x => x.EndTime, rlbp.EndTime)
                        .Set(x => x.StartTime, rlbp.StartTime)
                        .Set(x => x.UpdateTime, DateTime.Now)
                        .Where(x => x.Id == rlbp.Id).ExecuteAffrows();
                    if (ret > 0)
                    {
                        var retVhost = VhostApis.GetVhostByDomain(rlbp.DeviceId!, rlbp.Vhost!, out rs);
                        bool retAddVhost = false;
                        if (retVhost == null)
                        {
                            var retVhostTemp = VhostApis.GetVhostTemplate(VhostIngestInputType.WebCast, out rs);
                            retVhostTemp.Vdvr!.Dvr_path = Common.WorkPath + rlbp.DeviceId +
                                                          "/wwwroot/dvr/[2006][01][02]/[vhost]/[app]/[stream]/[15]/[2006][01][02][15][04][05].mp4";
                            retVhostTemp.VhostDomain = "webcast";
                            retVhostTemp.Enabled = true;
                            retAddVhost = VhostApis.SetVhost(rlbp.DeviceId!, retVhostTemp, out rs);
                        }
                        else
                        {
                            retAddVhost = true;
                        }

                        if (retAddVhost)
                        {
                            return true;
                        }

                        OrmService.Db.Delete<LiveBroadcastPlan>().Where(x =>
                            x.DeviceId!.Trim().ToLower().Equals(rlbp.DeviceId!.Trim().ToLower())
                            && x.App!.Trim().ToLower().Equals(rlbp.App!.Trim().ToLower())
                            && x.Vhost!.Trim().ToLower().Equals(rlbp.Vhost!.Trim().ToLower())
                            && x.Stream!.Trim().ToLower().Equals(rlbp.Stream!.Trim().ToLower())).ExecuteAffrows();
                        return false;
                    }

                    rlbp.UpdateTime = DateTime.Now;
                    rlbp.PlanStatus = LiveBroadcastPlanStatus.WaitForExec;
                    ret = OrmService.Db.Insert<LiveBroadcastPlan>(rlbp).ExecuteAffrows();
                    if (ret > 0)
                    {
                        var retVhost = VhostApis.GetVhostByDomain(rlbp.DeviceId!, rlbp.Vhost!, out rs);
                        bool retAddVhost = false;
                        if (retVhost == null)
                        {
                            var retVhostTemp = VhostApis.GetVhostTemplate(VhostIngestInputType.WebCast, out rs);
                            retVhostTemp.Vdvr!.Dvr_path = Common.WorkPath + rlbp.DeviceId +
                                                          "/wwwroot/dvr/[2006][01][02]/[vhost]/[app]/[stream]/[15]/[2006][01][02][15][04][05].mp4";
                            retVhostTemp.VhostDomain = "webcast";
                            retVhostTemp.Enabled = true;
                            retAddVhost = VhostApis.SetVhost(rlbp.DeviceId!, retVhostTemp, out rs);
                        }
                        else
                        {
                            retAddVhost = true;
                        }

                        if (retAddVhost)
                        {
                            return true;
                        }

                        OrmService.Db.Delete<LiveBroadcastPlan>().Where(x =>
                            x.DeviceId!.Trim().ToLower().Equals(rlbp.DeviceId!.Trim().ToLower())
                            && x.App!.Trim().ToLower().Equals(rlbp.App!.Trim().ToLower())
                            && x.Vhost!.Trim().ToLower().Equals(rlbp.Vhost!.Trim().ToLower())
                            && x.Stream!.Trim().ToLower().Equals(rlbp.Stream!.Trim().ToLower())).ExecuteAffrows();

                        return false;
                    }
                }
            }
            catch
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SystemDataBaseExcept,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SystemDataBaseExcept],
                };
                return false;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.Other,
                Message = ErrorMessage.ErrorDic![ErrorNumber.Other],
            };
            return false;
        }
    }
}
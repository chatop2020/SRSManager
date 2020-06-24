using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager.Apis;
using SrsManageCommon;
using SrsManageCommon.ControllerStructs;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// 直播计划接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class LiveBroadcastController : ControllerBase
    {
        /// <summary>
        /// 检查推流直播连接是否在计划内
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Live/CheckIsLivePlan")]
        public JsonResult CheckIsLivePlan(LiveBroadcastPlan plan )
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {plan});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = LiveBroadcastApis.CheckLivePlan(plan, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        
        /// <summary>
        /// 检查客户端连接是否是直播流
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Live/CheckLiveCh")]
        public JsonResult CheckLiveCh(OnlineClient client )
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {client});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = LiveBroadcastApis.CheckIsLiveCh(client, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 删除直播计划byId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/Live/DeleteLivePlanById")]
        public JsonResult DeleteLivePlanById(long id )
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {id});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = LiveBroadcastApis.DeleteLivePlanById(id, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
          
        /// <summary>
        /// 获取直播计划列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Live/GetLivePlanList")]
        public JsonResult GetLivePlanList(ReqLiveBroadcastPlan rlbp )
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {rlbp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = LiveBroadcastApis.GetLivePlanList(rlbp, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 创建或修改一个直播计划
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/Live/SetLivePlan")]
        public JsonResult SetLivePlan(ReqLiveBroadcastPlan rlbp )
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {rlbp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = LiveBroadcastApis.SetLivePlan(rlbp, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
    }
}
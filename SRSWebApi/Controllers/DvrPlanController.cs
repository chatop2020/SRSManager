using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager.Apis;
using SrsManageCommon;
using SRSManageCommon.ControllerStructs.RequestModules;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// 授权访问接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class DvrPlanController: ControllerBase
    {
            /// <summary>
        /// 获取录像文件ByDeviceId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/GetDvrVideoList")]
        public JsonResult GetDvrVideoList(ReqGetDvrVideo rgdv)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{rgdv});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = DvrPlanApis.GetDvrVideoList(rgdv,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 删除一个录制计划ById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/DeleteDvrPlanById")]
        public JsonResult DeleteDvrPlanById(long id)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{id});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = DvrPlanApis.DeleteDvrPlanById(id,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 启用或停用一个录制计划
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/OnOrOffDvrPlanById")]
        public JsonResult OnOrOffDvrPlanById(long id,bool enable)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{id,enable});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = DvrPlanApis.OnOrOffDvrPlanById(id,enable,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        
        /*/// <summary>
        /// 修改录制计划ById
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/SetDvrPlanById")]
        public JsonResult SetDvrPlanById(StreamDvrPlan sdp)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{sdp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = DvrPlanApis.SetDvrPlanById(sdp,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }*/
        /// <summary>
        /// 修改录制计划
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/SetDvrPlan")]
        public JsonResult SetDvrPlan(StreamDvrPlan sdp)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{sdp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = DvrPlanApis.SetDvrPlan(sdp,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 创建录制计划
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/CreateDvrPlan")]
        public JsonResult CreateDvrPlan(StreamDvrPlan sdp)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{sdp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = DvrPlanApis.CreateDvrPlan(sdp,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /*
        /// <summary>
        /// 获取录制计划ById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/GetDvrPlanById")]
        public JsonResult GetDvrPlanById(long id)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{id});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = DvrPlanApis.GetDvrPlanById(id,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        */
        
        /// <summary>
        /// 获取录制计划
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/GetDvrPlan")]
        public JsonResult GetDvrPlanList(ReqGetDvrPlan rdp)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[]{rdp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }
            var rt = DvrPlanApis.GetDvrPlanList(rdp,out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
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
    public class DvrPlanController : ControllerBase
    {
    
        /// <summary>
        /// 裁剪合并视频文件,callbackurl为空且时间间隔不超过10分钟将同步返回，否则完成后异步回调callbackurl地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/CutOrMergeVideoFile")]
        public JsonResult CutOrMergeVideoFile(ReqCutOrMergeVideoFile rcmv)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {rcmv});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = DvrPlanApis.CutOrMergeVideoFile(rcmv, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
        
        /// <summary>
        /// 恢复被软删除的录像文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/UndoSoftDelete")]
        public JsonResult UndoSoftDelete(long dvrVideoId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {dvrVideoId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = DvrPlanApis.UndoSoftDelete(dvrVideoId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 删除一个录像文件ById（硬删除，立即删除文件，数据库做delete标记）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/HardDeleteDvrVideoById")]
        public JsonResult HardDeleteDvrVideoById(long dvrVideoId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {dvrVideoId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = DvrPlanApis.HardDeleteDvrVideoById(dvrVideoId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 删除一个录像文件ById（软删除，只做标记，不删除文件，文件在24小时后删除）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/SoftDeleteDvrVideoById")]
        public JsonResult SoftDeleteDvrVideoById(long dvrVideoId)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {dvrVideoId});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = DvrPlanApis.SoftDeleteDvrVideoById(dvrVideoId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取录像文件(条件灵活)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/GetDvrVideoList")]
        public JsonResult GetDvrVideoList(ReqGetDvrVideo rgdv)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {rgdv});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = DvrPlanApis.GetDvrVideoList(rgdv, out ResponseStruct rs);
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
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {id});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = DvrPlanApis.DeleteDvrPlanById(id, out ResponseStruct rs);
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
        public JsonResult OnOrOffDvrPlanById(long id, bool enable)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {id, enable});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = DvrPlanApis.OnOrOffDvrPlanById(id, enable, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }


       

        /// <summary>
        /// 个性录制计划ById
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sdp"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/DvrPlan/SetDvrPlanById")]
        public JsonResult SetDvrPlanById(int id,ReqStreamDvrPlan sdp)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {id,sdp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = DvrPlanApis.SetDvrPlanById(id,sdp, out ResponseStruct rs);
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
        public JsonResult CreateDvrPlan(ReqStreamDvrPlan sdp)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {sdp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = DvrPlanApis.CreateDvrPlan(sdp, out ResponseStruct rs);
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
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {rdp});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            var rt = DvrPlanApis.GetDvrPlanList(rdp, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using SrsApis.SrsManager;
using SrsApis.SrsManager.Apis;
using SrsApis.SrsManager.Apis.ApiModules;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;
using SrsWebApi.Attributes;
using SrsWebApi.RequestModules;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// 全局SRS接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class GlobalSrsController : ControllerBase
    {
        /// <summary>
        /// srs是否正在运行
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/IsRunning")]
        public JsonResult IsRunning(string deviceId)
        {
            var rt = GlobalSrsApis.IsRunning(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// srs是否完成初始化
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/IsInit")]
        public JsonResult IsInit(string deviceId)
        {
            var rt = GlobalSrsApis.IsInit(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 启动srs
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/StartSrs")]
        public JsonResult StartSrs(string deviceId)
        {
            var rt = GlobalSrsApis.StartSrs(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 停止srs
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/StopSrs")]
        public JsonResult StopSrs(string deviceId)
        {
            var rt = GlobalSrsApis.StopSrs(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 重启srs
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/RestartSrs")]
        public JsonResult RestartSrs(string deviceId)
        {
            var rt = GlobalSrsApis.RestartSrs(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 重新加载srs配置（srs.reload）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/ReloadSrs")]
        public JsonResult ReloadtSrs(string deviceId)
        {
            var rt = GlobalSrsApis.ReloadSrs(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改全局参数Chunksize
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/GlobalChangeChunksize")]
        public JsonResult GlobalChangeChunksize(string deviceId, ushort chunkSize)
        {
            var rt = GlobalSrsApis.GlobalChangeChunksize(deviceId, chunkSize, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改全局参数HttpApiListen
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/GlobalChangeHttpApiListen")]
        public JsonResult GlobalChangeHttpApiListen(string deviceId, ushort port)
        {
            var rt = GlobalSrsApis.GlobalChangeHttpApipListen(deviceId, port, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改全局参数HttpApiEnable
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/GlobalChangeHttpApiEnable")]
        public JsonResult GlobalChangeHttpApiEnable(string deviceId, bool enable)
        {
            var rt = GlobalSrsApis.GlobalChangeHttpApiEnable(deviceId, enable, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改全局参数Maxconnections
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/GlobalChangeMaxConnections")]
        public JsonResult GlobalChangeMaxConnections(string deviceId, ushort max)
        {
            var rt = GlobalSrsApis.GlobalChangeMaxConnections(deviceId, max, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改全局参数rtmp listen
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/GlobalChangeRtmpListen")]
        public JsonResult GlobalChangeRtmpListen(string deviceId, ushort port)
        {
            var rt = GlobalSrsApis.GlobalChangeRtmpListen(deviceId, port, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改全局参数Httpserver listen
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/GlobalChangeHttpServerListen")]
        public JsonResult GlobalChangeHttpServerListen(string deviceId, ushort port)
        {
            var rt = GlobalSrsApis.GlobalChangeHttpServerListen(deviceId, port, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改全局参数HttpserverPath
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/GlobalChangeHttpServerPath")]
        public JsonResult GlobalChangeHttpServerPath(string deviceId, string path)
        {
            var rt = GlobalSrsApis.GlobalChangeHttpServerPath(deviceId, path, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改全局参数Httpserver enable
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/GlobalChangeHttpServerEnable")]
        public JsonResult GlobalChangeHttpServerEnable(string deviceId, bool enable)
        {
            var rt = GlobalSrsApis.GlobalChangeHttpServerEnable(deviceId, enable, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 获取srs实例的全局参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/GetGlobalParams")]
        public JsonResult GetGlobalParams(string deviceId)
        {
            var rt = GlobalSrsApis.GetGlobalParams(deviceId, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }

        /// <summary>
        /// 修改srs实例的全局参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthVerify]
        [Log]
        [Route("/GlobalSrs/ChangeGlobalParams")]
        public JsonResult ChangeGlobalParams(ReqChangeSrsGlobalParams req)
        {
            var rt = GlobalSrsApis.ChangeGlobalParams(req.DeviceId, req.Gm, out ResponseStruct rs);
            return Program.CommonFunctions.DelApisResult(rt, rs);
        }
    }
}
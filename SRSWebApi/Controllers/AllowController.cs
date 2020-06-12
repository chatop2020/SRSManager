using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SrsManageCommon;
using SRSManageCommon.ControllerStructs.RequestModules;
using SRSManageCommon.ControllerStructs.ResponseModules;
using SRSManageCommon.ManageStructs;
using SrsWebApi.Attributes;

namespace SrsWebApi.Controllers
{
    /// <summary>
    /// 授权访问接口类
    /// </summary>
    [ApiController]
    [Route("")]
    public class AllowController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 注入httpcontext
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public AllowController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 刷新Session
        /// </summary>
        /// <param name="request">旧的session</param>
        /// <returns></returns>
        [HttpPost]
        [Log]
        [Route("/Allow/RefreshSession")]
        public JsonResult RefreshSession([FromBody] Session request)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {request});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            string remoteIpaddr = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            if (Program.CommonFunctions.CheckAllow(remoteIpaddr, request.AllowKey))
            {
                if (request.Expires >= Program.CommonFunctions.GetTimeStampMilliseconds() ||
                    Math.Abs(request.Expires - Program.CommonFunctions.GetTimeStampMilliseconds()) <
                    (1000 * 60)) //1分钟内要过期的就刷新
                {
                    Session session = Program.CommonFunctions.SessionManager.RefreshSession(request);
                    if (session != null)
                    {
                        var result = new JsonResult(session);
                        result.StatusCode = (int) HttpStatusCode.OK;
                        return result;
                    }
                    else
                    {
                        ResponseStruct rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.SystemSessionExcept,
                            Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemSessionExcept]!,
                        };
                        var result = new JsonResult(rs);
                        result.StatusCode = (int) HttpStatusCode.OK;
                        return result;
                    }
                }
                else
                {
                    ResponseStruct rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SystemSessionItWorks,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemSessionItWorks]!,
                    };
                    var result = new JsonResult(rs);
                    result.StatusCode = (int) HttpStatusCode.OK;
                    return result;
                }
            }
            else
            {
                ResponseStruct rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckAllowKeyFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckAllowKeyFail]!,
                };
                var result = new JsonResult(rs);
                result.StatusCode = (int) HttpStatusCode.MethodNotAllowed;
                return result;
            }
        }

        /// <summary>
        /// 获取一个session用于通讯
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Log]
        [Route("/Allow/GetSession")]
        public JsonResult GetSession([FromBody] ReqGetSession request)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {request});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            string remoteIpaddr = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            string allowKey = request.AllowKey;
            if (Program.CommonFunctions.CheckAllow(remoteIpaddr, allowKey))
            {
                Session session = Program.CommonFunctions.SessionManager.NewSession(allowKey);
                var result = new JsonResult(session);
                result.StatusCode = (int) HttpStatusCode.OK;
                return result;
            }
            else
            {
                ResponseStruct rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckAllowKeyFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckAllowKeyFail]!,
                };
                var result = new JsonResult(rs);
                result.StatusCode = (int) HttpStatusCode.MethodNotAllowed;
                return result;
            }
        }

        /// <summary>
        /// 修改设置一个allow
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Log]
        [Route("/Allow/SetAllowByKey")]
        public JsonResult SetAllowByKey([FromBody] ReqSetOrAddAllow request)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {request});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            if (Program.CommonFunctions.CheckPassword(request.Password))
            {
                bool found = false;
                for (int i = 0; i <= Common.SystemConfig.AllowKeys.Count - 1; i++)
                {
                    if (Common.SystemConfig.AllowKeys[i].Key.Trim().ToLower()
                        .Equals(request.Allowkey.Key.Trim().ToLower()))
                    {
                        Common.SystemConfig.AllowKeys[i] = request.Allowkey;
                        if (Common.SystemConfig.RebuidConfig(Program.CommonFunctions.ConfPath))
                        {
                            found = true;
                        }

                        break;
                    }
                }

                if (found)
                {
                    ResponseStruct rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.None]!,
                    };
                    var result = new JsonResult(rs);
                    result.StatusCode = (int) HttpStatusCode.OK;
                    return result;
                }
                else
                {
                    ResponseStruct rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.SrsSubInstanceNotFound]!,
                    };
                    var result = new JsonResult(rs);
                    result.StatusCode = (int) HttpStatusCode.BadRequest;
                    return result;
                }
            }
            else
            {
                ResponseStruct rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckPasswordFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail]!,
                };

                var result = new JsonResult(rs);
                result.StatusCode = (int) HttpStatusCode.Unauthorized;
                return result;
            }
        }


        /// <summary>
        /// 删除一条allow
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Log]
        [Route("/Allow/DelAllowByKey")]
        public JsonResult DelAllowByKey([FromBody] ReqDelAllow request)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {request});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            if (Program.CommonFunctions.CheckPassword(request.Password))
            {
                bool found = false;
                for (int i = 0; i <= Common.SystemConfig.AllowKeys.Count - 1; i++)
                {
                    if (Common.SystemConfig.AllowKeys[i].Key.Trim().ToLower()
                        .Equals(request.Key.Trim().ToLower()))
                    {
                        Common.SystemConfig.AllowKeys[i] = null!;
                        if (Common.SystemConfig.RebuidConfig(Program.CommonFunctions.ConfPath))
                        {
                            found = true;
                        }

                        break;
                    }
                }

                if (found)
                {
                    SRSApis.Common.RemoveNull(Common.SystemConfig.AllowKeys);
                    ResponseStruct rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.None]!,
                    };

                    var result = new JsonResult(rs);
                    result.StatusCode = (int) HttpStatusCode.OK;
                    return result;
                }
                else
                {
                    ResponseStruct rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.SrsSubInstanceNotFound]!,
                    };

                    var result = new JsonResult(rs);
                    result.StatusCode = (int) HttpStatusCode.BadRequest;
                    return result;
                }
            }
            else
            {
                ResponseStruct rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckPasswordFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail]!,
                };

                var result = new JsonResult(rs);
                result.StatusCode = (int) HttpStatusCode.Unauthorized;
                return result;
            }
        }

        /// <summary>
        /// 添加一个allow
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Log]
        [Route("Allow/AddAllow")]
        public JsonResult AddAllow([FromBody] ReqSetOrAddAllow request)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {request});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            JsonResult result;
            if (Program.CommonFunctions.CheckPassword(request.Password))
            {
                var obj = Common.SystemConfig.AllowKeys.FindLast(x =>
                    x.Key.Trim().ToLower().Equals(request.Allowkey.Key.Trim().ToLower()));

                if (obj != null)
                {
                    ResponseStruct rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceAlreadyExists,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.SrsSubInstanceAlreadyExists]!,
                    };
                    result = new JsonResult(rs);
                    result.StatusCode = (int) HttpStatusCode.BadRequest;
                    return result;
                }

                if (string.IsNullOrEmpty(request.Allowkey.Key.Trim()) ||
                    !Common.IsUuidByError(request.Allowkey.Key))
                {
                    ResponseStruct rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.FunctionInputParamsError,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.FunctionInputParamsError]!,
                    };
                    result = new JsonResult(rs);
                    result.StatusCode = (int) HttpStatusCode.BadRequest;
                    return result;
                }

                Common.SystemConfig.AllowKeys.Add(request.Allowkey);
                if (Common.SystemConfig.RebuidConfig(Program.CommonFunctions.ConfPath))
                {
                    ResponseStruct rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.None]!,
                    };
                    result = new JsonResult(rs);
                    result.StatusCode = (int) HttpStatusCode.OK;
                    return result;
                }
                else
                {
                    ResponseStruct rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.Other,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.Other]!,
                    };
                    result = new JsonResult(rs);
                    result.StatusCode = (int) HttpStatusCode.BadRequest;
                    return result;
                }
            }
            else
            {
                ResponseStruct rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckPasswordFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail]!,
                };
                result = new JsonResult(rs);
                result.StatusCode = (int) HttpStatusCode.Unauthorized;
                return result;
            }
        }


        /// <summary>
        /// 获取授权列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Log]
        [Route("Allow/GetAllows")]
        public JsonResult GetAllows([FromBody] ReqGetAllows request)
        {
            ResponseStruct rss = CommonFunctions.CheckParams(new object[] {request});
            if (rss.Code != ErrorNumber.None)
            {
                return Program.CommonFunctions.DelApisResult(null!, rss);
            }

            if (Program.CommonFunctions.CheckPassword(request.Password))
            {
                AllowListModule result = new AllowListModule()
                {
                    AllowKeys = Common.SystemConfig.AllowKeys,
                };
                var result2 = new JsonResult(result);
                result2.StatusCode = (int) HttpStatusCode.OK;
                return result2;
            }
            else
            {
                ResponseStruct rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckPasswordFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail]!,
                };
                var result2 = new JsonResult(rs);
                result2.StatusCode = (int) HttpStatusCode.Unauthorized;
                return result2;
            }
        }
    }
}
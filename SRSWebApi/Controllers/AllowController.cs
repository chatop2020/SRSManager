using System;
using System.Net;
using SRSManageCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRSWebApi.Attributes;
using SRSWebApi.RequestModules;
using SRSWebApi.ResponseModules;

namespace SRSWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class AllowController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AllowController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
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
            string remoteIpaddr = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            if (Program.common.CheckAllow(remoteIpaddr, request.AllowKey))
            {
                if (request.Expires >= Program.common.GetTimeStampMilliseconds() || Math.Abs(request.Expires-Program.common.GetTimeStampMilliseconds()) <(1000*60)) //1分钟内要过期的就刷新
                {
                    Session session = Program.common.SessionManager.RefreshSession(request);
                    if (session != null)
                    {
                        var result = new JsonResult(session);
                        result.StatusCode = (int)HttpStatusCode.OK;
                        return result;
                    }
                    else
                    {
                        ResponseStruct rs= new ResponseStruct()
                        {
                            Code = ErrorNumber.SystemSessionExcept,
                            Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemSessionExcept],
                        }; 
                        var result = new JsonResult(rs);
                        result.StatusCode = (int)HttpStatusCode.OK;
                        return result;

                    }
                }
                else
                {
                    ResponseStruct rs= new ResponseStruct()
                    {
                        Code = ErrorNumber.SystemSessionItWorks,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemSessionItWorks],
                    }; 
                    var result = new JsonResult(rs);
                    result.StatusCode = (int)HttpStatusCode.OK;
                    return result;

                }
            }
            else
            {
                ResponseStruct rs= new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckAllowKeyFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckAllowKeyFail],
                }; 
                var result = new JsonResult(rs);
                result.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
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
            string remoteIpaddr = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            string allowKey = request.AllowKey;
            if (Program.common.CheckAllow(remoteIpaddr, allowKey))
            {
                Session session = Program.common.SessionManager.NewSession(allowKey);
                var result = new JsonResult(session);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;

            }
            else
            {
                ResponseStruct rs= new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckAllowKeyFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckAllowKeyFail],
                }; 
                var result = new JsonResult(rs);
                result.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
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
            if (Program.common.CheckPassword(request.Password))
            {
                bool found = false;
                for (int i = 0; i <= Program.common.conf.AllowKeys.Count - 1; i++)
                {
                    if (Program.common.conf.AllowKeys[i].Key.Trim().ToLower()
                        .Equals(request.Allowkey.Key.Trim().ToLower()))
                    {
                        Program.common.conf.AllowKeys[i] = request.Allowkey;
                        if (Program.common.conf.RebuidConfig(Program.common.ConfPath))
                        {
                            found = true;
                        }
                        break;
                    }
                }

                if (found)
                {
                    ResponseStruct rs= new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.None],
                    }; 
                    var result = new JsonResult(rs);
                    result.StatusCode = (int)HttpStatusCode.OK;
                    return result;

                }
                else
                {
                    ResponseStruct rs= new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.SrsSubInstanceNotFound],
                    }; 
                    var result = new JsonResult(rs);
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result;

                }
            }
            else
            {
                ResponseStruct rs= new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckPasswordFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail],
                }; 
                
                var result = new JsonResult(rs);
                result.StatusCode = (int)HttpStatusCode.Unauthorized;
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
            if (Program.common.CheckPassword(request.Password))
            {
                bool found = false;
                for (int i = 0; i <= Program.common.conf.AllowKeys.Count - 1; i++)
                {
                    if (Program.common.conf.AllowKeys[i].Key.Trim().ToLower().Equals(request.Key.Trim().ToLower()))
                    {

                        Program.common.conf.AllowKeys[i] = null;
                        if (Program.common.conf.RebuidConfig(Program.common.ConfPath))
                        {
                            found = true;
                        }
                        break;
                    }
                }

                if (found)
                {
                    SRSApis.Common.RemoveNull(Program.common.conf.AllowKeys);
                    ResponseStruct rs= new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.None],
                    }; 
                    
                    var result = new JsonResult(rs);
                    result.StatusCode = (int)HttpStatusCode.OK;
                    return result;

                }
                else
                {
                    ResponseStruct rs= new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.SrsSubInstanceNotFound],
                    }; 
                    
                    var result = new JsonResult(rs);
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result;

                }
            }
            else
            {
                 
                ResponseStruct rs= new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckPasswordFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail],
                }; 
                
                var result = new JsonResult(rs);
                result.StatusCode = (int)HttpStatusCode.Unauthorized;
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
            JsonResult result;
            if (Program.common.CheckPassword(request.Password))
            {
                var obj = Program.common.conf.AllowKeys.FindLast(x =>
                    x.Key.Trim().ToLower().Equals(request.Allowkey.Key.Trim().ToLower()));

                if (obj != null)
                {
                    
                    ResponseStruct rs= new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceAlreadyExists,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.SrsSubInstanceAlreadyExists],
                    }; 
                    result = new JsonResult(rs);
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result;

                }

                if (string.IsNullOrEmpty(request.Allowkey.Key.Trim()) ||
                    !Program.common.IsGuidByError(request.Allowkey.Key))
                {
                    ResponseStruct rs= new ResponseStruct()
                    {
                        Code = ErrorNumber.FunctionInputParamsError,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.FunctionInputParamsError],
                    };
                    result = new JsonResult(rs);
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result;

                }

                Program.common.conf.AllowKeys.Add(request.Allowkey);
                if (Program.common.conf.RebuidConfig(Program.common.ConfPath))
                {
                    ResponseStruct rs= new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.None],
                    };
                    result = new JsonResult(rs);
                    result.StatusCode = (int)HttpStatusCode.OK;
                    return result;
                }
                else
                {
                    ResponseStruct rs= new ResponseStruct()
                    {
                        Code = ErrorNumber.Other,
                        Message = ErrorMessage.ErrorDic?[ErrorNumber.Other],
                    };
                    result = new JsonResult(rs);
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result;
                }
            }
            else
            {
                ResponseStruct rs= new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckPasswordFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail],
                };
                result = new JsonResult(rs);
                result.StatusCode = (int)HttpStatusCode.Unauthorized;
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
            if (Program.common.CheckPassword(request.Password))
            {
                AllowListModule result = new AllowListModule()
                {
                    AllowKeys = Program.common.conf.AllowKeys,
                };
                var result2 = new JsonResult(result);
                result2.StatusCode = (int)HttpStatusCode.OK;
                return result2;

            }
            else
            {
                ResponseStruct rs= new ResponseStruct()
                {
                    Code = ErrorNumber.SystemCheckPasswordFail,
                    Message = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail],
                };
                var result2 = new JsonResult(rs);
                result2.StatusCode = (int)HttpStatusCode.Unauthorized;
                return result2;

            }
        }
    }
}
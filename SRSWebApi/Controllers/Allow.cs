using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRSWebApi.RequestModules;
using SRSWebApi.ResponseModules;

namespace SRSWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class Allow : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public Allow(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        
        /// <summary>
        /// 刷新Session
        /// </summary>
        /// <param name="request">旧的session</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Allow/RefreshSession")]
        public BaseResponseModule RefreshSession([FromBody] Session request)
        {
            string remoteIpaddr = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            if (Program.common.CheckAllow(remoteIpaddr, request.AllowKey))
            {
                if (request.Expires >= Environment.TickCount64)
                {
                    Session session = Program.common.SessionManager.RefreshSession(request);
                    if (session != null)
                    {
                        return new BaseResponseModule()
                        {
                            Code = HttpStatusCode.OK,
                            Msg = JsonHelper.ToJson(session),
                        };
                    }
                    else
                    {
                        return new BaseResponseModule()
                        {
                            Code = HttpStatusCode.MethodNotAllowed,
                            Msg =  ErrorMessage.ErrorDic?[ErrorNumber.SystemSessionExcept],
                        };
                    }
                }
                else
                {
                    return new BaseResponseModule()
                    {
                        Code = HttpStatusCode.OK,
                        Msg = "无需刷新",
                    };
                }
            }
            else
            {
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.MethodNotAllowed,
                    Msg = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckAllowKeyFail],
                };
            }  
        }

        /// <summary>
        /// 获取一个session用于通讯
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Allow/GetSession")]
        public BaseResponseModule GetSession([FromBody] ReqGetSession request)
        {
            string remoteIpaddr = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            string allowKey = request.Key;
            if (Program.common.CheckAllow(remoteIpaddr, allowKey))
            {
                Session session = Program.common.SessionManager.NewSession(allowKey);
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.OK,
                    Msg = JsonHelper.ToJson(session),
                };
            }
            else
            {
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.MethodNotAllowed,
                    Msg = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckAllowKeyFail],
                };
            }
        }

        /// <summary>
        /// 修改设置一个allow
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Allow/SetAllowByKey")]
        public BaseResponseModule SetAllowByKey([FromBody] ReqSetOrAddAllow request)
        {
            if (Program.common.CheckPassword(request.Password))
            {
                bool found = false;
                for (int i = 0; i <= Program.common.conf.AllowKeys.Count - 1; i++)
                {
                    if (Program.common.conf.AllowKeys[i].Key.Trim().ToLower()
                        .Equals(request.Allowkey.Key.Trim().ToLower()))
                    {
                        found = true;
                        Program.common.conf.AllowKeys[i] = request.Allowkey;
                        break;
                    }
                }

                if (found)
                {
                    return new BaseResponseModule()
                    {
                        Code = HttpStatusCode.OK,
                        Msg = ErrorMessage.ErrorDic?[ErrorNumber.None],
                    };
                }
                else
                {
                    return new BaseResponseModule()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Msg = ErrorMessage.ErrorDic?[ErrorNumber.SRSSubInstanceNotFound],
                    };
                }
            }
            else
            {
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.Unauthorized,
                    Msg = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail],
                };
            }
        }


        /// <summary>
        /// 删除一条allow
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Allow/DelAllowByKey")]
        public BaseResponseModule DelAllowByKey([FromBody] ReqDelAllow request)
        {
            if (Program.common.CheckPassword(request.Password))
            {
                bool found = false;
                for (int i = 0; i <= Program.common.conf.AllowKeys.Count - 1; i++)
                {
                    if (Program.common.conf.AllowKeys[i].Key.Trim().ToLower().Equals(request.Key.Trim().ToLower()))
                    {
                        found = true;
                        Program.common.conf.AllowKeys[i] = null;
                        break;
                    }
                }

                if (found)
                {
                    SRSApis.Common.RemoveNull(Program.common.conf.AllowKeys);
                    return new BaseResponseModule()
                    {
                        Code = HttpStatusCode.OK,
                        Msg = ErrorMessage.ErrorDic?[ErrorNumber.None],
                    };
                }
                else
                {
                    return new BaseResponseModule()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Msg = ErrorMessage.ErrorDic?[ErrorNumber.SRSSubInstanceNotFound],
                    };
                }
            }
            else
            {
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.Unauthorized,
                    Msg = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail],
                };
            }
        }

        /// <summary>
        /// 添加一个allow
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Allow/AddAllow")]
        public BaseResponseModule AddAllow([FromBody] ReqSetOrAddAllow request)
        {
            if (Program.common.CheckPassword(request.Password))
            {
                var obj = Program.common.conf.AllowKeys.FindLast(x =>
                    x.Key.Trim().ToLower().Equals(request.Allowkey.Key.Trim().ToLower()));
                if (obj != null)
                {
                    return new BaseResponseModule()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Msg =ErrorMessage.ErrorDic?[ErrorNumber.SRSSubInstanceAlreadyExists],
                    };
                }

                if (string.IsNullOrEmpty(request.Allowkey.Key.Trim()) ||
                    !Program.common.IsGuidByError(request.Allowkey.Key))
                {
                    return new BaseResponseModule()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Msg = ErrorMessage.ErrorDic?[ErrorNumber.FunctionInputParamsError],
                    };
                }

                Program.common.conf.AllowKeys.Add(request.Allowkey);
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.OK,
                    Msg = ErrorMessage.ErrorDic?[ErrorNumber.None],
                };
            }
            else
            {
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.Unauthorized,
                    Msg = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail],
                };
            }
        }


        /// <summary>
        /// 获取授权列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Allow/GetAllows")]
        public BaseResponseModule GetAllows([FromBody] ReqGetAllows request)
        {
            if (Program.common.CheckPassword(request.Password))
            {
                AllowListModule result = new AllowListModule()
                {
                    AllowKeys = Program.common.conf.AllowKeys,
                };
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.OK,
                    Msg = JsonHelper.ToJson(result),
                };
            }
            else
            {
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.Unauthorized,
                    Msg = ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail],
                };
            }
        }
    }
}
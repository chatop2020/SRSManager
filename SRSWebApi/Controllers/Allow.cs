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
        public JsonResult RefreshSession([FromBody] Session request)
        {
            string remoteIpaddr = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            if (Program.common.CheckAllow(remoteIpaddr, request.AllowKey))
            {
                if (request.Expires >=Program.common.GetTimeStampMilliseconds())
                {
                    Session session = Program.common.SessionManager.RefreshSession(request);
                    if (session != null)
                    {
                       var result= new JsonResult(session);
                       result.StatusCode = (int)HttpStatusCode.OK;
                       return result;
                    }
                    else
                    {
                        var result= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SystemSessionExcept]);
                        result.StatusCode = (int)HttpStatusCode.OK;
                        return result;
                       
                    }
                }
                else
                {
                    var result= new JsonResult("无需刷新");
                    result.StatusCode = (int)HttpStatusCode.OK;
                    return result;
                  
                }
            }
            else
            {
                var result= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckAllowKeyFail]);
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
        [Route("/Allow/GetSession")]
        public JsonResult GetSession([FromBody] ReqGetSession request)
        {
            string remoteIpaddr = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            string allowKey = request.AllowKey;
            if (Program.common.CheckAllow(remoteIpaddr, allowKey))
            {
                Session session = Program.common.SessionManager.NewSession(allowKey);
                var result= new JsonResult(session);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
              
            }
            else
            {
                var result= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckAllowKeyFail]);
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
                        found = true;
                        Program.common.conf.AllowKeys[i] = request.Allowkey;
                        break;
                    }
                }

                if (found)
                {
                    var result= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.None]);
                    result.StatusCode = (int)HttpStatusCode.OK;
                    return result;
                   
                }
                else
                {
                    var result= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SRSSubInstanceNotFound]);
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result;
                   
                }
            }
            else
            {
                var result= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail]);
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
                        found = true;
                        Program.common.conf.AllowKeys[i] = null;
                        break;
                    }
                }

                if (found)
                {
                    SRSApis.Common.RemoveNull(Program.common.conf.AllowKeys);
                    var result= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.None]);
                    result.StatusCode = (int)HttpStatusCode.OK;
                    return result;
                   
                }
                else
                {
                    var result= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SRSSubInstanceNotFound]);
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result;
                    
                }
            }
            else
            {
                var result= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail]);
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
                    result = new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SRSSubInstanceAlreadyExists]);
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result;
                   
                }

                if (string.IsNullOrEmpty(request.Allowkey.Key.Trim()) ||
                    !Program.common.IsGuidByError(request.Allowkey.Key))
                {  result= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.FunctionInputParamsError]);
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result;
                   
                }

                Program.common.conf.AllowKeys.Add(request.Allowkey);
                result = new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.None]);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
               
            }
            else
            {
                result = new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail]);
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
        [Route("Allow/GetAllows")]
        public JsonResult GetAllows([FromBody] ReqGetAllows request)
        {
            if (Program.common.CheckPassword(request.Password))
            {
                AllowListModule result = new AllowListModule()
                {
                    AllowKeys = Program.common.conf.AllowKeys,
                };
                var result2= new JsonResult(result);
                result2.StatusCode = (int)HttpStatusCode.OK;
                return result2;
             
            }
            else
            {
                var result2= new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckPasswordFail]);
                result2.StatusCode = (int)HttpStatusCode.Unauthorized;
                return result2;
              
            }
        }
    }
}
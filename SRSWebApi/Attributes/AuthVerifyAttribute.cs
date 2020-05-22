using System;
using System.Net;
using SRSManageCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SRSWebApi.Attributes
{
    public class AuthVerifyAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <summary>
        /// 判断用户session及allowkey的合法性
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (Program.common.isDebug) return;
            string remoteIpAddr = context.HttpContext.Connection.RemoteIpAddress.ToString();
            string sessionCode = context.HttpContext.Request.Headers["SessionCode"];
            string allowKey = context.HttpContext.Request.Headers["Allowkey"];
            if (sessionCode == null || !Program.common.CheckSession(sessionCode))
            {
                var result = new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SystemSessionExcept]);
                result.StatusCode = (int) HttpStatusCode.BadRequest;
                context.Result = result;
            }

            if (allowKey == null || !Program.common.CheckAllow(remoteIpAddr, allowKey))
            {
                var result = new JsonResult(ErrorMessage.ErrorDic?[ErrorNumber.SystemCheckAllowKeyFail]);
                result.StatusCode = (int) HttpStatusCode.BadRequest;
                context.Result = result;
            }
        }
    }
}
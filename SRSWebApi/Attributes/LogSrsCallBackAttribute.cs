using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SRSManageCommon;

namespace SRSWebApi.Attributes
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public class LogSrsCallBackAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// 请求后
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        /// <summary>
        /// 请求中
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string remoteIpAddr = context.HttpContext.Connection.RemoteIpAddress.ToString();
            if (context.HttpContext.Request.Method.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {
                LogWebApiWriter.WriteWebApiLog(
                    $@"INPUT    {remoteIpAddr}    {context.HttpContext.Request.Method}    {context.HttpContext.Request.Path}",
                    $@"{JsonConvert.SerializeObject(context.ActionArguments)}", ConsoleColor.Gray);
            }
            else
            {
                LogWebApiWriter.WriteWebApiLog(
                    $@"INPUT    {remoteIpAddr}    {context.HttpContext.Request.Method}    {context.HttpContext.Request.Path}",
                    $@"{JsonConvert.SerializeObject(context.ActionArguments)}", ConsoleColor.Gray);
            }
        }
    }
}
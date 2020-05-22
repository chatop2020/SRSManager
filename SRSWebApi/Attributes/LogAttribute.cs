using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using SRSManageCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SRSApis;
using SRSWebApi;
using SRSWebApi.ResponseModules;

namespace SRSWebApi.Attributes
{
    public class LogAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string info = $@"StatusCode:{(context.Result as JsonResult).StatusCode}";
            if ((context.Result as JsonResult).StatusCode != (int)HttpStatusCode.OK)
            {
                info = $@"{info}  Body: { JsonConvert.SerializeObject((context.Result as JsonResult).Value as ResponseStruct)}";
                LogWebApiWriter.WriteWebApiLog($@"OUTPUT  {context.HttpContext.Request.Method}  {context.HttpContext.Request.Path}", info, ConsoleColor.Yellow);
            }
            else
            {
                info = $@"{info}  Body: { JsonConvert.SerializeObject((context.Result as JsonResult).Value)}";
                LogWebApiWriter.WriteWebApiLog($@"OUTPUT  {context.HttpContext.Request.Method}  {context.HttpContext.Request.Path}", info, ConsoleColor.Gray);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Method.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {
                LogWebApiWriter.WriteWebApiLog($@"INPUT  {context.HttpContext.Request.Method}  {context.HttpContext.Request.Path}", $@"{JsonConvert.SerializeObject(context.ActionArguments)}", ConsoleColor.Gray);
            }
            else
            {
                LogWebApiWriter.WriteWebApiLog($@"INPUT  {context.HttpContext.Request.Method}  {context.HttpContext.Request.Path}", $@"{JsonConvert.SerializeObject(context.ActionArguments)}", ConsoleColor.Gray);
            }
        }
    }
}
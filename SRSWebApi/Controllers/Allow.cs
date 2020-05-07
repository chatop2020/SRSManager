using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SRSWebApi.RequestModules;
using SRSWebApi.ResponseModules;

namespace SRSWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class Allow : ControllerBase
    {
        private readonly ILogger<Allow> _logger;

        public Allow(ILogger<Allow> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 添加一个allow
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("allow/addallows")]
        public BaseResponseModule AddAllows([FromBody] ReqAddAllow request)
        {
            if (Common.CheckPassword(request.Password))
            {
                var obj = Common.conf.AllowKeys.FindLast(x =>
                    x.Key.Trim().ToLower().Equals(request.Allowkey.Key.Trim().ToLower()));
                if (obj != null)
                {
                    return new BaseResponseModule()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Msg = JsonHelper.ToJson(ErrorMessage.ErrorDic[ErrorNumber.SRSSubInstanceAlreadyExists]),
                    };
                }

                if (string.IsNullOrEmpty(request.Allowkey.Key.Trim()) || !Common.IsGuidByError(request.Allowkey.Key))
                {
                    return new BaseResponseModule()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Msg = JsonHelper.ToJson(ErrorMessage.ErrorDic[ErrorNumber.FunctionInputParamsError]),
                    };
                }

                Common.conf.AllowKeys.Add(request.Allowkey);
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.OK,
                    Msg = JsonHelper.ToJson(ErrorMessage.ErrorDic[ErrorNumber.None]),
                };
            }
            else
            {
                return new BaseResponseModule()
                {
                    Code = HttpStatusCode.Unauthorized,
                    Msg = ErrorMessage.ErrorDic[ErrorNumber.SystemCheckPasswordFail],
                };
            }
        }


        /// <summary>
        /// 获取授权列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("allow/getallows")]
        public BaseResponseModule GetAllows([FromBody] ReqGetAllows request)
        {
            if (Common.CheckPassword(request.Password))
            {
                AllowListModule result = new AllowListModule()
                {
                    AllowKeys = Common.conf.AllowKeys,
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
                    Msg = ErrorMessage.ErrorDic[ErrorNumber.SystemCheckPasswordFail],
                };
            }
        }
    }
}
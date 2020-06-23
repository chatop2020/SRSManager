using System;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using SRSApis;
using SrsManageCommon;
using SRSManageCommon.ManageStructs;
using Common = SrsManageCommon.Common;

namespace SrsWebApi
{
    /// <summary>
    /// 通用类
    /// </summary>
    public class CommonFunctions

    {
        /// <summary>
        /// 检查controller的输入参数
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static ResponseStruct CheckParams(object[] objs)
        {
            foreach (var obj in objs)
            {
                if (obj == null)
                {
                    return new ResponseStruct()
                    {
                        Code = ErrorNumber.FunctionInputParamsError,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                    };
                }
            }

            return new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
        }


        /// <summary>
        /// 调试模式下不启用授权和session验证
        /// </summary>
        public readonly bool IsDebug = true;

        /// <summary>
        /// 基础路由地址
        /// </summary>
        public string BaseUrl = null!;


        /// <summary>
        /// 配置文件地址
        /// </summary>
        public string ConfPath = null!;

        /// <summary>
        /// Session管理器
        /// </summary>
        public SessionManager SessionManager = null!;


        /// <summary>
        /// 工作目录
        /// </summary>
        public string WorkPath = null!;




        /// <summary>
        /// 获取时间戳(毫秒级)
        /// </summary>
        /// <returns></returns>
        public long GetTimeStampMilliseconds()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

        private bool checkFFmpegBin(string ffpath = "")
        {
            if (string.IsNullOrEmpty(ffpath))
            {
                ffpath = "ffmpeg";
            }

            LinuxShell.Run(ffpath, 1000, out string std, out string err);
            if (!string.IsNullOrEmpty(std))
            {
                if (std.ToLower().Contains("ffmpeg version"))
                {
                    return true;
                }
            }

            if (!string.IsNullOrEmpty(err))
            {
                if (err.ToLower().Contains("ffmpeg version"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 通用类初始化
        /// </summary>
        public void CommonInit()
        {
            Common.SystemConfig = new SystemConfig();
            WorkPath = Environment.CurrentDirectory + "/";
            ConfPath = WorkPath + "srswebapi.wconf";

            if (Common.SystemConfig.LoadConfig(ConfPath))
            {
                if (!checkFFmpegBin(Common.FFmpegBinPath))
                {
                    LogWriter.WriteLog("FFmpeg可执行文件不存在，系统退出，请保证FFmpeg可执行文件存在", Common.FFmpegBinPath);
                    Common.KillSelf();
                }
                BaseUrl = "http://*:" + Common.SystemConfig.HttpPort;
                ErrorMessage.Init();
                SessionManager = new SessionManager();
                SRSApis.Common.init_SrsServer();
            }
            else
            {
                LogWriter.WriteLog("系统配置文件加载异常，系统退出", ConfPath);
                Common.KillSelf();
            }
        }

        /// <summary>
        /// 检测session和allow
        /// </summary>
        /// <param name="ipAddr"></param>
        /// <param name="allowKey"></param>
        /// <param name="sessionCode"></param>
        /// <returns></returns>
        public bool CheckAuth(string ipAddr, string allowKey, string sessionCode)
        {
            if (!CheckSession(sessionCode)) return false;
            if (!CheckAllow(ipAddr, allowKey)) return false;
            return true;
        }

        /// <summary>
        /// 检查密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckPassword(string password)
        {
            return Common.SystemConfig.Password.Trim().Equals(password.Trim());
        }

        /// <summary>
        /// 检查Session是否正常
        /// </summary>
        /// <param name="sessionCode"></param>
        /// <returns></returns>
        public bool CheckSession(string sessionCode)
        {
            Session s = this.SessionManager.SessionList.FindLast(x =>
                x.SessionCode.Trim().ToLower().Equals(sessionCode.Trim().ToLower()))!;
            long a = this.GetTimeStampMilliseconds();

            if (s != null && s.Expires > a)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 检查appkey
        /// </summary>
        /// <param name="ipAddr"></param>
        /// <param name="allowKey"></param>
        /// <returns></returns>
        public bool CheckAllow(string ipAddr, string allowKey)
        {
            if (Common.SystemConfig.AllowKeys == null ||
                Common.SystemConfig.AllowKeys.Count == 0) return true;
            foreach (var ak in Common.SystemConfig.AllowKeys)
            {
                foreach (var ip in ak.IpArray)
                {
                    string[] ip_tmp;
                    string[] ipAddr_tmp;
                    string ipReal;
                    string ipAddrReal;
                    ipReal = ip;
                    ipAddrReal = ipAddr;
                    if (ip.Trim() == "*" || string.IsNullOrEmpty(ip))
                    {
                        if (allowKey.Trim().ToLower().Equals(ak.Key.Trim().ToLower()))
                        {
                            return true;
                        }

                        return false;
                    }

                    if (ip.Contains('*'))
                    {
                        ip_tmp = ip.Split('.', StringSplitOptions.RemoveEmptyEntries);
                        ipAddr_tmp = ipAddr.Split('.', StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i <= ip_tmp.Length - 1; i++)
                        {
                            if (ip_tmp[i].Trim().Equals("*"))
                            {
                                ipAddr_tmp[i] = "*";
                            }
                        }

                        ipReal = String.Join(".", ip_tmp);
                        ipAddrReal = String.Join(".", ipAddr_tmp);
                    }

                    if (ipReal.Trim().Equals(ipAddrReal.Trim()) &&
                        allowKey.Trim().ToLower().Equals(ak.Key.Trim().ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// apis返回结果统一处理
        /// </summary>
        /// <param name="rt">返回值</param>
        /// <param name="rs">ResponseStruct</param>
        /// <returns></returns>
        public JsonResult DelApisResult(object rt, ResponseStruct rs)
        {
            if (rs.Code != (int) ErrorNumber.None)
            {
                return new JsonResult(rs) {StatusCode = (int) HttpStatusCode.BadRequest};
            }

            return new JsonResult(rt) {StatusCode = (int) HttpStatusCode.OK};
        }
    }
}
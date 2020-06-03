using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SRSApis;
using SrsApis.SrsManager.Apis.ApiModules;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;
using Common = SRSApis.Common;

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
        /// SrsOnlineClient管理
        /// </summary>
        public static SrsClientManager SrsOnlineClient = null!;

        /// <summary>
        /// 调试模式下不启用授权和session验证
        /// </summary>
        public readonly bool IsDebug = true;

        /// <summary>
        /// 基础路由地址
        /// </summary>
        public string BaseUrl = null!;


        /// <summary>
        /// srswebapi配置文件类
        /// </summary>
        public Config Conf = new Config();

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
        /// ffmpeg的可执行文件地址
        /// </summary>
        public string FFmpegBinPath = "./ffmpeg";

       // public string FFmpegBinPath = "/usr/local/bin/ffmpeg";


        /// <summary>
        /// 获取时间戳(毫秒级)
        /// </summary>
        /// <returns></returns>
        public long GetTimeStampMilliseconds()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }


        /// <summary>
        /// 通用类初始化
        /// </summary>
        public void CommonInit()
        {
            if (!File.Exists(FFmpegBinPath))
            {
                Console.WriteLine("FFMPEG程度不存在，启动异常..." + FFmpegBinPath);
                return;
            }

            WorkPath = Environment.CurrentDirectory + "/";
            ConfPath = WorkPath + "srswebapi.wconf";
            BaseUrl = "http://*:" + Conf.HttpPort;
            if (Conf.LoadConfig(ConfPath))
            {
                ErrorMessage.Init();
                SessionManager = new SessionManager();

                Common.init_SrsServer();
                SrsOnlineClient = new SrsClientManager();
            }
            else
            {
                Console.WriteLine("读取配置文件失败，启动异常...");
                return;
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
            return Conf.Password.Trim().Equals(password.Trim());
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
            if (Conf.AllowKeys == null || Conf.AllowKeys.Count == 0) return true;
            foreach (var ak in Conf.AllowKeys)
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
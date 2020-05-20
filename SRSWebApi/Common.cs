using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SRSApis;

namespace SRSWebApi
{
    public class Common
    {
        public string WorkPath;
        public string ConfPath;
        public string BaseUrl;
        public SessionManager SessionManager;
        public bool isDebug = true;


        /// <summary>
        /// 获取时间戳(毫秒级)
        /// </summary>
        /// <returns></returns>
        public long GetTimeStampMilliseconds()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

        public Common()
        {
        }

        /// <summary>
        /// 生成guid
        /// </summary>
        /// <returns></returns>
        public string CreateUUID()
        {
            return Guid.NewGuid().ToString("D");
        }

        public void CommonInit()
        {
            WorkPath = Environment.CurrentDirectory + "/";
            ConfPath = WorkPath + "srswebapi.wconf";
            BaseUrl = "http://*:" + conf.HttpPort;
            if (conf.LoadConfig(ConfPath))
            {
                ErrorMessage.Init();
                SessionManager = new SessionManager();
                SRSApis.Common.init_SrsServer();
                
            }
            else
            {
                Console.WriteLine("读取配置文件失败，启动异常...");
            }
        }

        /// <summary>
        /// 是否为GUID
        /// </summary>
        /// <param name="strSrc"></param>
        /// <returns></returns>
        public bool IsGuidByError(string strSrc)
        {
            if (String.IsNullOrEmpty(strSrc))
            {
                return false;
            }

            bool _result = false;
            try
            {
                Guid _t = new Guid(strSrc);
                _result = true;
            }
            catch
            {
            }

            return _result;
        }

        public Config conf = new Config();


        public bool CheckAuth(string ipAddr, string allowKey, string sessionCode)
        {
            if (!CheckSession(sessionCode)) return false;
            if(!CheckAllow(ipAddr,allowKey)) return false;
            return true;
        }
        /// <summary>
        /// 检查密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckPassword(string password)
        {
            return conf.Password.Trim().Equals(password.Trim());
        }

        /// <summary>
        /// 检查Session是否正常
        /// </summary>
        /// <param name="sessionCode"></param>
        /// <returns></returns>
        public bool CheckSession(string sessionCode)
        {
            Session s = this.SessionManager.SessionList.FindLast(x =>
                x.SessionCode.Trim().ToLower().Equals(sessionCode.Trim().ToLower()));
            long a = this.GetTimeStampMilliseconds();
            
            if (s != null && s.Expires > a )
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
            if (conf.AllowKeys == null || conf.AllowKeys.Count == 0) return true;
            foreach (var ak in conf.AllowKeys)
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
            if (rs.Code != (int)ErrorNumber.None)
            {
                return new JsonResult(rs) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
            return new JsonResult(rt) { StatusCode = (int)HttpStatusCode.OK };
        }
        
    }
}
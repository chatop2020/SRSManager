using System;

namespace SRSWebApi
{
    public static class Common
    {
        public static Config conf = new Config();

        /// <summary>
        /// 检查密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckPassword(string password)
        {
            return conf.Password.Trim().Equals(password.Trim());
        }

        /// <summary>
        /// 检查appkey
        /// </summary>
        /// <param name="ipAddr"></param>
        /// <param name="allowKey"></param>
        /// <returns></returns>
        public static bool CheckAllow(string ipAddr, string allowKey)
        {
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
                    if (ip.Trim() == "*")
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
    }
}
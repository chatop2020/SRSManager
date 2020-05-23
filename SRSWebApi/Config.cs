using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SRSWebApi
{
    /// <summary>
    /// allowkey管理类
    /// </summary>
    [Serializable]
    public class AllowKey
    {
        private List<string> _ipArray = new List<string>();
        private string _key = null!;

        /// <summary>
        /// key值
        /// </summary>
        public string Key
        {
            get => _key;
            set => _key = value;
        }

        /// <summary>
        /// ip地址列表
        /// </summary>
        public List<string> IpArray
        {
            get => _ipArray;
            set => _ipArray = value;
        }
    }

    /// <summary>
    /// 配置文件类
    /// </summary>
    [Serializable]
    public class Config
    {
        private List<AllowKey> _allowKeys = new List<AllowKey>();
        private ushort _httpPort = 5800;
        private string _password = "password123!@#";

        /// <summary>
        /// http端口
        /// </summary>
        public ushort HttpPort
        {
            get => _httpPort;
            set => _httpPort = value;
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        /// <summary>
        /// 控制访问授权
        /// </summary>
        public List<AllowKey> AllowKeys
        {
            get => _allowKeys;
            set => _allowKeys = value;
        }

        private string[] getkv(string s, char splitchar)
        {
            return s.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
        }


        private bool ParseConfig(List<string> lines)
        {
            foreach (var s in lines)
            {
                string tmps = s.Trim().ToLower();
                if (!tmps.EndsWith(";")) continue;
                tmps = tmps.Replace(";", "");
                string[] kv = getkv(tmps, '=');
                if (kv.Length != 2) continue;
                kv[0] = kv[0].Trim().ToLower();
                switch (kv[0])
                {
                    case "httpport":

                        if (kv.Length == 2)
                        {
                            ushort v;
                            if (ushort.TryParse(kv[1], out v))
                            {
                                HttpPort = v;
                            }
                        }

                        break;
                    case "password":

                        if (kv.Length == 2)
                        {
                            if (!string.IsNullOrEmpty(kv[1]))
                            {
                                Password = kv[1].Trim();
                            }
                        }

                        break;
                    case "allowkey":
                        string[] kv1 = getkv(kv[1], '\t');
                        if (kv1.Length > 1)
                        {
                            AllowKey ak = new AllowKey();
                            ak.Key = kv1[0];
                            for (int i = 1; i <= kv1.Length - 1; i++)
                            {
                                ak.IpArray.Add(kv1[i].Trim());
                            }

                            AllowKeys.Add(ak);
                        }

                        break;
                }
            }

            return true;
        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool RebuidConfig(string filePath)
        {
            List<string> writeFile = new List<string>();
            writeFile.Add("httpport=" + HttpPort + ";");
            writeFile.Add("password=" + Password + ";");
            foreach (var ak in _allowKeys)
            {
                if (ak != null)
                {
                    string tmps = "";
                    foreach (string ip in ak.IpArray)
                    {
                        if (!string.IsNullOrEmpty(ip))
                        {
                            tmps += ip + "\t";
                        }
                    }

                    writeFile.Add("allowkey=" + ak.Key + "\t" + tmps + ";");
                }
            }

            try
            {
                File.WriteAllLines(filePath, writeFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool LoadConfig(string filePath)
        {
            if (File.Exists(filePath))
            {
                List<string> tmp_sl = File.ReadAllLines(filePath).ToList();
                if (tmp_sl != null && tmp_sl.Count > 0)
                {
                    if (ParseConfig(tmp_sl))
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
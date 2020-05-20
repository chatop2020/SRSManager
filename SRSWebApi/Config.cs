using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SRSWebApi
{
    [Serializable]
    public class AllowKey
    {
        private string key;
        private List<string> ipArray = new List<string>();

        public string Key
        {
            get => key;
            set => key = value;
        }

        public List<string> IpArray
        {
            get => ipArray;
            set => ipArray = value;
        }
    }

    [Serializable]
    public class Config
    {
        private ushort http_port = 5800;
        private string password = "password123!@#";
        private List<AllowKey> allowKeys = new List<AllowKey>();

        public ushort HttpPort
        {
            get => http_port;
            set => http_port = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public List<AllowKey> AllowKeys
        {
            get => allowKeys;
            set => allowKeys = value;
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

        public bool RebuidConfig(string filePath)
        {
            List<string> writeFile = new List<string>();
            writeFile.Add("httpport=" + HttpPort + ";");
            writeFile.Add("password=" + Password + ";");
            foreach (var ak in allowKeys)
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
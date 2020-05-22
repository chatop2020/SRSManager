using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using Common;
using OnvifManager;
using SRSApis.SRSManager;
using SRSConfFile;

namespace SRSApis
{
    [Serializable]
    public class OnvifConfig
    {
        private string ipAddr;
        private string? username;
        private string? password;

        public string IpAddr
        {
            get => ipAddr;
            set => ipAddr = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? Username
        {
            get => username;
            set => username = value;
        }

        public string? Password
        {
            get => password;
            set => password = value;
        }
    }

    public static class Common
    {
        public static readonly string WorkPath = Environment.CurrentDirectory + "/";
        public static readonly string LogPath = WorkPath + "logs/";
        public static List<SrsManager> SrsManagers = new List<SrsManager>();
        public static List<OnvifInstance> OnvifManagers = new List<OnvifInstance>();

        /// <summary>
        /// 对象克隆
        /// </summary>
        /// <param name="RealObject"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ObjectClone<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(objectStream);
            }
        }

        /// <summary>
        /// 删除List<T>中null的记录
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        public static void RemoveNull<T>(List<T> list)
        {
            // 找出第一个空元素 O(n)
            int count = list.Count;
            for (int i = 0; i < count; i++)
                if (list[i] == null)
                {
                    // 记录当前位置
                    int newCount = i++;

                    // 对每个非空元素，复制至当前位置 O(n)
                    for (; i < count; i++)
                        if (list[i] != null)
                            list[newCount++] = list[i];

                    // 移除多余的元素 O(n)
                    list.RemoveRange(newCount, count - newCount);
                    break;
                }
        }

        /// <summary>
        /// 刷新SRS实例的配置文件
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool RefreshSrsObject(SrsManager sm, out ResponseStruct rs)
        {
            SrsConfigBuild.Build(sm.Srs, sm.srs_ConfigPath);
            return sm.Reload(out rs);
        }

        /// <summary>
        /// 启动SRS实例
        /// </summary>
        public static void startServers()
        {
            ResponseStruct rs;
            bool ret;
            foreach (SrsManager sm in SrsManagers)
            {
                ret = sm.Start(out rs);
                string rs_str = JsonHelper.ToJson(rs);
                if (ret)
                {
                    LogWriter.WriteLog("SRS启动成功...DeviceID:" + sm.srs_deviceId, rs_str);
                }
                else
                {
                    LogWriter.WriteLog("SRS启动失败...DeviceID:" + sm.srs_deviceId, rs_str, ConsoleColor.Yellow);
                }
            }
        }

        /// <summary>
        /// 检测是否为ip 地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIpAddr(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 重新加载onvif的配置文件 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static List<OnvifConfig> loadOnvifConfig(string filePath)
        {
            List<OnvifConfig> ocList = null!;
            string[] strArray = File.ReadAllLines(filePath);
            if (strArray != null)
            {
                foreach (var str in strArray)
                {
                    string s = str.Trim();
                    if (s.Contains('#')) continue;
                    if (!s.Contains(';')) continue;
                    s = s.Replace(";", "");
                    string[] part = s.Split("\t", StringSplitOptions.RemoveEmptyEntries);
                    OnvifConfig oc = null!;
                    if (part != null && part.Length > 0)
                    {
                        if (part.Length == 1 && IsIpAddr(part[0].Trim()))
                        {
                            oc = new OnvifConfig();
                            oc.IpAddr = part[0].Trim();
                        }
                        else if (part.Length == 2 && IsIpAddr(part[0].Trim()))
                        {
                            oc = new OnvifConfig();
                            oc.IpAddr = part[0].Trim();
                            oc.Username = part[1].Trim();
                        }
                        else if (part.Length == 3 && IsIpAddr(part[0].Trim()))
                        {
                            oc = new OnvifConfig();
                            oc.IpAddr = part[0].Trim();
                            oc.Username = part[1].Trim();
                            oc.Password = part[2].Trim();
                        }
                    }

                    if (oc != null)
                    {
                        if (ocList == null) ocList = new List<OnvifConfig>();
                        ocList.Add(oc);
                    }
                }
            }

            return ocList!;
        }

        /// <summary>
        /// 初始化onvif设备
        /// </summary>
        public static void InitOnvifMonitors()
        {
            if (OnvifManagers != null && OnvifManagers.Count > 0)
            {
                foreach (var om in OnvifManagers)
                {
                    try
                    {
                        om.OnvifMonitor = new OnvifMonitor(om.IpAddr, om.Username, om.Password);
                    }
                    catch
                    {
                        om.OnvifMonitor = null!;
                    }
                }
            }
        }

        /// <summary>
        /// 载入onvif设备配置
        /// </summary>
        public static void LoadOnvifMonitors()
        {
            DirectoryInfo dir = new DirectoryInfo(WorkPath);
            OnvifManagers.Clear();
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Extension.Trim().ToLower().Equals(".oconf")) //找到配置文件
                {
                    List<OnvifConfig> ocList = loadOnvifConfig(file.FullName);
                    if (ocList != null && ocList.Count > 0)
                    {
                        if (OnvifManagers == null) OnvifManagers = new List<OnvifInstance>();
                        foreach (var oc in ocList)
                        {
                            OnvifInstance oi = new OnvifInstance();
                            oi.Password = oc.Password!;
                            oi.Username = oc.Username!;
                            oi.IpAddr = oc.IpAddr!;
                            oi.ConfigPath = file.FullName;
                            OnvifManagers.Add(oi);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 初始化SRS实例
        /// </summary>
        public static void init_SrsServer()
        {
            DirectoryInfo dir = new DirectoryInfo(WorkPath);
            ResponseStruct rs;
            bool ret = false;
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Extension.Trim().ToLower().Equals(".conf")) //找到配置文件
                {
                    SrsManager sm = new SrsManager();
                    ret = sm.SRS_Init(file.FullName, out rs);
                    string rs_str = JsonHelper.ToJson(rs);
                    if (!ret)
                    {
                        LogWriter.WriteLog("初始化SRS配置失败...ConfigPath:" + file.FullName, rs_str, ConsoleColor.Yellow);
                    }
                    else
                    {
                        LogWriter.WriteLog("初始化SRS成功...ConfigPath:" + file.FullName, rs_str);
                        SrsManagers.Add(sm);
                    }
                }
            }

            if (SrsManagers.Count == 0)
            {
                SrsManager sm = new SrsManager();
                ret = sm.CreateSrsManager(out rs);
                string rs_str = JsonHelper.ToJson(rs);
                if (!ret)
                {
                    LogWriter.WriteLog("创建SRS实例失败...:", rs_str, ConsoleColor.Yellow);
                }
                else
                {
                    LogWriter.WriteLog("初始化SRS成功...ConfigPath:" + sm.srs_ConfigPath, rs_str);
                    SrsManagers.Add(sm);
                }
            }
        }

        static Common()
        {
            ErrorMessage.Init();
            Directory.CreateDirectory(LogPath);
        }
    }
}
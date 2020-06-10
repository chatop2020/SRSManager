using System;
using System.Collections.Generic;
using System.IO;
using SrsApis.SrsManager;
using SrsApis.SrsManager.Apis;
using SRSApis.SystemAutonomy;
using SrsConfFile;
using SrsManageCommon;
using SRSManageCommon.ManageStructs;

namespace SRSApis
{
    [Serializable]
    public class OnvifConfig
    {
        private string _ipAddr = null!;
        private string? _password;
        private string? _username;

        public string IpAddr
        {
            get => _ipAddr;
            set => _ipAddr = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? Username
        {
            get => _username;
            set => _username = value;
        }

        public string? Password
        {
            get => _password;
            set => _password = value;
        }
    }

    public static class Common
    {
        public static readonly string WorkPath = Environment.CurrentDirectory + "/";
        public static readonly string LogPath = WorkPath + "logs/";
        public static List<SrsManager> SrsManagers = new List<SrsManager>();
        public static List<OnvifInstance> OnvifManagers = new List<OnvifInstance>();
        public static Object LockObj = new object();
        /// <summary>
        /// SrsOnlineClient管理
        /// </summary>
        public static SrsClientManager SrsOnlineClient;

        public static SrsAndFFmpegLogMonitor SrsAndFFmpegLogMonitor;
        public static ExecutionDvrPlan? ExecutionDvrPlan;
        public static KeepIngestStream KeepIngestStream;

        static Common()
        {
            ErrorMessage.Init();
            Directory.CreateDirectory(LogPath);
            SrsOnlineClient = new SrsClientManager();
            SrsAndFFmpegLogMonitor= new SrsAndFFmpegLogMonitor();
           // ExecutionDvrPlan= new ExecutionDvrPlan();
            KeepIngestStream = new KeepIngestStream();
        }

        /*/// <summary>
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
        }*/

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
        /// 刷新并向磁盘写入SRS实例的配置文件
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool RefreshSrsObject(SrsManager sm, out ResponseStruct rs)
        {
            SrsConfigBuild.Build(sm.Srs, sm.SrsConfigPath);
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
                string rsStr = JsonHelper.ToJson(rs);
                if (ret)
                {
                    LogWriter.WriteLog("SRS启动成功...DeviceID:" + sm.SrsDeviceId, rsStr);
                }
                else
                {
                    LogWriter.WriteLog("SRS启动失败...DeviceID:" + sm.SrsDeviceId, rsStr, ConsoleColor.Yellow);
                }
            }
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
                        if (om.OnvifMonitor == null)
                            om.OnvifMonitor = new OnvifMonitor(om.IpAddr, om.Username!, om.Password!);
                    }
                    catch
                    {
                        om.OnvifMonitor = null!;
                    }
                }
            }
        }


        public static bool WriteOnvifMonitors()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(WorkPath);
                if (OnvifManagers != null && OnvifManagers.Count > 0)
                {
                    List<OnvifMonitorStruct> onvifList = OnvifMonitorApis.GetOnvifMonitorList(out ResponseStruct rs);
                    if (onvifList != null && onvifList.Count > 0)
                    {
                        string configStr = JsonHelper.ToJson(onvifList);
                        configStr = JsonHelper.ConvertJsonString(configStr);

                        if (string.IsNullOrEmpty(configStr))
                        {
                            return false;
                        }
                        else
                        {
                            File.WriteAllText(WorkPath + "system.oconf", configStr);
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 载入onvif设备配置
        /// </summary>
        public static bool LoadOnvifMonitors()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(WorkPath);
                OnvifManagers.Clear();
                foreach (FileInfo file in dir.GetFiles())
                {
                    if (file.Extension.Trim().ToLower().Equals(".oconf")) //找到配置文件
                    {
                        List<OnvifMonitorStruct> onvifList =
                            JsonHelper.FromJson<List<OnvifMonitorStruct>>(File.ReadAllText(file.FullName));
                        if (onvifList != null && onvifList.Count > 0)
                        {
                            if (OnvifManagers == null) OnvifManagers = new List<OnvifInstance>();
                            foreach (var ov in onvifList)
                            {
                                OnvifInstance oi = new OnvifInstance();
                                oi.Password = ov.Password;
                                oi.Username = ov.Username;
                                oi.ConfigPath = file.FullName;
                                oi.IpAddr = ov.Host!;
                                OnvifManagers.Add(oi);
                            }
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
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
                    string rsStr = JsonHelper.ToJson(rs);
                    if (!ret)
                    {
                        LogWriter.WriteLog("初始化SRS配置失败...ConfigPath:" + file.FullName, rsStr, ConsoleColor.Yellow);
                    }
                    else
                    {
                        LogWriter.WriteLog("初始化SRS成功...ConfigPath:" + file.FullName, rsStr);
                        SrsManagers.Add(sm);
                    }
                }
            }

            if (SrsManagers.Count == 0)
            {
                SrsManager sm = new SrsManager();
                ret = sm.CreateSrsManager(out rs);
                string rsStr = JsonHelper.ToJson(rs);
                if (!ret)
                {
                    LogWriter.WriteLog("创建SRS实例失败...:", rsStr, ConsoleColor.Yellow);
                }
                else
                {
                    LogWriter.WriteLog("初始化SRS成功...ConfigPath:" + sm.SrsConfigPath, rsStr);
                    SrsManagers.Add(sm);
                }
            }
        }
    }
}
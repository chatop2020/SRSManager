using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using OnvifManager;
using SRSApis.SRSManager;
using SRSConfFile;

namespace SRSApis
{
    public static class Common
    {
        public static readonly string WorkPath = Environment.CurrentDirectory + "/";
        public static readonly string LogPath = WorkPath + "logs/";
        public static List<SrsManager> SrsManagers = new List<SrsManager>();
        public static List<OnvifMonitor> OnvifManagers = new List<OnvifMonitor>();

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
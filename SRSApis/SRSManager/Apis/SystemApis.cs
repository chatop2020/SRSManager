using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSManageCommon;

namespace SRSApis.SRSManager.Apis
{
    public static class SystemApis
    {
        /// <summary>
        /// 根据ip删除onvif配置文件
        /// </summary>
        /// <param name="ipAddr"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<OnvifMonitorStruct> DelOnvifConfigByIpAddress(string ipAddr, out ResponseStruct rs)
        {
            if (Common.OnvifManagers != null && Common.OnvifManagers.Count > 0)
            {
                OnvifInstance ovi = Common.OnvifManagers.FindLast(x => x.IpAddr.Trim().Equals(ipAddr.Trim()))!;
                if (ovi != null)
                {
                    Common.OnvifManagers.Remove(ovi);
                }

                return OnvifMonitorApis.GetOnvifMonitorList(out rs);
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifMonitorNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifMonitorNotInit],
                };
                return null!;
            }
        }

        /// <summary>
        /// 写入onvif配置文件
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<OnvifMonitorStruct> WriteOnvifConfig(out ResponseStruct rs)
        {
            if (Common.OnvifManagers != null && Common.OnvifManagers.Count > 0)
            {
                if (Common.WriteOnvifMonitors())
                {
                    return OnvifMonitorApis.GetOnvifMonitorList(out rs);
                }
                else
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.OnvifConfigWriteExcept,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifConfigWriteExcept],
                    };
                    return null!;
                }
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifMonitorNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifMonitorNotInit],
                };
                return null!;
            }
        }

        /// <summary>
        /// 读取onvif配置文件
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<OnvifMonitorStruct> LoadOnvifConfig(out ResponseStruct rs)
        {
            if (Common.LoadOnvifMonitors())
            {
                return OnvifMonitorApis.GetOnvifMonitorList(out rs);
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifConfigLoadExcept,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifConfigLoadExcept],
                };
                return null!;
            }
        }


        /*/*public static bool DeleteOnvifConfig(string ipAddr)
        {
            
        }#1#
        /// <summary>
        /// 重新加载onvif配置文件
        /// </summary>
        /// <returns></returns>
        public static bool ReloadOnvifConfig()
        {
            try
            {
                SRSManageCommon.LoadOnvifMonitors();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 重写配置文件
        /// </summary>
        /// <returns></returns>
        public static bool ReWriteOnvifConfig()
        {
            List<OnvifConfigTemp> tmpConfig = new List<OnvifConfigTemp>();
            if (SRSManageCommon.OnvifManagers != null)
            {
                foreach (var om in SRSManageCommon.OnvifManagers)
                {
                    String filename = om.ConfigPath;
                    String? username = om.Username;
                    String? password = om.Password;
                    String? ipaddr = om.IpAddr;
                    OnvifConfigTemp oct = tmpConfig.FindLast(x => x.FilePath.Trim().Equals(filename.Trim()))!;
                    if (oct != null)
                    {
                        string s = ipaddr + "\t";
                        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                        {
                            s += username + "\t";
                            s += password + ";";
                        }

                        if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
                        {
                            s += username + ";";
                        }

                        oct.Context.Add(s);
                    }
                    else
                    {
                        oct = new OnvifConfigTemp();
                        oct.FilePath = filename;
                        string s = ipaddr + "\t";
                        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                        {
                            s += username + "\t";
                            s += password + ";";
                        }

                        if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
                        {
                            s += username + ";";
                        }

                        oct.Context.Add(s);
                        tmpConfig.Add(oct);
                    }
                }

                foreach (var tmp in tmpConfig)
                {
                    File.WriteAllLines(tmp.FilePath, tmp.Context);
                }

                return true;
            }

            return false;
        }*/

        /// <summary>
        /// 刷新srs配置
        /// </summary>
        /// <param name="sm"></param>
        /// <returns></returns>
        public static bool RefreshSrsObject(SrsManager sm)
        {
            ResponseStruct rs;
            return Common.RefreshSrsObject(sm, out rs);
        }

        /// <summary>
        /// 获取系统中的SRS实例设备ID列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllSrsManagerDeviceId()
        {
            List<string> list = null!;
            if (Common.SrsManagers.Count > 0)
            {
                list = new List<string>();
            }
            else
            {
                return null!;
            }

            foreach (var srs in Common.SrsManagers)
            {
                if (srs != null)
                {
                    list.Add(srs.srs_deviceId);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取一个SRSManage实例
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static SrsManager GetSrsManagerInstanceByDeviceId(string deviceId)
        {
            foreach (var srs in Common.SrsManagers)
            {
                if (srs != null)
                {
                    if (srs.srs_deviceId.Equals(deviceId)) return srs;
                }
            }

            return null!;
        }


        /// <summary>
        /// 获取系统中的磁盘信息
        /// </summary>
        /// <returns></returns>
        public static List<DriveDiskInfo> GetDriveDisksInfo()
        {
            List<DriveDiskInfo> disks = new List<DriveDiskInfo>();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo d in drives)
            {
                DriveDiskInfo ddi = new DriveDiskInfo()
                {
                    Format = d.DriveFormat,
                    VolumeLabel = d.VolumeLabel,
                    Free = (ulong) d.AvailableFreeSpace / 1000 / 1000,
                    Size = (ulong) d.TotalSize / 1000 / 1000,
                    Path = d.Name,
                    RootDirectory = d.RootDirectory.FullName,
                };
                if (ddi.Size > 0 && ddi.Free > 0)
                {
                    disks.Add(ddi);
                }
            }

            return disks;
        }

        /// <summary>
        /// 获取系统平台信息
        /// </summary>
        /// <returns></returns>
        public static SystemInfoModule GetSystemInfo()
        {
            SystemInfoModule sim = new SystemInfoModule();
            sim.NetworkInterfaceList = GetNetworkAdapterList();
            sim.Architecture = RuntimeInformation.OSArchitecture.ToString();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                sim.Platform = "linux";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                sim.Platform = "windows";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                sim.Platform = "Mac/OSX";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
                sim.Platform = "freebsd";
            sim.DisksInfo = GetDriveDisksInfo();
            sim.Version = RuntimeInformation.OSDescription + " " + Environment.OSVersion;
            sim.X64 = Environment.Is64BitOperatingSystem;
            sim.HostName = Environment.MachineName;
            sim.CpuCoreSize = (ushort) Environment.ProcessorCount;
            return sim;
        }

        /// <summary>
        /// 获取系统网络信息
        /// </summary>
        /// <returns></returns>
        public static List<NetworkInterfaceModule> GetNetworkAdapterList()
        {
            List<NetworkInterfaceModule> listofnetwork = new List<NetworkInterfaceModule>();
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            string ipaddr = "";
            ushort index = 0;
            if (adapters.Length > 0)
            {
                foreach (NetworkInterface adapter in adapters)
                {
                    if (adapter.NetworkInterfaceType != NetworkInterfaceType.Ethernet) continue;
                    ipaddr = "";
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    UnicastIPAddressInformationCollection ipCollection = adapterProperties.UnicastAddresses;
                    foreach (UnicastIPAddressInformation ipadd in ipCollection)
                    {
                        if (ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipaddr = ipadd.Address.ToString(); //获取ip
                        }
                        else if (ipadd.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            //本机IPV6 地址,不取IPV6地址
                        }
                    }

                    NetworkInterfaceModule tmp_adapter = new NetworkInterfaceModule()
                    {
                        Index = index,
                        Name = adapter.Name,
                        //  Speed = (adapter.Speed / 1000 / 1000).ToString() + "MB", //linux not Supported
                        Mac = adapter.GetPhysicalAddress().ToString(),
                        Type = adapter.NetworkInterfaceType.ToString(),
                        Ipaddr = ipaddr,
                    };
                    index++;
                    if (!string.IsNullOrEmpty(tmp_adapter.Ipaddr))
                    {
                        int loop = 1;
                        if (!tmp_adapter.Mac.Contains('-'))
                        {
                            for (int i = 1; i < 10; i += 2)
                            {
                                tmp_adapter.Mac = tmp_adapter.Mac.Insert(i + loop, "-");
                                loop += 1;
                            }
                        }

                        listofnetwork.Add(tmp_adapter);
                    }
                }

                return listofnetwork;
            }

            return null!;
        }
    }
}
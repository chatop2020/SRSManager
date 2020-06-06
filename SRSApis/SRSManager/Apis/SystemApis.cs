using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using SrsApis.SrsManager.Apis.ApiModules;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;
using Common = SRSApis.Common;

namespace SrsApis.SrsManager.Apis
{
    public static class SystemApis
    {
        /// <summary>
        /// 删除一个SrsInstance
        /// </summary>
        /// <param name="devid"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DelSrsInstanceByDeviceId(string devid, out ResponseStruct rs)
        {
            if (SRSApis.Common.SrsManagers == null) SRSApis.Common.SrsManagers = new List<SrsManager>();
            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(devid.Trim().ToUpper()));
            if (ret != null)
            {
                SRSApis.Common.SrsManagers.Remove(ret);
                if (ret.Srs != null && (ret.IsRunning || ret.IsInit))
                {
                    //停掉srs进程
                    while (ret.IsRunning)
                    {
                        ret.Stop(out rs);
                        Thread.Sleep(100);
                    }
                }

                File.Delete(ret.SrsConfigPath);
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                return true;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return false;
            }
        }

        /// <summary>
        /// 检查新建SRS实例的各类端口是否有冲突
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        private static bool checkNewSrsInstanceListenRight(SrsManager sm, out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            ushort? port = sm.Srs.Listen;
            if (port == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            var ret = SRSApis.Common.SrsManagers.FindLast(x => x.Srs.Listen == port);
            if (ret != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsInstanceListenExists,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsInstanceListenExists],
                };
                return false;
            }

            if (sm.Srs.Http_api != null && sm.Srs.Http_api.Listen != null)
            {
                port = sm.Srs.Http_api.Listen;
                ret = SRSApis.Common.SrsManagers.FindLast(x => x.Srs.Http_api!.Listen == port);
                if (ret != null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsInstanceHttpApiListenExists,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsInstanceHttpApiListenExists],
                    };
                    return false;
                }
            }

            if (sm.Srs.Http_server != null && sm.Srs.Http_server.Listen != null)
            {
                port = sm.Srs.Http_server.Listen;
                ret = SRSApis.Common.SrsManagers.FindLast(x => x.Srs.Http_server!.Listen == port);
                if (ret != null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsInstanceHttpServerListenExists,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsInstanceHttpServerListenExists],
                    };
                    return false;
                }
            }

            if (sm.Srs.Rtc_server != null && sm.Srs.Rtc_server.Listen != null)
            {
                port = sm.Srs.Rtc_server.Listen;
                ret = SRSApis.Common.SrsManagers.FindLast(x => x.Srs.Rtc_server!.Listen == port);
                if (ret != null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsInstanceRtcServerListenExists,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsInstanceRtcServerListenExists],
                    };
                    return false;
                }
            }

            if (sm.Srs.Srt_server != null && sm.Srs.Srt_server.Listen != null)
            {
                port = sm.Srs.Srt_server.Listen;
                ret = SRSApis.Common.SrsManagers.FindLast(x => x.Srs.Srt_server!.Listen == port);
                if (ret != null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsInstanceSrtServerListenExists,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsInstanceSrtServerListenExists],
                    };
                    return false;
                }
            }

            if (sm.Srs.Stream_casters != null && sm.Srs.Stream_casters.Count > 0)
            {
                foreach (var caster in sm.Srs.Stream_casters)
                {
                    if (caster != null && caster.Listen != null)
                    {
                        foreach (var srs in SRSApis.Common.SrsManagers)
                        {
                            foreach (var sc in srs.Srs.Stream_casters!)
                            {
                                if (sc != null)
                                {
                                    if (sc.Listen == caster.Listen)
                                    {
                                        rs = new ResponseStruct()
                                        {
                                            Code = ErrorNumber.SrsInstanceStreamCasterListenExists,
                                            Message = ErrorMessage.ErrorDic![
                                                ErrorNumber.SrsInstanceStreamCasterListenExists],
                                        };
                                        return false;
                                    }

                                    if (caster.sip != null && sc.sip != null && caster.sip.Listen != null &&
                                        sc.sip.Listen != null)
                                    {
                                        if (caster.sip.Listen == sc.sip.Listen)
                                        {
                                            rs = new ResponseStruct()
                                            {
                                                Code = ErrorNumber.SrsInstanceStreamCasterSipListenExists,
                                                Message = ErrorMessage.ErrorDic![
                                                    ErrorNumber.SrsInstanceStreamCasterSipListenExists],
                                            };
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return true;
        }

        /// <summary>
        /// 检查新建srs进程实例的各种路径是否正常
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        private static bool checkNewSrsInstancePathRight(SrsManager sm, out ResponseStruct rs)
        {
            if (sm == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            string devId = sm.SrsDeviceId;
            string confPath = sm.SrsConfigPath;
            if (string.IsNullOrEmpty(devId) || string.IsNullOrEmpty(confPath))
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(devId.Trim().ToUpper()));
            if (ret != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsInstanceExists,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsInstanceExists],
                };
                return false;
            }

            ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsConfigPath.Trim().ToUpper().Equals(confPath.Trim().ToUpper()));
            if (ret != null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsInstanceConfigPathExists,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsInstanceConfigPathExists],
                };
                return false;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return true;
        }

        /// <summary>
        /// 获取srs实例模板
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static SrsManager GetSrsInstanceTemplate(out ResponseStruct rs)
        {
            SrsManager srsManager = new SrsManager();
            srsManager.Srs = new SrsSystemConfClass();

            srsManager.Srs = new SrsSystemConfClass();
            srsManager.Srs.Listen = 1935;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                srsManager.Srs.Max_connections = 1000;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                srsManager.Srs.Max_connections = 128;
            }
            else
            {
                srsManager.Srs.Max_connections = 512;
            }

            srsManager.SrsDeviceId = SrsManageCommon.Common.CreateUuid()?.Trim()!;
            srsManager.SrsWorkPath = SRSApis.Common.WorkPath;
            srsManager.Srs.Srs_log_file = srsManager.SrsWorkPath + srsManager.SrsDeviceId + "/srs.log";
            srsManager.Srs.Srs_log_level = "verbose"; //初始为观察者
            srsManager.Srs.Pid = srsManager.SrsWorkPath + srsManager.SrsDeviceId + "/srs.pid";
            srsManager.Srs.Chunk_size = 6000;
            srsManager.Srs.Ff_log_dir = srsManager.SrsWorkPath + srsManager.SrsDeviceId + "/ffmpegLog/";
            srsManager.Srs.Ff_log_level = "warning";
            srsManager.Srs.Daemon = true;
            srsManager.Srs.Utc_time = false;
            srsManager.Srs.Work_dir = srsManager.SrsWorkPath;
            srsManager.Srs.Asprocess = false; //如果父进程被关闭，false的话srs不会关闭
            srsManager.Srs.Inotify_auto_reload = false; //配置文件修改不自动reload
            srsManager.Srs.Srs_log_tank = "file";
            srsManager.Srs.Grace_start_wait = 2300;
            srsManager.Srs.Grace_final_wait = 3200;
            srsManager.Srs.Force_grace_quit = false;
            srsManager.Srs.Http_api = new SrsHttpApiConfClass();
            srsManager.Srs.Http_api.Crossdomain = true;
            srsManager.Srs.Http_api.Enabled = true;
            srsManager.Srs.Http_api.Listen = 8000;
            srsManager.Srs.Http_api.InstanceName = "";
            srsManager.Srs.Http_api.SectionsName = "http_api";
            /*srsManager.Srs.Http_api.Raw_Api = new RawApi();
            srsManager.Srs.Http_api.Raw_Api.Allow_query = true;
            srsManager.Srs.Http_api.Raw_Api.Allow_reload = true;
            srsManager.Srs.Http_api.Raw_Api.Allow_update = true;
            srsManager.Srs.Http_api.Raw_Api.SectionsName = "raw_api";
            srsManager.Srs.Http_api.Raw_Api.Enabled = true;*/
            srsManager.Srs.Heartbeat = new SrsHeartbeatConfClass();
            srsManager.Srs.Heartbeat.Device_id = SrsManageCommon.Common.AddDoubleQuotation(srsManager.SrsDeviceId !);
            srsManager.Srs.Heartbeat.Enabled = true;
            srsManager.Srs.Heartbeat.SectionsName = "heartbeat";
            srsManager.Srs.Heartbeat.Interval = 5; //按秒计
            srsManager.Srs.Heartbeat.Summaries = true;
            srsManager.Srs.Heartbeat.Url = "http://127.0.0.1:5000/api/v1/heartbeat";
            srsManager.Srs.Http_server = new SrsHttpServerConfClass();
            srsManager.Srs.Http_server.Enabled = true;
            srsManager.Srs.Http_server.Dir = srsManager.SrsWorkPath + srsManager.SrsDeviceId + "/wwwroot";
            srsManager.Srs.Http_server.Listen = 8001;
            srsManager.Srs.Http_server.SectionsName = "http_server";
            srsManager.Srs.Http_server.Crossdomain = true;
            srsManager.Srs.Vhosts = new List<SrsvHostConfClass>();
            SrsvHostConfClass vhost = new SrsvHostConfClass();
            vhost.SectionsName = "vhost";
            vhost.VhostDomain = "__defaultVhost__";
            srsManager.Srs.Vhosts.Add(vhost);
            rs = new ResponseStruct();
            rs.Code = ErrorNumber.None;
            rs.Message = ErrorMessage.ErrorDic![ErrorNumber.None];
            return srsManager;
        }

        /// <summary>
        /// 创建一个新的SRS实例
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static SrsManager CreateNewSrsInstance(SrsManager sm, out ResponseStruct rs)
        {
            if (SRSApis.Common.SrsManagers == null) SRSApis.Common.SrsManagers = new List<SrsManager>();
            if (!checkNewSrsInstancePathRight(sm, out rs)) //检查路径是否正常
            {
                return null!;
            }

            if (!checkNewSrsInstanceListenRight(sm, out rs)) //检查监听端口是否正常
            {
                return null!;
            }

            if (!sm.CreateSrsManagerSelf(out rs))
            {
                return null!;
            }

            return sm;
        }

        /// <summary>
        /// 根据ip删除onvif配置文件
        /// </summary>
        /// <param name="ipAddr"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<OnvifMonitorStruct> DelOnvifConfigByIpAddress(string ipAddr, out ResponseStruct rs)
        {
            if (SRSApis.Common.OnvifManagers != null && SRSApis.Common.OnvifManagers.Count > 0)
            {
                OnvifInstance ovi = SRSApis.Common.OnvifManagers.FindLast(x => x.IpAddr.Trim().Equals(ipAddr.Trim()))!;
                if (ovi != null)
                {
                    SRSApis.Common.OnvifManagers.Remove(ovi);
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
            if (SRSApis.Common.OnvifManagers != null && SRSApis.Common.OnvifManagers.Count > 0)
            {
                if (SRSApis.Common.WriteOnvifMonitors())
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
            if (SRSApis.Common.LoadOnvifMonitors())
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


        /// <summary>
        /// 刷新srs配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool RefreshSrsObject(string deviceId, out ResponseStruct rs)
        {
            var ret = SRSApis.Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                return SRSApis.Common.RefreshSrsObject(ret, out rs);
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 获取系统中的SRS实例设备ID列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllSrsManagerDeviceId()
        {
            List<string> list = null!;
            if (SRSApis.Common.SrsManagers.Count > 0)
            {
                list = new List<string>();
            }
            else
            {
                return null!;
            }

            foreach (var srs in SRSApis.Common.SrsManagers)
            {
                if (srs != null)
                {
                    list.Add(srs.SrsDeviceId);
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
                    if (srs.SrsDeviceId.Equals(deviceId)) return srs;
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

            if (Common.SrsManagers != null && Common.SrsManagers.Count > 0)
            {
                foreach (var sm in Common.SrsManagers)
                {
                    if (sm.IsRunning && sm.Srs.Http_api != null && sm.Srs.Http_api.Enabled == true)
                    {
                        string reqUrl = "http://127.0.0.1:" + sm!.Srs.Http_api!.Listen + "/api/v1/summaries";
                        try
                        {
                            string tmpStr = NetHelper.Get(reqUrl);
                            var retReq = JsonHelper.FromJson<SrsSystemInfo>(tmpStr);
                            if (retReq != null && retReq.Data != null && retReq.Data.Self != null)
                            {
                                if (sim.SrsList == null) sim.SrsList = new List<Self_Srs>();
                                string filename = Path.GetFileName(retReq.Data.Self.Argv)!;
                                string ext = Path.GetExtension(filename);
                                retReq.Data.Self.Srs_DeviceId = filename.Replace(ext, "");
                                sim.SrsList.Add(retReq.Data.Self);
                                if (sim.System == null)
                                {
                                    sim.System = retReq.Data.System;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }

                    Thread.Sleep(50);
                }
            }

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
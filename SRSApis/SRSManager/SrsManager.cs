using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using SrsConfFile;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;
using Common = SRSApis.Common;

namespace SrsApis.SrsManager
{
    [Serializable]
    public class SrsManager
    {
        private SrsSystemConfClass _srs = null!;
        private string _srsConfigPath = "";
        private string _srsDeviceId = "";
        private string _srsPidValue = "";
        private string _srsWorkPath = Environment.CurrentDirectory + "/";

        public SrsSystemConfClass Srs
        {
            get => _srs;
            set => _srs = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string SrsConfigPath
        {
            get => _srsConfigPath;
            set => _srsConfigPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string SrsDeviceId
        {
            get => _srsDeviceId;
            set => _srsDeviceId = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string SrsWorkPath
        {
            get => _srsWorkPath;
            set => _srsWorkPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string SrsPidValue
        {
            get => _srsPidValue;
            set => _srsPidValue = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// SRS是否完成初始化
        /// </summary>
        public bool IsInit
        {
            get
            {
                if (Srs == null || Srs.Heartbeat == null)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// SRS是否正在运行中
        /// </summary>
        public bool IsRunning
        {
            get
            {
                if (Srs != null)
                {
                    string pidValue = "";
                    if (getPidValue(Srs.Pid!, out pidValue))
                    {
                        string cmd = "";
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        {
                            cmd = "ps -aux |grep " + pidValue + "|grep -v grep|awk \'{print $2}\'";
                        }
                        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                        {
                            cmd = "ps -A |grep " + pidValue + "|grep -v grep|awk \'{print $1}\'";
                        }

                        string stdout = "";
                        string errout = "";
                        bool ret = LinuxShell.Run(cmd, 1000, out stdout, out errout);
                        if (ret && string.IsNullOrEmpty(errout))
                        {
                            if (stdout.Trim().Equals(pidValue.Trim()))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }

                        return false;
                    }

                    return false;
                }

                return false;
            }
        }

        private bool checkFile()
        {
            if (!Directory.Exists(SrsWorkPath + SrsDeviceId))
            {
                Directory.CreateDirectory(SrsWorkPath + SrsDeviceId);
            }

            if (!Directory.Exists(SrsWorkPath + SrsDeviceId + "/wwwroot"))
            {
                Directory.CreateDirectory(SrsWorkPath + SrsDeviceId + "/wwwroot");
            }

            if (!Directory.Exists(SrsWorkPath + SrsDeviceId + "/ffmpegLog"))
            {
                Directory.CreateDirectory(SrsWorkPath + SrsDeviceId + "/ffmpegLog");
            }

            if (File.Exists(_srsConfigPath) && File.Exists(SrsWorkPath + "srs"))
            {
                return true;
            }

            return false;
        }

        public bool CreateSrsManagerSelf(out ResponseStruct rs)
        {
            if (IsInit)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsCreateError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsCreateError] + "\r\n实例已经被初始化",
                };
                return false;
            }

            try
            {
                Directory.CreateDirectory(SrsWorkPath + SrsDeviceId);
                Directory.CreateDirectory(Srs.Ff_log_dir);
                Directory.CreateDirectory(Srs.Http_server!.Dir);
                SrsConfigBuild.Build(Srs, this.SrsWorkPath + this.SrsDeviceId + ".conf");
                this.SrsConfigPath = this.SrsWorkPath + this.SrsDeviceId + ".conf";
                rs = new ResponseStruct();
                rs.Code = ErrorNumber.None;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.None];
                Common.SrsManagers.Add(this);
                return true;
            }
            catch (Exception ex)
            {
                rs = new ResponseStruct();
                rs.Code = ErrorNumber.SrsCreateError;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsCreateError] + "\r\n" + ex.Message + "\r\n" +
                             ex.StackTrace;
                return false;
            }
        }

        /// <summary>
        /// 创建一个空的SRS实例
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public bool CreateSrsManager(out ResponseStruct rs)
        {
            if (IsInit)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsCreateError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsCreateError] + "\r\n实例已经被初始化",
                };
                return false;
            }

            try
            {
                Srs = new SrsSystemConfClass();
                Srs.Listen = 1935;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Srs.Max_connections = 1000;
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Srs.Max_connections = 128;
                }
                else
                {
                    Srs.Max_connections = 512;
                }

                _srsDeviceId = SrsManageCommon.Common.CreateUuid()?.Trim()!;
                Srs.Srs_log_file = SrsWorkPath + SrsDeviceId + "/srs.log";
                Srs.Srs_log_level = "verbose"; //初始为观察者
                Srs.Pid = _srsWorkPath + SrsDeviceId + "/srs.pid";
                Srs.Chunk_size = 6000;
                Srs.Ff_log_dir = SrsWorkPath + SrsDeviceId + "/ffmpegLog/";
                Srs.Ff_log_level = "warning";
                Srs.Daemon = true;
                Srs.Utc_time = false;
                Srs.Work_dir = SrsWorkPath;
                Srs.Asprocess = false; //如果父进程被关闭，false的话srs不会关闭
                Srs.Inotify_auto_reload = false; //配置文件修改不自动reload
                Srs.Srs_log_tank = "file";
                Srs.Grace_start_wait = 2300;
                Srs.Grace_final_wait = 3200;
                Srs.Force_grace_quit = false;
                Srs.Http_api = new SrsHttpApiConfClass();
                Srs.Http_api.Crossdomain = true;
                Srs.Http_api.Enabled = true;
                Srs.Http_api.Listen = 8000;
                Srs.Http_api.InstanceName = "";
                Srs.Http_api.SectionsName = "http_api";
                /*Srs.Http_api.Raw_Api = new RawApi();
                Srs.Http_api.Raw_Api.Allow_query = true;
                Srs.Http_api.Raw_Api.Allow_reload = true;
                Srs.Http_api.Raw_Api.Allow_update = true;
                Srs.Http_api.Raw_Api.SectionsName = "raw_api";
                Srs.Http_api.Raw_Api.Enabled = true;*/
                Srs.Heartbeat = new SrsHeartbeatConfClass();
                Srs.Heartbeat.Device_id = SrsManageCommon.Common.AddDoubleQuotation(SrsDeviceId !);
                Srs.Heartbeat.Enabled = true;
                Srs.Heartbeat.SectionsName = "heartbeat";
                Srs.Heartbeat.Interval = 60; //按秒计
                Srs.Heartbeat.Summaries = true;
                Srs.Heartbeat.Url = "http://127.0.0.1:5800/SrsHooks/OnHeartbeat";
                Srs.Http_server = new SrsHttpServerConfClass();
                Srs.Http_server.Enabled = true;
                Srs.Http_server.Dir = SrsWorkPath + SrsDeviceId + "/wwwroot";
                Srs.Http_server.Listen = 8001;
                Srs.Http_server.SectionsName = "http_server";
                Srs.Http_server.Crossdomain = true;
                Srs.Vhosts = new List<SrsvHostConfClass>();
                SrsvHostConfClass vhost = new SrsvHostConfClass();
                vhost.SectionsName = "vhost";
                vhost.VhostDomain = "__defaultVhost__";
                vhost.Vhttp_hooks = new HttpHooks();
                vhost.Vhttp_hooks!.Enabled = true;
                vhost.Vhttp_hooks!.On_connect = "http://127.0.0.1:5800/SrsHooks/OnConnect";
                vhost.Vhttp_hooks!.On_publish = "http://127.0.0.1:5800/SrsHooks/OnPublish";
                vhost.Vhttp_hooks!.On_close = "http://127.0.0.1:5800/SrsHooks/OnClose";
                vhost.Vhttp_hooks!.On_play = "http://127.0.0.1:5800/SrsHooks/OnPlay";
                vhost.Vhttp_hooks!.On_unpublish = "http://127.0.0.1:5800/SrsHooks/OnUnPublish";
                vhost.Vhttp_hooks!.On_stop = "http://127.0.0.1:5800/SrsHooks/OnStop";
                vhost.Vhttp_hooks!.On_dvr = "http://127.0.0.1:5800/SrsHooks/OnDvr";
                vhost.Vhttp_hooks!.On_hls = "http://127.0.0.1:5800/SrsHooks/Test";
                vhost.Vhttp_hooks!.On_hls_notify = "http://127.0.0.1:5800/SrsHooks/Test";
                Srs.Vhosts.Add(vhost);
                Directory.CreateDirectory(SrsWorkPath + SrsDeviceId);
                Directory.CreateDirectory(Srs.Ff_log_dir);
                Directory.CreateDirectory(Srs.Http_server.Dir);
                SrsConfigBuild.Build(Srs, SrsWorkPath + SrsDeviceId + ".conf");
                SrsConfigPath = SrsWorkPath + SrsDeviceId + ".conf";
                rs = new ResponseStruct();
                rs.Code = ErrorNumber.None;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.None];

                return true;
            }
            catch (Exception ex)
            {
                rs = new ResponseStruct();
                rs.Code = ErrorNumber.SrsCreateError;
                rs.Message = ErrorMessage.ErrorDic![ErrorNumber.SrsCreateError] + "\r\n" + ex.Message + "\r\n" +
                             ex.StackTrace;
                return false;
            }
        }


        /// <summary>
        /// 获取当前SRS进程的pid号
        /// </summary>
        /// <param name="pidPath"></param>
        /// <param name="pidValue"></param>
        /// <returns></returns>
        private bool getPidValue(string pidPath, out string pidValue)
        {
            pidValue = "";
            if (File.Exists(pidPath))
            {
                string stdout = "";
                string errout = "";
                LinuxShell.Run("cat " + pidPath, 300, out stdout, out errout);
                pidValue = stdout.Trim();
                if (!string.IsNullOrEmpty(pidValue))
                {
                    SrsPidValue = pidValue;
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// 初始化SRS配置文件 ，配置文件加载成SRS配置实例
        /// </summary>
        /// <param name="confPath">配置文件路径</param>
        /// <param name="rs">返回值</param>
        /// <returns></returns>
        public bool SRS_Init(string confPath, out ResponseStruct rs)
        {
            if (!File.Exists(confPath))
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.ConfigFile,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.ConfigFile],
                };
                return false;
            }

            if (SrsConfigParse.LoadSrsConfObject(confPath))
            {
                try
                {
                    Srs = new SrsSystemConfClass();
                    SrsConfigParse.Parse();
                    SrsConfigParse.Trim();
                    SrsConfigParse.Render(SrsConfigParse.RootSection, Srs);
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                    };
                    if (Srs.Heartbeat != null)
                    {
                        _srsConfigPath = _srsWorkPath +
                                         SrsManageCommon.Common.RemoveDoubleQuotation(Srs.Heartbeat.Device_id!) +
                                         ".conf";
                        _srsDeviceId = SrsManageCommon.Common.RemoveDoubleQuotation(Srs.Heartbeat.Device_id!)!;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.Other,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.Other] + "\r\n" + ex.Message + "\r\n" +
                                  ex.StackTrace,
                    };
                    return false;
                }
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.ConfigFile,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.ConfigFile],
                };
                return false;
            }
        }

        /// <summary>
        /// 重新启动SRS进程
        /// </summary>
        /// <param name="rs">返回结构</param>
        /// <returns>返回成功或失败</returns>
        public bool Restart(out ResponseStruct rs)
        {
            if (IsRunning)
            {
                bool ret = Stop(out rs);
                if (!ret || rs.Code != ErrorNumber.None)
                {
                    return false;
                }
            }

            bool ret2 = Start(out rs);
            if (!ret2 || rs.Code != ErrorNumber.None)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 刷新SRS配置
        /// </summary>
        /// <param name="rs">返回结构</param>
        /// <returns>返回成功或失败</returns>
        public bool Reload(out ResponseStruct rs)
        {
            if (!IsRunning)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsTerminated,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsTerminated],
                };
                return false;
            }

            string cmd = "kill -s SIGHUP " + SrsPidValue + " && ret=$? && echo $ret";
            string std = "";
            string err = "";
            bool ret = LinuxShell.Run(cmd, 1000, out std, out err);
            if (!ret && (string.IsNullOrEmpty(err) && string.IsNullOrEmpty(std)))
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsReloadError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsReloadError],
                };
                return false;
            }
            else
            {
                if (!std.Trim().Equals("0") && !err.Trim().Equals("0"))
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsReloadError,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsReloadError],
                    };
                    return false;
                }
                else
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                    };
                    return true;
                }
            }
        }

        /// <summary>
        /// 启动SRS进程
        /// </summary>
        /// <param name="rs">返回结构</param>
        /// <returns>返回成功或失败</returns>
        public bool Start(out ResponseStruct rs)
        {
            if (IsRunning)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.StartRuningSrsError,
                    Message =
                        ErrorMessage.ErrorDic![ErrorNumber.StartRuningSrsError] + "\r\npid:(" + SrsPidValue + ")",
                };
                return false;
            }

            if (!checkFile())
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsNotFound],
                };
                return false;
            }

            string cmd = "ulimit -c unlimited";
            LinuxShell.Run(cmd);
            cmd = "cd " + SrsWorkPath;
            LinuxShell.Run(cmd);
            string srsPath = SrsWorkPath + "srs";
            cmd = srsPath + " -c " + SrsConfigPath;
            if (File.Exists(Srs.Pid))
            {
                File.Delete(Srs.Pid);
            }

            LinuxShell.Run(cmd, 1000);
            int i = 0;
            while (!IsRunning && i < 50) //check srs process running ,wait 5sec
            {
                i++;
                Thread.Sleep(100);
            }

            if (!IsRunning)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.StartSrsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.StartSrsError] + "\r\npid:(" + SrsPidValue + ")",
                };
                return false;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\npid:(" + SrsPidValue + ")",
            };
            lock (SrsManageCommon.Common.LockDbObjForOnlineClient)
            {
                OrmService.Db.Delete<OnlineClient>().Where(x => x.Device_Id!.Equals(SrsDeviceId)).ExecuteAffrows();
            }

            return true;
        }

        /// <summary>
        /// 终止SRS进程
        /// </summary>
        /// <param name="rs">返回结构</param>
        /// <returns>返回成功或失败</returns>
        public bool Stop(out ResponseStruct rs)
        {
            if (IsRunning)
            {
                string cmd = "kill -s SIGTERM " + SrsPidValue + " 2>/dev/null";
                for (int i = 0; i < 100; i++)
                {
                    LinuxShell.Run(cmd, 100);
                    if (!IsRunning)
                    {
                        if (File.Exists(Srs.Pid)) File.Delete(Srs.Pid);
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                        };
                        return true;
                    }

                    Thread.Sleep(100);
                }

                for (int i = 0; i < 5; i++)
                {
                    cmd = "kill -s SIGKILL " + SrsPidValue + " 2>/dev/null";
                    LinuxShell.Run(cmd, 100);
                    if (!IsRunning)
                    {
                        if (File.Exists(Srs.Pid)) File.Delete(Srs.Pid);
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.ConfigFile],
                        };
                        return true;
                    }

                    Thread.Sleep(30);
                }

                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.StopSrsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.StopSrsError],
                };
                return false;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                return true;
            }
        }
    }
}
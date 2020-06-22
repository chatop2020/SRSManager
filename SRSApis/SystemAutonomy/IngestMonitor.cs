using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SrsApis.SrsManager.Apis;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;

namespace SRSApis.SystemAutonomy
{
    public class MonitorStruct
    {
        private string? _deviceId;
        private string? _vhostDomain;
        private string? _app;
        private string? _stream;
        private string? _filename;
        private BlockingCollection<byte> _highFrequencyUpdateList = new BlockingCollection<byte>(100);
        private int _timeoutTimes = 0;

        public string? DeviceId
        {
            get => _deviceId;
            set => _deviceId = value;
        }

        public string? VhostDomain
        {
            get => _vhostDomain;
            set => _vhostDomain = value;
        }

        public string? App
        {
            get => _app;
            set => _app = value;
        }

        public string? Stream
        {
            get => _stream;
            set => _stream = value;
        }

        public BlockingCollection<byte> HighFrequencyUpdateList
        {
            get => _highFrequencyUpdateList;
            set => _highFrequencyUpdateList = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int TimeOutTimes
        {
            get => _timeoutTimes;
            set => _timeoutTimes = value;
        }

        public string? Filename
        {
            get => _filename;
            set => _filename = value;
        }

        public MonitorStruct(string _deviceId, string _vhostDomain, string _app, string _stream, string _filename)
        {
            DeviceId = _deviceId;
            VhostDomain = _vhostDomain;
            App = _app;
            Stream = _stream;
            Filename = _filename;
            Task.Factory.StartNew(() =>
            {
                foreach (var value in HighFrequencyUpdateList.GetConsumingEnumerable())
                {
                    Thread.Sleep(10000); //人为延迟100毫秒，有内容就延迟，没内容就阻塞
                    TimeOutTimes = TimeOutTimes > 0 ? TimeOutTimes-- : 0;
                }
            });
        }
    }

    /// <summary>
    /// 发现如果ffmpeg出现异常退出或其他情况下，srs会自动监控并重启ffmpeg进程
    /// 只有当ffmpeg不退出，但拉流出现异常时，srs无法主动发现并处理这样的情况
    /// 所以,本方法采用监控ffmpeg日志写入情况来判断拉流是否正常，当ffmpeg拉流
    /// 出现异常情况时，日志会疯狂写入，而正常拉流时日志内容非常少，因此本类做了
    /// 一个系统级的文件变化监控，当发生有文件变化时，写一个状态到阻塞队列，阻塞
    /// 队列会去处理这个状态，每次处理的时候都等待100毫秒，同时阻塞队列有一个数
    /// 量上线，当出现数量上线时，说明100毫秒一次的处理已经跟不上日志的产生了，
    /// 大概可以说明ffmpeg的日志在疯狂产生，因此在多次出现（这里确定的数量是100次）
    /// 这个情况的时候需要重启ingest拉流器来解决这个问题，这就是这个类的运作原理。
    /// </summary>
    public class IngestMonitor
    {
        private string _ffmpegLogPath;
        private string _logExt;
        private string? _deviceId;
        private List<MonitorStruct> _monitorStructList = new List<MonitorStruct>();
        private FileSystemWatcher _watcher = new FileSystemWatcher();

        public string FfmpegLogPath
        {
            get => _ffmpegLogPath;
            set => _ffmpegLogPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string LogExt
        {
            get => _logExt;
            set => _logExt = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? DeviceId
        {
            get => _deviceId;
            set => _deviceId = value;
        }

        public List<MonitorStruct> MonitorStructList
        {
            get => _monitorStructList;
            set => _monitorStructList = value ?? throw new ArgumentNullException(nameof(value));
        }

        public FileSystemWatcher Watcher
        {
            get => _watcher;
            set => _watcher = value;
        }

        private void restartIngest(string deviceId, string vhostDomain, Ingest ingest)
        {
            LogWriter.WriteLog("重启设备ID:" + deviceId + "下的" + vhostDomain + "下的" + ingest.IngestName + " Ingest");

            lock (SrsManageCommon.Common.LockDbObjForOnlineClient)
            {
                OrmService.Db.Delete<OnlineClient>().Where(x => x.RtspUrl == ingest.Input!.Url).ExecuteAffrows();
            }

            var retInt = foundProcess(ingest);
            if (retInt > -1)
            {
                try
                {
                    string cmd = "kill -9 " + retInt.ToString();
                    LinuxShell.Run(cmd, 1000);
                }
                catch (Exception ex)
                {
                    LogWriter.WriteLog(
                        "重启设备ID:" + deviceId + "下的" + vhostDomain + "下的" + ingest.IngestName + " Ingest失败",
                        ex.Message + "\r\n" + ex.StackTrace, ConsoleColor.Yellow);
                }
            }

            ResponseStruct rs = null!;
            VhostIngestApis.OnOrOffIngest(deviceId, vhostDomain, ingest.IngestName!, false, out rs);
            SystemApis.RefreshSrsObject(deviceId, out rs);
            Thread.Sleep(1000);
            VhostIngestApis.OnOrOffIngest(deviceId, vhostDomain, ingest.IngestName!, true, out rs);
            SystemApis.RefreshSrsObject(deviceId, out rs);
        }

        private int foundProcess(Ingest ingest)
        {
            string url = ingest.Input!.Url!.Replace("&", @"\&");
            string cmd = "ps  -aux |grep " + url + "|grep -v grep |awk '{print $2}'";
            LinuxShell.Run(cmd, 1000, out string sdt, out string err);
            if (string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(err))
            {
                return -1;
            }

            if (int.TryParse(sdt, out int i))
            {
                return i;
            }

            if (int.TryParse(err, out int j))
            {
                return j;
            }

            return -1;
        }


        private void OnChanged(object source, FileSystemEventArgs e)
        {
            var find = MonitorStructList.FindLast(x => x.Filename!.Equals(e.Name));
            if (find == null)
            {
                string[] strArr = e.Name.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string app = "";
                string vhost = "";
                string stream = "";
                if (strArr.Length >= 5)
                {
                    stream = strArr[4].TrimEnd(LogExt.ToCharArray()).Trim();
                    app = strArr[3].Trim();
                    vhost = strArr[2].Trim();
                }

                MonitorStructList.Add(new MonitorStruct(DeviceId!, vhost, app, stream, e.Name));
            }
            else
            {
                if (!find.HighFrequencyUpdateList.TryAdd(1, 50)) //尝试添加，超时50毫秒
                {
                    find.TimeOutTimes++; //超时了，超时数次+1
                }

                if (find.TimeOutTimes >= find.HighFrequencyUpdateList.BoundedCapacity) //如果超时次数大于最大队列数了，就要重启ingest了
                {
                    Watcher.EnableRaisingEvents = false;
                    Console.WriteLine("stop watcher");
                    string[] strArr = e.Name.Split('-', StringSplitOptions.RemoveEmptyEntries);
                    string app = "";
                    string vhost = "";
                    string stream = "";
                    if (strArr.Length >= 5)
                    {
                        stream = strArr[4].TrimEnd(LogExt.ToCharArray()).Trim();
                        app = strArr[3].Trim();
                        vhost = strArr[2].Trim();
                    }

                    Console.WriteLine("remove object");
                    try
                    {
                        for (int i = 0; i <= MonitorStructList.Count - 1; i++)
                        {
                            Console.WriteLine(MonitorStructList[i].Filename+"->"+find.Filename);
                            if (MonitorStructList[i].Filename!.Equals(find.Filename))
                            {
                                MonitorStructList[i].HighFrequencyUpdateList.Dispose();
                                MonitorStructList[i] = null!;
                                break;
                            }
                        }
                        /*MonitorStructList[MonitorStructList.IndexOf(find)].HighFrequencyUpdateList.Dispose();
                        MonitorStructList.Remove(find);*/
                        SrsManageCommon.Common.RemoveNull(MonitorStructList);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message+"\r\n"+ex.StackTrace);
                    }

                    Ingest ingest =
                        VhostIngestApis.GetVhostIngest(DeviceId!, vhost, stream, out ResponseStruct rs);
                    if (ingest == null || rs.Code != ErrorNumber.None)
                    {
                        Console.WriteLine("getIngest except:"+rs.Code.ToString()+" msg:"+rs.Message);
                    }
                    Console.WriteLine("get ingest");
                    restartIngest(DeviceId!, vhost, ingest!);
                    Console.WriteLine("restart ingest");
                    LogWriter.WriteLog("监控发现有Ingest异常，执行重启...",
                        string.Format("DeviceId:{0},Vhost:{1},App:{2},Stream:{3}", DeviceId, vhost, app, stream),
                        ConsoleColor.Yellow);
                    Console.WriteLine("start watcher");
                    Watcher.EnableRaisingEvents = true;
                }
            }
        }

        public IngestMonitor(string ffmpegLogPath, string logExt, string? deviceId)
        {
            _ffmpegLogPath = ffmpegLogPath;
            _logExt = logExt;
            _deviceId = deviceId;
            Watcher.Path = FfmpegLogPath;
            Watcher.IncludeSubdirectories = false;
            Watcher.Filter = "*" + LogExt;
            Watcher.Changed += OnChanged;
            Watcher.EnableRaisingEvents = true;
        }
    }
}
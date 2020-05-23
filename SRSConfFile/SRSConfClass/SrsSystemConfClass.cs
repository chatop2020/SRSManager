using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SRSConfFile.SRSConfClass
{
    [Serializable]
    public class SrsSystemConfClass : SrsConfBase
    {
        private bool? asprocess; //if parent process quit the srs process will be exit if is true

        private bool? auto_reload_for_docker; //If on, it will set inotify_auto_reload to on in docker, even it's off.
        private ushort? chunk_size; //default 60000 ,min 128 max 65536

        private string? confFilePath;
        private List<string>? configLines;
        private List<string>? configLinesTrim;

        private bool? daemon; //will be run on backgroud default true
        private string? deviceId;

        private bool?
            disable_daemon_for_docker; //whether disable daemon type for docker,if on will set daemon to false in docker,even daemon is on.

        private bool?
            empty_ip_ok; //if client ip is empty the ignore this connect without warnings or errors if it is true

        private string? ff_log_dir; //ffmpeg log path,if "/dev/null" will be disable ffmpeg log output
        private string? ff_log_level; //ffmpeg log level default is info
        private bool? force_grace_quit; //force gracefully quit,not fast quit,default is false
        private int? grace_final_wait; //exit process will be wait a few ms,default is 3200ms this is the max wait time

        private int? grace_start_wait; //exit process will be wait a few ms,default is 2300ms
        private SrsHeartbeatConfClass? heartbeat;
        private SrsHttpApiConfClass? http_api;
        private SrsHttpServerConfClass? http_server;

        private bool?
            inotify_auto_reload; //Whether auto reload by watching the config file by inotify,i think inotify is system message event,if config be changed then srs will be reload it as soon,default is false

        private SrsKafkaConfClass? kafka;
        private ushort? listen; //rtmp listen port,default 1935(rtmp default)

        private ushort?
            max_connections; //defalut is 1000,if exceed the max connections,server will drop the new connection

        private string? pid; // srs process id path

        //if true will be use gmtime() generate the time struct,default false
        private int? pithy_print_ms; //print out time interval use unit is microsecond
        private SrsRtcServerConfClass? rtc_server;
        private string? srs_log_file; //if srs log output type is file ,then log will be push to path of the var

        private string? srs_log_level; //srs log level can be verbose,info,trace,warn,error

        private string?
            srs_log_tank; //srs log output type if is "file" will be push to file else if is "console" then push log to console

        private SrsSrtServerConfClass? srtServer;
        private SrsStatsConfClass? stats;
        private List<SrsStreamCasterConfClass>? stream_casters;
        private string? streamNodeIpAddr;
        private ushort? streamNodPort;
        private float? tcmalloc_release_rate;

        private bool? utc_time; //use utc_time to generate the time struct,if false will be use localtime to generate it
        private List<SrsvHostConfClass>? vhosts;
        private string? work_dir; //work on this dir

        public SrsSystemConfClass()
        {
        }

        public SrsSystemConfClass(string confPath)
        {
            if (File.Exists(confPath))
            {
                ConfFilePath = confPath;
                if (ConfigLines == null) ConfigLines = new List<string>();
                ConfigLines.Clear();
                if (ConfigLinesTrim == null) ConfigLinesTrim = new List<string>();
                ConfigLinesTrim.Clear();
                foreach (string str in File.ReadAllLines(confPath, Encoding.Default))
                {
                    var str_tmp = str.Trim();
                    if (!string.IsNullOrEmpty(str_tmp) && !str_tmp.StartsWith('#'))
                    {
                        ConfigLines.Add(str);
                        ConfigLinesTrim.Add(str_tmp);
                    }
                }
            }
        }

        public SrsRtcServerConfClass? Rtc_server
        {
            get => rtc_server;
            set => rtc_server = value;
        }

        public float? Tcmalloc_release_rate
        {
            get => tcmalloc_release_rate;
            set => tcmalloc_release_rate = value;
        }

        public ushort? Listen
        {
            get => listen;
            set => listen = value;
        }

        public string? Pid
        {
            get => pid;
            set => pid = value;
        }

        public ushort? Chunk_size
        {
            get => chunk_size;
            set => chunk_size = value;
        }

        public string? Ff_log_dir
        {
            get => ff_log_dir;
            set => ff_log_dir = value;
        }

        public string? Ff_log_level
        {
            get => ff_log_level;
            set => ff_log_level = value;
        }

        public string? Srs_log_tank
        {
            get => srs_log_tank;
            set => srs_log_tank = value;
        }

        public string? Srs_log_level
        {
            get => srs_log_level;
            set => srs_log_level = value;
        }

        public string? Srs_log_file
        {
            get => srs_log_file;
            set => srs_log_file = value;
        }

        public ushort? Max_connections
        {
            get => max_connections;
            set => max_connections = value;
        }

        public bool? Daemon
        {
            get => daemon;
            set => daemon = value;
        }

        public bool? Utc_time
        {
            get => utc_time;
            set => utc_time = value;
        }

        public int? Pithy_print_ms
        {
            get => pithy_print_ms;
            set => pithy_print_ms = value;
        }

        public string? Work_dir
        {
            get => work_dir;
            set => work_dir = value;
        }

        public bool? Asprocess
        {
            get => asprocess;
            set => asprocess = value;
        }

        public bool? Empty_ip_ok
        {
            get => empty_ip_ok;
            set => empty_ip_ok = value;
        }

        public int? Grace_start_wait
        {
            get => grace_start_wait;
            set => grace_start_wait = value;
        }

        public int? Grace_final_wait
        {
            get => grace_final_wait;
            set => grace_final_wait = value;
        }

        public bool? Force_grace_quit
        {
            get => force_grace_quit;
            set => force_grace_quit = value;
        }

        public bool? Disable_daemon_for_docker
        {
            get => disable_daemon_for_docker;
            set => disable_daemon_for_docker = value;
        }

        public bool? Inotify_auto_reload
        {
            get => inotify_auto_reload;
            set => inotify_auto_reload = value;
        }

        public bool? Auto_reload_for_docker
        {
            get => auto_reload_for_docker;
            set => auto_reload_for_docker = value;
        }


        public SrsHeartbeatConfClass? Heartbeat
        {
            get => heartbeat;
            set => heartbeat = value;
        }

        public SrsStatsConfClass? Stats
        {
            get => stats;
            set => stats = value;
        }

        public SrsHttpApiConfClass? Http_api
        {
            get => http_api;
            set => http_api = value;
        }

        public SrsHttpServerConfClass? Http_server
        {
            get => http_server;
            set => http_server = value;
        }

        public List<SrsStreamCasterConfClass>? Stream_casters
        {
            get => stream_casters;
            set => stream_casters = value;
        }

        public SrsSrtServerConfClass? Srt_server
        {
            get => srtServer;
            set => srtServer = value;
        }

        public SrsKafkaConfClass? Kafka
        {
            get => kafka;
            set => kafka = value;
        }

        public List<SrsvHostConfClass>? Vhosts
        {
            get => vhosts;
            set => vhosts = value;
        }

        public List<string>? ConfigLines
        {
            get => configLines;
            set => configLines = value;
        }

        public string? StreamNodeIpAddr
        {
            get => streamNodeIpAddr;
            set => streamNodeIpAddr = value;
        }

        public ushort? StreamNodPort
        {
            get => streamNodPort;
            set => streamNodPort = value;
        }

        public string? DeviceId
        {
            get => deviceId;
            set => deviceId = value;
        }

        public List<string>? ConfigLinesTrim
        {
            get => configLinesTrim;
            set => configLinesTrim = value;
        }

        public string? ConfFilePath
        {
            get => confFilePath;
            set => confFilePath = value;
        }
    }
}
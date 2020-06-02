using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;

namespace SrsApis.SrsManager.Apis.ApiModules
{
    [Serializable]
    public class Self_Srs
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Version { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public int? Pid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Ppid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Argv { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string? Cwd { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public long? Mem_kbyte { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Mem_percent { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public float? Cpu_percent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Srs_uptime { get; set; }
    }

    [Serializable]
    public class System_Srs
    {
        /// <summary>
        /// 
        /// </summary>
        public float? Cpu_percent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Disk_read_KBps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Disk_write_KBps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Disk_busy_percent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Mem_ram_kbyte { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? Mem_ram_percent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Mem_swap_kbyte { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Mem_swap_percent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Cpus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Cpus_online { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? Uptime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? Ilde_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? Load_1m { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? Load_5m { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? Load_15m { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Net_sample_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Net_recv_bytes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Net_send_bytes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Net_recvi_bytes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Net_sendi_bytes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Srs_sample_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Srs_recv_bytes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Srs_send_bytes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Conn_sys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Conn_sys_et { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Conn_sys_tw { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Conn_sys_udp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Conn_srs { get; set; }
    }

    [Serializable]
    public class Data_Srs
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Ok { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public long? Now_ms { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Self")]
        public Self_Srs? Self { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("System")]
        public System_Srs? System { get; set; } = null!;
    }

    [Serializable]
    public class SrsSystemInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Server { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Data")]
        public Data_Srs? Data { get; set; } = null!;
    }

    public class SystemInfoModule
    {
        private string? architecture;
        private ushort? cpuCoreSize;
        private List<DriveDiskInfo>? disksInfo;
        private string? hostName;
        private List<NetworkInterfaceModule>? networkInterfaceList;
        private string? platform;
        private string? version;
        private bool? x64;
        private List<Self_Srs>? _srsList;
        private System_Srs? _system;

        public List<Self_Srs>? SrsList
        {
            get => _srsList;
            set => _srsList = value;
        }

        [JsonProperty("System")]
        public System_Srs? System
        {
            get => _system;
            set => _system = value ?? throw new ArgumentNullException(nameof(value));
        }


        public List<NetworkInterfaceModule> NetworkInterfaceList
        {
            get => networkInterfaceList!;
            set => networkInterfaceList = value;
        }

        public List<DriveDiskInfo> DisksInfo
        {
            get => disksInfo!;
            set => disksInfo = value;
        }


        public string Platform
        {
            get => platform!;
            set => platform = value;
        }

        public string Architecture
        {
            get => architecture!;
            set => architecture = value;
        }

        public bool? X64
        {
            get => x64!;
            set => x64 = value;
        }

        public string HostName
        {
            get => hostName!;
            set => hostName = value;
        }

        public ushort? CpuCoreSize
        {
            get => cpuCoreSize;
            set => cpuCoreSize = value;
        }

        public string Version
        {
            get => version!;
            set => version = value;
        }
    }
}
using System.Collections.Generic;

namespace SRSApis.SRSManager.Apis.ApiModules
{
    public class SystemInfoModule
    {
        private string? architecture;
        private ushort? cpuCoreSize;

        private List<DriveDiskInfo>? disksInfo;
        private string? hostName;
        private List<NetworkInterfaceModule>? networkInterfaceList;

        /*private UInt64 systemTotalMemorySize;
        private UInt64 systemFreeMemorySize;*/
        private string? platform;
        private string? version;
        private bool? x64;

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

        /*
        public ulong SystemTotalMemorySize
        {
            get => systemTotalMemorySize;
            set => systemTotalMemorySize = value;
        }

        public ulong SystemFreeMemorySize
        {
            get => systemFreeMemorySize;
            set => systemFreeMemorySize = value;
        }
        */

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
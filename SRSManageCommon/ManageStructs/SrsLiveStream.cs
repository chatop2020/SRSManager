using System;
using SrsManageCommon;

namespace SRSManageCommon.ManageStructs
{
    [Serializable]
    public class SrsLiveStream
    {
        private string? _deviceId;
        private string? _vhostDomain;
        private string? _ingestName;
        private string? _liveStream;
        private MonitorType? _monitorType;

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

        public string? IngestName
        {
            get => _ingestName;
            set => _ingestName = value;
        }

        public string? LiveStream
        {
            get => _liveStream;
            set => _liveStream = value;
        }

        public MonitorType? MonitorType
        {
            get => _monitorType;
            set => _monitorType = value;
        }
    }
}
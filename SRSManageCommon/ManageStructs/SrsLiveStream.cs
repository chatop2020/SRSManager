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
        private string? _app;
        private string? _stream;
        private MonitorType? _monitorType;
        private string? _ipAddress;
        private string? _username;
        private string? _password;

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
            set
            {
                _liveStream = value;
                try
                {
                    string[] arr = _liveStream!.Split("/", StringSplitOptions.RemoveEmptyEntries);
                    _app = arr[0];
                    _stream = arr[1];
                }
                catch
                {
                    // ignored
                }
            }
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


        public MonitorType? MonitorType
        {
            get => _monitorType;
            set => _monitorType = value;
        }

        public string? IpAddress
        {
            get => _ipAddress;
            set => _ipAddress = value;
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
}
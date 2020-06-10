using System;

namespace SRSManageCommon.ControllerStructs.RequestModules
{
    [Serializable]
    public class ReqGetDvrPlan
    {
        private string? _deviceId;
        private string? _vhostDomain;
        private string? _app;
        private string? _stream;

        public string? DeviceId
        {
            get => _deviceId;
            set => _deviceId = value ?? throw new ArgumentNullException(nameof(value));
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
    }
}
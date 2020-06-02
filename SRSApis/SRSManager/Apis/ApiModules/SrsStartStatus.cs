using System;

namespace SrsApis.SrsManager.Apis.ApiModules
{
    [Serializable]
    public class SrsStartStatus
    {
        private string? _deviceId = null!;
        private bool? _isStarted;
        private string? _message;

        public string? DeviceId
        {
            get => _deviceId;
            set => _deviceId = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool? IsStarted
        {
            get => _isStarted;
            set => _isStarted = value;
        }

        public string? Message
        {
            get => _message;
            set => _message = value;
        }
    }
}
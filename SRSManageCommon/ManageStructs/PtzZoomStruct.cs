using System;

namespace SRSManageCommon.ManageStructs
{
    [Serializable]
    public enum ZoomDir
    {
        MORE,
        LESS,
    }

    [Serializable]
    public class PtzZoomStruct
    {
        private string? _ipAddr;
        private string? _profileToken;
        private ZoomDir? _zoomDir;

        public string? IpAddr
        {
            get => _ipAddr;
            set => _ipAddr = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? ProfileToken
        {
            get => _profileToken;
            set => _profileToken = value ?? throw new ArgumentNullException(nameof(value));
        }

        public ZoomDir? ZoomDir
        {
            get => _zoomDir;
            set => _zoomDir = value;
        }
    }
}
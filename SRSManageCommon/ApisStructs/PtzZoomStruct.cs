using System;

namespace SrsManageCommon.ApisStructs
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
        private string ipAddr;
        private string profileToken;
        private ZoomDir zoomDir;

        public string IpAddr
        {
            get => ipAddr;
            set => ipAddr = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string ProfileToken
        {
            get => profileToken;
            set => profileToken = value ?? throw new ArgumentNullException(nameof(value));
        }

        public ZoomDir ZoomDir
        {
            get => zoomDir;
            set => zoomDir = value;
        }
    }
}
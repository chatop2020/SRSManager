using System;

namespace SRSConfFile.SRSConfClass
{
    [Serializable]
    public class SrsHttpServerConfClass : SrsConfBase
    {
        private string? _instanceName;
        private bool? crossdomain;
        private string? dir; //webroot path
        private bool? enabled;
        private ushort? listen = 8080;

        public SrsHttpServerConfClass()
        {
            SectionsName = "http_server";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public ushort? Listen
        {
            get => listen;
            set => listen = value;
        }

        public string? Dir
        {
            get => dir;
            set => dir = value;
        }

        public bool? Crossdomain
        {
            get => crossdomain;
            set => crossdomain = value;
        }

        public string? InstanceName
        {
            get => _instanceName;
            set => _instanceName = value;
        }
    }
}
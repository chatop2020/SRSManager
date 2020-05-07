using System;

namespace SRSConfFile.SRSConfClass
{
    [Serializable]
    public class RawApi : SrsConfBase
    {
        private bool? enabled;
        private bool? allow_reload;
        private bool? allow_query;
        private bool? allow_update;

        public RawApi()
        {
            SectionsName = "raw_api";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public bool? Allow_reload
        {
            get => allow_reload;
            set => allow_reload = value;
        }

        public bool? Allow_query
        {
            get => allow_query;
            set => allow_query = value;
        }

        public bool? Allow_update
        {
            get => allow_update;
            set => allow_update = value;
        }
    }

    [Serializable]
    public class SrsHttpApiConfClass : SrsConfBase
    {
        private string? instanceName;
        private bool? enabled;
        private ushort? listen; //httpapi port
        private bool? crossdomain; //if true can crossdomain
        private RawApi? raw_Api;

        public SrsHttpApiConfClass()
        {
            SectionsName = "http_api";
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

        public bool? Crossdomain
        {
            get => crossdomain;
            set => crossdomain = value;
        }

        public RawApi? Raw_Api
        {
            get => raw_Api;
            set => raw_Api = value;
        }

        public string? InstanceName
        {
            get => instanceName;
            set => instanceName = value;
        }
    }
}
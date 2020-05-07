using System;

namespace SRSConfFile.SRSConfClass
{
    [Serializable]
    public class SrsSrtServerConfClass : SrsConfBase
    {
        private string? _instanceName;
        private bool? enabled;
        private ushort? listen;
        private int? maxbw;
        private int? connect_timeout;
        private int? peerlatency;
        private int? recvlatency;
        private string? default_app;

        public string? Default_app
        {
            get => default_app;
            set => default_app = value;
        }

        public SrsSrtServerConfClass()
        {
            SectionsName = "srt_server";
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

        public int? Maxbw
        {
            get => maxbw;
            set => maxbw = value;
        }

        public int? Connect_timeout
        {
            get => connect_timeout;
            set => connect_timeout = value;
        }

        public int? Peerlatency
        {
            get => peerlatency;
            set => peerlatency = value;
        }

        public int? Recvlatency
        {
            get => recvlatency;
            set => recvlatency = value;
        }


        public string? InstanceName
        {
            get => _instanceName;
            set => _instanceName = value;
        }
    }
}
using System;

namespace SRSConfFile.SRSConfClass
{
    [Serializable]
    public class BlackHole : SrsConfBase
    {
        private bool? enabled;
        private string? publisher;

        public BlackHole()
        {
            SectionsName = "black_hole";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? Publisher
        {
            get => publisher;
            set => publisher = value;
        }
    }

    [Serializable]
    public class SrsRtcServerConfClass : SrsConfBase
    {
        private bool? enabled;
        private ushort? listen;
        private string? candidate;
        private bool? ecdsa;
        private ushort? sendmmsg;
        private bool? encrypt;
        private ushort? reuseport;
        private bool? merge_nalus;
        private bool? gso;
        private ushort? padding;
        private bool? perf_stat;
        private ushort? queue_length;
        private BlackHole? black_hole;

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

        public string? Candidate
        {
            get => candidate;
            set => candidate = value;
        }

        public bool? Ecdsa
        {
            get => ecdsa;
            set => ecdsa = value;
        }

        public ushort? Sendmmsg
        {
            get => sendmmsg;
            set => sendmmsg = value;
        }

        public bool? Encrypt
        {
            get => encrypt;
            set => encrypt = value;
        }

        public ushort? Reuseport
        {
            get => reuseport;
            set => reuseport = value;
        }

        public bool? Merge_nalus
        {
            get => merge_nalus;
            set => merge_nalus = value;
        }

        public bool? Gso
        {
            get => gso;
            set => gso = value;
        }

        public ushort? Padding
        {
            get => padding;
            set => padding = value;
        }

        public bool? Perf_stat
        {
            get => perf_stat;
            set => perf_stat = value;
        }

        public ushort? Queue_length
        {
            get => queue_length;
            set => queue_length = value;
        }

        public BlackHole? Black_hole
        {
            get => black_hole;
            set => black_hole = value;
        }

        public SrsRtcServerConfClass()
        {
            SectionsName = "rtc_server";
        }
    }
}
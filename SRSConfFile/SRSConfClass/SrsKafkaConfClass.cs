using System;

namespace SrsConfFile.SRSConfClass
{
    [Serializable]
    public class SrsKafkaConfClass : SrsConfBase
    {
        private string? _instanceName;
        private string? brokers;
        private bool? enabled;
        private string? topic;

        public SrsKafkaConfClass()
        {
            SectionsName = "kafka";
        }


        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? Brokers
        {
            get => brokers;
            set => brokers = value;
        }

        public string? Topic
        {
            get => topic;
            set => topic = value;
        }

        public string? InstanceName
        {
            get => _instanceName;
            set => _instanceName = value;
        }
    }
}
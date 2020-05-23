using System;

namespace SRSConfFile.SRSConfClass
{
    [Serializable]
    public class SrsHeartbeatConfClass : SrsConfBase
    {
        private string? _instanceName;

        //    {
        //       "device_id": "my-srs-device",
        //       "ip": "192.168.1.100"
        //   }
        private string? device_id; //the srs name

        private bool? enabled; //if true will be push srs status to other server(webapi),

        //to report self is live of died,config stats.network must be setted
        private float? interval; //how many seconds to report a per

        private bool?
            summaries; //if true will be report srs run information ,such as cpu rate,memory use rate,network ...

        private string? url; //server webapi url,will write like this 


        public SrsHeartbeatConfClass()
        {
            SectionsName = "heartbeat";
        }


        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public float? Interval
        {
            get => interval;
            set => interval = value;
        }

        public string? Url
        {
            get => url;
            set => url = value;
        }

        public string? Device_id
        {
            get => device_id;
            set => device_id = value;
        }

        public bool? Summaries
        {
            get => summaries;
            set => summaries = value;
        }

        public string? InstanceName
        {
            get => _instanceName;
            set => _instanceName = value;
        }
    }
}
using System;

namespace SRSApis.SRSManager.Apis.ApiModules
{
    [Serializable]
    public class VhostIngestNameModule
    {
        private string? vhostDomain;
        private string? ingestInstanceName;

        public string? VhostDomain
        {
            get => vhostDomain;
            set => vhostDomain = value;
        }

        public string? IngestInstanceName
        {
            get => ingestInstanceName;
            set => ingestInstanceName = value;
        }
    }
}
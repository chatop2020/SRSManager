using System;

namespace SRSManageCommon.ManageStructs
{
    [Serializable]
    public class VhostIngestNameModule
    {
        private string? ingestInstanceName;
        private string? vhostDomain;

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
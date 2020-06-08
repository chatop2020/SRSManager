using System;

namespace SRSManageCommon.ManageStructs
{
    [Serializable]
    public class VhostTranscodeNameModule
    {
        private string? transcodeInstanceName;
        private string? vhostDomain;

        public string? VhostDomain
        {
            get => vhostDomain;
            set => vhostDomain = value;
        }

        public string? TranscodeInstanceName
        {
            get => transcodeInstanceName;
            set => transcodeInstanceName = value;
        }
    }
}
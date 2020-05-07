using System;

namespace SRSApis.SRSManager.Apis.ApiModules
{
    [Serializable]
    public class VhostTranscodeNameModule
    {
        private string? vhostDomain;
        private string? transcodeInstanceName;

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
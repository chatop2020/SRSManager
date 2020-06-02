using System;

namespace SrsConfFile.SRSConfClass
{
    [Serializable]
    public class SrsStatsConfClass : SrsConfBase
    {
        private string? disk; //monitor disk list use bankspace split 
        private byte? network; //network device index for use

        public SrsStatsConfClass()
        {
            SectionsName = "stats";
        }

        public byte? Network
        {
            get => network;
            set => network = value;
        }

        public string? Disk
        {
            get => disk;
            set => disk = value;
        }
    }
}
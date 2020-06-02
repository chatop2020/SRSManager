using System;

namespace SrsConfFile.SRSConfClass
{
    [Serializable]
    public class SrsConfBase
    {
        private string? sectionsName;

        public string? SectionsName
        {
            get => sectionsName;
            set => sectionsName = value;
        }
    }
}
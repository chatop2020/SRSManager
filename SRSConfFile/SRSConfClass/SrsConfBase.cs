using System;
using System.Text.Json.Serialization;


namespace SrsConfFile.SRSConfClass
{
    [Serializable]
    public class SrsConfBase
    {
        private string? sectionsName;
      
        [JsonIgnore]
        public string? SectionsName
        {
            get => sectionsName;
            set => sectionsName = value;
        }
    }
}
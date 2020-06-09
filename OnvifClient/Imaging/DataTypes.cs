using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Mictlanix.DotNet.Onvif.Imaging
{
    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver20/imaging/wsdl")]
    public partial class Capabilities
    {
        private XElement[] anyField;

        private bool imageStabilizationField;

        private bool imageStabilizationFieldSpecified;

        private bool presetsField;

        private bool presetsFieldSpecified;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool ImageStabilization
        {
            get { return this.imageStabilizationField; }
            set { this.imageStabilizationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ImageStabilizationSpecified
        {
            get { return this.imageStabilizationFieldSpecified; }
            set { this.imageStabilizationFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool Presets
        {
            get { return this.presetsField; }
            set { this.presetsField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool PresetsSpecified
        {
            get { return this.presetsFieldSpecified; }
            set { this.presetsFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver20/imaging/wsdl")]
    public partial class ImagingPreset
    {
        private string nameField;

        private string tokenField;

        private string typeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string token
        {
            get { return this.tokenField; }
            set { this.tokenField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }
    }
}
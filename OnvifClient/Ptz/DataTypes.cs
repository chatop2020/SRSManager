using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Mictlanix.DotNet.Onvif.Ptz
{
    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver20/ptz/wsdl")]
    public partial class Capabilities
    {
        private XElement[] anyField;

        private bool eFlipField;

        private bool eFlipFieldSpecified;

        private bool getCompatibleConfigurationsField;

        private bool getCompatibleConfigurationsFieldSpecified;

        private bool moveStatusField;

        private bool moveStatusFieldSpecified;

        private bool reverseField;

        private bool reverseFieldSpecified;

        private bool statusPositionField;

        private bool statusPositionFieldSpecified;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool EFlip
        {
            get { return this.eFlipField; }
            set { this.eFlipField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool EFlipSpecified
        {
            get { return this.eFlipFieldSpecified; }
            set { this.eFlipFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool Reverse
        {
            get { return this.reverseField; }
            set { this.reverseField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ReverseSpecified
        {
            get { return this.reverseFieldSpecified; }
            set { this.reverseFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool GetCompatibleConfigurations
        {
            get { return this.getCompatibleConfigurationsField; }
            set { this.getCompatibleConfigurationsField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool GetCompatibleConfigurationsSpecified
        {
            get { return this.getCompatibleConfigurationsFieldSpecified; }
            set { this.getCompatibleConfigurationsFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool MoveStatus
        {
            get { return this.moveStatusField; }
            set { this.moveStatusField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MoveStatusSpecified
        {
            get { return this.moveStatusFieldSpecified; }
            set { this.moveStatusFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool StatusPosition
        {
            get { return this.statusPositionField; }
            set { this.statusPositionField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool StatusPositionSpecified
        {
            get { return this.statusPositionFieldSpecified; }
            set { this.statusPositionFieldSpecified = value; }
        }
    }
}
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;
using Mictlanix.DotNet.Onvif.Common;

namespace Mictlanix.DotNet.Onvif.Media
{
    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/media/wsdl")]
    public partial class Capabilities
    {
        private XElement[] anyField;

        private bool eXICompressionField;

        private bool eXICompressionFieldSpecified;

        private bool oSDField;

        private bool oSDFieldSpecified;
        private ProfileCapabilities profileCapabilitiesField;

        private bool rotationField;

        private bool rotationFieldSpecified;

        private bool snapshotUriField;

        private bool snapshotUriFieldSpecified;

        private StreamingCapabilities streamingCapabilitiesField;

        private bool temporaryOSDTextField;

        private bool temporaryOSDTextFieldSpecified;

        private bool videoSourceModeField;

        private bool videoSourceModeFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ProfileCapabilities ProfileCapabilities
        {
            get { return this.profileCapabilitiesField; }
            set { this.profileCapabilitiesField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public StreamingCapabilities StreamingCapabilities
        {
            get { return this.streamingCapabilitiesField; }
            set { this.streamingCapabilitiesField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool SnapshotUri
        {
            get { return this.snapshotUriField; }
            set { this.snapshotUriField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool SnapshotUriSpecified
        {
            get { return this.snapshotUriFieldSpecified; }
            set { this.snapshotUriFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool Rotation
        {
            get { return this.rotationField; }
            set { this.rotationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RotationSpecified
        {
            get { return this.rotationFieldSpecified; }
            set { this.rotationFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool VideoSourceMode
        {
            get { return this.videoSourceModeField; }
            set { this.videoSourceModeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool VideoSourceModeSpecified
        {
            get { return this.videoSourceModeFieldSpecified; }
            set { this.videoSourceModeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool OSD
        {
            get { return this.oSDField; }
            set { this.oSDField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool OSDSpecified
        {
            get { return this.oSDFieldSpecified; }
            set { this.oSDFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool TemporaryOSDText
        {
            get { return this.temporaryOSDTextField; }
            set { this.temporaryOSDTextField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool TemporaryOSDTextSpecified
        {
            get { return this.temporaryOSDTextFieldSpecified; }
            set { this.temporaryOSDTextFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool EXICompression
        {
            get { return this.eXICompressionField; }
            set { this.eXICompressionField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool EXICompressionSpecified
        {
            get { return this.eXICompressionFieldSpecified; }
            set { this.eXICompressionFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/media/wsdl")]
    public partial class ProfileCapabilities
    {
        private XElement[] anyField;

        private int maximumNumberOfProfilesField;

        private bool maximumNumberOfProfilesFieldSpecified;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int MaximumNumberOfProfiles
        {
            get { return this.maximumNumberOfProfilesField; }
            set { this.maximumNumberOfProfilesField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaximumNumberOfProfilesSpecified
        {
            get { return this.maximumNumberOfProfilesFieldSpecified; }
            set { this.maximumNumberOfProfilesFieldSpecified = value; }
        }
    }


    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/media/wsdl")]
    public partial class VideoSourceModeExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/media/wsdl")]
    public partial class VideoSourceMode
    {
        private string descriptionField;

        private bool enabledField;

        private bool enabledFieldSpecified;

        private string encodingsField;

        private VideoSourceModeExtension extensionField;
        private float maxFramerateField;

        private VideoResolution maxResolutionField;

        private bool rebootField;

        private string tokenField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public float MaxFramerate
        {
            get { return this.maxFramerateField; }
            set { this.maxFramerateField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public VideoResolution MaxResolution
        {
            get { return this.maxResolutionField; }
            set { this.maxResolutionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string Encodings
        {
            get { return this.encodingsField; }
            set { this.encodingsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool Reboot
        {
            get { return this.rebootField; }
            set { this.rebootField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string Description
        {
            get { return this.descriptionField; }
            set { this.descriptionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public VideoSourceModeExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
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
        public bool Enabled
        {
            get { return this.enabledField; }
            set { this.enabledField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnabledSpecified
        {
            get { return this.enabledFieldSpecified; }
            set { this.enabledFieldSpecified = value; }
        }
    }


    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/media/wsdl")]
    public partial class StreamingCapabilities
    {
        private XElement[] anyField;

        private bool nonAggregateControlField;

        private bool nonAggregateControlFieldSpecified;

        private bool noRTSPStreamingField;

        private bool noRTSPStreamingFieldSpecified;

        private bool rTP_RTSP_TCPField;

        private bool rTP_RTSP_TCPFieldSpecified;

        private bool rTP_TCPField;

        private bool rTP_TCPFieldSpecified;

        private bool rTPMulticastField;

        private bool rTPMulticastFieldSpecified;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool RTPMulticast
        {
            get { return this.rTPMulticastField; }
            set { this.rTPMulticastField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RTPMulticastSpecified
        {
            get { return this.rTPMulticastFieldSpecified; }
            set { this.rTPMulticastFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool RTP_TCP
        {
            get { return this.rTP_TCPField; }
            set { this.rTP_TCPField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RTP_TCPSpecified
        {
            get { return this.rTP_TCPFieldSpecified; }
            set { this.rTP_TCPFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool RTP_RTSP_TCP
        {
            get { return this.rTP_RTSP_TCPField; }
            set { this.rTP_RTSP_TCPField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RTP_RTSP_TCPSpecified
        {
            get { return this.rTP_RTSP_TCPFieldSpecified; }
            set { this.rTP_RTSP_TCPFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool NonAggregateControl
        {
            get { return this.nonAggregateControlField; }
            set { this.nonAggregateControlField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool NonAggregateControlSpecified
        {
            get { return this.nonAggregateControlFieldSpecified; }
            set { this.nonAggregateControlFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool NoRTSPStreaming
        {
            get { return this.noRTSPStreamingField; }
            set { this.noRTSPStreamingField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool NoRTSPStreamingSpecified
        {
            get { return this.noRTSPStreamingFieldSpecified; }
            set { this.noRTSPStreamingFieldSpecified = value; }
        }
    }
}
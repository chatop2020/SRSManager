using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Mictlanix.DotNet.Onvif.Device;

namespace Mictlanix.DotNet.Onvif.Common
{
    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OnvifVersion
    {
        private int majorField;

        private int minorField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int Major
        {
            get { return this.majorField; }
            set { this.majorField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Minor
        {
            get { return this.minorField; }
            set { this.minorField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class LocalOrientation
    {
        private XElement[] anyField;

        private float panField;

        private bool panFieldSpecified;

        private float rollField;

        private bool rollFieldSpecified;

        private float tiltField;

        private bool tiltFieldSpecified;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float pan
        {
            get { return this.panField; }
            set { this.panField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool panSpecified
        {
            get { return this.panFieldSpecified; }
            set { this.panFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float tilt
        {
            get { return this.tiltField; }
            set { this.tiltField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool tiltSpecified
        {
            get { return this.tiltFieldSpecified; }
            set { this.tiltFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float roll
        {
            get { return this.rollField; }
            set { this.rollField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool rollSpecified
        {
            get { return this.rollFieldSpecified; }
            set { this.rollFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class LocalLocation
    {
        private XElement[] anyField;

        private float xField;

        private bool xFieldSpecified;

        private float yField;

        private bool yFieldSpecified;

        private float zField;

        private bool zFieldSpecified;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float x
        {
            get { return this.xField; }
            set { this.xField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool xSpecified
        {
            get { return this.xFieldSpecified; }
            set { this.xFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float y
        {
            get { return this.yField; }
            set { this.yField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ySpecified
        {
            get { return this.yFieldSpecified; }
            set { this.yFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float z
        {
            get { return this.zField; }
            set { this.zField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool zSpecified
        {
            get { return this.zFieldSpecified; }
            set { this.zFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class GeoOrientation
    {
        private XElement[] anyField;

        private float pitchField;

        private bool pitchFieldSpecified;

        private float rollField;

        private bool rollFieldSpecified;

        private float yawField;

        private bool yawFieldSpecified;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float roll
        {
            get { return this.rollField; }
            set { this.rollField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool rollSpecified
        {
            get { return this.rollFieldSpecified; }
            set { this.rollFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float pitch
        {
            get { return this.pitchField; }
            set { this.pitchField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool pitchSpecified
        {
            get { return this.pitchFieldSpecified; }
            set { this.pitchFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float yaw
        {
            get { return this.yawField; }
            set { this.yawField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool yawSpecified
        {
            get { return this.yawFieldSpecified; }
            set { this.yawFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class GeoLocation
    {
        private XElement[] anyField;

        private float elevationField;

        private bool elevationFieldSpecified;

        private double latField;

        private bool latFieldSpecified;

        private double lonField;

        private bool lonFieldSpecified;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public double lon
        {
            get { return this.lonField; }
            set { this.lonField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool lonSpecified
        {
            get { return this.lonFieldSpecified; }
            set { this.lonFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public double lat
        {
            get { return this.latField; }
            set { this.latField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool latSpecified
        {
            get { return this.latFieldSpecified; }
            set { this.latFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float elevation
        {
            get { return this.elevationField; }
            set { this.elevationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool elevationSpecified
        {
            get { return this.elevationFieldSpecified; }
            set { this.elevationFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class LocationEntity
    {
        private bool autoGeoField;

        private bool autoGeoFieldSpecified;

        private string entityField;

        private bool fixedField;

        private bool fixedFieldSpecified;
        private GeoLocation geoLocationField;

        private GeoOrientation geoOrientationField;

        private string geoSourceField;

        private LocalLocation localLocationField;

        private LocalOrientation localOrientationField;

        private string tokenField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public GeoLocation GeoLocation
        {
            get { return this.geoLocationField; }
            set { this.geoLocationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public GeoOrientation GeoOrientation
        {
            get { return this.geoOrientationField; }
            set { this.geoOrientationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public LocalLocation LocalLocation
        {
            get { return this.localLocationField; }
            set { this.localLocationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public LocalOrientation LocalOrientation
        {
            get { return this.localOrientationField; }
            set { this.localOrientationField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Entity
        {
            get { return this.entityField; }
            set { this.entityField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Token
        {
            get { return this.tokenField; }
            set { this.tokenField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool Fixed
        {
            get { return this.fixedField; }
            set { this.fixedField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool FixedSpecified
        {
            get { return this.fixedFieldSpecified; }
            set { this.fixedFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "anyURI")]
        public string GeoSource
        {
            get { return this.geoSourceField; }
            set { this.geoSourceField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool AutoGeo
        {
            get { return this.autoGeoField; }
            set { this.autoGeoField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool AutoGeoSpecified
        {
            get { return this.autoGeoFieldSpecified; }
            set { this.autoGeoFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SystemLogUri
    {
        private XElement[] anyField;
        private SystemLogType typeField;

        private string uriField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public SystemLogType Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 1)]
        public string Uri
        {
            get { return this.uriField; }
            set { this.uriField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum SystemLogType
    {
        /// <remarks/>
        System,

        /// <remarks/>
        Access,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot11AvailableNetworksExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot11AvailableNetworks
    {
        private Dot11AuthAndMangementSuite[] authAndMangementSuiteField;

        private string bSSIDField;

        private Dot11AvailableNetworksExtension extensionField;

        private Dot11Cipher[] groupCipherField;

        private Dot11Cipher[] pairCipherField;

        private Dot11SignalStrength signalStrengthField;

        private bool signalStrengthFieldSpecified;
        private byte[] sSIDField;

        /// <remarks/>
        [XmlElement(DataType = "hexBinary", Order = 0)]
        public byte[] SSID
        {
            get { return this.sSIDField; }
            set { this.sSIDField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string BSSID
        {
            get { return this.bSSIDField; }
            set { this.bSSIDField = value; }
        }

        /// <remarks/>
        [XmlElement("AuthAndMangementSuite", Order = 2)]
        public Dot11AuthAndMangementSuite[] AuthAndMangementSuite
        {
            get { return this.authAndMangementSuiteField; }
            set { this.authAndMangementSuiteField = value; }
        }

        /// <remarks/>
        [XmlElement("PairCipher", Order = 3)]
        public Dot11Cipher[] PairCipher
        {
            get { return this.pairCipherField; }
            set { this.pairCipherField = value; }
        }

        /// <remarks/>
        [XmlElement("GroupCipher", Order = 4)]
        public Dot11Cipher[] GroupCipher
        {
            get { return this.groupCipherField; }
            set { this.groupCipherField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public Dot11SignalStrength SignalStrength
        {
            get { return this.signalStrengthField; }
            set { this.signalStrengthField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool SignalStrengthSpecified
        {
            get { return this.signalStrengthFieldSpecified; }
            set { this.signalStrengthFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public Dot11AvailableNetworksExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum Dot11AuthAndMangementSuite
    {
        /// <remarks/>
        None,

        /// <remarks/>
        Dot1X,

        /// <remarks/>
        PSK,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum Dot11Cipher
    {
        /// <remarks/>
        CCMP,

        /// <remarks/>
        TKIP,

        /// <remarks/>
        Any,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum Dot11SignalStrength
    {
        /// <remarks/>
        None,

        /// <remarks/>
        [XmlEnum("Very Bad")]
        VeryBad,

        /// <remarks/>
        Bad,

        /// <remarks/>
        Good,

        /// <remarks/>
        [XmlEnum("Very Good")]
        VeryGood,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot11Status
    {
        private string activeConfigAliasField;

        private XElement[] anyField;

        private string bSSIDField;

        private Dot11Cipher groupCipherField;

        private bool groupCipherFieldSpecified;

        private Dot11Cipher pairCipherField;

        private bool pairCipherFieldSpecified;

        private Dot11SignalStrength signalStrengthField;

        private bool signalStrengthFieldSpecified;
        private byte[] sSIDField;

        /// <remarks/>
        [XmlElement(DataType = "hexBinary", Order = 0)]
        public byte[] SSID
        {
            get { return this.sSIDField; }
            set { this.sSIDField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string BSSID
        {
            get { return this.bSSIDField; }
            set { this.bSSIDField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public Dot11Cipher PairCipher
        {
            get { return this.pairCipherField; }
            set { this.pairCipherField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool PairCipherSpecified
        {
            get { return this.pairCipherFieldSpecified; }
            set { this.pairCipherFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public Dot11Cipher GroupCipher
        {
            get { return this.groupCipherField; }
            set { this.groupCipherField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool GroupCipherSpecified
        {
            get { return this.groupCipherFieldSpecified; }
            set { this.groupCipherFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public Dot11SignalStrength SignalStrength
        {
            get { return this.signalStrengthField; }
            set { this.signalStrengthField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool SignalStrengthSpecified
        {
            get { return this.signalStrengthFieldSpecified; }
            set { this.signalStrengthFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string ActiveConfigAlias
        {
            get { return this.activeConfigAliasField; }
            set { this.activeConfigAliasField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 6)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot11Capabilities
    {
        private bool adHocStationModeField;

        private XElement[] anyField;

        private bool multipleConfigurationField;

        private bool scanAvailableNetworksField;
        private bool tKIPField;

        private bool wEPField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool TKIP
        {
            get { return this.tKIPField; }
            set { this.tKIPField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool ScanAvailableNetworks
        {
            get { return this.scanAvailableNetworksField; }
            set { this.scanAvailableNetworksField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool MultipleConfiguration
        {
            get { return this.multipleConfigurationField; }
            set { this.multipleConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool AdHocStationMode
        {
            get { return this.adHocStationModeField; }
            set { this.adHocStationModeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public bool WEP
        {
            get { return this.wEPField; }
            set { this.wEPField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 5)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot1XConfigurationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class EapMethodExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class TLSConfiguration
    {
        private XElement[] anyField;
        private string certificateIDField;

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 0)]
        public string CertificateID
        {
            get { return this.certificateIDField; }
            set { this.certificateIDField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class EAPMethodConfiguration
    {
        private EapMethodExtension extensionField;

        private string passwordField;
        private TLSConfiguration tLSConfigurationField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public TLSConfiguration TLSConfiguration
        {
            get { return this.tLSConfigurationField; }
            set { this.tLSConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string Password
        {
            get { return this.passwordField; }
            set { this.passwordField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public EapMethodExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot1XConfiguration
    {
        private string anonymousIDField;

        private string[] cACertificateIDField;
        private string dot1XConfigurationTokenField;

        private EAPMethodConfiguration eAPMethodConfigurationField;

        private int eAPMethodField;

        private Dot1XConfigurationExtension extensionField;

        private string identityField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Dot1XConfigurationToken
        {
            get { return this.dot1XConfigurationTokenField; }
            set { this.dot1XConfigurationTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string Identity
        {
            get { return this.identityField; }
            set { this.identityField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string AnonymousID
        {
            get { return this.anonymousIDField; }
            set { this.anonymousIDField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int EAPMethod
        {
            get { return this.eAPMethodField; }
            set { this.eAPMethodField = value; }
        }

        /// <remarks/>
        [XmlElement("CACertificateID", DataType = "token", Order = 4)]
        public string[] CACertificateID
        {
            get { return this.cACertificateIDField; }
            set { this.cACertificateIDField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public EAPMethodConfiguration EAPMethodConfiguration
        {
            get { return this.eAPMethodConfigurationField; }
            set { this.eAPMethodConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public Dot1XConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class CertificateInformationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DateTimeRange
    {
        private XElement[] anyField;
        private System.DateTime fromField;

        private System.DateTime untilField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public System.DateTime From
        {
            get { return this.fromField; }
            set { this.fromField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public System.DateTime Until
        {
            get { return this.untilField; }
            set { this.untilField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class CertificateUsage
    {
        private bool criticalField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute()]
        public bool Critical
        {
            get { return this.criticalField; }
            set { this.criticalField = value; }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class CertificateInformation
    {
        private string certificateIDField;

        private CertificateUsage extendedKeyUsageField;

        private CertificateInformationExtension extensionField;

        private string issuerDNField;

        private int keyLengthField;

        private bool keyLengthFieldSpecified;

        private CertificateUsage keyUsageField;

        private string serialNumField;

        private string signatureAlgorithmField;

        private string subjectDNField;

        private DateTimeRange validityField;

        private string versionField;

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 0)]
        public string CertificateID
        {
            get { return this.certificateIDField; }
            set { this.certificateIDField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string IssuerDN
        {
            get { return this.issuerDNField; }
            set { this.issuerDNField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string SubjectDN
        {
            get { return this.subjectDNField; }
            set { this.subjectDNField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public CertificateUsage KeyUsage
        {
            get { return this.keyUsageField; }
            set { this.keyUsageField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public CertificateUsage ExtendedKeyUsage
        {
            get { return this.extendedKeyUsageField; }
            set { this.extendedKeyUsageField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int KeyLength
        {
            get { return this.keyLengthField; }
            set { this.keyLengthField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool KeyLengthSpecified
        {
            get { return this.keyLengthFieldSpecified; }
            set { this.keyLengthFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string Version
        {
            get { return this.versionField; }
            set { this.versionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public string SerialNum
        {
            get { return this.serialNumField; }
            set { this.serialNumField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public string SignatureAlgorithm
        {
            get { return this.signatureAlgorithmField; }
            set { this.signatureAlgorithmField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public DateTimeRange Validity
        {
            get { return this.validityField; }
            set { this.validityField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public CertificateInformationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class CertificateWithPrivateKey
    {
        private XElement[] anyField;

        private BinaryData certificateField;
        private string certificateIDField;

        private BinaryData privateKeyField;

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 0)]
        public string CertificateID
        {
            get { return this.certificateIDField; }
            set { this.certificateIDField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public BinaryData Certificate
        {
            get { return this.certificateField; }
            set { this.certificateField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public BinaryData PrivateKey
        {
            get { return this.privateKeyField; }
            set { this.privateKeyField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class BinaryData
    {
        private string contentTypeField;
        private byte[] dataField;

        /// <remarks/>
        [XmlElement(DataType = "base64Binary", Order = 0)]
        public byte[] Data
        {
            get { return this.dataField; }
            set { this.dataField = value; }
        }

        /// <remarks/>
        [XmlAttribute(Form = XmlSchemaForm.Qualified,
            Namespace = "http://www.w3.org/2005/05/xmlmime")]
        public string contentType
        {
            get { return this.contentTypeField; }
            set { this.contentTypeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class CertificateStatus
    {
        private XElement[] anyField;
        private string certificateIDField;

        private bool statusField;

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 0)]
        public string CertificateID
        {
            get { return this.certificateIDField; }
            set { this.certificateIDField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool Status
        {
            get { return this.statusField; }
            set { this.statusField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Certificate
    {
        private BinaryData certificate1Field;
        private string certificateIDField;

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 0)]
        public string CertificateID
        {
            get { return this.certificateIDField; }
            set { this.certificateIDField = value; }
        }

        /// <remarks/>
        [XmlElement("Certificate", Order = 1)]
        public BinaryData Certificate1
        {
            get { return this.certificate1Field; }
            set { this.certificate1Field = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IPAddressFilterExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IPAddressFilter
    {
        private IPAddressFilterExtension extensionField;

        private PrefixedIPv4Address[] iPv4AddressField;

        private PrefixedIPv6Address[] iPv6AddressField;
        private IPAddressFilterType typeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IPAddressFilterType Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlElement("IPv4Address", Order = 1)]
        public PrefixedIPv4Address[] IPv4Address
        {
            get { return this.iPv4AddressField; }
            set { this.iPv4AddressField = value; }
        }

        /// <remarks/>
        [XmlElement("IPv6Address", Order = 2)]
        public PrefixedIPv6Address[] IPv6Address
        {
            get { return this.iPv6AddressField; }
            set { this.iPv6AddressField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IPAddressFilterExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum IPAddressFilterType
    {
        /// <remarks/>
        Allow,

        /// <remarks/>
        Deny,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PrefixedIPv4Address
    {
        private string addressField;

        private int prefixLengthField;

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 0)]
        public string Address
        {
            get { return this.addressField; }
            set { this.addressField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int PrefixLength
        {
            get { return this.prefixLengthField; }
            set { this.prefixLengthField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PrefixedIPv6Address
    {
        private string addressField;

        private int prefixLengthField;

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 0)]
        public string Address
        {
            get { return this.addressField; }
            set { this.addressField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int PrefixLength
        {
            get { return this.prefixLengthField; }
            set { this.prefixLengthField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkZeroConfigurationExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkZeroConfigurationExtension
    {
        private NetworkZeroConfiguration[] additionalField;
        private XElement[] anyField;

        private NetworkZeroConfigurationExtension2 extensionField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement("Additional", Order = 1)]
        public NetworkZeroConfiguration[] Additional
        {
            get { return this.additionalField; }
            set { this.additionalField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public NetworkZeroConfigurationExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkZeroConfiguration
    {
        private string[] addressesField;

        private bool enabledField;

        private NetworkZeroConfigurationExtension extensionField;
        private string interfaceTokenField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string InterfaceToken
        {
            get { return this.interfaceTokenField; }
            set { this.interfaceTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool Enabled
        {
            get { return this.enabledField; }
            set { this.enabledField = value; }
        }

        /// <remarks/>
        [XmlElement("Addresses", DataType = "token", Order = 2)]
        public string[] Addresses
        {
            get { return this.addressesField; }
            set { this.addressesField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public NetworkZeroConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkGateway
    {
        private string[] iPv4AddressField;

        private string[] iPv6AddressField;

        /// <remarks/>
        [XmlElement("IPv4Address", DataType = "token", Order = 0)]
        public string[] IPv4Address
        {
            get { return this.iPv4AddressField; }
            set { this.iPv4AddressField = value; }
        }

        /// <remarks/>
        [XmlElement("IPv6Address", DataType = "token", Order = 1)]
        public string[] IPv6Address
        {
            get { return this.iPv6AddressField; }
            set { this.iPv6AddressField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkProtocolExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkProtocol
    {
        private bool enabledField;

        private NetworkProtocolExtension extensionField;
        private NetworkProtocolType nameField;

        private int[] portField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public NetworkProtocolType Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool Enabled
        {
            get { return this.enabledField; }
            set { this.enabledField = value; }
        }

        /// <remarks/>
        [XmlElement("Port", Order = 2)]
        public int[] Port
        {
            get { return this.portField; }
            set { this.portField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public NetworkProtocolExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum NetworkProtocolType
    {
        /// <remarks/>
        HTTP,

        /// <remarks/>
        HTTPS,

        /// <remarks/>
        RTSP,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkInterfaceSetConfigurationExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkInterfaceSetConfigurationExtension
    {
        private XElement[] anyField;

        private Dot11Configuration[] dot11Field;

        private Dot3Configuration[] dot3Field;

        private NetworkInterfaceSetConfigurationExtension2 extensionField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement("Dot3", Order = 1)]
        public Dot3Configuration[] Dot3
        {
            get { return this.dot3Field; }
            set { this.dot3Field = value; }
        }

        /// <remarks/>
        [XmlElement("Dot11", Order = 2)]
        public Dot11Configuration[] Dot11
        {
            get { return this.dot11Field; }
            set { this.dot11Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public NetworkInterfaceSetConfigurationExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot3Configuration
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot11Configuration
    {
        private string aliasField;

        private XElement[] anyField;

        private Dot11StationMode modeField;

        private string priorityField;

        private Dot11SecurityConfiguration securityField;
        private byte[] sSIDField;

        /// <remarks/>
        [XmlElement(DataType = "hexBinary", Order = 0)]
        public byte[] SSID
        {
            get { return this.sSIDField; }
            set { this.sSIDField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Dot11StationMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string Alias
        {
            get { return this.aliasField; }
            set { this.aliasField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 3)]
        public string Priority
        {
            get { return this.priorityField; }
            set { this.priorityField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public Dot11SecurityConfiguration Security
        {
            get { return this.securityField; }
            set { this.securityField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 5)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum Dot11StationMode
    {
        /// <remarks/>
        [XmlEnum("Ad-hoc")]
        Adhoc,

        /// <remarks/>
        Infrastructure,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot11SecurityConfiguration
    {
        private Dot11Cipher algorithmField;

        private bool algorithmFieldSpecified;

        private string dot1XField;

        private Dot11SecurityConfigurationExtension extensionField;
        private Dot11SecurityMode modeField;

        private Dot11PSKSet pSKField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public Dot11SecurityMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Dot11Cipher Algorithm
        {
            get { return this.algorithmField; }
            set { this.algorithmField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool AlgorithmSpecified
        {
            get { return this.algorithmFieldSpecified; }
            set { this.algorithmFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public Dot11PSKSet PSK
        {
            get { return this.pSKField; }
            set { this.pSKField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string Dot1X
        {
            get { return this.dot1XField; }
            set { this.dot1XField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public Dot11SecurityConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum Dot11SecurityMode
    {
        /// <remarks/>
        None,

        /// <remarks/>
        WEP,

        /// <remarks/>
        PSK,

        /// <remarks/>
        Dot1X,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot11PSKSet
    {
        private Dot11PSKSetExtension extensionField;
        private byte[] keyField;

        private string passphraseField;

        /// <remarks/>
        [XmlElement(DataType = "hexBinary", Order = 0)]
        public byte[] Key
        {
            get { return this.keyField; }
            set { this.keyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string Passphrase
        {
            get { return this.passphraseField; }
            set { this.passphraseField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public Dot11PSKSetExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot11PSKSetExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Dot11SecurityConfigurationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IPv6NetworkInterfaceSetConfiguration
    {
        private bool acceptRouterAdvertField;

        private bool acceptRouterAdvertFieldSpecified;

        private IPv6DHCPConfiguration dHCPField;

        private bool dHCPFieldSpecified;
        private bool enabledField;

        private bool enabledFieldSpecified;

        private PrefixedIPv6Address[] manualField;

        /// <remarks/>
        [XmlElement(Order = 0)]
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

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool AcceptRouterAdvert
        {
            get { return this.acceptRouterAdvertField; }
            set { this.acceptRouterAdvertField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool AcceptRouterAdvertSpecified
        {
            get { return this.acceptRouterAdvertFieldSpecified; }
            set { this.acceptRouterAdvertFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement("Manual", Order = 2)]
        public PrefixedIPv6Address[] Manual
        {
            get { return this.manualField; }
            set { this.manualField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IPv6DHCPConfiguration DHCP
        {
            get { return this.dHCPField; }
            set { this.dHCPField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DHCPSpecified
        {
            get { return this.dHCPFieldSpecified; }
            set { this.dHCPFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum IPv6DHCPConfiguration
    {
        /// <remarks/>
        Auto,

        /// <remarks/>
        Stateful,

        /// <remarks/>
        Stateless,

        /// <remarks/>
        Off,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IPv4NetworkInterfaceSetConfiguration
    {
        private bool dHCPField;

        private bool dHCPFieldSpecified;
        private bool enabledField;

        private bool enabledFieldSpecified;

        private PrefixedIPv4Address[] manualField;

        /// <remarks/>
        [XmlElement(Order = 0)]
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

        /// <remarks/>
        [XmlElement("Manual", Order = 1)]
        public PrefixedIPv4Address[] Manual
        {
            get { return this.manualField; }
            set { this.manualField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool DHCP
        {
            get { return this.dHCPField; }
            set { this.dHCPField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DHCPSpecified
        {
            get { return this.dHCPFieldSpecified; }
            set { this.dHCPFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkInterfaceSetConfiguration
    {
        private bool enabledField;

        private bool enabledFieldSpecified;

        private NetworkInterfaceSetConfigurationExtension extensionField;

        private IPv4NetworkInterfaceSetConfiguration iPv4Field;

        private IPv6NetworkInterfaceSetConfiguration iPv6Field;

        private NetworkInterfaceConnectionSetting linkField;

        private int mTUField;

        private bool mTUFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
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

        /// <remarks/>
        [XmlElement(Order = 1)]
        public NetworkInterfaceConnectionSetting Link
        {
            get { return this.linkField; }
            set { this.linkField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int MTU
        {
            get { return this.mTUField; }
            set { this.mTUField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MTUSpecified
        {
            get { return this.mTUFieldSpecified; }
            set { this.mTUFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IPv4NetworkInterfaceSetConfiguration IPv4
        {
            get { return this.iPv4Field; }
            set { this.iPv4Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public IPv6NetworkInterfaceSetConfiguration IPv6
        {
            get { return this.iPv6Field; }
            set { this.iPv6Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public NetworkInterfaceSetConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkInterfaceConnectionSetting
    {
        private bool autoNegotiationField;

        private Duplex duplexField;

        private int speedField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool AutoNegotiation
        {
            get { return this.autoNegotiationField; }
            set { this.autoNegotiationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Speed
        {
            get { return this.speedField; }
            set { this.speedField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public Duplex Duplex
        {
            get { return this.duplexField; }
            set { this.duplexField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum Duplex
    {
        /// <remarks/>
        Full,

        /// <remarks/>
        Half,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDConfigurationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDImgConfigurationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDImgConfiguration
    {
        private OSDImgConfigurationExtension extensionField;
        private string imgPathField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string ImgPath
        {
            get { return this.imgPathField; }
            set { this.imgPathField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OSDImgConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDTextConfigurationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Color
    {
        private string colorspaceField;
        private float xField;

        private float yField;

        private float zField;

        /// <remarks/>
        [XmlAttribute()]
        public float X
        {
            get { return this.xField; }
            set { this.xField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float Y
        {
            get { return this.yField; }
            set { this.yField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float Z
        {
            get { return this.zField; }
            set { this.zField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "anyURI")]
        public string Colorspace
        {
            get { return this.colorspaceField; }
            set { this.colorspaceField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDColor
    {
        private Color colorField;

        private int transparentField;

        private bool transparentFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public Color Color
        {
            get { return this.colorField; }
            set { this.colorField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int Transparent
        {
            get { return this.transparentField; }
            set { this.transparentField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool TransparentSpecified
        {
            get { return this.transparentFieldSpecified; }
            set { this.transparentFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDTextConfiguration
    {
        private OSDColor backgroundColorField;

        private string dateFormatField;

        private OSDTextConfigurationExtension extensionField;

        private OSDColor fontColorField;

        private int fontSizeField;

        private bool fontSizeFieldSpecified;

        private bool isPersistentTextField;

        private bool isPersistentTextFieldSpecified;

        private string plainTextField;

        private string timeFormatField;
        private string typeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string DateFormat
        {
            get { return this.dateFormatField; }
            set { this.dateFormatField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string TimeFormat
        {
            get { return this.timeFormatField; }
            set { this.timeFormatField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int FontSize
        {
            get { return this.fontSizeField; }
            set { this.fontSizeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool FontSizeSpecified
        {
            get { return this.fontSizeFieldSpecified; }
            set { this.fontSizeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OSDColor FontColor
        {
            get { return this.fontColorField; }
            set { this.fontColorField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OSDColor BackgroundColor
        {
            get { return this.backgroundColorField; }
            set { this.backgroundColorField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string PlainText
        {
            get { return this.plainTextField; }
            set { this.plainTextField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public OSDTextConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool IsPersistentText
        {
            get { return this.isPersistentTextField; }
            set { this.isPersistentTextField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsPersistentTextSpecified
        {
            get { return this.isPersistentTextFieldSpecified; }
            set { this.isPersistentTextFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDPosConfigurationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Vector
    {
        private float xField;

        private bool xFieldSpecified;

        private float yField;

        private bool yFieldSpecified;

        /// <remarks/>
        [XmlAttribute()]
        public float x
        {
            get { return this.xField; }
            set { this.xField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool xSpecified
        {
            get { return this.xFieldSpecified; }
            set { this.xFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float y
        {
            get { return this.yField; }
            set { this.yField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ySpecified
        {
            get { return this.yFieldSpecified; }
            set { this.yFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDPosConfiguration
    {
        private OSDPosConfigurationExtension extensionField;

        private Vector posField;
        private string typeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Vector Pos
        {
            get { return this.posField; }
            set { this.posField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OSDPosConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDReference
    {
        private string valueField;

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZNodeExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourSupportedExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourSupported
    {
        private PTZPresetTourSupportedExtension extensionField;
        private int maximumNumberOfPresetToursField;

        private PTZPresetTourOperation[] pTZPresetTourOperationField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int MaximumNumberOfPresetTours
        {
            get { return this.maximumNumberOfPresetToursField; }
            set { this.maximumNumberOfPresetToursField = value; }
        }

        /// <remarks/>
        [XmlElement("PTZPresetTourOperation", Order = 1)]
        public PTZPresetTourOperation[] PTZPresetTourOperation
        {
            get { return this.pTZPresetTourOperationField; }
            set { this.pTZPresetTourOperationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public PTZPresetTourSupportedExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum PTZPresetTourOperation
    {
        /// <remarks/>
        Start,

        /// <remarks/>
        Stop,

        /// <remarks/>
        Pause,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZNodeExtension
    {
        private XElement[] anyField;

        private PTZNodeExtension2 extensionField;

        private PTZPresetTourSupported supportedPresetTourField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public PTZPresetTourSupported SupportedPresetTour
        {
            get { return this.supportedPresetTourField; }
            set { this.supportedPresetTourField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public PTZNodeExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZSpacesExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Space1DDescription
    {
        private string uRIField;

        private FloatRange xRangeField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string URI
        {
            get { return this.uRIField; }
            set { this.uRIField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange XRange
        {
            get { return this.xRangeField; }
            set { this.xRangeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class FloatRange
    {
        private float maxField;
        private float minField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public float Min
        {
            get { return this.minField; }
            set { this.minField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Max
        {
            get { return this.maxField; }
            set { this.maxField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Space2DDescription
    {
        private string uRIField;

        private FloatRange xRangeField;

        private FloatRange yRangeField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string URI
        {
            get { return this.uRIField; }
            set { this.uRIField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange XRange
        {
            get { return this.xRangeField; }
            set { this.xRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public FloatRange YRange
        {
            get { return this.yRangeField; }
            set { this.yRangeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZSpaces
    {
        private Space2DDescription[] absolutePanTiltPositionSpaceField;

        private Space1DDescription[] absoluteZoomPositionSpaceField;

        private Space2DDescription[] continuousPanTiltVelocitySpaceField;

        private Space1DDescription[] continuousZoomVelocitySpaceField;

        private PTZSpacesExtension extensionField;

        private Space1DDescription[] panTiltSpeedSpaceField;

        private Space2DDescription[] relativePanTiltTranslationSpaceField;

        private Space1DDescription[] relativeZoomTranslationSpaceField;

        private Space1DDescription[] zoomSpeedSpaceField;

        /// <remarks/>
        [XmlElement("AbsolutePanTiltPositionSpace", Order = 0)]
        public Space2DDescription[] AbsolutePanTiltPositionSpace
        {
            get { return this.absolutePanTiltPositionSpaceField; }
            set { this.absolutePanTiltPositionSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement("AbsoluteZoomPositionSpace", Order = 1)]
        public Space1DDescription[] AbsoluteZoomPositionSpace
        {
            get { return this.absoluteZoomPositionSpaceField; }
            set { this.absoluteZoomPositionSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement("RelativePanTiltTranslationSpace", Order = 2)]
        public Space2DDescription[] RelativePanTiltTranslationSpace
        {
            get { return this.relativePanTiltTranslationSpaceField; }
            set { this.relativePanTiltTranslationSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement("RelativeZoomTranslationSpace", Order = 3)]
        public Space1DDescription[] RelativeZoomTranslationSpace
        {
            get { return this.relativeZoomTranslationSpaceField; }
            set { this.relativeZoomTranslationSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement("ContinuousPanTiltVelocitySpace", Order = 4)]
        public Space2DDescription[] ContinuousPanTiltVelocitySpace
        {
            get { return this.continuousPanTiltVelocitySpaceField; }
            set { this.continuousPanTiltVelocitySpaceField = value; }
        }

        /// <remarks/>
        [XmlElement("ContinuousZoomVelocitySpace", Order = 5)]
        public Space1DDescription[] ContinuousZoomVelocitySpace
        {
            get { return this.continuousZoomVelocitySpaceField; }
            set { this.continuousZoomVelocitySpaceField = value; }
        }

        /// <remarks/>
        [XmlElement("PanTiltSpeedSpace", Order = 6)]
        public Space1DDescription[] PanTiltSpeedSpace
        {
            get { return this.panTiltSpeedSpaceField; }
            set { this.panTiltSpeedSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement("ZoomSpeedSpace", Order = 7)]
        public Space1DDescription[] ZoomSpeedSpace
        {
            get { return this.zoomSpeedSpaceField; }
            set { this.zoomSpeedSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public PTZSpacesExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RelayOutputSettings
    {
        private string delayTimeField;

        private RelayIdleState idleStateField;
        private RelayMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public RelayMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 1)]
        public string DelayTime
        {
            get { return this.delayTimeField; }
            set { this.delayTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public RelayIdleState IdleState
        {
            get { return this.idleStateField; }
            set { this.idleStateField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum RelayMode
    {
        /// <remarks/>
        Monostable,

        /// <remarks/>
        Bistable,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum RelayIdleState
    {
        /// <remarks/>
        closed,

        /// <remarks/>
        open,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkInterfaceExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkInterfaceExtension
    {
        private XElement[] anyField;

        private Dot11Configuration[] dot11Field;

        private Dot3Configuration[] dot3Field;

        private NetworkInterfaceExtension2 extensionField;

        private int interfaceTypeField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int InterfaceType
        {
            get { return this.interfaceTypeField; }
            set { this.interfaceTypeField = value; }
        }

        /// <remarks/>
        [XmlElement("Dot3", Order = 2)]
        public Dot3Configuration[] Dot3
        {
            get { return this.dot3Field; }
            set { this.dot3Field = value; }
        }

        /// <remarks/>
        [XmlElement("Dot11", Order = 3)]
        public Dot11Configuration[] Dot11
        {
            get { return this.dot11Field; }
            set { this.dot11Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public NetworkInterfaceExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IPv6ConfigurationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IPv6Configuration
    {
        private bool acceptRouterAdvertField;

        private bool acceptRouterAdvertFieldSpecified;

        private IPv6DHCPConfiguration dHCPField;

        private IPv6ConfigurationExtension extensionField;

        private PrefixedIPv6Address[] fromDHCPField;

        private PrefixedIPv6Address[] fromRAField;

        private PrefixedIPv6Address[] linkLocalField;

        private PrefixedIPv6Address[] manualField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool AcceptRouterAdvert
        {
            get { return this.acceptRouterAdvertField; }
            set { this.acceptRouterAdvertField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool AcceptRouterAdvertSpecified
        {
            get { return this.acceptRouterAdvertFieldSpecified; }
            set { this.acceptRouterAdvertFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public IPv6DHCPConfiguration DHCP
        {
            get { return this.dHCPField; }
            set { this.dHCPField = value; }
        }

        /// <remarks/>
        [XmlElement("Manual", Order = 2)]
        public PrefixedIPv6Address[] Manual
        {
            get { return this.manualField; }
            set { this.manualField = value; }
        }

        /// <remarks/>
        [XmlElement("LinkLocal", Order = 3)]
        public PrefixedIPv6Address[] LinkLocal
        {
            get { return this.linkLocalField; }
            set { this.linkLocalField = value; }
        }

        /// <remarks/>
        [XmlElement("FromDHCP", Order = 4)]
        public PrefixedIPv6Address[] FromDHCP
        {
            get { return this.fromDHCPField; }
            set { this.fromDHCPField = value; }
        }

        /// <remarks/>
        [XmlElement("FromRA", Order = 5)]
        public PrefixedIPv6Address[] FromRA
        {
            get { return this.fromRAField; }
            set { this.fromRAField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public IPv6ConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IPv6NetworkInterface
    {
        private IPv6Configuration configField;
        private bool enabledField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool Enabled
        {
            get { return this.enabledField; }
            set { this.enabledField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public IPv6Configuration Config
        {
            get { return this.configField; }
            set { this.configField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IPv4Configuration
    {
        private XElement[] anyField;

        private bool dHCPField;

        private PrefixedIPv4Address fromDHCPField;

        private PrefixedIPv4Address linkLocalField;
        private PrefixedIPv4Address[] manualField;

        /// <remarks/>
        [XmlElement("Manual", Order = 0)]
        public PrefixedIPv4Address[] Manual
        {
            get { return this.manualField; }
            set { this.manualField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public PrefixedIPv4Address LinkLocal
        {
            get { return this.linkLocalField; }
            set { this.linkLocalField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public PrefixedIPv4Address FromDHCP
        {
            get { return this.fromDHCPField; }
            set { this.fromDHCPField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool DHCP
        {
            get { return this.dHCPField; }
            set { this.dHCPField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 4)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IPv4NetworkInterface
    {
        private IPv4Configuration configField;
        private bool enabledField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool Enabled
        {
            get { return this.enabledField; }
            set { this.enabledField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public IPv4Configuration Config
        {
            get { return this.configField; }
            set { this.configField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkInterfaceLink
    {
        private NetworkInterfaceConnectionSetting adminSettingsField;

        private int interfaceTypeField;

        private NetworkInterfaceConnectionSetting operSettingsField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public NetworkInterfaceConnectionSetting AdminSettings
        {
            get { return this.adminSettingsField; }
            set { this.adminSettingsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public NetworkInterfaceConnectionSetting OperSettings
        {
            get { return this.operSettingsField; }
            set { this.operSettingsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int InterfaceType
        {
            get { return this.interfaceTypeField; }
            set { this.interfaceTypeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkInterfaceInfo
    {
        private string hwAddressField;

        private int mTUField;

        private bool mTUFieldSpecified;
        private string nameField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 1)]
        public string HwAddress
        {
            get { return this.hwAddressField; }
            set { this.hwAddressField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int MTU
        {
            get { return this.mTUField; }
            set { this.mTUField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MTUSpecified
        {
            get { return this.mTUFieldSpecified; }
            set { this.mTUFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoOutputExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class LayoutExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PaneLayout
    {
        private XElement[] anyField;

        private Rectangle areaField;
        private string paneField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Pane
        {
            get { return this.paneField; }
            set { this.paneField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Rectangle Area
        {
            get { return this.areaField; }
            set { this.areaField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Rectangle
    {
        private float bottomField;

        private bool bottomFieldSpecified;

        private float leftField;

        private bool leftFieldSpecified;

        private float rightField;

        private bool rightFieldSpecified;

        private float topField;

        private bool topFieldSpecified;

        /// <remarks/>
        [XmlAttribute()]
        public float bottom
        {
            get { return this.bottomField; }
            set { this.bottomField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool bottomSpecified
        {
            get { return this.bottomFieldSpecified; }
            set { this.bottomFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float top
        {
            get { return this.topField; }
            set { this.topField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool topSpecified
        {
            get { return this.topFieldSpecified; }
            set { this.topFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float right
        {
            get { return this.rightField; }
            set { this.rightField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool rightSpecified
        {
            get { return this.rightFieldSpecified; }
            set { this.rightFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float left
        {
            get { return this.leftField; }
            set { this.leftField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool leftSpecified
        {
            get { return this.leftFieldSpecified; }
            set { this.leftFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Layout
    {
        private LayoutExtension extensionField;
        private PaneLayout[] paneLayoutField;

        /// <remarks/>
        [XmlElement("PaneLayout", Order = 0)]
        public PaneLayout[] PaneLayout
        {
            get { return this.paneLayoutField; }
            set { this.paneLayoutField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public LayoutExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoSourceExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingSettingsExtension204
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NoiseReduction
    {
        private XElement[] anyField;
        private float levelField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public float Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DefoggingExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Defogging
    {
        private DefoggingExtension extensionField;

        private float levelField;

        private bool levelFieldSpecified;
        private string modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool LevelSpecified
        {
            get { return this.levelFieldSpecified; }
            set { this.levelFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public DefoggingExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ToneCompensationExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ToneCompensation
    {
        private ToneCompensationExtension extensionField;

        private float levelField;

        private bool levelFieldSpecified;
        private string modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool LevelSpecified
        {
            get { return this.levelFieldSpecified; }
            set { this.levelFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ToneCompensationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingSettingsExtension203
    {
        private Defogging defoggingField;

        private ImagingSettingsExtension204 extensionField;

        private NoiseReduction noiseReductionField;
        private ToneCompensation toneCompensationField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ToneCompensation ToneCompensation
        {
            get { return this.toneCompensationField; }
            set { this.toneCompensationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Defogging Defogging
        {
            get { return this.defoggingField; }
            set { this.defoggingField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public NoiseReduction NoiseReduction
        {
            get { return this.noiseReductionField; }
            set { this.noiseReductionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public ImagingSettingsExtension204 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IrCutFilterAutoAdjustmentExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IrCutFilterAutoAdjustment
    {
        private float boundaryOffsetField;

        private bool boundaryOffsetFieldSpecified;
        private string boundaryTypeField;

        private IrCutFilterAutoAdjustmentExtension extensionField;

        private string responseTimeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string BoundaryType
        {
            get { return this.boundaryTypeField; }
            set { this.boundaryTypeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float BoundaryOffset
        {
            get { return this.boundaryOffsetField; }
            set { this.boundaryOffsetField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool BoundaryOffsetSpecified
        {
            get { return this.boundaryOffsetFieldSpecified; }
            set { this.boundaryOffsetFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 2)]
        public string ResponseTime
        {
            get { return this.responseTimeField; }
            set { this.responseTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IrCutFilterAutoAdjustmentExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingSettingsExtension202
    {
        private ImagingSettingsExtension203 extensionField;
        private IrCutFilterAutoAdjustment[] irCutFilterAutoAdjustmentField;

        /// <remarks/>
        [XmlElement("IrCutFilterAutoAdjustment", Order = 0)]
        public IrCutFilterAutoAdjustment[] IrCutFilterAutoAdjustment
        {
            get { return this.irCutFilterAutoAdjustmentField; }
            set { this.irCutFilterAutoAdjustmentField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ImagingSettingsExtension203 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImageStabilizationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImageStabilization
    {
        private ImageStabilizationExtension extensionField;

        private float levelField;

        private bool levelFieldSpecified;
        private ImageStabilizationMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ImageStabilizationMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool LevelSpecified
        {
            get { return this.levelFieldSpecified; }
            set { this.levelFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ImageStabilizationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum ImageStabilizationMode
    {
        /// <remarks/>
        OFF,

        /// <remarks/>
        ON,

        /// <remarks/>
        AUTO,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingSettingsExtension20
    {
        private XElement[] anyField;

        private ImagingSettingsExtension202 extensionField;

        private ImageStabilization imageStabilizationField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ImageStabilization ImageStabilization
        {
            get { return this.imageStabilizationField; }
            set { this.imageStabilizationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ImagingSettingsExtension202 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class WhiteBalance20Extension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class WhiteBalance20
    {
        private float cbGainField;

        private bool cbGainFieldSpecified;

        private float crGainField;

        private bool crGainFieldSpecified;

        private WhiteBalance20Extension extensionField;
        private WhiteBalanceMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public WhiteBalanceMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float CrGain
        {
            get { return this.crGainField; }
            set { this.crGainField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool CrGainSpecified
        {
            get { return this.crGainFieldSpecified; }
            set { this.crGainFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public float CbGain
        {
            get { return this.cbGainField; }
            set { this.cbGainField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool CbGainSpecified
        {
            get { return this.cbGainFieldSpecified; }
            set { this.cbGainFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public WhiteBalance20Extension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum WhiteBalanceMode
    {
        /// <remarks/>
        AUTO,

        /// <remarks/>
        MANUAL,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class WideDynamicRange20
    {
        private float levelField;

        private bool levelFieldSpecified;
        private WideDynamicMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public WideDynamicMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool LevelSpecified
        {
            get { return this.levelFieldSpecified; }
            set { this.levelFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum WideDynamicMode
    {
        /// <remarks/>
        OFF,

        /// <remarks/>
        ON,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class FocusConfiguration20Extension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class FocusConfiguration20
    {
        private AutoFocusMode autoFocusModeField;

        private float defaultSpeedField;

        private bool defaultSpeedFieldSpecified;

        private FocusConfiguration20Extension extensionField;

        private float farLimitField;

        private bool farLimitFieldSpecified;

        private float nearLimitField;

        private bool nearLimitFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AutoFocusMode AutoFocusMode
        {
            get { return this.autoFocusModeField; }
            set { this.autoFocusModeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float DefaultSpeed
        {
            get { return this.defaultSpeedField; }
            set { this.defaultSpeedField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DefaultSpeedSpecified
        {
            get { return this.defaultSpeedFieldSpecified; }
            set { this.defaultSpeedFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public float NearLimit
        {
            get { return this.nearLimitField; }
            set { this.nearLimitField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool NearLimitSpecified
        {
            get { return this.nearLimitFieldSpecified; }
            set { this.nearLimitFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public float FarLimit
        {
            get { return this.farLimitField; }
            set { this.farLimitField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool FarLimitSpecified
        {
            get { return this.farLimitFieldSpecified; }
            set { this.farLimitFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public FocusConfiguration20Extension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum AutoFocusMode
    {
        /// <remarks/>
        AUTO,

        /// <remarks/>
        MANUAL,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Exposure20
    {
        private float exposureTimeField;

        private bool exposureTimeFieldSpecified;

        private float gainField;

        private bool gainFieldSpecified;

        private float irisField;

        private bool irisFieldSpecified;

        private float maxExposureTimeField;

        private bool maxExposureTimeFieldSpecified;

        private float maxGainField;

        private bool maxGainFieldSpecified;

        private float maxIrisField;

        private bool maxIrisFieldSpecified;

        private float minExposureTimeField;

        private bool minExposureTimeFieldSpecified;

        private float minGainField;

        private bool minGainFieldSpecified;

        private float minIrisField;

        private bool minIrisFieldSpecified;
        private ExposureMode modeField;

        private ExposurePriority priorityField;

        private bool priorityFieldSpecified;

        private Rectangle windowField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ExposureMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ExposurePriority Priority
        {
            get { return this.priorityField; }
            set { this.priorityField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool PrioritySpecified
        {
            get { return this.priorityFieldSpecified; }
            set { this.priorityFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public Rectangle Window
        {
            get { return this.windowField; }
            set { this.windowField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public float MinExposureTime
        {
            get { return this.minExposureTimeField; }
            set { this.minExposureTimeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinExposureTimeSpecified
        {
            get { return this.minExposureTimeFieldSpecified; }
            set { this.minExposureTimeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public float MaxExposureTime
        {
            get { return this.maxExposureTimeField; }
            set { this.maxExposureTimeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxExposureTimeSpecified
        {
            get { return this.maxExposureTimeFieldSpecified; }
            set { this.maxExposureTimeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public float MinGain
        {
            get { return this.minGainField; }
            set { this.minGainField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinGainSpecified
        {
            get { return this.minGainFieldSpecified; }
            set { this.minGainFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public float MaxGain
        {
            get { return this.maxGainField; }
            set { this.maxGainField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxGainSpecified
        {
            get { return this.maxGainFieldSpecified; }
            set { this.maxGainFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public float MinIris
        {
            get { return this.minIrisField; }
            set { this.minIrisField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinIrisSpecified
        {
            get { return this.minIrisFieldSpecified; }
            set { this.minIrisFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public float MaxIris
        {
            get { return this.maxIrisField; }
            set { this.maxIrisField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxIrisSpecified
        {
            get { return this.maxIrisFieldSpecified; }
            set { this.maxIrisFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public float ExposureTime
        {
            get { return this.exposureTimeField; }
            set { this.exposureTimeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ExposureTimeSpecified
        {
            get { return this.exposureTimeFieldSpecified; }
            set { this.exposureTimeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public float Gain
        {
            get { return this.gainField; }
            set { this.gainField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool GainSpecified
        {
            get { return this.gainFieldSpecified; }
            set { this.gainFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public float Iris
        {
            get { return this.irisField; }
            set { this.irisField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool IrisSpecified
        {
            get { return this.irisFieldSpecified; }
            set { this.irisFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum ExposureMode
    {
        /// <remarks/>
        AUTO,

        /// <remarks/>
        MANUAL,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum ExposurePriority
    {
        /// <remarks/>
        LowNoise,

        /// <remarks/>
        FrameRate,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class BacklightCompensation20
    {
        private float levelField;

        private bool levelFieldSpecified;
        private BacklightCompensationMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public BacklightCompensationMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool LevelSpecified
        {
            get { return this.levelFieldSpecified; }
            set { this.levelFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum BacklightCompensationMode
    {
        /// <remarks/>
        OFF,

        /// <remarks/>
        ON,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingSettings20
    {
        private BacklightCompensation20 backlightCompensationField;

        private float brightnessField;

        private bool brightnessFieldSpecified;

        private float colorSaturationField;

        private bool colorSaturationFieldSpecified;

        private float contrastField;

        private bool contrastFieldSpecified;

        private Exposure20 exposureField;

        private ImagingSettingsExtension20 extensionField;

        private FocusConfiguration20 focusField;

        private IrCutFilterMode irCutFilterField;

        private bool irCutFilterFieldSpecified;

        private float sharpnessField;

        private bool sharpnessFieldSpecified;

        private WhiteBalance20 whiteBalanceField;

        private WideDynamicRange20 wideDynamicRangeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public BacklightCompensation20 BacklightCompensation
        {
            get { return this.backlightCompensationField; }
            set { this.backlightCompensationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Brightness
        {
            get { return this.brightnessField; }
            set { this.brightnessField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool BrightnessSpecified
        {
            get { return this.brightnessFieldSpecified; }
            set { this.brightnessFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public float ColorSaturation
        {
            get { return this.colorSaturationField; }
            set { this.colorSaturationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ColorSaturationSpecified
        {
            get { return this.colorSaturationFieldSpecified; }
            set { this.colorSaturationFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public float Contrast
        {
            get { return this.contrastField; }
            set { this.contrastField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ContrastSpecified
        {
            get { return this.contrastFieldSpecified; }
            set { this.contrastFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public Exposure20 Exposure
        {
            get { return this.exposureField; }
            set { this.exposureField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public FocusConfiguration20 Focus
        {
            get { return this.focusField; }
            set { this.focusField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public IrCutFilterMode IrCutFilter
        {
            get { return this.irCutFilterField; }
            set { this.irCutFilterField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool IrCutFilterSpecified
        {
            get { return this.irCutFilterFieldSpecified; }
            set { this.irCutFilterFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public float Sharpness
        {
            get { return this.sharpnessField; }
            set { this.sharpnessField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool SharpnessSpecified
        {
            get { return this.sharpnessFieldSpecified; }
            set { this.sharpnessFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public WideDynamicRange20 WideDynamicRange
        {
            get { return this.wideDynamicRangeField; }
            set { this.wideDynamicRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public WhiteBalance20 WhiteBalance
        {
            get { return this.whiteBalanceField; }
            set { this.whiteBalanceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public ImagingSettingsExtension20 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum IrCutFilterMode
    {
        /// <remarks/>
        ON,

        /// <remarks/>
        OFF,

        /// <remarks/>
        AUTO,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoSourceExtension
    {
        private XElement[] anyField;

        private VideoSourceExtension2 extensionField;

        private ImagingSettings20 imagingField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ImagingSettings20 Imaging
        {
            get { return this.imagingField; }
            set { this.imagingField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public VideoSourceExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingSettingsExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class WhiteBalance
    {
        private XElement[] anyField;

        private float cbGainField;

        private float crGainField;
        private WhiteBalanceMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public WhiteBalanceMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float CrGain
        {
            get { return this.crGainField; }
            set { this.crGainField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public float CbGain
        {
            get { return this.cbGainField; }
            set { this.cbGainField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class WideDynamicRange
    {
        private float levelField;
        private WideDynamicMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public WideDynamicMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class FocusConfiguration
    {
        private XElement[] anyField;
        private AutoFocusMode autoFocusModeField;

        private float defaultSpeedField;

        private float farLimitField;

        private float nearLimitField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AutoFocusMode AutoFocusMode
        {
            get { return this.autoFocusModeField; }
            set { this.autoFocusModeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float DefaultSpeed
        {
            get { return this.defaultSpeedField; }
            set { this.defaultSpeedField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public float NearLimit
        {
            get { return this.nearLimitField; }
            set { this.nearLimitField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public float FarLimit
        {
            get { return this.farLimitField; }
            set { this.farLimitField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 4)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Exposure
    {
        private float exposureTimeField;

        private float gainField;

        private float irisField;

        private float maxExposureTimeField;

        private float maxGainField;

        private float maxIrisField;

        private float minExposureTimeField;

        private float minGainField;

        private float minIrisField;
        private ExposureMode modeField;

        private ExposurePriority priorityField;

        private Rectangle windowField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ExposureMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ExposurePriority Priority
        {
            get { return this.priorityField; }
            set { this.priorityField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public Rectangle Window
        {
            get { return this.windowField; }
            set { this.windowField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public float MinExposureTime
        {
            get { return this.minExposureTimeField; }
            set { this.minExposureTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public float MaxExposureTime
        {
            get { return this.maxExposureTimeField; }
            set { this.maxExposureTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public float MinGain
        {
            get { return this.minGainField; }
            set { this.minGainField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public float MaxGain
        {
            get { return this.maxGainField; }
            set { this.maxGainField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public float MinIris
        {
            get { return this.minIrisField; }
            set { this.minIrisField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public float MaxIris
        {
            get { return this.maxIrisField; }
            set { this.maxIrisField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public float ExposureTime
        {
            get { return this.exposureTimeField; }
            set { this.exposureTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public float Gain
        {
            get { return this.gainField; }
            set { this.gainField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public float Iris
        {
            get { return this.irisField; }
            set { this.irisField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class BacklightCompensation
    {
        private float levelField;
        private BacklightCompensationMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public BacklightCompensationMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingSettings
    {
        private BacklightCompensation backlightCompensationField;

        private float brightnessField;

        private bool brightnessFieldSpecified;

        private float colorSaturationField;

        private bool colorSaturationFieldSpecified;

        private float contrastField;

        private bool contrastFieldSpecified;

        private Exposure exposureField;

        private ImagingSettingsExtension extensionField;

        private FocusConfiguration focusField;

        private IrCutFilterMode irCutFilterField;

        private bool irCutFilterFieldSpecified;

        private float sharpnessField;

        private bool sharpnessFieldSpecified;

        private WhiteBalance whiteBalanceField;

        private WideDynamicRange wideDynamicRangeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public BacklightCompensation BacklightCompensation
        {
            get { return this.backlightCompensationField; }
            set { this.backlightCompensationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Brightness
        {
            get { return this.brightnessField; }
            set { this.brightnessField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool BrightnessSpecified
        {
            get { return this.brightnessFieldSpecified; }
            set { this.brightnessFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public float ColorSaturation
        {
            get { return this.colorSaturationField; }
            set { this.colorSaturationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ColorSaturationSpecified
        {
            get { return this.colorSaturationFieldSpecified; }
            set { this.colorSaturationFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public float Contrast
        {
            get { return this.contrastField; }
            set { this.contrastField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ContrastSpecified
        {
            get { return this.contrastFieldSpecified; }
            set { this.contrastFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public Exposure Exposure
        {
            get { return this.exposureField; }
            set { this.exposureField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public FocusConfiguration Focus
        {
            get { return this.focusField; }
            set { this.focusField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public IrCutFilterMode IrCutFilter
        {
            get { return this.irCutFilterField; }
            set { this.irCutFilterField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool IrCutFilterSpecified
        {
            get { return this.irCutFilterFieldSpecified; }
            set { this.irCutFilterFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public float Sharpness
        {
            get { return this.sharpnessField; }
            set { this.sharpnessField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool SharpnessSpecified
        {
            get { return this.sharpnessFieldSpecified; }
            set { this.sharpnessFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public WideDynamicRange WideDynamicRange
        {
            get { return this.wideDynamicRangeField; }
            set { this.wideDynamicRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public WhiteBalance WhiteBalance
        {
            get { return this.whiteBalanceField; }
            set { this.whiteBalanceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public ImagingSettingsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoResolution
    {
        private int heightField;
        private int widthField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int Width
        {
            get { return this.widthField; }
            set { this.widthField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Height
        {
            get { return this.heightField; }
            set { this.heightField = value; }
        }
    }

    /// <remarks/>
    [XmlInclude(typeof(OSDConfiguration))]
    [XmlInclude(typeof(PTZNode))]
    [XmlInclude(typeof(DigitalInput))]
    [XmlInclude(typeof(RelayOutput))]
    [XmlInclude(typeof(NetworkInterface))]
    [XmlInclude(typeof(AudioOutput))]
    [XmlInclude(typeof(VideoOutput))]
    [XmlInclude(typeof(AudioSource))]
    [XmlInclude(typeof(VideoSource))]
    [XmlInclude(typeof(StorageConfiguration))]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DeviceEntity
    {
        private string tokenField;

        /// <remarks/>
        [XmlAttribute()]
        public string token
        {
            get { return this.tokenField; }
            set { this.tokenField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDConfiguration : DeviceEntity
    {
        private OSDConfigurationExtension extensionField;

        private OSDImgConfiguration imageField;

        private OSDPosConfiguration positionField;

        private OSDTextConfiguration textStringField;

        private OSDType typeField;
        private OSDReference videoSourceConfigurationTokenField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public OSDReference VideoSourceConfigurationToken
        {
            get { return this.videoSourceConfigurationTokenField; }
            set { this.videoSourceConfigurationTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OSDType Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OSDPosConfiguration Position
        {
            get { return this.positionField; }
            set { this.positionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OSDTextConfiguration TextString
        {
            get { return this.textStringField; }
            set { this.textStringField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OSDImgConfiguration Image
        {
            get { return this.imageField; }
            set { this.imageField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OSDConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum OSDType
    {
        /// <remarks/>
        Text,

        /// <remarks/>
        Image,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZNode : DeviceEntity
    {
        private string[] auxiliaryCommandsField;

        private PTZNodeExtension extensionField;

        private bool fixedHomePositionField;

        private bool fixedHomePositionFieldSpecified;

        private bool geoMoveField;

        private bool geoMoveFieldSpecified;

        private bool homeSupportedField;

        private int maximumNumberOfPresetsField;
        private string nameField;

        private PTZSpaces supportedPTZSpacesField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public PTZSpaces SupportedPTZSpaces
        {
            get { return this.supportedPTZSpacesField; }
            set { this.supportedPTZSpacesField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int MaximumNumberOfPresets
        {
            get { return this.maximumNumberOfPresetsField; }
            set { this.maximumNumberOfPresetsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool HomeSupported
        {
            get { return this.homeSupportedField; }
            set { this.homeSupportedField = value; }
        }

        /// <remarks/>
        [XmlElement("AuxiliaryCommands", Order = 4)]
        public string[] AuxiliaryCommands
        {
            get { return this.auxiliaryCommandsField; }
            set { this.auxiliaryCommandsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public PTZNodeExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool FixedHomePosition
        {
            get { return this.fixedHomePositionField; }
            set { this.fixedHomePositionField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool FixedHomePositionSpecified
        {
            get { return this.fixedHomePositionFieldSpecified; }
            set { this.fixedHomePositionFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool GeoMove
        {
            get { return this.geoMoveField; }
            set { this.geoMoveField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool GeoMoveSpecified
        {
            get { return this.geoMoveFieldSpecified; }
            set { this.geoMoveFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DigitalInput : DeviceEntity
    {
        private XElement[] anyField;

        private DigitalIdleState idleStateField;

        private bool idleStateFieldSpecified;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public DigitalIdleState IdleState
        {
            get { return this.idleStateField; }
            set { this.idleStateField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool IdleStateSpecified
        {
            get { return this.idleStateFieldSpecified; }
            set { this.idleStateFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum DigitalIdleState
    {
        /// <remarks/>
        closed,

        /// <remarks/>
        open,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RelayOutput : DeviceEntity
    {
        private XElement[] anyField;
        private RelayOutputSettings propertiesField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public RelayOutputSettings Properties
        {
            get { return this.propertiesField; }
            set { this.propertiesField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkInterface : DeviceEntity
    {
        private bool enabledField;

        private NetworkInterfaceExtension extensionField;

        private NetworkInterfaceInfo infoField;

        private IPv4NetworkInterface iPv4Field;

        private IPv6NetworkInterface iPv6Field;

        private NetworkInterfaceLink linkField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool Enabled
        {
            get { return this.enabledField; }
            set { this.enabledField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public NetworkInterfaceInfo Info
        {
            get { return this.infoField; }
            set { this.infoField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public NetworkInterfaceLink Link
        {
            get { return this.linkField; }
            set { this.linkField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IPv4NetworkInterface IPv4
        {
            get { return this.iPv4Field; }
            set { this.iPv4Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public IPv6NetworkInterface IPv6
        {
            get { return this.iPv6Field; }
            set { this.iPv6Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public NetworkInterfaceExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioOutput : DeviceEntity
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoOutput : DeviceEntity
    {
        private float aspectRatioField;

        private bool aspectRatioFieldSpecified;

        private VideoOutputExtension extensionField;
        private Layout layoutField;

        private float refreshRateField;

        private bool refreshRateFieldSpecified;

        private VideoResolution resolutionField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public Layout Layout
        {
            get { return this.layoutField; }
            set { this.layoutField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public VideoResolution Resolution
        {
            get { return this.resolutionField; }
            set { this.resolutionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public float RefreshRate
        {
            get { return this.refreshRateField; }
            set { this.refreshRateField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RefreshRateSpecified
        {
            get { return this.refreshRateFieldSpecified; }
            set { this.refreshRateFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public float AspectRatio
        {
            get { return this.aspectRatioField; }
            set { this.aspectRatioField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool AspectRatioSpecified
        {
            get { return this.aspectRatioFieldSpecified; }
            set { this.aspectRatioFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public VideoOutputExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioSource : DeviceEntity
    {
        private XElement[] anyField;
        private int channelsField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int Channels
        {
            get { return this.channelsField; }
            set { this.channelsField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoSource : DeviceEntity
    {
        private VideoSourceExtension extensionField;
        private float framerateField;

        private ImagingSettings imagingField;

        private VideoResolution resolutionField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public float Framerate
        {
            get { return this.framerateField; }
            set { this.framerateField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public VideoResolution Resolution
        {
            get { return this.resolutionField; }
            set { this.resolutionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ImagingSettings Imaging
        {
            get { return this.imagingField; }
            set { this.imagingField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public VideoSourceExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DynamicDNSInformationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DynamicDNSInformation
    {
        private DynamicDNSInformationExtension extensionField;

        private string nameField;

        private string tTLField;
        private DynamicDNSType typeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public DynamicDNSType Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 1)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 2)]
        public string TTL
        {
            get { return this.tTLField; }
            set { this.tTLField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public DynamicDNSInformationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum DynamicDNSType
    {
        /// <remarks/>
        NoUpdate,

        /// <remarks/>
        ClientUpdates,

        /// <remarks/>
        ServerUpdates,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NTPInformationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NTPInformation
    {
        private NTPInformationExtension extensionField;
        private bool fromDHCPField;

        private NetworkHost[] nTPFromDHCPField;

        private NetworkHost[] nTPManualField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool FromDHCP
        {
            get { return this.fromDHCPField; }
            set { this.fromDHCPField = value; }
        }

        /// <remarks/>
        [XmlElement("NTPFromDHCP", Order = 1)]
        public NetworkHost[] NTPFromDHCP
        {
            get { return this.nTPFromDHCPField; }
            set { this.nTPFromDHCPField = value; }
        }

        /// <remarks/>
        [XmlElement("NTPManual", Order = 2)]
        public NetworkHost[] NTPManual
        {
            get { return this.nTPManualField; }
            set { this.nTPManualField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public NTPInformationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkHost
    {
        private string dNSnameField;

        private NetworkHostExtension extensionField;

        private string iPv4AddressField;

        private string iPv6AddressField;
        private NetworkHostType typeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public NetworkHostType Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 1)]
        public string IPv4Address
        {
            get { return this.iPv4AddressField; }
            set { this.iPv4AddressField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 2)]
        public string IPv6Address
        {
            get { return this.iPv6AddressField; }
            set { this.iPv6AddressField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 3)]
        public string DNSname
        {
            get { return this.dNSnameField; }
            set { this.dNSnameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public NetworkHostExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum NetworkHostType
    {
        /// <remarks/>
        IPv4,

        /// <remarks/>
        IPv6,

        /// <remarks/>
        DNS,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkHostExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DNSInformationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IPAddress
    {
        private string iPv4AddressField;

        private string iPv6AddressField;
        private IPType typeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IPType Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 1)]
        public string IPv4Address
        {
            get { return this.iPv4AddressField; }
            set { this.iPv4AddressField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 2)]
        public string IPv6Address
        {
            get { return this.iPv6AddressField; }
            set { this.iPv6AddressField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum IPType
    {
        /// <remarks/>
        IPv4,

        /// <remarks/>
        IPv6,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DNSInformation
    {
        private IPAddress[] dNSFromDHCPField;

        private IPAddress[] dNSManualField;

        private DNSInformationExtension extensionField;
        private bool fromDHCPField;

        private string[] searchDomainField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool FromDHCP
        {
            get { return this.fromDHCPField; }
            set { this.fromDHCPField = value; }
        }

        /// <remarks/>
        [XmlElement("SearchDomain", DataType = "token", Order = 1)]
        public string[] SearchDomain
        {
            get { return this.searchDomainField; }
            set { this.searchDomainField = value; }
        }

        /// <remarks/>
        [XmlElement("DNSFromDHCP", Order = 2)]
        public IPAddress[] DNSFromDHCP
        {
            get { return this.dNSFromDHCPField; }
            set { this.dNSFromDHCPField = value; }
        }

        /// <remarks/>
        [XmlElement("DNSManual", Order = 3)]
        public IPAddress[] DNSManual
        {
            get { return this.dNSManualField; }
            set { this.dNSManualField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public DNSInformationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class HostnameInformationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class HostnameInformation
    {
        private HostnameInformationExtension extensionField;
        private bool fromDHCPField;

        private string nameField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool FromDHCP
        {
            get { return this.fromDHCPField; }
            set { this.fromDHCPField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 1)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public HostnameInformationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class CapabilitiesExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsDeviceExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsDeviceCapabilities
    {
        private AnalyticsDeviceExtension extensionField;

        private bool ruleSupportField;

        private bool ruleSupportFieldSpecified;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool RuleSupport
        {
            get { return this.ruleSupportField; }
            set { this.ruleSupportField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RuleSupportSpecified
        {
            get { return this.ruleSupportFieldSpecified; }
            set { this.ruleSupportFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public AnalyticsDeviceExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ReceiverCapabilities
    {
        private XElement[] anyField;

        private int maximumRTSPURILengthField;

        private bool rTP_MulticastField;

        private bool rTP_RTSP_TCPField;

        private bool rTP_TCPField;

        private int supportedReceiversField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool RTP_Multicast
        {
            get { return this.rTP_MulticastField; }
            set { this.rTP_MulticastField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool RTP_TCP
        {
            get { return this.rTP_TCPField; }
            set { this.rTP_TCPField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool RTP_RTSP_TCP
        {
            get { return this.rTP_RTSP_TCPField; }
            set { this.rTP_RTSP_TCPField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public int SupportedReceivers
        {
            get { return this.supportedReceiversField; }
            set { this.supportedReceiversField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int MaximumRTSPURILength
        {
            get { return this.maximumRTSPURILengthField; }
            set { this.maximumRTSPURILengthField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 6)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ReplayCapabilities
    {
        private XElement[] anyField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SearchCapabilities
    {
        private XElement[] anyField;

        private bool metadataSearchField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool MetadataSearch
        {
            get { return this.metadataSearchField; }
            set { this.metadataSearchField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RecordingCapabilities
    {
        private XElement[] anyField;

        private bool dynamicRecordingsField;

        private bool dynamicTracksField;

        private int maxStringLengthField;

        private bool mediaProfileSourceField;

        private bool receiverSourceField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool ReceiverSource
        {
            get { return this.receiverSourceField; }
            set { this.receiverSourceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool MediaProfileSource
        {
            get { return this.mediaProfileSourceField; }
            set { this.mediaProfileSourceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool DynamicRecordings
        {
            get { return this.dynamicRecordingsField; }
            set { this.dynamicRecordingsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public bool DynamicTracks
        {
            get { return this.dynamicTracksField; }
            set { this.dynamicTracksField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int MaxStringLength
        {
            get { return this.maxStringLengthField; }
            set { this.maxStringLengthField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 6)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DisplayCapabilities
    {
        private XElement[] anyField;

        private bool fixedLayoutField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool FixedLayout
        {
            get { return this.fixedLayoutField; }
            set { this.fixedLayoutField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DeviceIOCapabilities
    {
        private XElement[] anyField;

        private int audioOutputsField;

        private int audioSourcesField;

        private int relayOutputsField;

        private int videoOutputsField;

        private int videoSourcesField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int VideoSources
        {
            get { return this.videoSourcesField; }
            set { this.videoSourcesField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int VideoOutputs
        {
            get { return this.videoOutputsField; }
            set { this.videoOutputsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int AudioSources
        {
            get { return this.audioSourcesField; }
            set { this.audioSourcesField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public int AudioOutputs
        {
            get { return this.audioOutputsField; }
            set { this.audioOutputsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int RelayOutputs
        {
            get { return this.relayOutputsField; }
            set { this.relayOutputsField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 6)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class CapabilitiesExtension
    {
        private AnalyticsDeviceCapabilities analyticsDeviceField;
        private XElement[] anyField;

        private DeviceIOCapabilities deviceIOField;

        private DisplayCapabilities displayField;

        private CapabilitiesExtension2 extensionsField;

        private ReceiverCapabilities receiverField;

        private RecordingCapabilities recordingField;

        private ReplayCapabilities replayField;

        private SearchCapabilities searchField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public DeviceIOCapabilities DeviceIO
        {
            get { return this.deviceIOField; }
            set { this.deviceIOField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public DisplayCapabilities Display
        {
            get { return this.displayField; }
            set { this.displayField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public RecordingCapabilities Recording
        {
            get { return this.recordingField; }
            set { this.recordingField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public SearchCapabilities Search
        {
            get { return this.searchField; }
            set { this.searchField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public ReplayCapabilities Replay
        {
            get { return this.replayField; }
            set { this.replayField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public ReceiverCapabilities Receiver
        {
            get { return this.receiverField; }
            set { this.receiverField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public AnalyticsDeviceCapabilities AnalyticsDevice
        {
            get { return this.analyticsDeviceField; }
            set { this.analyticsDeviceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public CapabilitiesExtension2 Extensions
        {
            get { return this.extensionsField; }
            set { this.extensionsField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZCapabilities
    {
        private XElement[] anyField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ProfileCapabilities
    {
        private XElement[] anyField;
        private int maximumNumberOfProfilesField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int MaximumNumberOfProfiles
        {
            get { return this.maximumNumberOfProfilesField; }
            set { this.maximumNumberOfProfilesField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MediaCapabilitiesExtension
    {
        private XElement[] anyField;
        private ProfileCapabilities profileCapabilitiesField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ProfileCapabilities ProfileCapabilities
        {
            get { return this.profileCapabilitiesField; }
            set { this.profileCapabilitiesField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RealTimeStreamingCapabilitiesExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RealTimeStreamingCapabilities
    {
        private RealTimeStreamingCapabilitiesExtension extensionField;

        private bool rTP_RTSP_TCPField;

        private bool rTP_RTSP_TCPFieldSpecified;

        private bool rTP_TCPField;

        private bool rTP_TCPFieldSpecified;
        private bool rTPMulticastField;

        private bool rTPMulticastFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
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
        [XmlElement(Order = 1)]
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
        [XmlElement(Order = 2)]
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
        [XmlElement(Order = 3)]
        public RealTimeStreamingCapabilitiesExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MediaCapabilities
    {
        private XElement[] anyField;

        private MediaCapabilitiesExtension extensionField;

        private RealTimeStreamingCapabilities streamingCapabilitiesField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public RealTimeStreamingCapabilities StreamingCapabilities
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
        [XmlElement(Order = 3)]
        public MediaCapabilitiesExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingCapabilities
    {
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class EventCapabilities
    {
        private XElement[] anyField;

        private bool wSPausableSubscriptionManagerInterfaceSupportField;

        private bool wSPullPointSupportField;

        private bool wSSubscriptionPolicySupportField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool WSSubscriptionPolicySupport
        {
            get { return this.wSSubscriptionPolicySupportField; }
            set { this.wSSubscriptionPolicySupportField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool WSPullPointSupport
        {
            get { return this.wSPullPointSupportField; }
            set { this.wSPullPointSupportField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool WSPausableSubscriptionManagerInterfaceSupport
        {
            get { return this.wSPausableSubscriptionManagerInterfaceSupportField; }
            set { this.wSPausableSubscriptionManagerInterfaceSupportField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 4)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DeviceCapabilitiesExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SecurityCapabilitiesExtension2
    {
        private XElement[] anyField;
        private bool dot1XField;

        private bool remoteUserHandlingField;

        private int[] supportedEAPMethodField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool Dot1X
        {
            get { return this.dot1XField; }
            set { this.dot1XField = value; }
        }

        /// <remarks/>
        [XmlElement("SupportedEAPMethod", Order = 1)]
        public int[] SupportedEAPMethod
        {
            get { return this.supportedEAPMethodField; }
            set { this.supportedEAPMethodField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool RemoteUserHandling
        {
            get { return this.remoteUserHandlingField; }
            set { this.remoteUserHandlingField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SecurityCapabilitiesExtension
    {
        private SecurityCapabilitiesExtension2 extensionField;
        private bool tLS10Field;

        /// <remarks/>
        [XmlElement("TLS1.0", Order = 0)]
        public bool TLS10
        {
            get { return this.tLS10Field; }
            set { this.tLS10Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public SecurityCapabilitiesExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(TypeName = "SecurityCapabilities",
        Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SecurityCapabilities1
    {
        private bool accessPolicyConfigField;

        private XElement[] anyField;

        private SecurityCapabilitiesExtension extensionField;

        private bool kerberosTokenField;

        private bool onboardKeyGenerationField;

        private bool rELTokenField;

        private bool sAMLTokenField;
        private bool tLS11Field;

        private bool tLS12Field;

        private bool x509TokenField;

        /// <remarks/>
        [XmlElement("TLS1.1", Order = 0)]
        public bool TLS11
        {
            get { return this.tLS11Field; }
            set { this.tLS11Field = value; }
        }

        /// <remarks/>
        [XmlElement("TLS1.2", Order = 1)]
        public bool TLS12
        {
            get { return this.tLS12Field; }
            set { this.tLS12Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool OnboardKeyGeneration
        {
            get { return this.onboardKeyGenerationField; }
            set { this.onboardKeyGenerationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool AccessPolicyConfig
        {
            get { return this.accessPolicyConfigField; }
            set { this.accessPolicyConfigField = value; }
        }

        /// <remarks/>
        [XmlElement("X.509Token", Order = 4)]
        public bool X509Token
        {
            get { return this.x509TokenField; }
            set { this.x509TokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public bool SAMLToken
        {
            get { return this.sAMLTokenField; }
            set { this.sAMLTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public bool KerberosToken
        {
            get { return this.kerberosTokenField; }
            set { this.kerberosTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public bool RELToken
        {
            get { return this.rELTokenField; }
            set { this.rELTokenField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 8)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public SecurityCapabilitiesExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IOCapabilitiesExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IOCapabilitiesExtension
    {
        private XElement[] anyField;

        private string[] auxiliaryCommandsField;

        private bool auxiliaryField;

        private bool auxiliaryFieldSpecified;

        private IOCapabilitiesExtension2 extensionField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool Auxiliary
        {
            get { return this.auxiliaryField; }
            set { this.auxiliaryField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool AuxiliarySpecified
        {
            get { return this.auxiliaryFieldSpecified; }
            set { this.auxiliaryFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement("AuxiliaryCommands", Order = 2)]
        public string[] AuxiliaryCommands
        {
            get { return this.auxiliaryCommandsField; }
            set { this.auxiliaryCommandsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IOCapabilitiesExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IOCapabilities
    {
        private IOCapabilitiesExtension extensionField;
        private int inputConnectorsField;

        private bool inputConnectorsFieldSpecified;

        private int relayOutputsField;

        private bool relayOutputsFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int InputConnectors
        {
            get { return this.inputConnectorsField; }
            set { this.inputConnectorsField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool InputConnectorsSpecified
        {
            get { return this.inputConnectorsFieldSpecified; }
            set { this.inputConnectorsFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int RelayOutputs
        {
            get { return this.relayOutputsField; }
            set { this.relayOutputsField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RelayOutputsSpecified
        {
            get { return this.relayOutputsFieldSpecified; }
            set { this.relayOutputsFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public IOCapabilitiesExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SystemCapabilitiesExtension2
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SystemCapabilitiesExtension
    {
        private XElement[] anyField;

        private SystemCapabilitiesExtension2 extensionField;

        private bool httpFirmwareUpgradeField;

        private bool httpFirmwareUpgradeFieldSpecified;

        private bool httpSupportInformationField;

        private bool httpSupportInformationFieldSpecified;

        private bool httpSystemBackupField;

        private bool httpSystemBackupFieldSpecified;

        private bool httpSystemLoggingField;

        private bool httpSystemLoggingFieldSpecified;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool HttpFirmwareUpgrade
        {
            get { return this.httpFirmwareUpgradeField; }
            set { this.httpFirmwareUpgradeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool HttpFirmwareUpgradeSpecified
        {
            get { return this.httpFirmwareUpgradeFieldSpecified; }
            set { this.httpFirmwareUpgradeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool HttpSystemBackup
        {
            get { return this.httpSystemBackupField; }
            set { this.httpSystemBackupField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool HttpSystemBackupSpecified
        {
            get { return this.httpSystemBackupFieldSpecified; }
            set { this.httpSystemBackupFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool HttpSystemLogging
        {
            get { return this.httpSystemLoggingField; }
            set { this.httpSystemLoggingField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool HttpSystemLoggingSpecified
        {
            get { return this.httpSystemLoggingFieldSpecified; }
            set { this.httpSystemLoggingFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public bool HttpSupportInformation
        {
            get { return this.httpSupportInformationField; }
            set { this.httpSupportInformationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool HttpSupportInformationSpecified
        {
            get { return this.httpSupportInformationFieldSpecified; }
            set { this.httpSupportInformationFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public SystemCapabilitiesExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(TypeName = "SystemCapabilities",
        Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SystemCapabilities1
    {
        private bool discoveryByeField;
        private bool discoveryResolveField;

        private SystemCapabilitiesExtension extensionField;

        private bool firmwareUpgradeField;

        private bool remoteDiscoveryField;

        private OnvifVersion[] supportedVersionsField;

        private bool systemBackupField;

        private bool systemLoggingField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool DiscoveryResolve
        {
            get { return this.discoveryResolveField; }
            set { this.discoveryResolveField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool DiscoveryBye
        {
            get { return this.discoveryByeField; }
            set { this.discoveryByeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool RemoteDiscovery
        {
            get { return this.remoteDiscoveryField; }
            set { this.remoteDiscoveryField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool SystemBackup
        {
            get { return this.systemBackupField; }
            set { this.systemBackupField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public bool SystemLogging
        {
            get { return this.systemLoggingField; }
            set { this.systemLoggingField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public bool FirmwareUpgrade
        {
            get { return this.firmwareUpgradeField; }
            set { this.firmwareUpgradeField = value; }
        }

        /// <remarks/>
        [XmlElement("SupportedVersions", Order = 6)]
        public OnvifVersion[] SupportedVersions
        {
            get { return this.supportedVersionsField; }
            set { this.supportedVersionsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public SystemCapabilitiesExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkCapabilitiesExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkCapabilitiesExtension
    {
        private XElement[] anyField;

        private bool dot11ConfigurationField;

        private bool dot11ConfigurationFieldSpecified;

        private NetworkCapabilitiesExtension2 extensionField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool Dot11Configuration
        {
            get { return this.dot11ConfigurationField; }
            set { this.dot11ConfigurationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool Dot11ConfigurationSpecified
        {
            get { return this.dot11ConfigurationFieldSpecified; }
            set { this.dot11ConfigurationFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public NetworkCapabilitiesExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(TypeName = "NetworkCapabilities",
        Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NetworkCapabilities1
    {
        private bool dynDNSField;

        private bool dynDNSFieldSpecified;

        private NetworkCapabilitiesExtension extensionField;
        private bool iPFilterField;

        private bool iPFilterFieldSpecified;

        private bool iPVersion6Field;

        private bool iPVersion6FieldSpecified;

        private bool zeroConfigurationField;

        private bool zeroConfigurationFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool IPFilter
        {
            get { return this.iPFilterField; }
            set { this.iPFilterField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool IPFilterSpecified
        {
            get { return this.iPFilterFieldSpecified; }
            set { this.iPFilterFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool ZeroConfiguration
        {
            get { return this.zeroConfigurationField; }
            set { this.zeroConfigurationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ZeroConfigurationSpecified
        {
            get { return this.zeroConfigurationFieldSpecified; }
            set { this.zeroConfigurationFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool IPVersion6
        {
            get { return this.iPVersion6Field; }
            set { this.iPVersion6Field = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool IPVersion6Specified
        {
            get { return this.iPVersion6FieldSpecified; }
            set { this.iPVersion6FieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool DynDNS
        {
            get { return this.dynDNSField; }
            set { this.dynDNSField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DynDNSSpecified
        {
            get { return this.dynDNSFieldSpecified; }
            set { this.dynDNSFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public NetworkCapabilitiesExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DeviceCapabilities
    {
        private DeviceCapabilitiesExtension extensionField;

        private IOCapabilities ioField;

        private NetworkCapabilities1 networkField;

        private SecurityCapabilities1 securityField;

        private SystemCapabilities1 systemField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public NetworkCapabilities1 Network
        {
            get { return this.networkField; }
            set { this.networkField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public SystemCapabilities1 System
        {
            get { return this.systemField; }
            set { this.systemField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IOCapabilities IO
        {
            get { return this.ioField; }
            set { this.ioField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public SecurityCapabilities1 Security
        {
            get { return this.securityField; }
            set { this.securityField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public DeviceCapabilitiesExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsCapabilities
    {
        private bool analyticsModuleSupportField;

        private XElement[] anyField;

        private bool ruleSupportField;
        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool RuleSupport
        {
            get { return this.ruleSupportField; }
            set { this.ruleSupportField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool AnalyticsModuleSupport
        {
            get { return this.analyticsModuleSupportField; }
            set { this.analyticsModuleSupportField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Capabilities
    {
        private AnalyticsCapabilities analyticsField;

        private DeviceCapabilities deviceField;

        private EventCapabilities eventsField;

        private CapabilitiesExtension extensionField;

        private ImagingCapabilities imagingField;

        private MediaCapabilities mediaField;

        private PTZCapabilities pTZField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AnalyticsCapabilities Analytics
        {
            get { return this.analyticsField; }
            set { this.analyticsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public DeviceCapabilities Device
        {
            get { return this.deviceField; }
            set { this.deviceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public EventCapabilities Events
        {
            get { return this.eventsField; }
            set { this.eventsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public ImagingCapabilities Imaging
        {
            get { return this.imagingField; }
            set { this.imagingField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public MediaCapabilities Media
        {
            get { return this.mediaField; }
            set { this.mediaField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public PTZCapabilities PTZ
        {
            get { return this.pTZField; }
            set { this.pTZField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public CapabilitiesExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class UserExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class User
    {
        private UserExtension extensionField;

        private string passwordField;

        private UserLevel userLevelField;
        private string usernameField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Username
        {
            get { return this.usernameField; }
            set { this.usernameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string Password
        {
            get { return this.passwordField; }
            set { this.passwordField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public UserLevel UserLevel
        {
            get { return this.userLevelField; }
            set { this.userLevelField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public UserExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum UserLevel
    {
        /// <remarks/>
        Administrator,

        /// <remarks/>
        Operator,

        /// <remarks/>
        User,

        /// <remarks/>
        Anonymous,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RemoteUser
    {
        private XElement[] anyField;

        private string passwordField;

        private bool useDerivedPasswordField;
        private string usernameField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Username
        {
            get { return this.usernameField; }
            set { this.usernameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string Password
        {
            get { return this.passwordField; }
            set { this.passwordField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool UseDerivedPassword
        {
            get { return this.useDerivedPasswordField; }
            set { this.useDerivedPasswordField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Scope
    {
        private ScopeDefinition scopeDefField;

        private string scopeItemField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ScopeDefinition ScopeDef
        {
            get { return this.scopeDefField; }
            set { this.scopeDefField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 1)]
        public string ScopeItem
        {
            get { return this.scopeItemField; }
            set { this.scopeItemField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum ScopeDefinition
    {
        /// <remarks/>
        Fixed,

        /// <remarks/>
        Configurable,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SupportInformation
    {
        private AttachmentData binaryField;

        private string stringField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AttachmentData Binary
        {
            get { return this.binaryField; }
            set { this.binaryField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string String
        {
            get { return this.stringField; }
            set { this.stringField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AttachmentData
    {
        private string contentTypeField;
        private Include includeField;

        /// <remarks/>
        [XmlElement(Namespace = "http://www.w3.org/2004/08/xop/include", Order = 0)]
        public Include Include
        {
            get { return this.includeField; }
            set { this.includeField = value; }
        }

        /// <remarks/>
        [XmlAttribute(Form = XmlSchemaForm.Qualified,
            Namespace = "http://www.w3.org/2005/05/xmlmime")]
        public string contentType
        {
            get { return this.contentTypeField; }
            set { this.contentTypeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.w3.org/2004/08/xop/include")]
    public partial class Include
    {
        private XElement[] anyField;

        private string hrefField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "anyURI")]
        public string href
        {
            get { return this.hrefField; }
            set { this.hrefField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SystemLog
    {
        private AttachmentData binaryField;

        private string stringField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AttachmentData Binary
        {
            get { return this.binaryField; }
            set { this.binaryField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string String
        {
            get { return this.stringField; }
            set { this.stringField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class BackupFile
    {
        private AttachmentData dataField;
        private string nameField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public AttachmentData Data
        {
            get { return this.dataField; }
            set { this.dataField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SystemDateTimeExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SystemDateTime
    {
        private SetDateTimeType dateTimeTypeField;

        private bool daylightSavingsField;

        private SystemDateTimeExtension extensionField;

        private DateTime localDateTimeField;

        private TimeZone timeZoneField;

        private DateTime uTCDateTimeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public SetDateTimeType DateTimeType
        {
            get { return this.dateTimeTypeField; }
            set { this.dateTimeTypeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool DaylightSavings
        {
            get { return this.daylightSavingsField; }
            set { this.daylightSavingsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public TimeZone TimeZone
        {
            get { return this.timeZoneField; }
            set { this.timeZoneField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public DateTime UTCDateTime
        {
            get { return this.uTCDateTimeField; }
            set { this.uTCDateTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public DateTime LocalDateTime
        {
            get { return this.localDateTimeField; }
            set { this.localDateTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public SystemDateTimeExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum SetDateTimeType
    {
        /// <remarks/>
        Manual,

        /// <remarks/>
        NTP,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class TimeZone
    {
        private string tzField;

        /// <remarks/>
        [XmlElement(DataType = "token", Order = 0)]
        public string TZ
        {
            get { return this.tzField; }
            set { this.tzField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DateTime
    {
        private Date dateField;
        private Time timeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public Time Time
        {
            get { return this.timeField; }
            set { this.timeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Date Date
        {
            get { return this.dateField; }
            set { this.dateField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Time
    {
        private int hourField;

        private int minuteField;

        private int secondField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int Hour
        {
            get { return this.hourField; }
            set { this.hourField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Minute
        {
            get { return this.minuteField; }
            set { this.minuteField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int Second
        {
            get { return this.secondField; }
            set { this.secondField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Date
    {
        private int dayField;

        private int monthField;
        private int yearField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int Year
        {
            get { return this.yearField; }
            set { this.yearField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Month
        {
            get { return this.monthField; }
            set { this.monthField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int Day
        {
            get { return this.dayField; }
            set { this.dayField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum FactoryDefaultType
    {
        /// <remarks/>
        Hard,

        /// <remarks/>
        Soft,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum DiscoveryMode
    {
        /// <remarks/>
        Discoverable,

        /// <remarks/>
        NonDiscoverable,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum CapabilityCategory
    {
        /// <remarks/>
        All,

        /// <remarks/>
        Analytics,

        /// <remarks/>
        Device,

        /// <remarks/>
        Events,

        /// <remarks/>
        Imaging,

        /// <remarks/>
        Media,

        /// <remarks/>
        PTZ,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum RelayLogicalState
    {
        /// <remarks/>
        active,

        /// <remarks/>
        inactive,
    }


    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDConfigurationOptionsExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDImgOptionsExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDImgOptions
    {
        private OSDImgOptionsExtension extensionField;

        private string[] formatsSupportedField;
        private string[] imagePathField;

        private int maxHeightField;

        private bool maxHeightFieldSpecified;

        private int maxSizeField;

        private bool maxSizeFieldSpecified;

        private int maxWidthField;

        private bool maxWidthFieldSpecified;

        /// <remarks/>
        [XmlElement("ImagePath", DataType = "anyURI", Order = 0)]
        public string[] ImagePath
        {
            get { return this.imagePathField; }
            set { this.imagePathField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OSDImgOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string[] FormatsSupported
        {
            get { return this.formatsSupportedField; }
            set { this.formatsSupportedField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int MaxSize
        {
            get { return this.maxSizeField; }
            set { this.maxSizeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxSizeSpecified
        {
            get { return this.maxSizeFieldSpecified; }
            set { this.maxSizeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int MaxWidth
        {
            get { return this.maxWidthField; }
            set { this.maxWidthField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxWidthSpecified
        {
            get { return this.maxWidthFieldSpecified; }
            set { this.maxWidthFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int MaxHeight
        {
            get { return this.maxHeightField; }
            set { this.maxHeightField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxHeightSpecified
        {
            get { return this.maxHeightFieldSpecified; }
            set { this.maxHeightFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDTextOptionsExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDColorOptionsExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ColorspaceRange
    {
        private string colorspaceField;
        private FloatRange xField;

        private FloatRange yField;

        private FloatRange zField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public FloatRange X
        {
            get { return this.xField; }
            set { this.xField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange Y
        {
            get { return this.yField; }
            set { this.yField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public FloatRange Z
        {
            get { return this.zField; }
            set { this.zField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 3)]
        public string Colorspace
        {
            get { return this.colorspaceField; }
            set { this.colorspaceField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ColorOptions
    {
        private object[] itemsField;

        /// <remarks/>
        [XmlElement("ColorList", typeof(Color), Order = 0)]
        [XmlElement("ColorspaceRange", typeof(ColorspaceRange), Order = 0)]
        public object[] Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDColorOptions
    {
        private ColorOptions colorField;

        private OSDColorOptionsExtension extensionField;

        private IntRange transparentField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ColorOptions Color
        {
            get { return this.colorField; }
            set { this.colorField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public IntRange Transparent
        {
            get { return this.transparentField; }
            set { this.transparentField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OSDColorOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IntRange
    {
        private int maxField;
        private int minField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int Min
        {
            get { return this.minField; }
            set { this.minField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Max
        {
            get { return this.maxField; }
            set { this.maxField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDTextOptions
    {
        private OSDColorOptions backgroundColorField;

        private string[] dateFormatField;

        private OSDTextOptionsExtension extensionField;

        private OSDColorOptions fontColorField;

        private IntRange fontSizeRangeField;

        private string[] timeFormatField;
        private string[] typeField;

        /// <remarks/>
        [XmlElement("Type", Order = 0)]
        public string[] Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public IntRange FontSizeRange
        {
            get { return this.fontSizeRangeField; }
            set { this.fontSizeRangeField = value; }
        }

        /// <remarks/>
        [XmlElement("DateFormat", Order = 2)]
        public string[] DateFormat
        {
            get { return this.dateFormatField; }
            set { this.dateFormatField = value; }
        }

        /// <remarks/>
        [XmlElement("TimeFormat", Order = 3)]
        public string[] TimeFormat
        {
            get { return this.timeFormatField; }
            set { this.timeFormatField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OSDColorOptions FontColor
        {
            get { return this.fontColorField; }
            set { this.fontColorField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OSDColorOptions BackgroundColor
        {
            get { return this.backgroundColorField; }
            set { this.backgroundColorField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public OSDTextOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MaximumNumberOfOSDs
    {
        private int dateAndTimeField;

        private bool dateAndTimeFieldSpecified;

        private int dateField;

        private bool dateFieldSpecified;

        private int imageField;

        private bool imageFieldSpecified;

        private int plainTextField;

        private bool plainTextFieldSpecified;

        private int timeField;

        private bool timeFieldSpecified;
        private int totalField;

        /// <remarks/>
        [XmlAttribute()]
        public int Total
        {
            get { return this.totalField; }
            set { this.totalField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int Image
        {
            get { return this.imageField; }
            set { this.imageField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ImageSpecified
        {
            get { return this.imageFieldSpecified; }
            set { this.imageFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int PlainText
        {
            get { return this.plainTextField; }
            set { this.plainTextField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool PlainTextSpecified
        {
            get { return this.plainTextFieldSpecified; }
            set { this.plainTextFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int Date
        {
            get { return this.dateField; }
            set { this.dateField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DateSpecified
        {
            get { return this.dateFieldSpecified; }
            set { this.dateFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int Time
        {
            get { return this.timeField; }
            set { this.timeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool TimeSpecified
        {
            get { return this.timeFieldSpecified; }
            set { this.timeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int DateAndTime
        {
            get { return this.dateAndTimeField; }
            set { this.dateAndTimeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DateAndTimeSpecified
        {
            get { return this.dateAndTimeFieldSpecified; }
            set { this.dateAndTimeFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class OSDConfigurationOptions
    {
        private OSDConfigurationOptionsExtension extensionField;

        private OSDImgOptions imageOptionField;
        private MaximumNumberOfOSDs maximumNumberOfOSDsField;

        private string[] positionOptionField;

        private OSDTextOptions textOptionField;

        private OSDType[] typeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public MaximumNumberOfOSDs MaximumNumberOfOSDs
        {
            get { return this.maximumNumberOfOSDsField; }
            set { this.maximumNumberOfOSDsField = value; }
        }

        /// <remarks/>
        [XmlElement("Type", Order = 1)]
        public OSDType[] Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlElement("PositionOption", Order = 2)]
        public string[] PositionOption
        {
            get { return this.positionOptionField; }
            set { this.positionOptionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OSDTextOptions TextOption
        {
            get { return this.textOptionField; }
            set { this.textOptionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OSDImgOptions ImageOption
        {
            get { return this.imageOptionField; }
            set { this.imageOptionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OSDConfigurationOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MediaUri
    {
        private XElement[] anyField;

        private bool invalidAfterConnectField;

        private bool invalidAfterRebootField;

        private string timeoutField;
        private string uriField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string Uri
        {
            get { return this.uriField; }
            set { this.uriField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool InvalidAfterConnect
        {
            get { return this.invalidAfterConnectField; }
            set { this.invalidAfterConnectField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool InvalidAfterReboot
        {
            get { return this.invalidAfterRebootField; }
            set { this.invalidAfterRebootField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 3)]
        public string Timeout
        {
            get { return this.timeoutField; }
            set { this.timeoutField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 4)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Transport
    {
        private TransportProtocol protocolField;

        private Transport tunnelField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public TransportProtocol Protocol
        {
            get { return this.protocolField; }
            set { this.protocolField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Transport Tunnel
        {
            get { return this.tunnelField; }
            set { this.tunnelField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum TransportProtocol
    {
        /// <remarks/>
        UDP,

        /// <remarks/>
        TCP,

        /// <remarks/>
        RTSP,

        /// <remarks/>
        HTTP,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class StreamSetup
    {
        private XElement[] anyField;
        private StreamType streamField;

        private Transport transportField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public StreamType Stream
        {
            get { return this.streamField; }
            set { this.streamField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Transport Transport
        {
            get { return this.transportField; }
            set { this.transportField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum StreamType
    {
        /// <remarks/>
        [XmlEnum("RTP-Unicast")]
        RTPUnicast,

        /// <remarks/>
        [XmlEnum("RTP-Multicast")]
        RTPMulticast,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioDecoderConfigurationOptionsExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class G726DecOptions
    {
        private XElement[] anyField;
        private int[] bitrateField;

        private int[] sampleRateRangeField;

        /// <remarks/>
        [XmlArray(Order = 0)]
        [XmlArrayItem("Items", IsNullable = false)]
        public int[] Bitrate
        {
            get { return this.bitrateField; }
            set { this.bitrateField = value; }
        }

        /// <remarks/>
        [XmlArray(Order = 1)]
        [XmlArrayItem("Items", IsNullable = false)]
        public int[] SampleRateRange
        {
            get { return this.sampleRateRangeField; }
            set { this.sampleRateRangeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class G711DecOptions
    {
        private XElement[] anyField;
        private int[] bitrateField;

        private int[] sampleRateRangeField;

        /// <remarks/>
        [XmlArray(Order = 0)]
        [XmlArrayItem("Items", IsNullable = false)]
        public int[] Bitrate
        {
            get { return this.bitrateField; }
            set { this.bitrateField = value; }
        }

        /// <remarks/>
        [XmlArray(Order = 1)]
        [XmlArrayItem("Items", IsNullable = false)]
        public int[] SampleRateRange
        {
            get { return this.sampleRateRangeField; }
            set { this.sampleRateRangeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AACDecOptions
    {
        private XElement[] anyField;
        private int[] bitrateField;

        private int[] sampleRateRangeField;

        /// <remarks/>
        [XmlArray(Order = 0)]
        [XmlArrayItem("Items", IsNullable = false)]
        public int[] Bitrate
        {
            get { return this.bitrateField; }
            set { this.bitrateField = value; }
        }

        /// <remarks/>
        [XmlArray(Order = 1)]
        [XmlArrayItem("Items", IsNullable = false)]
        public int[] SampleRateRange
        {
            get { return this.sampleRateRangeField; }
            set { this.sampleRateRangeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioDecoderConfigurationOptions
    {
        private AACDecOptions aACDecOptionsField;

        private AudioDecoderConfigurationOptionsExtension extensionField;

        private G711DecOptions g711DecOptionsField;

        private G726DecOptions g726DecOptionsField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AACDecOptions AACDecOptions
        {
            get { return this.aACDecOptionsField; }
            set { this.aACDecOptionsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public G711DecOptions G711DecOptions
        {
            get { return this.g711DecOptionsField; }
            set { this.g711DecOptionsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public G726DecOptions G726DecOptions
        {
            get { return this.g726DecOptionsField; }
            set { this.g726DecOptionsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public AudioDecoderConfigurationOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioOutputConfigurationOptions
    {
        private XElement[] anyField;

        private IntRange outputLevelRangeField;
        private string[] outputTokensAvailableField;

        private string[] sendPrimacyOptionsField;

        /// <remarks/>
        [XmlElement("OutputTokensAvailable", Order = 0)]
        public string[] OutputTokensAvailable
        {
            get { return this.outputTokensAvailableField; }
            set { this.outputTokensAvailableField = value; }
        }

        /// <remarks/>
        [XmlElement("SendPrimacyOptions", DataType = "anyURI", Order = 1)]
        public string[] SendPrimacyOptions
        {
            get { return this.sendPrimacyOptionsField; }
            set { this.sendPrimacyOptionsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public IntRange OutputLevelRange
        {
            get { return this.outputLevelRangeField; }
            set { this.outputLevelRangeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MetadataConfigurationOptionsExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MetadataConfigurationOptionsExtension
    {
        private string[] compressionTypeField;

        private MetadataConfigurationOptionsExtension2 extensionField;

        /// <remarks/>
        [XmlElement("CompressionType", Order = 0)]
        public string[] CompressionType
        {
            get { return this.compressionTypeField; }
            set { this.compressionTypeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public MetadataConfigurationOptionsExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZStatusFilterOptionsExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZStatusFilterOptions
    {
        private XElement[] anyField;

        private PTZStatusFilterOptionsExtension extensionField;

        private bool panTiltPositionSupportedField;

        private bool panTiltPositionSupportedFieldSpecified;
        private bool panTiltStatusSupportedField;

        private bool zoomPositionSupportedField;

        private bool zoomPositionSupportedFieldSpecified;

        private bool zoomStatusSupportedField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool PanTiltStatusSupported
        {
            get { return this.panTiltStatusSupportedField; }
            set { this.panTiltStatusSupportedField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool ZoomStatusSupported
        {
            get { return this.zoomStatusSupportedField; }
            set { this.zoomStatusSupportedField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool PanTiltPositionSupported
        {
            get { return this.panTiltPositionSupportedField; }
            set { this.panTiltPositionSupportedField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool PanTiltPositionSupportedSpecified
        {
            get { return this.panTiltPositionSupportedFieldSpecified; }
            set { this.panTiltPositionSupportedFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public bool ZoomPositionSupported
        {
            get { return this.zoomPositionSupportedField; }
            set { this.zoomPositionSupportedField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ZoomPositionSupportedSpecified
        {
            get { return this.zoomPositionSupportedFieldSpecified; }
            set { this.zoomPositionSupportedFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public PTZStatusFilterOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MetadataConfigurationOptions
    {
        private XElement[] anyField;

        private MetadataConfigurationOptionsExtension extensionField;

        private bool geoLocationField;

        private bool geoLocationFieldSpecified;
        private PTZStatusFilterOptions pTZStatusFilterOptionsField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public PTZStatusFilterOptions PTZStatusFilterOptions
        {
            get { return this.pTZStatusFilterOptionsField; }
            set { this.pTZStatusFilterOptionsField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public MetadataConfigurationOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool GeoLocation
        {
            get { return this.geoLocationField; }
            set { this.geoLocationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool GeoLocationSpecified
        {
            get { return this.geoLocationFieldSpecified; }
            set { this.geoLocationFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioEncoderConfigurationOption
    {
        private XElement[] anyField;

        private int[] bitrateListField;
        private AudioEncoding encodingField;

        private int[] sampleRateListField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AudioEncoding Encoding
        {
            get { return this.encodingField; }
            set { this.encodingField = value; }
        }

        /// <remarks/>
        [XmlArray(Order = 1)]
        [XmlArrayItem("Items", IsNullable = false)]
        public int[] BitrateList
        {
            get { return this.bitrateListField; }
            set { this.bitrateListField = value; }
        }

        /// <remarks/>
        [XmlArray(Order = 2)]
        [XmlArrayItem("Items", IsNullable = false)]
        public int[] SampleRateList
        {
            get { return this.sampleRateListField; }
            set { this.sampleRateListField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum AudioEncoding
    {
        /// <remarks/>
        G711,

        /// <remarks/>
        G726,

        /// <remarks/>
        AAC,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioEncoderConfigurationOptions
    {
        private AudioEncoderConfigurationOption[] optionsField;

        /// <remarks/>
        [XmlElement("Options", Order = 0)]
        public AudioEncoderConfigurationOption[] Options
        {
            get { return this.optionsField; }
            set { this.optionsField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioSourceOptionsExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioSourceConfigurationOptions
    {
        private AudioSourceOptionsExtension extensionField;
        private string[] inputTokensAvailableField;

        /// <remarks/>
        [XmlElement("InputTokensAvailable", Order = 0)]
        public string[] InputTokensAvailable
        {
            get { return this.inputTokensAvailableField; }
            set { this.inputTokensAvailableField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public AudioSourceOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoEncoderOptionsExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoEncoderOptionsExtension
    {
        private XElement[] anyField;

        private VideoEncoderOptionsExtension2 extensionField;

        private H264Options2 h264Field;

        private JpegOptions2 jPEGField;

        private Mpeg4Options2 mPEG4Field;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public JpegOptions2 JPEG
        {
            get { return this.jPEGField; }
            set { this.jPEGField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public Mpeg4Options2 MPEG4
        {
            get { return this.mPEG4Field; }
            set { this.mPEG4Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public H264Options2 H264
        {
            get { return this.h264Field; }
            set { this.h264Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public VideoEncoderOptionsExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class JpegOptions2 : JpegOptions
    {
        private XElement[] anyField;
        private IntRange bitrateRangeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IntRange BitrateRange
        {
            get { return this.bitrateRangeField; }
            set { this.bitrateRangeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [XmlInclude(typeof(JpegOptions2))]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class JpegOptions
    {
        private IntRange encodingIntervalRangeField;

        private IntRange frameRateRangeField;
        private VideoResolution[] resolutionsAvailableField;

        /// <remarks/>
        [XmlElement("ResolutionsAvailable", Order = 0)]
        public VideoResolution[] ResolutionsAvailable
        {
            get { return this.resolutionsAvailableField; }
            set { this.resolutionsAvailableField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public IntRange FrameRateRange
        {
            get { return this.frameRateRangeField; }
            set { this.frameRateRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public IntRange EncodingIntervalRange
        {
            get { return this.encodingIntervalRangeField; }
            set { this.encodingIntervalRangeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Mpeg4Options2 : Mpeg4Options
    {
        private XElement[] anyField;
        private IntRange bitrateRangeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IntRange BitrateRange
        {
            get { return this.bitrateRangeField; }
            set { this.bitrateRangeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [XmlInclude(typeof(Mpeg4Options2))]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Mpeg4Options
    {
        private IntRange encodingIntervalRangeField;

        private IntRange frameRateRangeField;

        private IntRange govLengthRangeField;

        private Mpeg4Profile[] mpeg4ProfilesSupportedField;
        private VideoResolution[] resolutionsAvailableField;

        /// <remarks/>
        [XmlElement("ResolutionsAvailable", Order = 0)]
        public VideoResolution[] ResolutionsAvailable
        {
            get { return this.resolutionsAvailableField; }
            set { this.resolutionsAvailableField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public IntRange GovLengthRange
        {
            get { return this.govLengthRangeField; }
            set { this.govLengthRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public IntRange FrameRateRange
        {
            get { return this.frameRateRangeField; }
            set { this.frameRateRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IntRange EncodingIntervalRange
        {
            get { return this.encodingIntervalRangeField; }
            set { this.encodingIntervalRangeField = value; }
        }

        /// <remarks/>
        [XmlElement("Mpeg4ProfilesSupported", Order = 4)]
        public Mpeg4Profile[] Mpeg4ProfilesSupported
        {
            get { return this.mpeg4ProfilesSupportedField; }
            set { this.mpeg4ProfilesSupportedField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum Mpeg4Profile
    {
        /// <remarks/>
        SP,

        /// <remarks/>
        ASP,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class H264Options2 : H264Options
    {
        private XElement[] anyField;
        private IntRange bitrateRangeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IntRange BitrateRange
        {
            get { return this.bitrateRangeField; }
            set { this.bitrateRangeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [XmlInclude(typeof(H264Options2))]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class H264Options
    {
        private IntRange encodingIntervalRangeField;

        private IntRange frameRateRangeField;

        private IntRange govLengthRangeField;

        private H264Profile[] h264ProfilesSupportedField;
        private VideoResolution[] resolutionsAvailableField;

        /// <remarks/>
        [XmlElement("ResolutionsAvailable", Order = 0)]
        public VideoResolution[] ResolutionsAvailable
        {
            get { return this.resolutionsAvailableField; }
            set { this.resolutionsAvailableField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public IntRange GovLengthRange
        {
            get { return this.govLengthRangeField; }
            set { this.govLengthRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public IntRange FrameRateRange
        {
            get { return this.frameRateRangeField; }
            set { this.frameRateRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IntRange EncodingIntervalRange
        {
            get { return this.encodingIntervalRangeField; }
            set { this.encodingIntervalRangeField = value; }
        }

        /// <remarks/>
        [XmlElement("H264ProfilesSupported", Order = 4)]
        public H264Profile[] H264ProfilesSupported
        {
            get { return this.h264ProfilesSupportedField; }
            set { this.h264ProfilesSupportedField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum H264Profile
    {
        /// <remarks/>
        Baseline,

        /// <remarks/>
        Main,

        /// <remarks/>
        Extended,

        /// <remarks/>
        High,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoEncoderConfigurationOptions
    {
        private VideoEncoderOptionsExtension extensionField;

        private H264Options h264Field;

        private JpegOptions jPEGField;

        private Mpeg4Options mPEG4Field;
        private IntRange qualityRangeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IntRange QualityRange
        {
            get { return this.qualityRangeField; }
            set { this.qualityRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public JpegOptions JPEG
        {
            get { return this.jPEGField; }
            set { this.jPEGField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public Mpeg4Options MPEG4
        {
            get { return this.mPEG4Field; }
            set { this.mPEG4Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public H264Options H264
        {
            get { return this.h264Field; }
            set { this.h264Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public VideoEncoderOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoSourceConfigurationOptionsExtension2
    {
        private XElement[] anyField;
        private SceneOrientationMode[] sceneOrientationModeField;

        /// <remarks/>
        [XmlElement("SceneOrientationMode", Order = 0)]
        public SceneOrientationMode[] SceneOrientationMode
        {
            get { return this.sceneOrientationModeField; }
            set { this.sceneOrientationModeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum SceneOrientationMode
    {
        /// <remarks/>
        MANUAL,

        /// <remarks/>
        AUTO,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RotateOptionsExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RotateOptions
    {
        private int[] degreeListField;

        private RotateOptionsExtension extensionField;
        private RotateMode[] modeField;

        /// <remarks/>
        [XmlElement("Mode", Order = 0)]
        public RotateMode[] Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlArray(Order = 1)]
        [XmlArrayItem("Items", IsNullable = false)]
        public int[] DegreeList
        {
            get { return this.degreeListField; }
            set { this.degreeListField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public RotateOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum RotateMode
    {
        /// <remarks/>
        OFF,

        /// <remarks/>
        ON,

        /// <remarks/>
        AUTO,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoSourceConfigurationOptionsExtension
    {
        private XElement[] anyField;

        private VideoSourceConfigurationOptionsExtension2 extensionField;

        private RotateOptions rotateField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public RotateOptions Rotate
        {
            get { return this.rotateField; }
            set { this.rotateField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public VideoSourceConfigurationOptionsExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IntRectangleRange
    {
        private IntRange heightRangeField;

        private IntRange widthRangeField;
        private IntRange xRangeField;

        private IntRange yRangeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IntRange XRange
        {
            get { return this.xRangeField; }
            set { this.xRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public IntRange YRange
        {
            get { return this.yRangeField; }
            set { this.yRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public IntRange WidthRange
        {
            get { return this.widthRangeField; }
            set { this.widthRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IntRange HeightRange
        {
            get { return this.heightRangeField; }
            set { this.heightRangeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoSourceConfigurationOptions
    {
        private IntRectangleRange boundsRangeField;

        private VideoSourceConfigurationOptionsExtension extensionField;

        private int maximumNumberOfProfilesField;

        private bool maximumNumberOfProfilesFieldSpecified;

        private string[] videoSourceTokensAvailableField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IntRectangleRange BoundsRange
        {
            get { return this.boundsRangeField; }
            set { this.boundsRangeField = value; }
        }

        /// <remarks/>
        [XmlElement("VideoSourceTokensAvailable", Order = 1)]
        public string[] VideoSourceTokensAvailable
        {
            get { return this.videoSourceTokensAvailableField; }
            set { this.videoSourceTokensAvailableField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public VideoSourceConfigurationOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ProfileExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ProfileExtension
    {
        private XElement[] anyField;

        private AudioDecoderConfiguration audioDecoderConfigurationField;

        private AudioOutputConfiguration audioOutputConfigurationField;

        private ProfileExtension2 extensionField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public AudioOutputConfiguration AudioOutputConfiguration
        {
            get { return this.audioOutputConfigurationField; }
            set { this.audioOutputConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public AudioDecoderConfiguration AudioDecoderConfiguration
        {
            get { return this.audioDecoderConfigurationField; }
            set { this.audioDecoderConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public ProfileExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioOutputConfiguration : ConfigurationEntity
    {
        private XElement[] anyField;

        private int outputLevelField;
        private string outputTokenField;

        private string sendPrimacyField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string OutputToken
        {
            get { return this.outputTokenField; }
            set { this.outputTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 1)]
        public string SendPrimacy
        {
            get { return this.sendPrimacyField; }
            set { this.sendPrimacyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int OutputLevel
        {
            get { return this.outputLevelField; }
            set { this.outputLevelField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [XmlInclude(typeof(AnalyticsEngineControl))]
    [XmlInclude(typeof(AnalyticsEngineInput))]
    [XmlInclude(typeof(AnalyticsEngine))]
    [XmlInclude(typeof(PTZConfiguration))]
    [XmlInclude(typeof(AudioDecoderConfiguration))]
    [XmlInclude(typeof(AudioOutputConfiguration))]
    [XmlInclude(typeof(VideoOutputConfiguration))]
    [XmlInclude(typeof(MetadataConfiguration))]
    [XmlInclude(typeof(VideoAnalyticsConfiguration))]
    [XmlInclude(typeof(AudioEncoder2Configuration))]
    [XmlInclude(typeof(AudioEncoderConfiguration))]
    [XmlInclude(typeof(AudioSourceConfiguration))]
    [XmlInclude(typeof(VideoEncoder2Configuration))]
    [XmlInclude(typeof(VideoEncoderConfiguration))]
    [XmlInclude(typeof(VideoSourceConfiguration))]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ConfigurationEntity
    {
        private string nameField;

        private string tokenField;

        private int useCountField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int UseCount
        {
            get { return this.useCountField; }
            set { this.useCountField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string token
        {
            get { return this.tokenField; }
            set { this.tokenField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsEngineControl : ConfigurationEntity
    {
        private XElement[] anyField;

        private string engineConfigTokenField;
        private string engineTokenField;

        private string[] inputTokenField;

        private ModeOfOperation modeField;

        private MulticastConfiguration multicastField;

        private string[] receiverTokenField;

        private Config subscriptionField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EngineToken
        {
            get { return this.engineTokenField; }
            set { this.engineTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string EngineConfigToken
        {
            get { return this.engineConfigTokenField; }
            set { this.engineConfigTokenField = value; }
        }

        /// <remarks/>
        [XmlElement("InputToken", Order = 2)]
        public string[] InputToken
        {
            get { return this.inputTokenField; }
            set { this.inputTokenField = value; }
        }

        /// <remarks/>
        [XmlElement("ReceiverToken", Order = 3)]
        public string[] ReceiverToken
        {
            get { return this.receiverTokenField; }
            set { this.receiverTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public MulticastConfiguration Multicast
        {
            get { return this.multicastField; }
            set { this.multicastField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public Config Subscription
        {
            get { return this.subscriptionField; }
            set { this.subscriptionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public ModeOfOperation Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 7)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MulticastConfiguration
    {
        private IPAddress addressField;

        private XElement[] anyField;

        private bool autoStartField;

        private int portField;

        private int tTLField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IPAddress Address
        {
            get { return this.addressField; }
            set { this.addressField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Port
        {
            get { return this.portField; }
            set { this.portField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int TTL
        {
            get { return this.tTLField; }
            set { this.tTLField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool AutoStart
        {
            get { return this.autoStartField; }
            set { this.autoStartField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 4)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Config
    {
        private string nameField;
        private ItemList parametersField;

        private XmlQualifiedName typeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ItemList Parameters
        {
            get { return this.parametersField; }
            set { this.parametersField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public XmlQualifiedName Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ItemList
    {
        private ItemListElementItem[] elementItemField;

        private ItemListExtension extensionField;
        private ItemListSimpleItem[] simpleItemField;

        /// <remarks/>
        [XmlElement("SimpleItem", Order = 0)]
        public ItemListSimpleItem[] SimpleItem
        {
            get { return this.simpleItemField; }
            set { this.simpleItemField = value; }
        }

        /// <remarks/>
        [XmlElement("ElementItem", Order = 1)]
        public ItemListElementItem[] ElementItem
        {
            get { return this.elementItemField; }
            set { this.elementItemField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ItemListExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(AnonymousType = true, Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ItemListSimpleItem
    {
        private string nameField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute()]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(AnonymousType = true, Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ItemListElementItem
    {
        private XElement anyField;

        private string nameField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ItemListExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum ModeOfOperation
    {
        /// <remarks/>
        Idle,

        /// <remarks/>
        Active,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsEngineInput : ConfigurationEntity
    {
        private XElement[] anyField;

        private MetadataInput metadataInputField;
        private SourceIdentification sourceIdentificationField;

        private VideoEncoderConfiguration videoInputField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public SourceIdentification SourceIdentification
        {
            get { return this.sourceIdentificationField; }
            set { this.sourceIdentificationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public VideoEncoderConfiguration VideoInput
        {
            get { return this.videoInputField; }
            set { this.videoInputField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public MetadataInput MetadataInput
        {
            get { return this.metadataInputField; }
            set { this.metadataInputField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SourceIdentification
    {
        private SourceIdentificationExtension extensionField;
        private string nameField;

        private string[] tokenField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement("Token", Order = 1)]
        public string[] Token
        {
            get { return this.tokenField; }
            set { this.tokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public SourceIdentificationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SourceIdentificationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoEncoderConfiguration : ConfigurationEntity
    {
        private XElement[] anyField;
        private VideoEncoding encodingField;

        private H264Configuration h264Field;

        private Mpeg4Configuration mPEG4Field;

        private MulticastConfiguration multicastField;

        private float qualityField;

        private VideoRateControl rateControlField;

        private VideoResolution resolutionField;

        private string sessionTimeoutField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public VideoEncoding Encoding
        {
            get { return this.encodingField; }
            set { this.encodingField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public VideoResolution Resolution
        {
            get { return this.resolutionField; }
            set { this.resolutionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public float Quality
        {
            get { return this.qualityField; }
            set { this.qualityField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public VideoRateControl RateControl
        {
            get { return this.rateControlField; }
            set { this.rateControlField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public Mpeg4Configuration MPEG4
        {
            get { return this.mPEG4Field; }
            set { this.mPEG4Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public H264Configuration H264
        {
            get { return this.h264Field; }
            set { this.h264Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public MulticastConfiguration Multicast
        {
            get { return this.multicastField; }
            set { this.multicastField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 7)]
        public string SessionTimeout
        {
            get { return this.sessionTimeoutField; }
            set { this.sessionTimeoutField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 8)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum VideoEncoding
    {
        /// <remarks/>
        JPEG,

        /// <remarks/>
        MPEG4,

        /// <remarks/>
        H264,
        H265, //Supported huawei ipc
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoRateControl
    {
        private int bitrateLimitField;

        private int encodingIntervalField;
        private int frameRateLimitField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int FrameRateLimit
        {
            get { return this.frameRateLimitField; }
            set { this.frameRateLimitField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int EncodingInterval
        {
            get { return this.encodingIntervalField; }
            set { this.encodingIntervalField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int BitrateLimit
        {
            get { return this.bitrateLimitField; }
            set { this.bitrateLimitField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Mpeg4Configuration
    {
        private int govLengthField;

        private Mpeg4Profile mpeg4ProfileField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int GovLength
        {
            get { return this.govLengthField; }
            set { this.govLengthField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Mpeg4Profile Mpeg4Profile
        {
            get { return this.mpeg4ProfileField; }
            set { this.mpeg4ProfileField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class H264Configuration
    {
        private int govLengthField;

        private H264Profile h264ProfileField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int GovLength
        {
            get { return this.govLengthField; }
            set { this.govLengthField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public H264Profile H264Profile
        {
            get { return this.h264ProfileField; }
            set { this.h264ProfileField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MetadataInput
    {
        private MetadataInputExtension extensionField;
        private Config[] metadataConfigField;

        /// <remarks/>
        [XmlElement("MetadataConfig", Order = 0)]
        public Config[] MetadataConfig
        {
            get { return this.metadataConfigField; }
            set { this.metadataConfigField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public MetadataInputExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MetadataInputExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsEngine : ConfigurationEntity
    {
        private AnalyticsDeviceEngineConfiguration analyticsEngineConfigurationField;

        private XElement[] anyField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AnalyticsDeviceEngineConfiguration AnalyticsEngineConfiguration
        {
            get { return this.analyticsEngineConfigurationField; }
            set { this.analyticsEngineConfigurationField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsDeviceEngineConfiguration
    {
        private EngineConfiguration[] engineConfigurationField;

        private AnalyticsDeviceEngineConfigurationExtension extensionField;

        /// <remarks/>
        [XmlElement("EngineConfiguration", Order = 0)]
        public EngineConfiguration[] EngineConfiguration
        {
            get { return this.engineConfigurationField; }
            set { this.engineConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public AnalyticsDeviceEngineConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class EngineConfiguration
    {
        private AnalyticsEngineInputInfo analyticsEngineInputInfoField;

        private XElement[] anyField;
        private VideoAnalyticsConfiguration videoAnalyticsConfigurationField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public VideoAnalyticsConfiguration VideoAnalyticsConfiguration
        {
            get { return this.videoAnalyticsConfigurationField; }
            set { this.videoAnalyticsConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public AnalyticsEngineInputInfo AnalyticsEngineInputInfo
        {
            get { return this.analyticsEngineInputInfoField; }
            set { this.analyticsEngineInputInfoField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoAnalyticsConfiguration : ConfigurationEntity
    {
        private AnalyticsEngineConfiguration analyticsEngineConfigurationField;

        private XElement[] anyField;

        private RuleEngineConfiguration ruleEngineConfigurationField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AnalyticsEngineConfiguration AnalyticsEngineConfiguration
        {
            get { return this.analyticsEngineConfigurationField; }
            set { this.analyticsEngineConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public RuleEngineConfiguration RuleEngineConfiguration
        {
            get { return this.ruleEngineConfigurationField; }
            set { this.ruleEngineConfigurationField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsEngineConfiguration
    {
        private Config[] analyticsModuleField;

        private AnalyticsEngineConfigurationExtension extensionField;

        /// <remarks/>
        [XmlElement("AnalyticsModule", Order = 0)]
        public Config[] AnalyticsModule
        {
            get { return this.analyticsModuleField; }
            set { this.analyticsModuleField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public AnalyticsEngineConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsEngineConfigurationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RuleEngineConfiguration
    {
        private RuleEngineConfigurationExtension extensionField;
        private Config[] ruleField;

        /// <remarks/>
        [XmlElement("Rule", Order = 0)]
        public Config[] Rule
        {
            get { return this.ruleField; }
            set { this.ruleField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public RuleEngineConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RuleEngineConfigurationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsEngineInputInfo
    {
        private AnalyticsEngineInputInfoExtension extensionField;
        private Config inputInfoField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public Config InputInfo
        {
            get { return this.inputInfoField; }
            set { this.inputInfoField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public AnalyticsEngineInputInfoExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsEngineInputInfoExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AnalyticsDeviceEngineConfigurationExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZConfiguration : ConfigurationEntity
    {
        private string defaultAbsolutePantTiltPositionSpaceField;

        private string defaultAbsoluteZoomPositionSpaceField;

        private string defaultContinuousPanTiltVelocitySpaceField;

        private string defaultContinuousZoomVelocitySpaceField;

        private PTZSpeed defaultPTZSpeedField;

        private string defaultPTZTimeoutField;

        private string defaultRelativePanTiltTranslationSpaceField;

        private string defaultRelativeZoomTranslationSpaceField;

        private PTZConfigurationExtension extensionField;

        private int moveRampField;

        private bool moveRampFieldSpecified;
        private string nodeTokenField;

        private PanTiltLimits panTiltLimitsField;

        private int presetRampField;

        private bool presetRampFieldSpecified;

        private int presetTourRampField;

        private bool presetTourRampFieldSpecified;

        private ZoomLimits zoomLimitsField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string NodeToken
        {
            get { return this.nodeTokenField; }
            set { this.nodeTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 1)]
        public string DefaultAbsolutePantTiltPositionSpace
        {
            get { return this.defaultAbsolutePantTiltPositionSpaceField; }
            set { this.defaultAbsolutePantTiltPositionSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 2)]
        public string DefaultAbsoluteZoomPositionSpace
        {
            get { return this.defaultAbsoluteZoomPositionSpaceField; }
            set { this.defaultAbsoluteZoomPositionSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 3)]
        public string DefaultRelativePanTiltTranslationSpace
        {
            get { return this.defaultRelativePanTiltTranslationSpaceField; }
            set { this.defaultRelativePanTiltTranslationSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 4)]
        public string DefaultRelativeZoomTranslationSpace
        {
            get { return this.defaultRelativeZoomTranslationSpaceField; }
            set { this.defaultRelativeZoomTranslationSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 5)]
        public string DefaultContinuousPanTiltVelocitySpace
        {
            get { return this.defaultContinuousPanTiltVelocitySpaceField; }
            set { this.defaultContinuousPanTiltVelocitySpaceField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 6)]
        public string DefaultContinuousZoomVelocitySpace
        {
            get { return this.defaultContinuousZoomVelocitySpaceField; }
            set { this.defaultContinuousZoomVelocitySpaceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public PTZSpeed DefaultPTZSpeed
        {
            get { return this.defaultPTZSpeedField; }
            set { this.defaultPTZSpeedField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 8)]
        public string DefaultPTZTimeout
        {
            get { return this.defaultPTZTimeoutField; }
            set { this.defaultPTZTimeoutField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public PanTiltLimits PanTiltLimits
        {
            get { return this.panTiltLimitsField; }
            set { this.panTiltLimitsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public ZoomLimits ZoomLimits
        {
            get { return this.zoomLimitsField; }
            set { this.zoomLimitsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public PTZConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int MoveRamp
        {
            get { return this.moveRampField; }
            set { this.moveRampField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MoveRampSpecified
        {
            get { return this.moveRampFieldSpecified; }
            set { this.moveRampFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int PresetRamp
        {
            get { return this.presetRampField; }
            set { this.presetRampField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool PresetRampSpecified
        {
            get { return this.presetRampFieldSpecified; }
            set { this.presetRampFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int PresetTourRamp
        {
            get { return this.presetTourRampField; }
            set { this.presetTourRampField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool PresetTourRampSpecified
        {
            get { return this.presetTourRampFieldSpecified; }
            set { this.presetTourRampFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZSpeed
    {
        private Vector2D panTiltField;

        private Vector1D zoomField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public Vector2D PanTilt
        {
            get { return this.panTiltField; }
            set { this.panTiltField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Vector1D Zoom
        {
            get { return this.zoomField; }
            set { this.zoomField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Vector2D
    {
        private string spaceField;
        private float xField;

        private float yField;

        /// <remarks/>
        [XmlAttribute()]
        public float x
        {
            get { return this.xField; }
            set { this.xField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float y
        {
            get { return this.yField; }
            set { this.yField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "anyURI")]
        public string space
        {
            get { return this.spaceField; }
            set { this.spaceField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Vector1D
    {
        private string spaceField;
        private float xField;

        /// <remarks/>
        [XmlAttribute()]
        public float x
        {
            get { return this.xField; }
            set { this.xField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "anyURI")]
        public string space
        {
            get { return this.spaceField; }
            set { this.spaceField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PanTiltLimits
    {
        private Space2DDescription rangeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public Space2DDescription Range
        {
            get { return this.rangeField; }
            set { this.rangeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ZoomLimits
    {
        private Space1DDescription rangeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public Space1DDescription Range
        {
            get { return this.rangeField; }
            set { this.rangeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZConfigurationExtension
    {
        private XElement[] anyField;

        private PTZConfigurationExtension2 extensionField;

        private PTControlDirection pTControlDirectionField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public PTControlDirection PTControlDirection
        {
            get { return this.pTControlDirectionField; }
            set { this.pTControlDirectionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public PTZConfigurationExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTControlDirection
    {
        private EFlip eFlipField;

        private PTControlDirectionExtension extensionField;

        private Reverse reverseField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public EFlip EFlip
        {
            get { return this.eFlipField; }
            set { this.eFlipField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Reverse Reverse
        {
            get { return this.reverseField; }
            set { this.reverseField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public PTControlDirectionExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class EFlip
    {
        private XElement[] anyField;
        private EFlipMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public EFlipMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum EFlipMode
    {
        /// <remarks/>
        OFF,

        /// <remarks/>
        ON,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Reverse
    {
        private XElement[] anyField;
        private ReverseMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ReverseMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum ReverseMode
    {
        /// <remarks/>
        OFF,

        /// <remarks/>
        ON,

        /// <remarks/>
        AUTO,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTControlDirectionExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZConfigurationExtension2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioDecoderConfiguration : ConfigurationEntity
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoOutputConfiguration : ConfigurationEntity
    {
        private XElement[] anyField;
        private string outputTokenField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string OutputToken
        {
            get { return this.outputTokenField; }
            set { this.outputTokenField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MetadataConfiguration : ConfigurationEntity
    {
        private AnalyticsEngineConfiguration analyticsEngineConfigurationField;

        private bool analyticsField;

        private bool analyticsFieldSpecified;

        private XElement[] anyField;

        private string compressionTypeField;

        private EventSubscription eventsField;

        private MetadataConfigurationExtension extensionField;

        private bool geoLocationField;

        private bool geoLocationFieldSpecified;

        private MulticastConfiguration multicastField;
        private PTZFilter pTZStatusField;

        private string sessionTimeoutField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public PTZFilter PTZStatus
        {
            get { return this.pTZStatusField; }
            set { this.pTZStatusField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public EventSubscription Events
        {
            get { return this.eventsField; }
            set { this.eventsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool Analytics
        {
            get { return this.analyticsField; }
            set { this.analyticsField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool AnalyticsSpecified
        {
            get { return this.analyticsFieldSpecified; }
            set { this.analyticsFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public MulticastConfiguration Multicast
        {
            get { return this.multicastField; }
            set { this.multicastField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 4)]
        public string SessionTimeout
        {
            get { return this.sessionTimeoutField; }
            set { this.sessionTimeoutField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 5)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public AnalyticsEngineConfiguration AnalyticsEngineConfiguration
        {
            get { return this.analyticsEngineConfigurationField; }
            set { this.analyticsEngineConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public MetadataConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string CompressionType
        {
            get { return this.compressionTypeField; }
            set { this.compressionTypeField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool GeoLocation
        {
            get { return this.geoLocationField; }
            set { this.geoLocationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool GeoLocationSpecified
        {
            get { return this.geoLocationFieldSpecified; }
            set { this.geoLocationFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZFilter
    {
        private bool positionField;
        private bool statusField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool Status
        {
            get { return this.statusField; }
            set { this.statusField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool Position
        {
            get { return this.positionField; }
            set { this.positionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class EventSubscription
    {
        private XElement[] anyField;
        private FilterType filterField;

        private EventSubscriptionSubscriptionPolicy subscriptionPolicyField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public FilterType Filter
        {
            get { return this.filterField; }
            set { this.filterField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public EventSubscriptionSubscriptionPolicy SubscriptionPolicy
        {
            get { return this.subscriptionPolicyField; }
            set { this.subscriptionPolicyField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [XmlInclude(typeof(EventFilter))]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://docs.oasis-open.org/wsn/b-2")]
    public partial class FilterType
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class EventFilter : FilterType
    {}

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(AnonymousType = true, Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class EventSubscriptionSubscriptionPolicy
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MetadataConfigurationExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioEncoder2Configuration : ConfigurationEntity
    {
        private XElement[] anyField;

        private int bitrateField;
        private string encodingField;

        private MulticastConfiguration multicastField;

        private int sampleRateField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Encoding
        {
            get { return this.encodingField; }
            set { this.encodingField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public MulticastConfiguration Multicast
        {
            get { return this.multicastField; }
            set { this.multicastField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int Bitrate
        {
            get { return this.bitrateField; }
            set { this.bitrateField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int SampleRate
        {
            get { return this.sampleRateField; }
            set { this.sampleRateField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 4)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioEncoderConfiguration : ConfigurationEntity
    {
        private XElement[] anyField;

        private int bitrateField;
        private AudioEncoding encodingField;

        private MulticastConfiguration multicastField;

        private int sampleRateField;

        private string sessionTimeoutField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AudioEncoding Encoding
        {
            get { return this.encodingField; }
            set { this.encodingField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Bitrate
        {
            get { return this.bitrateField; }
            set { this.bitrateField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int SampleRate
        {
            get { return this.sampleRateField; }
            set { this.sampleRateField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public MulticastConfiguration Multicast
        {
            get { return this.multicastField; }
            set { this.multicastField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 4)]
        public string SessionTimeout
        {
            get { return this.sessionTimeoutField; }
            set { this.sessionTimeoutField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 5)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AudioSourceConfiguration : ConfigurationEntity
    {
        private XElement[] anyField;
        private string sourceTokenField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string SourceToken
        {
            get { return this.sourceTokenField; }
            set { this.sourceTokenField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoEncoder2Configuration : ConfigurationEntity
    {
        private XElement[] anyField;
        private string encodingField;

        private int govLengthField;

        private bool govLengthFieldSpecified;

        private MulticastConfiguration multicastField;

        private string profileField;

        private float qualityField;

        private VideoRateControl2 rateControlField;

        private VideoResolution2 resolutionField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Encoding
        {
            get { return this.encodingField; }
            set { this.encodingField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public VideoResolution2 Resolution
        {
            get { return this.resolutionField; }
            set { this.resolutionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public VideoRateControl2 RateControl
        {
            get { return this.rateControlField; }
            set { this.rateControlField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public MulticastConfiguration Multicast
        {
            get { return this.multicastField; }
            set { this.multicastField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public float Quality
        {
            get { return this.qualityField; }
            set { this.qualityField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 5)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int GovLength
        {
            get { return this.govLengthField; }
            set { this.govLengthField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool GovLengthSpecified
        {
            get { return this.govLengthFieldSpecified; }
            set { this.govLengthFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Profile
        {
            get { return this.profileField; }
            set { this.profileField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoResolution2
    {
        private XElement[] anyField;

        private int heightField;
        private int widthField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int Width
        {
            get { return this.widthField; }
            set { this.widthField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Height
        {
            get { return this.heightField; }
            set { this.heightField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoRateControl2
    {
        private XElement[] anyField;

        private int bitrateLimitField;

        private bool constantBitRateField;

        private bool constantBitRateFieldSpecified;
        private float frameRateLimitField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public float FrameRateLimit
        {
            get { return this.frameRateLimitField; }
            set { this.frameRateLimitField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int BitrateLimit
        {
            get { return this.bitrateLimitField; }
            set { this.bitrateLimitField = value; }
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
        public bool ConstantBitRate
        {
            get { return this.constantBitRateField; }
            set { this.constantBitRateField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ConstantBitRateSpecified
        {
            get { return this.constantBitRateFieldSpecified; }
            set { this.constantBitRateFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoSourceConfiguration : ConfigurationEntity
    {
        private XElement[] anyField;

        private IntRectangle boundsField;

        private VideoSourceConfigurationExtension extensionField;
        private string sourceTokenField;

        private string viewModeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string SourceToken
        {
            get { return this.sourceTokenField; }
            set { this.sourceTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public IntRectangle Bounds
        {
            get { return this.boundsField; }
            set { this.boundsField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public VideoSourceConfigurationExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string ViewMode
        {
            get { return this.viewModeField; }
            set { this.viewModeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IntRectangle
    {
        private int heightField;

        private int widthField;
        private int xField;

        private int yField;

        /// <remarks/>
        [XmlAttribute()]
        public int x
        {
            get { return this.xField; }
            set { this.xField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int y
        {
            get { return this.yField; }
            set { this.yField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int width
        {
            get { return this.widthField; }
            set { this.widthField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int height
        {
            get { return this.heightField; }
            set { this.heightField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoSourceConfigurationExtension
    {
        private VideoSourceConfigurationExtension2 extensionField;
        private Rotate rotateField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public Rotate Rotate
        {
            get { return this.rotateField; }
            set { this.rotateField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public VideoSourceConfigurationExtension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Rotate
    {
        private int degreeField;

        private bool degreeFieldSpecified;

        private RotateExtension extensionField;
        private RotateMode modeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public RotateMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Degree
        {
            get { return this.degreeField; }
            set { this.degreeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DegreeSpecified
        {
            get { return this.degreeFieldSpecified; }
            set { this.degreeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public RotateExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RotateExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class VideoSourceConfigurationExtension2
    {
        private XElement[] anyField;
        private LensDescription[] lensDescriptionField;

        private SceneOrientation sceneOrientationField;

        /// <remarks/>
        [XmlElement("LensDescription", Order = 0)]
        public LensDescription[] LensDescription
        {
            get { return this.lensDescriptionField; }
            set { this.lensDescriptionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public SceneOrientation SceneOrientation
        {
            get { return this.sceneOrientationField; }
            set { this.sceneOrientationField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class LensDescription
    {
        private XElement[] anyField;

        private float focalLengthField;

        private bool focalLengthFieldSpecified;
        private LensOffset offsetField;

        private LensProjection[] projectionField;

        private float xFactorField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public LensOffset Offset
        {
            get { return this.offsetField; }
            set { this.offsetField = value; }
        }

        /// <remarks/>
        [XmlElement("Projection", Order = 1)]
        public LensProjection[] Projection
        {
            get { return this.projectionField; }
            set { this.projectionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public float XFactor
        {
            get { return this.xFactorField; }
            set { this.xFactorField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float FocalLength
        {
            get { return this.focalLengthField; }
            set { this.focalLengthField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool FocalLengthSpecified
        {
            get { return this.focalLengthFieldSpecified; }
            set { this.focalLengthFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class LensOffset
    {
        private float xField;

        private bool xFieldSpecified;

        private float yField;

        private bool yFieldSpecified;

        /// <remarks/>
        [XmlAttribute()]
        public float x
        {
            get { return this.xField; }
            set { this.xField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool xSpecified
        {
            get { return this.xFieldSpecified; }
            set { this.xFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public float y
        {
            get { return this.yField; }
            set { this.yField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ySpecified
        {
            get { return this.yFieldSpecified; }
            set { this.yFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class LensProjection
    {
        private float angleField;

        private XElement[] anyField;

        private float radiusField;

        private float transmittanceField;

        private bool transmittanceFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public float Angle
        {
            get { return this.angleField; }
            set { this.angleField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Radius
        {
            get { return this.radiusField; }
            set { this.radiusField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public float Transmittance
        {
            get { return this.transmittanceField; }
            set { this.transmittanceField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool TransmittanceSpecified
        {
            get { return this.transmittanceFieldSpecified; }
            set { this.transmittanceFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class SceneOrientation
    {
        private SceneOrientationMode modeField;

        private string orientationField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public SceneOrientationMode Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string Orientation
        {
            get { return this.orientationField; }
            set { this.orientationField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class Profile
    {
        private AudioEncoderConfiguration audioEncoderConfigurationField;

        private AudioSourceConfiguration audioSourceConfigurationField;

        private ProfileExtension extensionField;

        private bool fixedField;

        private bool fixedFieldSpecified;

        private MetadataConfiguration metadataConfigurationField;
        private string nameField;

        private PTZConfiguration pTZConfigurationField;

        private string tokenField;

        private VideoAnalyticsConfiguration videoAnalyticsConfigurationField;

        private VideoEncoderConfiguration videoEncoderConfigurationField;

        private VideoSourceConfiguration videoSourceConfigurationField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public VideoSourceConfiguration VideoSourceConfiguration
        {
            get { return this.videoSourceConfigurationField; }
            set { this.videoSourceConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public AudioSourceConfiguration AudioSourceConfiguration
        {
            get { return this.audioSourceConfigurationField; }
            set { this.audioSourceConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public VideoEncoderConfiguration VideoEncoderConfiguration
        {
            get { return this.videoEncoderConfigurationField; }
            set { this.videoEncoderConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public AudioEncoderConfiguration AudioEncoderConfiguration
        {
            get { return this.audioEncoderConfigurationField; }
            set { this.audioEncoderConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public VideoAnalyticsConfiguration VideoAnalyticsConfiguration
        {
            get { return this.videoAnalyticsConfigurationField; }
            set { this.videoAnalyticsConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public PTZConfiguration PTZConfiguration
        {
            get { return this.pTZConfigurationField; }
            set { this.pTZConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public MetadataConfiguration MetadataConfiguration
        {
            get { return this.metadataConfigurationField; }
            set { this.metadataConfigurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public ProfileExtension Extension
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
        public bool @fixed
        {
            get { return this.fixedField; }
            set { this.fixedField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool fixedSpecified
        {
            get { return this.fixedFieldSpecified; }
            set { this.fixedFieldSpecified = value; }
        }
    }


    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourPresetDetailOptionsExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourPresetDetailOptions
    {
        private PTZPresetTourPresetDetailOptionsExtension extensionField;

        private bool homeField;

        private bool homeFieldSpecified;

        private Space2DDescription panTiltPositionSpaceField;
        private string[] presetTokenField;

        private Space1DDescription zoomPositionSpaceField;

        /// <remarks/>
        [XmlElement("PresetToken", Order = 0)]
        public string[] PresetToken
        {
            get { return this.presetTokenField; }
            set { this.presetTokenField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool Home
        {
            get { return this.homeField; }
            set { this.homeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool HomeSpecified
        {
            get { return this.homeFieldSpecified; }
            set { this.homeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public Space2DDescription PanTiltPositionSpace
        {
            get { return this.panTiltPositionSpaceField; }
            set { this.panTiltPositionSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public Space1DDescription ZoomPositionSpace
        {
            get { return this.zoomPositionSpaceField; }
            set { this.zoomPositionSpaceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public PTZPresetTourPresetDetailOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourSpotOptions
    {
        private XElement[] anyField;
        private PTZPresetTourPresetDetailOptions presetDetailField;

        private DurationRange stayTimeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public PTZPresetTourPresetDetailOptions PresetDetail
        {
            get { return this.presetDetailField; }
            set { this.presetDetailField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public DurationRange StayTime
        {
            get { return this.stayTimeField; }
            set { this.stayTimeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DurationRange
    {
        private string maxField;
        private string minField;

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 0)]
        public string Min
        {
            get { return this.minField; }
            set { this.minField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 1)]
        public string Max
        {
            get { return this.maxField; }
            set { this.maxField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourStartingConditionOptionsExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourStartingConditionOptions
    {
        private PTZPresetTourDirection[] directionField;

        private PTZPresetTourStartingConditionOptionsExtension extensionField;

        private DurationRange recurringDurationField;
        private IntRange recurringTimeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IntRange RecurringTime
        {
            get { return this.recurringTimeField; }
            set { this.recurringTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public DurationRange RecurringDuration
        {
            get { return this.recurringDurationField; }
            set { this.recurringDurationField = value; }
        }

        /// <remarks/>
        [XmlElement("Direction", Order = 2)]
        public PTZPresetTourDirection[] Direction
        {
            get { return this.directionField; }
            set { this.directionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public PTZPresetTourStartingConditionOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum PTZPresetTourDirection
    {
        /// <remarks/>
        Forward,

        /// <remarks/>
        Backward,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourOptions
    {
        private XElement[] anyField;
        private bool autoStartField;

        private PTZPresetTourStartingConditionOptions startingConditionField;

        private PTZPresetTourSpotOptions tourSpotField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool AutoStart
        {
            get { return this.autoStartField; }
            set { this.autoStartField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public PTZPresetTourStartingConditionOptions StartingCondition
        {
            get { return this.startingConditionField; }
            set { this.startingConditionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public PTZPresetTourSpotOptions TourSpot
        {
            get { return this.tourSpotField; }
            set { this.tourSpotField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 3)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourStartingConditionExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourStartingCondition
    {
        private PTZPresetTourDirection directionField;

        private bool directionFieldSpecified;

        private PTZPresetTourStartingConditionExtension extensionField;

        private bool randomPresetOrderField;

        private bool randomPresetOrderFieldSpecified;

        private string recurringDurationField;
        private int recurringTimeField;

        private bool recurringTimeFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int RecurringTime
        {
            get { return this.recurringTimeField; }
            set { this.recurringTimeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RecurringTimeSpecified
        {
            get { return this.recurringTimeFieldSpecified; }
            set { this.recurringTimeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 1)]
        public string RecurringDuration
        {
            get { return this.recurringDurationField; }
            set { this.recurringDurationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public PTZPresetTourDirection Direction
        {
            get { return this.directionField; }
            set { this.directionField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DirectionSpecified
        {
            get { return this.directionFieldSpecified; }
            set { this.directionFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public PTZPresetTourStartingConditionExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool RandomPresetOrder
        {
            get { return this.randomPresetOrderField; }
            set { this.randomPresetOrderField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RandomPresetOrderSpecified
        {
            get { return this.randomPresetOrderFieldSpecified; }
            set { this.randomPresetOrderFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourStatusExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourSpotExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourTypeExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourPresetDetail
    {
        private XElement[] anyField;
        private object itemField;

        /// <remarks/>
        [XmlElement("Home", typeof(bool), Order = 0)]
        [XmlElement("PTZPosition", typeof(PTZVector), Order = 0)]
        [XmlElement("PresetToken", typeof(string), Order = 0)]
        [XmlElement("TypeExtension", typeof(PTZPresetTourTypeExtension), Order = 0)]
        public object Item
        {
            get { return this.itemField; }
            set { this.itemField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZVector
    {
        private Vector2D panTiltField;

        private Vector1D zoomField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public Vector2D PanTilt
        {
            get { return this.panTiltField; }
            set { this.panTiltField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Vector1D Zoom
        {
            get { return this.zoomField; }
            set { this.zoomField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourSpot
    {
        private PTZPresetTourSpotExtension extensionField;
        private PTZPresetTourPresetDetail presetDetailField;

        private PTZSpeed speedField;

        private string stayTimeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public PTZPresetTourPresetDetail PresetDetail
        {
            get { return this.presetDetailField; }
            set { this.presetDetailField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public PTZSpeed Speed
        {
            get { return this.speedField; }
            set { this.speedField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "duration", Order = 2)]
        public string StayTime
        {
            get { return this.stayTimeField; }
            set { this.stayTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public PTZPresetTourSpotExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPresetTourStatus
    {
        private PTZPresetTourSpot currentTourSpotField;

        private PTZPresetTourStatusExtension extensionField;
        private PTZPresetTourState stateField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public PTZPresetTourState State
        {
            get { return this.stateField; }
            set { this.stateField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public PTZPresetTourSpot CurrentTourSpot
        {
            get { return this.currentTourSpotField; }
            set { this.currentTourSpotField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public PTZPresetTourStatusExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum PTZPresetTourState
    {
        /// <remarks/>
        Idle,

        /// <remarks/>
        Touring,

        /// <remarks/>
        Paused,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PresetTour
    {
        private bool autoStartField;

        private PTZPresetTourExtension extensionField;
        private string nameField;

        private PTZPresetTourStartingCondition startingConditionField;

        private PTZPresetTourStatus statusField;

        private string tokenField;

        private PTZPresetTourSpot[] tourSpotField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public PTZPresetTourStatus Status
        {
            get { return this.statusField; }
            set { this.statusField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool AutoStart
        {
            get { return this.autoStartField; }
            set { this.autoStartField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public PTZPresetTourStartingCondition StartingCondition
        {
            get { return this.startingConditionField; }
            set { this.startingConditionField = value; }
        }

        /// <remarks/>
        [XmlElement("TourSpot", Order = 4)]
        public PTZPresetTourSpot[] TourSpot
        {
            get { return this.tourSpotField; }
            set { this.tourSpotField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public PTZPresetTourExtension Extension
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
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZMoveStatus
    {
        private MoveStatus panTiltField;

        private bool panTiltFieldSpecified;

        private MoveStatus zoomField;

        private bool zoomFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public MoveStatus PanTilt
        {
            get { return this.panTiltField; }
            set { this.panTiltField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool PanTiltSpecified
        {
            get { return this.panTiltFieldSpecified; }
            set { this.panTiltFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public MoveStatus Zoom
        {
            get { return this.zoomField; }
            set { this.zoomField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool ZoomSpecified
        {
            get { return this.zoomFieldSpecified; }
            set { this.zoomFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public enum MoveStatus
    {
        /// <remarks/>
        IDLE,

        /// <remarks/>
        MOVING,

        /// <remarks/>
        UNKNOWN,
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZStatus
    {
        private XElement[] anyField;

        private string errorField;

        private PTZMoveStatus moveStatusField;
        private PTZVector positionField;

        private System.DateTime utcTimeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public PTZVector Position
        {
            get { return this.positionField; }
            set { this.positionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public PTZMoveStatus MoveStatus
        {
            get { return this.moveStatusField; }
            set { this.moveStatusField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string Error
        {
            get { return this.errorField; }
            set { this.errorField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public System.DateTime UtcTime
        {
            get { return this.utcTimeField; }
            set { this.utcTimeField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 4)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZPreset
    {
        private string nameField;

        private PTZVector pTZPositionField;

        private string tokenField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public PTZVector PTZPosition
        {
            get { return this.pTZPositionField; }
            set { this.pTZPositionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string token
        {
            get { return this.tokenField; }
            set { this.tokenField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZConfigurationOptions2
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTControlDirectionOptionsExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ReverseOptionsExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ReverseOptions
    {
        private ReverseOptionsExtension extensionField;
        private ReverseMode[] modeField;

        /// <remarks/>
        [XmlElement("Mode", Order = 0)]
        public ReverseMode[] Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ReverseOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class EFlipOptionsExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class EFlipOptions
    {
        private EFlipOptionsExtension extensionField;
        private EFlipMode[] modeField;

        /// <remarks/>
        [XmlElement("Mode", Order = 0)]
        public EFlipMode[] Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public EFlipOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTControlDirectionOptions
    {
        private EFlipOptions eFlipField;

        private PTControlDirectionOptionsExtension extensionField;

        private ReverseOptions reverseField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public EFlipOptions EFlip
        {
            get { return this.eFlipField; }
            set { this.eFlipField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ReverseOptions Reverse
        {
            get { return this.reverseField; }
            set { this.reverseField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public PTControlDirectionOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class PTZConfigurationOptions
    {
        private XElement[] anyField;

        private PTZConfigurationOptions2 extensionField;

        private PTControlDirectionOptions pTControlDirectionField;

        private int[] pTZRampsField;

        private DurationRange pTZTimeoutField;
        private PTZSpaces spacesField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public PTZSpaces Spaces
        {
            get { return this.spacesField; }
            set { this.spacesField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public DurationRange PTZTimeout
        {
            get { return this.pTZTimeoutField; }
            set { this.pTZTimeoutField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public PTControlDirectionOptions PTControlDirection
        {
            get { return this.pTControlDirectionField; }
            set { this.pTControlDirectionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public PTZConfigurationOptions2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int[] PTZRamps
        {
            get { return this.pTZRampsField; }
            set { this.pTZRampsField = value; }
        }
    }


    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingStatus20Extension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class FocusStatus20Extension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class FocusStatus20
    {
        private string errorField;

        private FocusStatus20Extension extensionField;

        private MoveStatus moveStatusField;
        private float positionField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public float Position
        {
            get { return this.positionField; }
            set { this.positionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public MoveStatus MoveStatus
        {
            get { return this.moveStatusField; }
            set { this.moveStatusField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string Error
        {
            get { return this.errorField; }
            set { this.errorField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public FocusStatus20Extension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingStatus20
    {
        private ImagingStatus20Extension extensionField;
        private FocusStatus20 focusStatus20Field;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public FocusStatus20 FocusStatus20
        {
            get { return this.focusStatus20Field; }
            set { this.focusStatus20Field = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ImagingStatus20Extension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ContinuousFocusOptions
    {
        private FloatRange speedField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public FloatRange Speed
        {
            get { return this.speedField; }
            set { this.speedField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RelativeFocusOptions20
    {
        private FloatRange distanceField;

        private FloatRange speedField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public FloatRange Distance
        {
            get { return this.distanceField; }
            set { this.distanceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange Speed
        {
            get { return this.speedField; }
            set { this.speedField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AbsoluteFocusOptions
    {
        private FloatRange positionField;

        private FloatRange speedField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public FloatRange Position
        {
            get { return this.positionField; }
            set { this.positionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange Speed
        {
            get { return this.speedField; }
            set { this.speedField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class MoveOptions20
    {
        private AbsoluteFocusOptions absoluteField;

        private ContinuousFocusOptions continuousField;

        private RelativeFocusOptions20 relativeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AbsoluteFocusOptions Absolute
        {
            get { return this.absoluteField; }
            set { this.absoluteField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public RelativeFocusOptions20 Relative
        {
            get { return this.relativeField; }
            set { this.relativeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ContinuousFocusOptions Continuous
        {
            get { return this.continuousField; }
            set { this.continuousField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ContinuousFocus
    {
        private float speedField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public float Speed
        {
            get { return this.speedField; }
            set { this.speedField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class RelativeFocus
    {
        private float distanceField;

        private float speedField;

        private bool speedFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public float Distance
        {
            get { return this.distanceField; }
            set { this.distanceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Speed
        {
            get { return this.speedField; }
            set { this.speedField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool SpeedSpecified
        {
            get { return this.speedFieldSpecified; }
            set { this.speedFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class AbsoluteFocus
    {
        private float positionField;

        private float speedField;

        private bool speedFieldSpecified;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public float Position
        {
            get { return this.positionField; }
            set { this.positionField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public float Speed
        {
            get { return this.speedField; }
            set { this.speedField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool SpeedSpecified
        {
            get { return this.speedFieldSpecified; }
            set { this.speedFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class FocusMove
    {
        private AbsoluteFocus absoluteField;

        private ContinuousFocus continuousField;

        private RelativeFocus relativeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public AbsoluteFocus Absolute
        {
            get { return this.absoluteField; }
            set { this.absoluteField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public RelativeFocus Relative
        {
            get { return this.relativeField; }
            set { this.relativeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ContinuousFocus Continuous
        {
            get { return this.continuousField; }
            set { this.continuousField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingOptions20Extension4
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class NoiseReductionOptions
    {
        private XElement[] anyField;
        private bool levelField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 1)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class DefoggingOptions
    {
        private XElement[] anyField;

        private bool levelField;
        private string[] modeField;

        /// <remarks/>
        [XmlElement("Mode", Order = 0)]
        public string[] Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ToneCompensationOptions
    {
        private XElement[] anyField;

        private bool levelField;
        private string[] modeField;

        /// <remarks/>
        [XmlElement("Mode", Order = 0)]
        public string[] Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }

        /// <remarks/>
        [XmlAnyElement(Order = 2)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingOptions20Extension3
    {
        private DefoggingOptions defoggingOptionsField;

        private ImagingOptions20Extension4 extensionField;

        private NoiseReductionOptions noiseReductionOptionsField;
        private ToneCompensationOptions toneCompensationOptionsField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public ToneCompensationOptions ToneCompensationOptions
        {
            get { return this.toneCompensationOptionsField; }
            set { this.toneCompensationOptionsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public DefoggingOptions DefoggingOptions
        {
            get { return this.defoggingOptionsField; }
            set { this.defoggingOptionsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public NoiseReductionOptions NoiseReductionOptions
        {
            get { return this.noiseReductionOptionsField; }
            set { this.noiseReductionOptionsField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public ImagingOptions20Extension4 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IrCutFilterAutoAdjustmentOptionsExtension
    {
        private XElement[] anyField;

        /// <remarks/>
        [XmlAnyElement(Namespace = "http://www.onvif.org/ver10/schema", Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class IrCutFilterAutoAdjustmentOptions
    {
        private bool boundaryOffsetField;

        private bool boundaryOffsetFieldSpecified;
        private string[] boundaryTypeField;

        private IrCutFilterAutoAdjustmentOptionsExtension extensionField;

        private DurationRange responseTimeRangeField;

        /// <remarks/>
        [XmlElement("BoundaryType", Order = 0)]
        public string[] BoundaryType
        {
            get { return this.boundaryTypeField; }
            set { this.boundaryTypeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool BoundaryOffset
        {
            get { return this.boundaryOffsetField; }
            set { this.boundaryOffsetField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool BoundaryOffsetSpecified
        {
            get { return this.boundaryOffsetFieldSpecified; }
            set { this.boundaryOffsetFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public DurationRange ResponseTimeRange
        {
            get { return this.responseTimeRangeField; }
            set { this.responseTimeRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public IrCutFilterAutoAdjustmentOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingOptions20Extension2
    {
        private ImagingOptions20Extension3 extensionField;
        private IrCutFilterAutoAdjustmentOptions irCutFilterAutoAdjustmentField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IrCutFilterAutoAdjustmentOptions IrCutFilterAutoAdjustment
        {
            get { return this.irCutFilterAutoAdjustmentField; }
            set { this.irCutFilterAutoAdjustmentField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ImagingOptions20Extension3 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImageStabilizationOptionsExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImageStabilizationOptions
    {
        private ImageStabilizationOptionsExtension extensionField;

        private FloatRange levelField;
        private ImageStabilizationMode[] modeField;

        /// <remarks/>
        [XmlElement("Mode", Order = 0)]
        public ImageStabilizationMode[] Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ImageStabilizationOptionsExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingOptions20Extension
    {
        private XElement[] anyField;

        private ImagingOptions20Extension2 extensionField;

        private ImageStabilizationOptions imageStabilizationField;

        /// <remarks/>
        [XmlAnyElement(Order = 0)]
        public XElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ImageStabilizationOptions ImageStabilization
        {
            get { return this.imageStabilizationField; }
            set { this.imageStabilizationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ImagingOptions20Extension2 Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class WhiteBalanceOptions20Extension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class WhiteBalanceOptions20
    {
        private WhiteBalanceOptions20Extension extensionField;
        private WhiteBalanceMode[] modeField;

        private FloatRange ybGainField;

        private FloatRange yrGainField;

        /// <remarks/>
        [XmlElement("Mode", Order = 0)]
        public WhiteBalanceMode[] Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange YrGain
        {
            get { return this.yrGainField; }
            set { this.yrGainField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public FloatRange YbGain
        {
            get { return this.ybGainField; }
            set { this.ybGainField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public WhiteBalanceOptions20Extension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class WideDynamicRangeOptions20
    {
        private FloatRange levelField;
        private WideDynamicMode[] modeField;

        /// <remarks/>
        [XmlElement("Mode", Order = 0)]
        public WideDynamicMode[] Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class FocusOptions20Extension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class FocusOptions20
    {
        private AutoFocusMode[] autoFocusModesField;

        private FloatRange defaultSpeedField;

        private FocusOptions20Extension extensionField;

        private FloatRange farLimitField;

        private FloatRange nearLimitField;

        /// <remarks/>
        [XmlElement("AutoFocusModes", Order = 0)]
        public AutoFocusMode[] AutoFocusModes
        {
            get { return this.autoFocusModesField; }
            set { this.autoFocusModesField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange DefaultSpeed
        {
            get { return this.defaultSpeedField; }
            set { this.defaultSpeedField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public FloatRange NearLimit
        {
            get { return this.nearLimitField; }
            set { this.nearLimitField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public FloatRange FarLimit
        {
            get { return this.farLimitField; }
            set { this.farLimitField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public FocusOptions20Extension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ExposureOptions20
    {
        private FloatRange exposureTimeField;

        private FloatRange gainField;

        private FloatRange irisField;

        private FloatRange maxExposureTimeField;

        private FloatRange maxGainField;

        private FloatRange maxIrisField;

        private FloatRange minExposureTimeField;

        private FloatRange minGainField;

        private FloatRange minIrisField;
        private ExposureMode[] modeField;

        private ExposurePriority[] priorityField;

        /// <remarks/>
        [XmlElement("Mode", Order = 0)]
        public ExposureMode[] Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement("Priority", Order = 1)]
        public ExposurePriority[] Priority
        {
            get { return this.priorityField; }
            set { this.priorityField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public FloatRange MinExposureTime
        {
            get { return this.minExposureTimeField; }
            set { this.minExposureTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public FloatRange MaxExposureTime
        {
            get { return this.maxExposureTimeField; }
            set { this.maxExposureTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public FloatRange MinGain
        {
            get { return this.minGainField; }
            set { this.minGainField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public FloatRange MaxGain
        {
            get { return this.maxGainField; }
            set { this.maxGainField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public FloatRange MinIris
        {
            get { return this.minIrisField; }
            set { this.minIrisField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public FloatRange MaxIris
        {
            get { return this.maxIrisField; }
            set { this.maxIrisField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public FloatRange ExposureTime
        {
            get { return this.exposureTimeField; }
            set { this.exposureTimeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public FloatRange Gain
        {
            get { return this.gainField; }
            set { this.gainField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public FloatRange Iris
        {
            get { return this.irisField; }
            set { this.irisField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class BacklightCompensationOptions20
    {
        private FloatRange levelField;
        private BacklightCompensationMode[] modeField;

        /// <remarks/>
        [XmlElement("Mode", Order = 0)]
        public BacklightCompensationMode[] Mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange Level
        {
            get { return this.levelField; }
            set { this.levelField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
    public partial class ImagingOptions20
    {
        private BacklightCompensationOptions20 backlightCompensationField;

        private FloatRange brightnessField;

        private FloatRange colorSaturationField;

        private FloatRange contrastField;

        private ExposureOptions20 exposureField;

        private ImagingOptions20Extension extensionField;

        private FocusOptions20 focusField;

        private IrCutFilterMode[] irCutFilterModesField;

        private FloatRange sharpnessField;

        private WhiteBalanceOptions20 whiteBalanceField;

        private WideDynamicRangeOptions20 wideDynamicRangeField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public BacklightCompensationOptions20 BacklightCompensation
        {
            get { return this.backlightCompensationField; }
            set { this.backlightCompensationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public FloatRange Brightness
        {
            get { return this.brightnessField; }
            set { this.brightnessField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public FloatRange ColorSaturation
        {
            get { return this.colorSaturationField; }
            set { this.colorSaturationField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public FloatRange Contrast
        {
            get { return this.contrastField; }
            set { this.contrastField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public ExposureOptions20 Exposure
        {
            get { return this.exposureField; }
            set { this.exposureField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public FocusOptions20 Focus
        {
            get { return this.focusField; }
            set { this.focusField = value; }
        }

        /// <remarks/>
        [XmlElement("IrCutFilterModes", Order = 6)]
        public IrCutFilterMode[] IrCutFilterModes
        {
            get { return this.irCutFilterModesField; }
            set { this.irCutFilterModesField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public FloatRange Sharpness
        {
            get { return this.sharpnessField; }
            set { this.sharpnessField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public WideDynamicRangeOptions20 WideDynamicRange
        {
            get { return this.wideDynamicRangeField; }
            set { this.wideDynamicRangeField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public WhiteBalanceOptions20 WhiteBalance
        {
            get { return this.whiteBalanceField; }
            set { this.whiteBalanceField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public ImagingOptions20Extension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }
}
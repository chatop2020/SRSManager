using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;
using Mictlanix.DotNet.Onvif.Common;

namespace Mictlanix.DotNet.Onvif.Device
{
    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class Service
    {
        private XElement[] anyField;

        private XElement capabilitiesField;
        private string namespaceField;

        private OnvifVersion versionField;

        private string xAddrField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string Namespace
        {
            get { return this.namespaceField; }
            set { this.namespaceField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 1)]
        public string XAddr
        {
            get { return this.xAddrField; }
            set { this.xAddrField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public XElement Capabilities
        {
            get { return this.capabilitiesField; }
            set { this.capabilitiesField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OnvifVersion Version
        {
            get { return this.versionField; }
            set { this.versionField = value; }
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class UserCredential
    {
        private UserCredentialExtension extensionField;

        private string passwordField;
        private string userNameField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string UserName
        {
            get { return this.userNameField; }
            set { this.userNameField = value; }
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
        public UserCredentialExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(AnonymousType = true,
        Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class UserCredentialExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class StorageConfigurationData
    {
        private StorageConfigurationDataExtension extensionField;
        private string localPathField;

        private string storageUriField;

        private string typeField;

        private UserCredential userField;

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 0)]
        public string LocalPath
        {
            get { return this.localPathField; }
            set { this.localPathField = value; }
        }

        /// <remarks/>
        [XmlElement(DataType = "anyURI", Order = 1)]
        public string StorageUri
        {
            get { return this.storageUriField; }
            set { this.storageUriField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public UserCredential User
        {
            get { return this.userField; }
            set { this.userField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public StorageConfigurationDataExtension Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(AnonymousType = true,
        Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class StorageConfigurationDataExtension
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
    [XmlType(Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class StorageConfiguration : DeviceEntity
    {
        private StorageConfigurationData dataField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public StorageConfigurationData Data
        {
            get { return this.dataField; }
            set { this.dataField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class MiscCapabilities
    {
        private string[] auxiliaryCommandsField;

        /// <remarks/>
        [XmlAttribute()]
        public string[] AuxiliaryCommands
        {
            get { return this.auxiliaryCommandsField; }
            set { this.auxiliaryCommandsField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class SystemCapabilities
    {
        private string[] autoGeoField;

        private bool discoveryByeField;

        private bool discoveryByeFieldSpecified;
        private bool discoveryResolveField;

        private bool discoveryResolveFieldSpecified;

        private bool firmwareUpgradeField;

        private bool firmwareUpgradeFieldSpecified;

        private int geoLocationEntriesField;

        private bool geoLocationEntriesFieldSpecified;

        private bool httpFirmwareUpgradeField;

        private bool httpFirmwareUpgradeFieldSpecified;

        private bool httpSupportInformationField;

        private bool httpSupportInformationFieldSpecified;

        private bool httpSystemBackupField;

        private bool httpSystemBackupFieldSpecified;

        private bool httpSystemLoggingField;

        private bool httpSystemLoggingFieldSpecified;

        private int maxStorageConfigurationsField;

        private bool maxStorageConfigurationsFieldSpecified;

        private bool remoteDiscoveryField;

        private bool remoteDiscoveryFieldSpecified;

        private bool storageConfigurationField;

        private bool storageConfigurationFieldSpecified;

        private string[] storageTypesSupportedField;

        private bool systemBackupField;

        private bool systemBackupFieldSpecified;

        private bool systemLoggingField;

        private bool systemLoggingFieldSpecified;

        /// <remarks/>
        [XmlAttribute()]
        public bool DiscoveryResolve
        {
            get { return this.discoveryResolveField; }
            set { this.discoveryResolveField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DiscoveryResolveSpecified
        {
            get { return this.discoveryResolveFieldSpecified; }
            set { this.discoveryResolveFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool DiscoveryBye
        {
            get { return this.discoveryByeField; }
            set { this.discoveryByeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DiscoveryByeSpecified
        {
            get { return this.discoveryByeFieldSpecified; }
            set { this.discoveryByeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool RemoteDiscovery
        {
            get { return this.remoteDiscoveryField; }
            set { this.remoteDiscoveryField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RemoteDiscoverySpecified
        {
            get { return this.remoteDiscoveryFieldSpecified; }
            set { this.remoteDiscoveryFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool SystemBackup
        {
            get { return this.systemBackupField; }
            set { this.systemBackupField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool SystemBackupSpecified
        {
            get { return this.systemBackupFieldSpecified; }
            set { this.systemBackupFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool SystemLogging
        {
            get { return this.systemLoggingField; }
            set { this.systemLoggingField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool SystemLoggingSpecified
        {
            get { return this.systemLoggingFieldSpecified; }
            set { this.systemLoggingFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool FirmwareUpgrade
        {
            get { return this.firmwareUpgradeField; }
            set { this.firmwareUpgradeField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool FirmwareUpgradeSpecified
        {
            get { return this.firmwareUpgradeFieldSpecified; }
            set { this.firmwareUpgradeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
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
        [XmlAttribute()]
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
        [XmlAttribute()]
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
        [XmlAttribute()]
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
        [XmlAttribute()]
        public bool StorageConfiguration
        {
            get { return this.storageConfigurationField; }
            set { this.storageConfigurationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool StorageConfigurationSpecified
        {
            get { return this.storageConfigurationFieldSpecified; }
            set { this.storageConfigurationFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int MaxStorageConfigurations
        {
            get { return this.maxStorageConfigurationsField; }
            set { this.maxStorageConfigurationsField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxStorageConfigurationsSpecified
        {
            get { return this.maxStorageConfigurationsFieldSpecified; }
            set { this.maxStorageConfigurationsFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int GeoLocationEntries
        {
            get { return this.geoLocationEntriesField; }
            set { this.geoLocationEntriesField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool GeoLocationEntriesSpecified
        {
            get { return this.geoLocationEntriesFieldSpecified; }
            set { this.geoLocationEntriesFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string[] AutoGeo
        {
            get { return this.autoGeoField; }
            set { this.autoGeoField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string[] StorageTypesSupported
        {
            get { return this.storageTypesSupportedField; }
            set { this.storageTypesSupportedField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class SecurityCapabilities
    {
        private bool accessPolicyConfigField;

        private bool accessPolicyConfigFieldSpecified;

        private bool defaultAccessPolicyField;

        private bool defaultAccessPolicyFieldSpecified;

        private bool dot1XField;

        private bool dot1XFieldSpecified;

        private bool httpDigestField;

        private bool httpDigestFieldSpecified;

        private bool kerberosTokenField;

        private bool kerberosTokenFieldSpecified;

        private int maxPasswordLengthField;

        private bool maxPasswordLengthFieldSpecified;

        private int maxUserNameLengthField;

        private bool maxUserNameLengthFieldSpecified;

        private int maxUsersField;

        private bool maxUsersFieldSpecified;

        private bool onboardKeyGenerationField;

        private bool onboardKeyGenerationFieldSpecified;

        private bool rELTokenField;

        private bool rELTokenFieldSpecified;

        private bool remoteUserHandlingField;

        private bool remoteUserHandlingFieldSpecified;

        private bool sAMLTokenField;

        private bool sAMLTokenFieldSpecified;

        private int[] supportedEAPMethodsField;
        private bool tLS10Field;

        private bool tLS10FieldSpecified;

        private bool tLS11Field;

        private bool tLS11FieldSpecified;

        private bool tLS12Field;

        private bool tLS12FieldSpecified;

        private bool usernameTokenField;

        private bool usernameTokenFieldSpecified;

        private bool x509TokenField;

        private bool x509TokenFieldSpecified;

        /// <remarks/>
        [XmlAttribute("TLS1.0")]
        public bool TLS10
        {
            get { return this.tLS10Field; }
            set { this.tLS10Field = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool TLS10Specified
        {
            get { return this.tLS10FieldSpecified; }
            set { this.tLS10FieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute("TLS1.1")]
        public bool TLS11
        {
            get { return this.tLS11Field; }
            set { this.tLS11Field = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool TLS11Specified
        {
            get { return this.tLS11FieldSpecified; }
            set { this.tLS11FieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute("TLS1.2")]
        public bool TLS12
        {
            get { return this.tLS12Field; }
            set { this.tLS12Field = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool TLS12Specified
        {
            get { return this.tLS12FieldSpecified; }
            set { this.tLS12FieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool OnboardKeyGeneration
        {
            get { return this.onboardKeyGenerationField; }
            set { this.onboardKeyGenerationField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool OnboardKeyGenerationSpecified
        {
            get { return this.onboardKeyGenerationFieldSpecified; }
            set { this.onboardKeyGenerationFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool AccessPolicyConfig
        {
            get { return this.accessPolicyConfigField; }
            set { this.accessPolicyConfigField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool AccessPolicyConfigSpecified
        {
            get { return this.accessPolicyConfigFieldSpecified; }
            set { this.accessPolicyConfigFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool DefaultAccessPolicy
        {
            get { return this.defaultAccessPolicyField; }
            set { this.defaultAccessPolicyField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DefaultAccessPolicySpecified
        {
            get { return this.defaultAccessPolicyFieldSpecified; }
            set { this.defaultAccessPolicyFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool Dot1X
        {
            get { return this.dot1XField; }
            set { this.dot1XField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool Dot1XSpecified
        {
            get { return this.dot1XFieldSpecified; }
            set { this.dot1XFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool RemoteUserHandling
        {
            get { return this.remoteUserHandlingField; }
            set { this.remoteUserHandlingField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RemoteUserHandlingSpecified
        {
            get { return this.remoteUserHandlingFieldSpecified; }
            set { this.remoteUserHandlingFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute("X.509Token")]
        public bool X509Token
        {
            get { return this.x509TokenField; }
            set { this.x509TokenField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool X509TokenSpecified
        {
            get { return this.x509TokenFieldSpecified; }
            set { this.x509TokenFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool SAMLToken
        {
            get { return this.sAMLTokenField; }
            set { this.sAMLTokenField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool SAMLTokenSpecified
        {
            get { return this.sAMLTokenFieldSpecified; }
            set { this.sAMLTokenFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool KerberosToken
        {
            get { return this.kerberosTokenField; }
            set { this.kerberosTokenField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool KerberosTokenSpecified
        {
            get { return this.kerberosTokenFieldSpecified; }
            set { this.kerberosTokenFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool UsernameToken
        {
            get { return this.usernameTokenField; }
            set { this.usernameTokenField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool UsernameTokenSpecified
        {
            get { return this.usernameTokenFieldSpecified; }
            set { this.usernameTokenFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool HttpDigest
        {
            get { return this.httpDigestField; }
            set { this.httpDigestField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool HttpDigestSpecified
        {
            get { return this.httpDigestFieldSpecified; }
            set { this.httpDigestFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool RELToken
        {
            get { return this.rELTokenField; }
            set { this.rELTokenField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool RELTokenSpecified
        {
            get { return this.rELTokenFieldSpecified; }
            set { this.rELTokenFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int[] SupportedEAPMethods
        {
            get { return this.supportedEAPMethodsField; }
            set { this.supportedEAPMethodsField = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int MaxUsers
        {
            get { return this.maxUsersField; }
            set { this.maxUsersField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxUsersSpecified
        {
            get { return this.maxUsersFieldSpecified; }
            set { this.maxUsersFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int MaxUserNameLength
        {
            get { return this.maxUserNameLengthField; }
            set { this.maxUserNameLengthField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxUserNameLengthSpecified
        {
            get { return this.maxUserNameLengthFieldSpecified; }
            set { this.maxUserNameLengthFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int MaxPasswordLength
        {
            get { return this.maxPasswordLengthField; }
            set { this.maxPasswordLengthField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxPasswordLengthSpecified
        {
            get { return this.maxPasswordLengthFieldSpecified; }
            set { this.maxPasswordLengthFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class NetworkCapabilities
    {
        private bool dHCPv6Field;

        private bool dHCPv6FieldSpecified;

        private bool dot11ConfigurationField;

        private bool dot11ConfigurationFieldSpecified;

        private int dot1XConfigurationsField;

        private bool dot1XConfigurationsFieldSpecified;

        private bool dynDNSField;

        private bool dynDNSFieldSpecified;

        private bool hostnameFromDHCPField;

        private bool hostnameFromDHCPFieldSpecified;
        private bool iPFilterField;

        private bool iPFilterFieldSpecified;

        private bool iPVersion6Field;

        private bool iPVersion6FieldSpecified;

        private int nTPField;

        private bool nTPFieldSpecified;

        private bool zeroConfigurationField;

        private bool zeroConfigurationFieldSpecified;

        /// <remarks/>
        [XmlAttribute()]
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
        [XmlAttribute()]
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
        [XmlAttribute()]
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
        [XmlAttribute()]
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
        [XmlAttribute()]
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
        [XmlAttribute()]
        public int Dot1XConfigurations
        {
            get { return this.dot1XConfigurationsField; }
            set { this.dot1XConfigurationsField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool Dot1XConfigurationsSpecified
        {
            get { return this.dot1XConfigurationsFieldSpecified; }
            set { this.dot1XConfigurationsFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool HostnameFromDHCP
        {
            get { return this.hostnameFromDHCPField; }
            set { this.hostnameFromDHCPField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool HostnameFromDHCPSpecified
        {
            get { return this.hostnameFromDHCPFieldSpecified; }
            set { this.hostnameFromDHCPFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public int NTP
        {
            get { return this.nTPField; }
            set { this.nTPField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool NTPSpecified
        {
            get { return this.nTPFieldSpecified; }
            set { this.nTPFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool DHCPv6
        {
            get { return this.dHCPv6Field; }
            set { this.dHCPv6Field = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool DHCPv6Specified
        {
            get { return this.dHCPv6FieldSpecified; }
            set { this.dHCPv6FieldSpecified = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class DeviceServiceCapabilities
    {
        private MiscCapabilities miscField;
        private NetworkCapabilities networkField;

        private SecurityCapabilities securityField;

        private SystemCapabilities systemField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public NetworkCapabilities Network
        {
            get { return this.networkField; }
            set { this.networkField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public SecurityCapabilities Security
        {
            get { return this.securityField; }
            set { this.securityField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public SystemCapabilities System
        {
            get { return this.systemField; }
            set { this.systemField = value; }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public MiscCapabilities Misc
        {
            get { return this.miscField; }
            set { this.miscField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [DebuggerStepThrough()]
    [XmlType(AnonymousType = true,
        Namespace = "http://www.onvif.org/ver10/device/wsdl")]
    public partial class GetSystemUrisResponseExtension
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
}
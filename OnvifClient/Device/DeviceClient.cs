using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Mictlanix.DotNet.Onvif.Common;
using DateTime = Mictlanix.DotNet.Onvif.Common.DateTime;
using TimeZone = Mictlanix.DotNet.Onvif.Common.TimeZone;

namespace Mictlanix.DotNet.Onvif.Device
{
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [ServiceContract(Namespace = "http://www.onvif.org/ver10/device/wsdl",
        ConfigurationName = "Mictlanix.DotNet.Onvif.Device.Device")]
    public interface Device
    {
        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetServices",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetServicesResponse> GetServicesAsync(
            GetServicesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetServiceCapabilities", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Capabilities")]
        Task<DeviceServiceCapabilities> GetServiceCapabilitiesAsync();

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetDeviceInformation", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetDeviceInformationResponse>
            GetDeviceInformationAsync(GetDeviceInformationRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetSystemDateAndTime", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetSystemDateAndTimeAsync(SetDateTimeType DateTimeType, bool DaylightSavings,
            TimeZone TimeZone, DateTime UTCDateTime);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetSystemDateAndTime", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "SystemDateAndTime")]
        Task<SystemDateTime> GetSystemDateAndTimeAsync();

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetSystemFactoryDefault", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetSystemFactoryDefaultAsync(FactoryDefaultType FactoryDefault);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/UpgradeSystemFirmware", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Message")]
        Task<string> UpgradeSystemFirmwareAsync(AttachmentData Firmware);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/SystemReboot",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Message")]
        Task<string> SystemRebootAsync();

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/RestoreSystem",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<RestoreSystemResponse> RestoreSystemAsync(
            RestoreSystemRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetSystemBackup", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetSystemBackupResponse> GetSystemBackupAsync(
            GetSystemBackupRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetSystemLog",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "SystemLog")]
        Task<SystemLog> GetSystemLogAsync(SystemLogType LogType);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetSystemSupportInformation", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "SupportInformation")]
        Task<SupportInformation> GetSystemSupportInformationAsync();

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetScopes",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetScopesResponse> GetScopesAsync(
            GetScopesRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/SetScopes",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetScopesResponse> SetScopesAsync(
            SetScopesRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/AddScopes",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<AddScopesResponse> AddScopesAsync(
            AddScopesRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/RemoveScopes",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<RemoveScopesResponse> RemoveScopesAsync(
            RemoveScopesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetDiscoveryMode", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "DiscoveryMode")]
        Task<DiscoveryMode> GetDiscoveryModeAsync();

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetDiscoveryMode", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetDiscoveryModeAsync(DiscoveryMode DiscoveryMode);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetRemoteDiscoveryMode", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "RemoteDiscoveryMode")]
        Task<DiscoveryMode> GetRemoteDiscoveryModeAsync();

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetRemoteDiscoveryMode", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetRemoteDiscoveryModeAsync(DiscoveryMode RemoteDiscoveryMode);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetDPAddresses", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetDPAddressesResponse> GetDPAddressesAsync(
            GetDPAddressesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetDPAddresses", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetDPAddressesResponse> SetDPAddressesAsync(
            SetDPAddressesRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetEndpointReference", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetEndpointReferenceResponse>
            GetEndpointReferenceAsync(GetEndpointReferenceRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetRemoteUser",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "RemoteUser")]
        Task<RemoteUser> GetRemoteUserAsync();

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/SetRemoteUser",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetRemoteUserAsync(RemoteUser RemoteUser);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetUsers",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetUsersResponse> GetUsersAsync(
            GetUsersRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/CreateUsers",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<CreateUsersResponse> CreateUsersAsync(
            CreateUsersRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/DeleteUsers",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<DeleteUsersResponse> DeleteUsersAsync(
            DeleteUsersRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/SetUser",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetUserResponse> SetUserAsync(
            SetUserRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetWsdlUrl",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetWsdlUrlResponse> GetWsdlUrlAsync(
            GetWsdlUrlRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetCapabilities", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCapabilitiesResponse> GetCapabilitiesAsync(
            GetCapabilitiesRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetHostname",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "HostnameInformation")]
        Task<HostnameInformation> GetHostnameAsync();

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/SetHostname",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetHostnameResponse> SetHostnameAsync(
            SetHostnameRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetHostnameFromDHCP", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "RebootNeeded")]
        Task<bool> SetHostnameFromDHCPAsync(bool FromDHCP);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetDNS",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "DNSInformation")]
        Task<DNSInformation> GetDNSAsync();

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/SetDNS",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetDNSResponse> SetDNSAsync(
            SetDNSRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetNTP",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "NTPInformation")]
        Task<NTPInformation> GetNTPAsync();

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/SetNTP",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetNTPResponse> SetNTPAsync(
            SetNTPRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetDynamicDNS",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "DynamicDNSInformation")]
        Task<DynamicDNSInformation> GetDynamicDNSAsync();

        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/SetDynamicDNS",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetDynamicDNSResponse> SetDynamicDNSAsync(
            SetDynamicDNSRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetNetworkInterfaces", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetNetworkInterfacesResponse>
            GetNetworkInterfacesAsync(GetNetworkInterfacesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetNetworkInterfaces", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "RebootNeeded")]
        Task<bool> SetNetworkInterfacesAsync(string InterfaceToken,
            NetworkInterfaceSetConfiguration NetworkInterface);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetNetworkProtocols", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetNetworkProtocolsResponse> GetNetworkProtocolsAsync(
            GetNetworkProtocolsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetNetworkProtocols", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetNetworkProtocolsResponse> SetNetworkProtocolsAsync(
            SetNetworkProtocolsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetNetworkDefaultGateway", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "NetworkGateway")]
        Task<NetworkGateway> GetNetworkDefaultGatewayAsync();

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetNetworkDefaultGateway", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetNetworkDefaultGatewayResponse>
            SetNetworkDefaultGatewayAsync(SetNetworkDefaultGatewayRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetZeroConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "ZeroConfiguration")]
        Task<NetworkZeroConfiguration> GetZeroConfigurationAsync();

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetZeroConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetZeroConfigurationAsync(string InterfaceToken, bool Enabled);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetIPAddressFilter", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "IPAddressFilter")]
        Task<IPAddressFilter> GetIPAddressFilterAsync();

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetIPAddressFilter", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetIPAddressFilterAsync(IPAddressFilter IPAddressFilter);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/AddIPAddressFilter", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AddIPAddressFilterAsync(IPAddressFilter IPAddressFilter);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/RemoveIPAddressFilter", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemoveIPAddressFilterAsync(IPAddressFilter IPAddressFilter);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetAccessPolicy", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "PolicyFile")]
        Task<BinaryData> GetAccessPolicyAsync();

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetAccessPolicy", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetAccessPolicyAsync(BinaryData PolicyFile);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/CreateCertificate", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<CreateCertificateResponse> CreateCertificateAsync(
            CreateCertificateRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetCertificates", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCertificatesResponse> GetCertificatesAsync(
            GetCertificatesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetCertificatesStatus", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCertificatesStatusResponse>
            GetCertificatesStatusAsync(GetCertificatesStatusRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetCertificatesStatus", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetCertificatesStatusResponse>
            SetCertificatesStatusAsync(SetCertificatesStatusRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/DeleteCertificates", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<DeleteCertificatesResponse> DeleteCertificatesAsync(
            DeleteCertificatesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetPkcs10Request", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetPkcs10RequestResponse> GetPkcs10RequestAsync(
            GetPkcs10RequestRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/LoadCertificates", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<LoadCertificatesResponse> LoadCertificatesAsync(
            LoadCertificatesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetClientCertificateMode", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Enabled")]
        Task<bool> GetClientCertificateModeAsync();

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetClientCertificateMode", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetClientCertificateModeAsync(bool Enabled);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetRelayOutputs", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetRelayOutputsResponse> GetRelayOutputsAsync(
            GetRelayOutputsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetRelayOutputSettings", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task
            SetRelayOutputSettingsAsync(string RelayOutputToken, RelayOutputSettings Properties);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetRelayOutputState", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetRelayOutputStateAsync(string RelayOutputToken, RelayLogicalState LogicalState);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SendAuxiliaryCommand", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "AuxiliaryCommandResponse")]
        Task<string> SendAuxiliaryCommandAsync(string AuxiliaryCommand);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetCACertificates", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCACertificatesResponse> GetCACertificatesAsync(
            GetCACertificatesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/LoadCertificateWithPrivateKey", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<LoadCertificateWithPrivateKeyResponse>
            LoadCertificateWithPrivateKeyAsync(
                LoadCertificateWithPrivateKeyRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetCertificateInformation", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCertificateInformationResponse>
            GetCertificateInformationAsync(GetCertificateInformationRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/LoadCACertificates", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<LoadCACertificatesResponse> LoadCACertificatesAsync(
            LoadCACertificatesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/CreateDot1XConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task CreateDot1XConfigurationAsync(Dot1XConfiguration Dot1XConfiguration);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetDot1XConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetDot1XConfigurationAsync(Dot1XConfiguration Dot1XConfiguration);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetDot1XConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Dot1XConfiguration")]
        Task<Dot1XConfiguration> GetDot1XConfigurationAsync(string Dot1XConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetDot1XConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetDot1XConfigurationsResponse>
            GetDot1XConfigurationsAsync(GetDot1XConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/DeleteDot1XConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<DeleteDot1XConfigurationResponse>
            DeleteDot1XConfigurationAsync(DeleteDot1XConfigurationRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetDot11Capabilities", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetDot11CapabilitiesResponse>
            GetDot11CapabilitiesAsync(GetDot11CapabilitiesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetDot11Status", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Status")]
        Task<Dot11Status> GetDot11StatusAsync(string InterfaceToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/ScanAvailableDot11Networks", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<ScanAvailableDot11NetworksResponse>
            ScanAvailableDot11NetworksAsync(ScanAvailableDot11NetworksRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(Action = "http://www.onvif.org/ver10/device/wsdl/GetSystemUris",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetSystemUrisResponse> GetSystemUrisAsync(
            GetSystemUrisRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/StartFirmwareUpgrade", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<StartFirmwareUpgradeResponse>
            StartFirmwareUpgradeAsync(StartFirmwareUpgradeRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/StartSystemRestore", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<StartSystemRestoreResponse> StartSystemRestoreAsync(
            StartSystemRestoreRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetStorageConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetStorageConfigurationsResponse>
            GetStorageConfigurationsAsync(GetStorageConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/CreateStorageConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Token")]
        Task<string> CreateStorageConfigurationAsync(
            StorageConfigurationData StorageConfiguration);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetStorageConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "StorageConfiguration")]
        Task<StorageConfiguration> GetStorageConfigurationAsync(string Token);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetStorageConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetStorageConfigurationAsync(StorageConfiguration StorageConfiguration);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/DeleteStorageConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task DeleteStorageConfigurationAsync(string Token);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/GetGeoLocation", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetGeoLocationResponse> GetGeoLocationAsync(
            GetGeoLocationRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/SetGeoLocation", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetGeoLocationResponse> SetGeoLocationAsync(
            SetGeoLocationRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/device/wsdl/DeleteGeoLocation", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<DeleteGeoLocationResponse> DeleteGeoLocationAsync(
            DeleteGeoLocationRequest request);
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetServices",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetServicesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public bool IncludeCapability;

        public GetServicesRequest()
        {
        }

        public GetServicesRequest(bool IncludeCapability)
        {
            this.IncludeCapability = IncludeCapability;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetServicesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetServicesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Service")]
        public Service[] Service;

        public GetServicesResponse()
        {
        }

        public GetServicesResponse(Service[] Service)
        {
            this.Service = Service;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetDeviceInformation",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetDeviceInformationRequest
    {
        public GetDeviceInformationRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetDeviceInformationResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetDeviceInformationResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 2)]
        public string FirmwareVersion;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 4)]
        public string HardwareId;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public string Manufacturer;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 1)]
        public string Model;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 3)]
        public string SerialNumber;

        public GetDeviceInformationResponse()
        {
        }

        public GetDeviceInformationResponse(string Manufacturer, string Model, string FirmwareVersion,
            string SerialNumber, string HardwareId)
        {
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.FirmwareVersion = FirmwareVersion;
            this.SerialNumber = SerialNumber;
            this.HardwareId = HardwareId;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "RestoreSystem",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class RestoreSystemRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("BackupFiles")]
        public BackupFile[] BackupFiles;

        public RestoreSystemRequest()
        {
        }

        public RestoreSystemRequest(BackupFile[] BackupFiles)
        {
            this.BackupFiles = BackupFiles;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "RestoreSystemResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class RestoreSystemResponse
    {
        public RestoreSystemResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetSystemBackup",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetSystemBackupRequest
    {
        public GetSystemBackupRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetSystemBackupResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetSystemBackupResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("BackupFiles")]
        public BackupFile[] BackupFiles;

        public GetSystemBackupResponse()
        {
        }

        public GetSystemBackupResponse(BackupFile[] BackupFiles)
        {
            this.BackupFiles = BackupFiles;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetScopes",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetScopesRequest
    {
        public GetScopesRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetScopesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetScopesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Scopes")]
        public Scope[] Scopes;

        public GetScopesResponse()
        {
        }

        public GetScopesResponse(Scope[] Scopes)
        {
            this.Scopes = Scopes;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetScopes",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetScopesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Scopes", DataType = "anyURI")]
        public string[] Scopes;

        public SetScopesRequest()
        {
        }

        public SetScopesRequest(string[] Scopes)
        {
            this.Scopes = Scopes;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetScopesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetScopesResponse
    {
        public SetScopesResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "AddScopes",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class AddScopesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("ScopeItem", DataType = "anyURI")]
        public string[] ScopeItem;

        public AddScopesRequest()
        {
        }

        public AddScopesRequest(string[] ScopeItem)
        {
            this.ScopeItem = ScopeItem;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "AddScopesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class AddScopesResponse
    {
        public AddScopesResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "RemoveScopes",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class RemoveScopesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("ScopeItem", DataType = "anyURI")]
        public string[] ScopeItem;

        public RemoveScopesRequest()
        {
        }

        public RemoveScopesRequest(string[] ScopeItem)
        {
            this.ScopeItem = ScopeItem;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "RemoveScopesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class RemoveScopesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("ScopeItem", DataType = "anyURI")]
        public string[] ScopeItem;

        public RemoveScopesResponse()
        {
        }

        public RemoveScopesResponse(string[] ScopeItem)
        {
            this.ScopeItem = ScopeItem;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetDPAddresses",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetDPAddressesRequest
    {
        public GetDPAddressesRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetDPAddressesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetDPAddressesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("DPAddress")]
        public NetworkHost[] DPAddress;

        public GetDPAddressesResponse()
        {
        }

        public GetDPAddressesResponse(NetworkHost[] DPAddress)
        {
            this.DPAddress = DPAddress;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetDPAddresses",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetDPAddressesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("DPAddress")]
        public NetworkHost[] DPAddress;

        public SetDPAddressesRequest()
        {
        }

        public SetDPAddressesRequest(NetworkHost[] DPAddress)
        {
            this.DPAddress = DPAddress;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetDPAddressesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetDPAddressesResponse
    {
        public SetDPAddressesResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetEndpointReference",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetEndpointReferenceRequest
    {
        public GetEndpointReferenceRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetEndpointReferenceResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetEndpointReferenceResponse
    {
        [MessageBodyMember(Namespace = "", Order = 1)]
        [XmlAnyElement()]
        public XElement[] Any;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public string GUID;

        public GetEndpointReferenceResponse()
        {
        }

        public GetEndpointReferenceResponse(string GUID, XElement[] Any)
        {
            this.GUID = GUID;
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetUsers",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetUsersRequest
    {
        public GetUsersRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetUsersResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetUsersResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("User")]
        public User[] User;

        public GetUsersResponse()
        {
        }

        public GetUsersResponse(User[] User)
        {
            this.User = User;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "CreateUsers",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class CreateUsersRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("User")]
        public User[] User;

        public CreateUsersRequest()
        {
        }

        public CreateUsersRequest(User[] User)
        {
            this.User = User;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "CreateUsersResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class CreateUsersResponse
    {
        public CreateUsersResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "DeleteUsers",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class DeleteUsersRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Username")]
        public string[] Username;

        public DeleteUsersRequest()
        {
        }

        public DeleteUsersRequest(string[] Username)
        {
            this.Username = Username;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "DeleteUsersResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class DeleteUsersResponse
    {
        public DeleteUsersResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetUser",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetUserRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("User")]
        public User[] User;

        public SetUserRequest()
        {
        }

        public SetUserRequest(User[] User)
        {
            this.User = User;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetUserResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetUserResponse
    {
        public SetUserResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetWsdlUrl",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetWsdlUrlRequest
    {
        public GetWsdlUrlRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetWsdlUrlResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetWsdlUrlResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement(DataType = "anyURI")]
        public string WsdlUrl;

        public GetWsdlUrlResponse()
        {
        }

        public GetWsdlUrlResponse(string WsdlUrl)
        {
            this.WsdlUrl = WsdlUrl;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCapabilities",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetCapabilitiesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Category")]
        public CapabilityCategory[] Category;

        public GetCapabilitiesRequest()
        {
        }

        public GetCapabilitiesRequest(CapabilityCategory[] Category)
        {
            this.Category = Category;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCapabilitiesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetCapabilitiesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public Capabilities Capabilities;

        public GetCapabilitiesResponse()
        {
        }

        public GetCapabilitiesResponse(Capabilities Capabilities)
        {
            this.Capabilities = Capabilities;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetHostname",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetHostnameRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement(DataType = "token")]
        public string Name;

        public SetHostnameRequest()
        {
        }

        public SetHostnameRequest(string Name)
        {
            this.Name = Name;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetHostnameResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetHostnameResponse
    {
        public SetHostnameResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetDNS",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetDNSRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 1)]
        [XmlElement("SearchDomain", DataType = "token")]
        public string[] SearchDomain;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 2)]
        [XmlElement("DNSManual")]
        public IPAddress[] DNSManual;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public bool FromDHCP;


        public SetDNSRequest()
        {
        }

        public SetDNSRequest(bool FromDHCP, string[] SearchDomain, IPAddress[] DNSManual)
        {
            this.FromDHCP = FromDHCP;
            this.SearchDomain = SearchDomain;
            this.DNSManual = DNSManual;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetDNSResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetDNSResponse
    {
        public SetDNSResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetNTP",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetNTPRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public bool FromDHCP;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 1)]
        [XmlElement("NTPManual")]
        public NetworkHost[] NTPManual;

        public SetNTPRequest()
        {
        }

        public SetNTPRequest(bool FromDHCP, NetworkHost[] NTPManual)
        {
            this.FromDHCP = FromDHCP;
            this.NTPManual = NTPManual;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetNTPResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetNTPResponse
    {
        public SetNTPResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetDynamicDNS",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetDynamicDNSRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 1)]
        [XmlElement(DataType = "token")]
        public string Name;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 2)]
        [XmlElement(DataType = "duration")]
        public string TTL;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public DynamicDNSType Type;

        public SetDynamicDNSRequest()
        {
        }

        public SetDynamicDNSRequest(DynamicDNSType Type, string Name, string TTL)
        {
            this.Type = Type;
            this.Name = Name;
            this.TTL = TTL;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetDynamicDNSResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetDynamicDNSResponse
    {
        public SetDynamicDNSResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetNetworkInterfaces",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetNetworkInterfacesRequest
    {
        public GetNetworkInterfacesRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetNetworkInterfacesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetNetworkInterfacesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("NetworkInterfaces")]
        public NetworkInterface[] NetworkInterfaces;

        public GetNetworkInterfacesResponse()
        {
        }

        public GetNetworkInterfacesResponse(NetworkInterface[] NetworkInterfaces)
        {
            this.NetworkInterfaces = NetworkInterfaces;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetNetworkProtocols",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetNetworkProtocolsRequest
    {
        public GetNetworkProtocolsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetNetworkProtocolsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetNetworkProtocolsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("NetworkProtocols")]
        public NetworkProtocol[] NetworkProtocols;

        public GetNetworkProtocolsResponse()
        {
        }

        public GetNetworkProtocolsResponse(NetworkProtocol[] NetworkProtocols)
        {
            this.NetworkProtocols = NetworkProtocols;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetNetworkProtocols",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetNetworkProtocolsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("NetworkProtocols")]
        public NetworkProtocol[] NetworkProtocols;

        public SetNetworkProtocolsRequest()
        {
        }

        public SetNetworkProtocolsRequest(NetworkProtocol[] NetworkProtocols)
        {
            this.NetworkProtocols = NetworkProtocols;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetNetworkProtocolsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetNetworkProtocolsResponse
    {
        public SetNetworkProtocolsResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetNetworkDefaultGateway",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetNetworkDefaultGatewayRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("IPv4Address", DataType = "token")]
        public string[] IPv4Address;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 1)]
        [XmlElement("IPv6Address", DataType = "token")]
        public string[] IPv6Address;

        public SetNetworkDefaultGatewayRequest()
        {
        }

        public SetNetworkDefaultGatewayRequest(string[] IPv4Address, string[] IPv6Address)
        {
            this.IPv4Address = IPv4Address;
            this.IPv6Address = IPv6Address;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetNetworkDefaultGatewayResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetNetworkDefaultGatewayResponse
    {
        public SetNetworkDefaultGatewayResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "CreateCertificate",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class CreateCertificateRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement(DataType = "token")]
        public string CertificateID;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 1)]
        public string Subject;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 3)]
        public System.DateTime ValidNotAfter;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 2)]
        public System.DateTime ValidNotBefore;

        public CreateCertificateRequest()
        {
        }

        public CreateCertificateRequest(string CertificateID, string Subject, System.DateTime ValidNotBefore,
            System.DateTime ValidNotAfter)
        {
            this.CertificateID = CertificateID;
            this.Subject = Subject;
            this.ValidNotBefore = ValidNotBefore;
            this.ValidNotAfter = ValidNotAfter;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "CreateCertificateResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class CreateCertificateResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public Certificate NvtCertificate;

        public CreateCertificateResponse()
        {
        }

        public CreateCertificateResponse(Certificate NvtCertificate)
        {
            this.NvtCertificate = NvtCertificate;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCertificates",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetCertificatesRequest
    {
        public GetCertificatesRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCertificatesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetCertificatesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("NvtCertificate")]
        public Certificate[] NvtCertificate;

        public GetCertificatesResponse()
        {
        }

        public GetCertificatesResponse(Certificate[] NvtCertificate)
        {
            this.NvtCertificate = NvtCertificate;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCertificatesStatus",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetCertificatesStatusRequest
    {
        public GetCertificatesStatusRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCertificatesStatusResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetCertificatesStatusResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("CertificateStatus")]
        public CertificateStatus[] CertificateStatus;

        public GetCertificatesStatusResponse()
        {
        }

        public GetCertificatesStatusResponse(CertificateStatus[] CertificateStatus)
        {
            this.CertificateStatus = CertificateStatus;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetCertificatesStatus",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetCertificatesStatusRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("CertificateStatus")]
        public CertificateStatus[] CertificateStatus;

        public SetCertificatesStatusRequest()
        {
        }

        public SetCertificatesStatusRequest(CertificateStatus[] CertificateStatus)
        {
            this.CertificateStatus = CertificateStatus;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetCertificatesStatusResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetCertificatesStatusResponse
    {
        public SetCertificatesStatusResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "DeleteCertificates",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class DeleteCertificatesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("CertificateID", DataType = "token")]
        public string[] CertificateID;

        public DeleteCertificatesRequest()
        {
        }

        public DeleteCertificatesRequest(string[] CertificateID)
        {
            this.CertificateID = CertificateID;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "DeleteCertificatesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class DeleteCertificatesResponse
    {
        public DeleteCertificatesResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetPkcs10Request",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetPkcs10RequestRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 2)]
        public BinaryData Attributes;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement(DataType = "token")]
        public string CertificateID;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 1)]
        public string Subject;

        public GetPkcs10RequestRequest()
        {
        }

        public GetPkcs10RequestRequest(string CertificateID, string Subject, BinaryData Attributes)
        {
            this.CertificateID = CertificateID;
            this.Subject = Subject;
            this.Attributes = Attributes;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetPkcs10RequestResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetPkcs10RequestResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public BinaryData Pkcs10Request;

        public GetPkcs10RequestResponse()
        {
        }

        public GetPkcs10RequestResponse(BinaryData Pkcs10Request)
        {
            this.Pkcs10Request = Pkcs10Request;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "LoadCertificates",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class LoadCertificatesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("NVTCertificate")]
        public Certificate[] NVTCertificate;

        public LoadCertificatesRequest()
        {
        }

        public LoadCertificatesRequest(Certificate[] NVTCertificate)
        {
            this.NVTCertificate = NVTCertificate;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "LoadCertificatesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class LoadCertificatesResponse
    {
        public LoadCertificatesResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetRelayOutputs",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetRelayOutputsRequest
    {
        public GetRelayOutputsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetRelayOutputsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetRelayOutputsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("RelayOutputs")]
        public RelayOutput[] RelayOutputs;

        public GetRelayOutputsResponse()
        {
        }

        public GetRelayOutputsResponse(RelayOutput[] RelayOutputs)
        {
            this.RelayOutputs = RelayOutputs;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCACertificates",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetCACertificatesRequest
    {
        public GetCACertificatesRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCACertificatesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetCACertificatesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("CACertificate")]
        public Certificate[] CACertificate;

        public GetCACertificatesResponse()
        {
        }

        public GetCACertificatesResponse(Certificate[] CACertificate)
        {
            this.CACertificate = CACertificate;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "LoadCertificateWithPrivateKey",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class LoadCertificateWithPrivateKeyRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("CertificateWithPrivateKey")]
        public CertificateWithPrivateKey[] CertificateWithPrivateKey;

        public LoadCertificateWithPrivateKeyRequest()
        {
        }

        public LoadCertificateWithPrivateKeyRequest(CertificateWithPrivateKey[] CertificateWithPrivateKey)
        {
            this.CertificateWithPrivateKey = CertificateWithPrivateKey;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "LoadCertificateWithPrivateKeyResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class LoadCertificateWithPrivateKeyResponse
    {
        public LoadCertificateWithPrivateKeyResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCertificateInformation",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetCertificateInformationRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement(DataType = "token")]
        public string CertificateID;

        public GetCertificateInformationRequest()
        {
        }

        public GetCertificateInformationRequest(string CertificateID)
        {
            this.CertificateID = CertificateID;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCertificateInformationResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetCertificateInformationResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public CertificateInformation CertificateInformation;

        public GetCertificateInformationResponse()
        {
        }

        public GetCertificateInformationResponse(CertificateInformation CertificateInformation)
        {
            this.CertificateInformation = CertificateInformation;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "LoadCACertificates",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class LoadCACertificatesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("CACertificate")]
        public Certificate[] CACertificate;

        public LoadCACertificatesRequest()
        {
        }

        public LoadCACertificatesRequest(Certificate[] CACertificate)
        {
            this.CACertificate = CACertificate;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "LoadCACertificatesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class LoadCACertificatesResponse
    {
        public LoadCACertificatesResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetDot1XConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetDot1XConfigurationsRequest
    {
        public GetDot1XConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetDot1XConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetDot1XConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Dot1XConfiguration")]
        public Dot1XConfiguration[] Dot1XConfiguration;

        public GetDot1XConfigurationsResponse()
        {
        }

        public GetDot1XConfigurationsResponse(Dot1XConfiguration[] Dot1XConfiguration)
        {
            this.Dot1XConfiguration = Dot1XConfiguration;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "DeleteDot1XConfiguration",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class DeleteDot1XConfigurationRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Dot1XConfigurationToken")]
        public string[] Dot1XConfigurationToken;

        public DeleteDot1XConfigurationRequest()
        {
        }

        public DeleteDot1XConfigurationRequest(string[] Dot1XConfigurationToken)
        {
            this.Dot1XConfigurationToken = Dot1XConfigurationToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "DeleteDot1XConfigurationResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class DeleteDot1XConfigurationResponse
    {
        public DeleteDot1XConfigurationResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetDot11Capabilities",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetDot11CapabilitiesRequest
    {
        [MessageBodyMember(Namespace = "", Order = 0)]
        [XmlAnyElement()]
        public XElement[] Any;

        public GetDot11CapabilitiesRequest()
        {
        }

        public GetDot11CapabilitiesRequest(XElement[] Any)
        {
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetDot11CapabilitiesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetDot11CapabilitiesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public Dot11Capabilities Capabilities;

        public GetDot11CapabilitiesResponse()
        {
        }

        public GetDot11CapabilitiesResponse(Dot11Capabilities Capabilities)
        {
            this.Capabilities = Capabilities;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "ScanAvailableDot11Networks",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class ScanAvailableDot11NetworksRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        public string InterfaceToken;

        public ScanAvailableDot11NetworksRequest()
        {
        }

        public ScanAvailableDot11NetworksRequest(string InterfaceToken)
        {
            this.InterfaceToken = InterfaceToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "ScanAvailableDot11NetworksResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class ScanAvailableDot11NetworksResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Networks")]
        public Dot11AvailableNetworks[] Networks;

        public ScanAvailableDot11NetworksResponse()
        {
        }

        public ScanAvailableDot11NetworksResponse(Dot11AvailableNetworks[] Networks)
        {
            this.Networks = Networks;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetSystemUris",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetSystemUrisRequest
    {
        public GetSystemUrisRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetSystemUrisResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetSystemUrisResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 3)]
        public GetSystemUrisResponseExtension Extension;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 1)]
        [XmlElement(DataType = "anyURI")]
        public string SupportInfoUri;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 2)]
        [XmlElement(DataType = "anyURI")]
        public string SystemBackupUri;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlArrayItem("SystemLog", Namespace = "http://www.onvif.org/ver10/schema",
            IsNullable = false)]
        public SystemLogUri[] SystemLogUris;

        public GetSystemUrisResponse()
        {
        }

        public GetSystemUrisResponse(SystemLogUri[] SystemLogUris, string SupportInfoUri, string SystemBackupUri,
            GetSystemUrisResponseExtension Extension)
        {
            this.SystemLogUris = SystemLogUris;
            this.SupportInfoUri = SupportInfoUri;
            this.SystemBackupUri = SystemBackupUri;
            this.Extension = Extension;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "StartFirmwareUpgrade",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class StartFirmwareUpgradeRequest
    {
        public StartFirmwareUpgradeRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "StartFirmwareUpgradeResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class StartFirmwareUpgradeResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement(DataType = "anyURI")]
        public string UploadUri;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 1)]
        [XmlElement(DataType = "duration")]
        public string UploadDelay;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 2)]
        [XmlElement(DataType = "duration")]
        public string ExpectedDownTime;


        public StartFirmwareUpgradeResponse()
        {
        }

        public StartFirmwareUpgradeResponse(string UploadUri, string UploadDelay, string ExpectedDownTime)
        {
            this.UploadUri = UploadUri;
            this.UploadDelay = UploadDelay;
            this.ExpectedDownTime = ExpectedDownTime;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "StartSystemRestore",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class StartSystemRestoreRequest
    {
        public StartSystemRestoreRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "StartSystemRestoreResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class StartSystemRestoreResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement(DataType = "anyURI")]
        public string UploadUri;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 1)]
        [XmlElement(DataType = "duration")]
        public string ExpectedDownTime;


        public StartSystemRestoreResponse()
        {
        }

        public StartSystemRestoreResponse(string UploadUri, string ExpectedDownTime)
        {
            this.UploadUri = UploadUri;
            this.ExpectedDownTime = ExpectedDownTime;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetStorageConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetStorageConfigurationsRequest
    {
        public GetStorageConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetStorageConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetStorageConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("StorageConfigurations")]
        public StorageConfiguration[] StorageConfigurations;

        public GetStorageConfigurationsResponse()
        {
        }

        public GetStorageConfigurationsResponse(StorageConfiguration[] StorageConfigurations)
        {
            this.StorageConfigurations = StorageConfigurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetGeoLocation",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetGeoLocationRequest
    {
        public GetGeoLocationRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetGeoLocationResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class GetGeoLocationResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Location")]
        public LocationEntity[] Location;

        public GetGeoLocationResponse()
        {
        }

        public GetGeoLocationResponse(LocationEntity[] Location)
        {
            this.Location = Location;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetGeoLocation",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetGeoLocationRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Location")]
        public LocationEntity[] Location;

        public SetGeoLocationRequest()
        {
        }

        public SetGeoLocationRequest(LocationEntity[] Location)
        {
            this.Location = Location;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "SetGeoLocationResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class SetGeoLocationResponse
    {
        public SetGeoLocationResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "DeleteGeoLocation",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class DeleteGeoLocationRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/device/wsdl",
            Order = 0)]
        [XmlElement("Location")]
        public LocationEntity[] Location;

        public DeleteGeoLocationRequest()
        {
        }

        public DeleteGeoLocationRequest(LocationEntity[] Location)
        {
            this.Location = Location;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "DeleteGeoLocationResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/device/wsdl", IsWrapped = true)]
    public partial class DeleteGeoLocationResponse
    {
        public DeleteGeoLocationResponse()
        {
        }
    }

    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    public interface DeviceChannel : Device, IClientChannel
    {
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    public partial class DeviceClient : ClientBase<Device>,
        Device
    {
        internal DeviceClient(Binding binding,
            EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetServicesResponse>
            Device.GetServicesAsync(
                GetServicesRequest request)
        {
            return base.Channel.GetServicesAsync(request);
        }

        public Task<DeviceServiceCapabilities> GetServiceCapabilitiesAsync()
        {
            return base.Channel.GetServiceCapabilitiesAsync();
        }

        public Task<GetDeviceInformationResponse>
            GetDeviceInformationAsync(GetDeviceInformationRequest request)
        {
            return base.Channel.GetDeviceInformationAsync(request);
        }

        public Task SetSystemDateAndTimeAsync(SetDateTimeType DateTimeType, bool DaylightSavings,
            TimeZone TimeZone, DateTime UTCDateTime)
        {
            return base.Channel.SetSystemDateAndTimeAsync(DateTimeType, DaylightSavings, TimeZone, UTCDateTime);
        }

        public Task<SystemDateTime> GetSystemDateAndTimeAsync()
        {
            return base.Channel.GetSystemDateAndTimeAsync();
        }

        public Task SetSystemFactoryDefaultAsync(FactoryDefaultType FactoryDefault)
        {
            return base.Channel.SetSystemFactoryDefaultAsync(FactoryDefault);
        }

        public Task<string> UpgradeSystemFirmwareAsync(AttachmentData Firmware)
        {
            return base.Channel.UpgradeSystemFirmwareAsync(Firmware);
        }

        public Task<string> SystemRebootAsync()
        {
            return base.Channel.SystemRebootAsync();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<RestoreSystemResponse>
            Device.RestoreSystemAsync(
                RestoreSystemRequest request)
        {
            return base.Channel.RestoreSystemAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetSystemBackupResponse>
            Device.GetSystemBackupAsync(
                GetSystemBackupRequest request)
        {
            return base.Channel.GetSystemBackupAsync(request);
        }

        public Task<SystemLog> GetSystemLogAsync(SystemLogType LogType)
        {
            return base.Channel.GetSystemLogAsync(LogType);
        }

        public Task<SupportInformation> GetSystemSupportInformationAsync()
        {
            return base.Channel.GetSystemSupportInformationAsync();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetScopesResponse>
            Device.GetScopesAsync(GetScopesRequest request)
        {
            return base.Channel.GetScopesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetScopesResponse>
            Device.SetScopesAsync(SetScopesRequest request)
        {
            return base.Channel.SetScopesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<AddScopesResponse>
            Device.AddScopesAsync(AddScopesRequest request)
        {
            return base.Channel.AddScopesAsync(request);
        }

        public Task<RemoveScopesResponse> RemoveScopesAsync(
            RemoveScopesRequest request)
        {
            return base.Channel.RemoveScopesAsync(request);
        }

        public Task<DiscoveryMode> GetDiscoveryModeAsync()
        {
            return base.Channel.GetDiscoveryModeAsync();
        }

        public Task SetDiscoveryModeAsync(DiscoveryMode DiscoveryMode)
        {
            return base.Channel.SetDiscoveryModeAsync(DiscoveryMode);
        }

        public Task<DiscoveryMode> GetRemoteDiscoveryModeAsync()
        {
            return base.Channel.GetRemoteDiscoveryModeAsync();
        }

        public Task SetRemoteDiscoveryModeAsync(DiscoveryMode RemoteDiscoveryMode)
        {
            return base.Channel.SetRemoteDiscoveryModeAsync(RemoteDiscoveryMode);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetDPAddressesResponse>
            Device.GetDPAddressesAsync(
                GetDPAddressesRequest request)
        {
            return base.Channel.GetDPAddressesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetDPAddressesResponse>
            Device.SetDPAddressesAsync(
                SetDPAddressesRequest request)
        {
            return base.Channel.SetDPAddressesAsync(request);
        }

        public Task<GetEndpointReferenceResponse>
            GetEndpointReferenceAsync(GetEndpointReferenceRequest request)
        {
            return base.Channel.GetEndpointReferenceAsync(request);
        }

        public Task<RemoteUser> GetRemoteUserAsync()
        {
            return base.Channel.GetRemoteUserAsync();
        }

        public Task SetRemoteUserAsync(RemoteUser RemoteUser)
        {
            return base.Channel.SetRemoteUserAsync(RemoteUser);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetUsersResponse> Device
            .GetUsersAsync(GetUsersRequest request)
        {
            return base.Channel.GetUsersAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<CreateUsersResponse>
            Device.CreateUsersAsync(
                CreateUsersRequest request)
        {
            return base.Channel.CreateUsersAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<DeleteUsersResponse>
            Device.DeleteUsersAsync(
                DeleteUsersRequest request)
        {
            return base.Channel.DeleteUsersAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetUserResponse> Device.
            SetUserAsync(SetUserRequest request)
        {
            return base.Channel.SetUserAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetWsdlUrlResponse>
            Device.GetWsdlUrlAsync(
                GetWsdlUrlRequest request)
        {
            return base.Channel.GetWsdlUrlAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCapabilitiesResponse>
            Device.GetCapabilitiesAsync(
                GetCapabilitiesRequest request)
        {
            return base.Channel.GetCapabilitiesAsync(request);
        }

        public Task<HostnameInformation> GetHostnameAsync()
        {
            return base.Channel.GetHostnameAsync();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetHostnameResponse>
            Device.SetHostnameAsync(
                SetHostnameRequest request)
        {
            return base.Channel.SetHostnameAsync(request);
        }

        public Task<bool> SetHostnameFromDHCPAsync(bool FromDHCP)
        {
            return base.Channel.SetHostnameFromDHCPAsync(FromDHCP);
        }

        public Task<DNSInformation> GetDNSAsync()
        {
            return base.Channel.GetDNSAsync();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetDNSResponse> Device.
            SetDNSAsync(SetDNSRequest request)
        {
            return base.Channel.SetDNSAsync(request);
        }

        public Task<NTPInformation> GetNTPAsync()
        {
            return base.Channel.GetNTPAsync();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetNTPResponse> Device.
            SetNTPAsync(SetNTPRequest request)
        {
            return base.Channel.SetNTPAsync(request);
        }

        public Task<DynamicDNSInformation> GetDynamicDNSAsync()
        {
            return base.Channel.GetDynamicDNSAsync();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetDynamicDNSResponse>
            Device.SetDynamicDNSAsync(
                SetDynamicDNSRequest request)
        {
            return base.Channel.SetDynamicDNSAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetNetworkInterfacesResponse>
            Device.GetNetworkInterfacesAsync(
                GetNetworkInterfacesRequest request)
        {
            return base.Channel.GetNetworkInterfacesAsync(request);
        }

        public Task<bool> SetNetworkInterfacesAsync(string InterfaceToken,
            NetworkInterfaceSetConfiguration NetworkInterface)
        {
            return base.Channel.SetNetworkInterfacesAsync(InterfaceToken, NetworkInterface);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetNetworkProtocolsResponse>
            Device.GetNetworkProtocolsAsync(
                GetNetworkProtocolsRequest request)
        {
            return base.Channel.GetNetworkProtocolsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetNetworkProtocolsResponse>
            Device.SetNetworkProtocolsAsync(
                SetNetworkProtocolsRequest request)
        {
            return base.Channel.SetNetworkProtocolsAsync(request);
        }

        public Task<NetworkGateway> GetNetworkDefaultGatewayAsync()
        {
            return base.Channel.GetNetworkDefaultGatewayAsync();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetNetworkDefaultGatewayResponse>
            Device.SetNetworkDefaultGatewayAsync(
                SetNetworkDefaultGatewayRequest request)
        {
            return base.Channel.SetNetworkDefaultGatewayAsync(request);
        }

        public Task<NetworkZeroConfiguration> GetZeroConfigurationAsync()
        {
            return base.Channel.GetZeroConfigurationAsync();
        }

        public Task SetZeroConfigurationAsync(string InterfaceToken, bool Enabled)
        {
            return base.Channel.SetZeroConfigurationAsync(InterfaceToken, Enabled);
        }

        public Task<IPAddressFilter> GetIPAddressFilterAsync()
        {
            return base.Channel.GetIPAddressFilterAsync();
        }

        public Task SetIPAddressFilterAsync(IPAddressFilter IPAddressFilter)
        {
            return base.Channel.SetIPAddressFilterAsync(IPAddressFilter);
        }

        public Task AddIPAddressFilterAsync(IPAddressFilter IPAddressFilter)
        {
            return base.Channel.AddIPAddressFilterAsync(IPAddressFilter);
        }

        public Task RemoveIPAddressFilterAsync(IPAddressFilter IPAddressFilter)
        {
            return base.Channel.RemoveIPAddressFilterAsync(IPAddressFilter);
        }

        public Task<BinaryData> GetAccessPolicyAsync()
        {
            return base.Channel.GetAccessPolicyAsync();
        }

        public Task SetAccessPolicyAsync(BinaryData PolicyFile)
        {
            return base.Channel.SetAccessPolicyAsync(PolicyFile);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<CreateCertificateResponse>
            Device.CreateCertificateAsync(
                CreateCertificateRequest request)
        {
            return base.Channel.CreateCertificateAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCertificatesResponse>
            Device.GetCertificatesAsync(
                GetCertificatesRequest request)
        {
            return base.Channel.GetCertificatesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCertificatesStatusResponse>
            Device.GetCertificatesStatusAsync(
                GetCertificatesStatusRequest request)
        {
            return base.Channel.GetCertificatesStatusAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetCertificatesStatusResponse>
            Device.SetCertificatesStatusAsync(
                SetCertificatesStatusRequest request)
        {
            return base.Channel.SetCertificatesStatusAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<DeleteCertificatesResponse>
            Device.DeleteCertificatesAsync(
                DeleteCertificatesRequest request)
        {
            return base.Channel.DeleteCertificatesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetPkcs10RequestResponse>
            Device.GetPkcs10RequestAsync(
                GetPkcs10RequestRequest request)
        {
            return base.Channel.GetPkcs10RequestAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<LoadCertificatesResponse>
            Device.LoadCertificatesAsync(
                LoadCertificatesRequest request)
        {
            return base.Channel.LoadCertificatesAsync(request);
        }

        public Task<bool> GetClientCertificateModeAsync()
        {
            return base.Channel.GetClientCertificateModeAsync();
        }

        public Task SetClientCertificateModeAsync(bool Enabled)
        {
            return base.Channel.SetClientCertificateModeAsync(Enabled);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetRelayOutputsResponse>
            Device.GetRelayOutputsAsync(
                GetRelayOutputsRequest request)
        {
            return base.Channel.GetRelayOutputsAsync(request);
        }

        public Task SetRelayOutputSettingsAsync(string RelayOutputToken,
            RelayOutputSettings Properties)
        {
            return base.Channel.SetRelayOutputSettingsAsync(RelayOutputToken, Properties);
        }

        public Task SetRelayOutputStateAsync(string RelayOutputToken,
            RelayLogicalState LogicalState)
        {
            return base.Channel.SetRelayOutputStateAsync(RelayOutputToken, LogicalState);
        }

        public Task<string> SendAuxiliaryCommandAsync(string AuxiliaryCommand)
        {
            return base.Channel.SendAuxiliaryCommandAsync(AuxiliaryCommand);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCACertificatesResponse>
            Device.GetCACertificatesAsync(
                GetCACertificatesRequest request)
        {
            return base.Channel.GetCACertificatesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<LoadCertificateWithPrivateKeyResponse>
            Device.LoadCertificateWithPrivateKeyAsync(
                LoadCertificateWithPrivateKeyRequest request)
        {
            return base.Channel.LoadCertificateWithPrivateKeyAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCertificateInformationResponse>
            Device.GetCertificateInformationAsync(
                GetCertificateInformationRequest request)
        {
            return base.Channel.GetCertificateInformationAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<LoadCACertificatesResponse>
            Device.LoadCACertificatesAsync(
                LoadCACertificatesRequest request)
        {
            return base.Channel.LoadCACertificatesAsync(request);
        }

        public Task CreateDot1XConfigurationAsync(Dot1XConfiguration Dot1XConfiguration)
        {
            return base.Channel.CreateDot1XConfigurationAsync(Dot1XConfiguration);
        }

        public Task SetDot1XConfigurationAsync(Dot1XConfiguration Dot1XConfiguration)
        {
            return base.Channel.SetDot1XConfigurationAsync(Dot1XConfiguration);
        }

        public Task<Dot1XConfiguration> GetDot1XConfigurationAsync(
            string Dot1XConfigurationToken)
        {
            return base.Channel.GetDot1XConfigurationAsync(Dot1XConfigurationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetDot1XConfigurationsResponse>
            Device.GetDot1XConfigurationsAsync(
                GetDot1XConfigurationsRequest request)
        {
            return base.Channel.GetDot1XConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<DeleteDot1XConfigurationResponse>
            Device.DeleteDot1XConfigurationAsync(
                DeleteDot1XConfigurationRequest request)
        {
            return base.Channel.DeleteDot1XConfigurationAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetDot11CapabilitiesResponse>
            Device.GetDot11CapabilitiesAsync(
                GetDot11CapabilitiesRequest request)
        {
            return base.Channel.GetDot11CapabilitiesAsync(request);
        }

        public Task<Dot11Status> GetDot11StatusAsync(string InterfaceToken)
        {
            return base.Channel.GetDot11StatusAsync(InterfaceToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ScanAvailableDot11NetworksResponse>
            Device.ScanAvailableDot11NetworksAsync(
                ScanAvailableDot11NetworksRequest request)
        {
            return base.Channel.ScanAvailableDot11NetworksAsync(request);
        }

        public Task<GetSystemUrisResponse> GetSystemUrisAsync(
            GetSystemUrisRequest request)
        {
            return base.Channel.GetSystemUrisAsync(request);
        }

        public Task<StartFirmwareUpgradeResponse>
            StartFirmwareUpgradeAsync(StartFirmwareUpgradeRequest request)
        {
            return base.Channel.StartFirmwareUpgradeAsync(request);
        }

        public Task<StartSystemRestoreResponse>
            StartSystemRestoreAsync(StartSystemRestoreRequest request)
        {
            return base.Channel.StartSystemRestoreAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetStorageConfigurationsResponse>
            Device.GetStorageConfigurationsAsync(
                GetStorageConfigurationsRequest request)
        {
            return base.Channel.GetStorageConfigurationsAsync(request);
        }

        public Task<string> CreateStorageConfigurationAsync(
            StorageConfigurationData StorageConfiguration)
        {
            return base.Channel.CreateStorageConfigurationAsync(StorageConfiguration);
        }

        public Task<StorageConfiguration> GetStorageConfigurationAsync(string Token)
        {
            return base.Channel.GetStorageConfigurationAsync(Token);
        }

        public Task SetStorageConfigurationAsync(StorageConfiguration StorageConfiguration)
        {
            return base.Channel.SetStorageConfigurationAsync(StorageConfiguration);
        }

        public Task DeleteStorageConfigurationAsync(string Token)
        {
            return base.Channel.DeleteStorageConfigurationAsync(Token);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetGeoLocationResponse>
            Device.GetGeoLocationAsync(
                GetGeoLocationRequest request)
        {
            return base.Channel.GetGeoLocationAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SetGeoLocationResponse>
            Device.SetGeoLocationAsync(
                SetGeoLocationRequest request)
        {
            return base.Channel.SetGeoLocationAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<DeleteGeoLocationResponse>
            Device.DeleteGeoLocationAsync(
                DeleteGeoLocationRequest request)
        {
            return base.Channel.DeleteGeoLocationAsync(request);
        }

        public Task<GetServicesResponse> GetServicesAsync(
            bool IncludeCapability)
        {
            GetServicesRequest inValue =
                new GetServicesRequest();
            inValue.IncludeCapability = IncludeCapability;
            return ((Device) (this)).GetServicesAsync(inValue);
        }

        public Task<RestoreSystemResponse> RestoreSystemAsync(
            BackupFile[] BackupFiles)
        {
            RestoreSystemRequest inValue =
                new RestoreSystemRequest();
            inValue.BackupFiles = BackupFiles;
            return ((Device) (this)).RestoreSystemAsync(inValue);
        }

        public Task<GetSystemBackupResponse> GetSystemBackupAsync()
        {
            GetSystemBackupRequest inValue =
                new GetSystemBackupRequest();
            return ((Device) (this)).GetSystemBackupAsync(inValue);
        }

        public Task<GetScopesResponse> GetScopesAsync()
        {
            GetScopesRequest inValue =
                new GetScopesRequest();
            return ((Device) (this)).GetScopesAsync(inValue);
        }

        public Task<SetScopesResponse> SetScopesAsync(
            string[] Scopes)
        {
            SetScopesRequest inValue =
                new SetScopesRequest();
            inValue.Scopes = Scopes;
            return ((Device) (this)).SetScopesAsync(inValue);
        }

        public Task<AddScopesResponse> AddScopesAsync(
            string[] ScopeItem)
        {
            AddScopesRequest inValue =
                new AddScopesRequest();
            inValue.ScopeItem = ScopeItem;
            return ((Device) (this)).AddScopesAsync(inValue);
        }

        public Task<GetDPAddressesResponse> GetDPAddressesAsync()
        {
            GetDPAddressesRequest inValue =
                new GetDPAddressesRequest();
            return ((Device) (this)).GetDPAddressesAsync(inValue);
        }

        public Task<SetDPAddressesResponse> SetDPAddressesAsync(
            NetworkHost[] DPAddress)
        {
            SetDPAddressesRequest inValue =
                new SetDPAddressesRequest();
            inValue.DPAddress = DPAddress;
            return ((Device) (this)).SetDPAddressesAsync(inValue);
        }

        public Task<GetUsersResponse> GetUsersAsync()
        {
            GetUsersRequest inValue = new GetUsersRequest();
            return ((Device) (this)).GetUsersAsync(inValue);
        }

        public Task<CreateUsersResponse> CreateUsersAsync(
            User[] User)
        {
            CreateUsersRequest inValue =
                new CreateUsersRequest();
            inValue.User = User;
            return ((Device) (this)).CreateUsersAsync(inValue);
        }

        public Task<DeleteUsersResponse> DeleteUsersAsync(
            string[] Username)
        {
            DeleteUsersRequest inValue =
                new DeleteUsersRequest();
            inValue.Username = Username;
            return ((Device) (this)).DeleteUsersAsync(inValue);
        }

        public Task<SetUserResponse> SetUserAsync(User[] User)
        {
            SetUserRequest inValue = new SetUserRequest();
            inValue.User = User;
            return ((Device) (this)).SetUserAsync(inValue);
        }

        public Task<GetWsdlUrlResponse> GetWsdlUrlAsync()
        {
            GetWsdlUrlRequest inValue =
                new GetWsdlUrlRequest();
            return ((Device) (this)).GetWsdlUrlAsync(inValue);
        }

        public Task<GetCapabilitiesResponse> GetCapabilitiesAsync(
            CapabilityCategory[] Category)
        {
            GetCapabilitiesRequest inValue =
                new GetCapabilitiesRequest();
            inValue.Category = Category;
            return ((Device) (this)).GetCapabilitiesAsync(inValue);
        }

        public Task<SetHostnameResponse> SetHostnameAsync(
            string Name)
        {
            SetHostnameRequest inValue =
                new SetHostnameRequest();
            inValue.Name = Name;
            return ((Device) (this)).SetHostnameAsync(inValue);
        }

        public Task<SetDNSResponse> SetDNSAsync(bool FromDHCP,
            string[] SearchDomain, IPAddress[] DNSManual)
        {
            SetDNSRequest inValue = new SetDNSRequest();
            inValue.FromDHCP = FromDHCP;
            inValue.SearchDomain = SearchDomain;
            inValue.DNSManual = DNSManual;
            return ((Device) (this)).SetDNSAsync(inValue);
        }

        public Task<SetNTPResponse> SetNTPAsync(bool FromDHCP,
            NetworkHost[] NTPManual)
        {
            SetNTPRequest inValue = new SetNTPRequest();
            inValue.FromDHCP = FromDHCP;
            inValue.NTPManual = NTPManual;
            return ((Device) (this)).SetNTPAsync(inValue);
        }

        public Task<SetDynamicDNSResponse> SetDynamicDNSAsync(
            DynamicDNSType Type, string Name, string TTL)
        {
            SetDynamicDNSRequest inValue =
                new SetDynamicDNSRequest();
            inValue.Type = Type;
            inValue.Name = Name;
            inValue.TTL = TTL;
            return ((Device) (this)).SetDynamicDNSAsync(inValue);
        }

        public Task<GetNetworkInterfacesResponse>
            GetNetworkInterfacesAsync()
        {
            GetNetworkInterfacesRequest inValue =
                new GetNetworkInterfacesRequest();
            return ((Device) (this)).GetNetworkInterfacesAsync(inValue);
        }

        public Task<GetNetworkProtocolsResponse>
            GetNetworkProtocolsAsync()
        {
            GetNetworkProtocolsRequest inValue =
                new GetNetworkProtocolsRequest();
            return ((Device) (this)).GetNetworkProtocolsAsync(inValue);
        }

        public Task<SetNetworkProtocolsResponse>
            SetNetworkProtocolsAsync(NetworkProtocol[] NetworkProtocols)
        {
            SetNetworkProtocolsRequest inValue =
                new SetNetworkProtocolsRequest();
            inValue.NetworkProtocols = NetworkProtocols;
            return ((Device) (this)).SetNetworkProtocolsAsync(inValue);
        }

        public Task<SetNetworkDefaultGatewayResponse>
            SetNetworkDefaultGatewayAsync(string[] IPv4Address, string[] IPv6Address)
        {
            SetNetworkDefaultGatewayRequest inValue =
                new SetNetworkDefaultGatewayRequest();
            inValue.IPv4Address = IPv4Address;
            inValue.IPv6Address = IPv6Address;
            return ((Device) (this)).SetNetworkDefaultGatewayAsync(inValue);
        }

        public Task<CreateCertificateResponse>
            CreateCertificateAsync(string CertificateID, string Subject, System.DateTime ValidNotBefore,
                System.DateTime ValidNotAfter)
        {
            CreateCertificateRequest inValue =
                new CreateCertificateRequest();
            inValue.CertificateID = CertificateID;
            inValue.Subject = Subject;
            inValue.ValidNotBefore = ValidNotBefore;
            inValue.ValidNotAfter = ValidNotAfter;
            return ((Device) (this)).CreateCertificateAsync(inValue);
        }

        public Task<GetCertificatesResponse> GetCertificatesAsync()
        {
            GetCertificatesRequest inValue =
                new GetCertificatesRequest();
            return ((Device) (this)).GetCertificatesAsync(inValue);
        }

        public Task<GetCertificatesStatusResponse>
            GetCertificatesStatusAsync()
        {
            GetCertificatesStatusRequest inValue =
                new GetCertificatesStatusRequest();
            return ((Device) (this)).GetCertificatesStatusAsync(inValue);
        }

        public Task<SetCertificatesStatusResponse>
            SetCertificatesStatusAsync(CertificateStatus[] CertificateStatus)
        {
            SetCertificatesStatusRequest inValue =
                new SetCertificatesStatusRequest();
            inValue.CertificateStatus = CertificateStatus;
            return ((Device) (this)).SetCertificatesStatusAsync(inValue);
        }

        public Task<DeleteCertificatesResponse>
            DeleteCertificatesAsync(string[] CertificateID)
        {
            DeleteCertificatesRequest inValue =
                new DeleteCertificatesRequest();
            inValue.CertificateID = CertificateID;
            return ((Device) (this)).DeleteCertificatesAsync(inValue);
        }

        public Task<GetPkcs10RequestResponse>
            GetPkcs10RequestAsync(string CertificateID, string Subject, BinaryData Attributes)
        {
            GetPkcs10RequestRequest inValue =
                new GetPkcs10RequestRequest();
            inValue.CertificateID = CertificateID;
            inValue.Subject = Subject;
            inValue.Attributes = Attributes;
            return ((Device) (this)).GetPkcs10RequestAsync(inValue);
        }

        public Task<LoadCertificatesResponse>
            LoadCertificatesAsync(Certificate[] NVTCertificate)
        {
            LoadCertificatesRequest inValue =
                new LoadCertificatesRequest();
            inValue.NVTCertificate = NVTCertificate;
            return ((Device) (this)).LoadCertificatesAsync(inValue);
        }

        public Task<GetRelayOutputsResponse> GetRelayOutputsAsync()
        {
            GetRelayOutputsRequest inValue =
                new GetRelayOutputsRequest();
            return ((Device) (this)).GetRelayOutputsAsync(inValue);
        }

        public Task<GetCACertificatesResponse>
            GetCACertificatesAsync()
        {
            GetCACertificatesRequest inValue =
                new GetCACertificatesRequest();
            return ((Device) (this)).GetCACertificatesAsync(inValue);
        }

        public Task<LoadCertificateWithPrivateKeyResponse>
            LoadCertificateWithPrivateKeyAsync(CertificateWithPrivateKey[] CertificateWithPrivateKey)
        {
            LoadCertificateWithPrivateKeyRequest inValue =
                new LoadCertificateWithPrivateKeyRequest();
            inValue.CertificateWithPrivateKey = CertificateWithPrivateKey;
            return ((Device) (this)).LoadCertificateWithPrivateKeyAsync(inValue);
        }

        public Task<GetCertificateInformationResponse>
            GetCertificateInformationAsync(string CertificateID)
        {
            GetCertificateInformationRequest inValue =
                new GetCertificateInformationRequest();
            inValue.CertificateID = CertificateID;
            return ((Device) (this)).GetCertificateInformationAsync(inValue);
        }

        public Task<LoadCACertificatesResponse>
            LoadCACertificatesAsync(Certificate[] CACertificate)
        {
            LoadCACertificatesRequest inValue =
                new LoadCACertificatesRequest();
            inValue.CACertificate = CACertificate;
            return ((Device) (this)).LoadCACertificatesAsync(inValue);
        }

        public Task<GetDot1XConfigurationsResponse>
            GetDot1XConfigurationsAsync()
        {
            GetDot1XConfigurationsRequest inValue =
                new GetDot1XConfigurationsRequest();
            return ((Device) (this)).GetDot1XConfigurationsAsync(inValue);
        }

        public Task<DeleteDot1XConfigurationResponse>
            DeleteDot1XConfigurationAsync(string[] Dot1XConfigurationToken)
        {
            DeleteDot1XConfigurationRequest inValue =
                new DeleteDot1XConfigurationRequest();
            inValue.Dot1XConfigurationToken = Dot1XConfigurationToken;
            return ((Device) (this)).DeleteDot1XConfigurationAsync(inValue);
        }

        public Task<GetDot11CapabilitiesResponse>
            GetDot11CapabilitiesAsync(XElement[] Any)
        {
            GetDot11CapabilitiesRequest inValue =
                new GetDot11CapabilitiesRequest();
            inValue.Any = Any;
            return ((Device) (this)).GetDot11CapabilitiesAsync(inValue);
        }

        public Task<ScanAvailableDot11NetworksResponse>
            ScanAvailableDot11NetworksAsync(string InterfaceToken)
        {
            ScanAvailableDot11NetworksRequest inValue =
                new ScanAvailableDot11NetworksRequest();
            inValue.InterfaceToken = InterfaceToken;
            return ((Device) (this)).ScanAvailableDot11NetworksAsync(inValue);
        }

        public Task<GetStorageConfigurationsResponse>
            GetStorageConfigurationsAsync()
        {
            GetStorageConfigurationsRequest inValue =
                new GetStorageConfigurationsRequest();
            return ((Device) (this)).GetStorageConfigurationsAsync(inValue);
        }

        public Task<GetGeoLocationResponse> GetGeoLocationAsync()
        {
            GetGeoLocationRequest inValue =
                new GetGeoLocationRequest();
            return ((Device) (this)).GetGeoLocationAsync(inValue);
        }

        public Task<SetGeoLocationResponse> SetGeoLocationAsync(
            LocationEntity[] Location)
        {
            SetGeoLocationRequest inValue =
                new SetGeoLocationRequest();
            inValue.Location = Location;
            return ((Device) (this)).SetGeoLocationAsync(inValue);
        }

        public Task<DeleteGeoLocationResponse>
            DeleteGeoLocationAsync(LocationEntity[] Location)
        {
            DeleteGeoLocationRequest inValue =
                new DeleteGeoLocationRequest();
            inValue.Location = Location;
            return ((Device) (this)).DeleteGeoLocationAsync(inValue);
        }

        public virtual Task OpenAsync()
        {
            return Task.Factory.FromAsync(
                ((ICommunicationObject) (this)).BeginOpen(null, null),
                new Action<IAsyncResult>(((ICommunicationObject) (this)).EndOpen));
        }

        public virtual Task CloseAsync()
        {
            return Task.Factory.FromAsync(
                ((ICommunicationObject) (this)).BeginClose(null, null),
                new Action<IAsyncResult>(((ICommunicationObject) (this)).EndClose));
        }
    }
}
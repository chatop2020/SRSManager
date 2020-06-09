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

namespace Mictlanix.DotNet.Onvif.Media
{
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [ServiceContract(Namespace = "http://www.onvif.org/ver10/media/wsdl",
        ConfigurationName = "Mictlanix.DotNet.Onvif.Media.Media")]
    public interface Media
    {
        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetServiceCapabilities", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Capabilities")]
        Task<Capabilities> GetServiceCapabilitiesAsync();

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdlGetVideoSources/", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetVideoSourcesResponse> GetVideoSourcesAsync(
            GetVideoSourcesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioSources", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetAudioSourcesResponse> GetAudioSourcesAsync(
            GetAudioSourcesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioOutputs", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetAudioOutputsResponse> GetAudioOutputsAsync(
            GetAudioOutputsRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/CreateProfile",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Profile")]
        Task<Profile> CreateProfileAsync(string Name, string Token);

        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdlGetProfile/",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Profile")]
        Task<Profile> GetProfileAsync(string ProfileToken);

        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/GetProfiles",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetProfilesResponse> GetProfilesAsync(
            GetProfilesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/AddVideoEncoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AddVideoEncoderConfigurationAsync(string ProfileToken, string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/RemoveVideoEncoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemoveVideoEncoderConfigurationAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/AddVideoSourceConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AddVideoSourceConfigurationAsync(string ProfileToken, string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/RemoveVideoSourceConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemoveVideoSourceConfigurationAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/AddAudioEncoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AddAudioEncoderConfigurationAsync(string ProfileToken, string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/RemoveAudioEncoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemoveAudioEncoderConfigurationAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/AddAudioSourceConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AddAudioSourceConfigurationAsync(string ProfileToken, string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/RemoveAudioSourceConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemoveAudioSourceConfigurationAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/AddPTZConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AddPTZConfigurationAsync(string ProfileToken, string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/RemovePTZConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemovePTZConfigurationAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/AddVideoAnalyticsConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AddVideoAnalyticsConfigurationAsync(string ProfileToken, string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/RemoveVideoAnalyticsConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemoveVideoAnalyticsConfigurationAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/AddMetadataConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AddMetadataConfigurationAsync(string ProfileToken, string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/RemoveMetadataConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemoveMetadataConfigurationAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/AddAudioOutputConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AddAudioOutputConfigurationAsync(string ProfileToken, string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/RemoveAudioOutputConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemoveAudioOutputConfigurationAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/AddAudioDecoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AddAudioDecoderConfigurationAsync(string ProfileToken, string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/RemoveAudioDecoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemoveAudioDecoderConfigurationAsync(string ProfileToken);

        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/DeleteProfile",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task DeleteProfileAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetVideoSourceConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetVideoSourceConfigurationsResponse>
            GetVideoSourceConfigurationsAsync(GetVideoSourceConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetVideoEncoderConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetVideoEncoderConfigurationsResponse>
            GetVideoEncoderConfigurationsAsync(
                GetVideoEncoderConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdlGetAudioSourceConfigurations/", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetAudioSourceConfigurationsResponse>
            GetAudioSourceConfigurationsAsync(GetAudioSourceConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioEncoderConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetAudioEncoderConfigurationsResponse>
            GetAudioEncoderConfigurationsAsync(
                GetAudioEncoderConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetVideoAnalyticsConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetVideoAnalyticsConfigurationsResponse>
            GetVideoAnalyticsConfigurationsAsync(
                GetVideoAnalyticsConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetMetadataConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetMetadataConfigurationsResponse>
            GetMetadataConfigurationsAsync(GetMetadataConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioOutputConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetAudioOutputConfigurationsResponse>
            GetAudioOutputConfigurationsAsync(GetAudioOutputConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioDecoderConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetAudioDecoderConfigurationsResponse>
            GetAudioDecoderConfigurationsAsync(
                GetAudioDecoderConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetVideoSourceConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Configuration")]
        Task<VideoSourceConfiguration> GetVideoSourceConfigurationAsync(
            string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetVideoEncoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Configuration")]
        Task<VideoEncoderConfiguration> GetVideoEncoderConfigurationAsync(
            string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioSourceConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Configuration")]
        Task<AudioSourceConfiguration> GetAudioSourceConfigurationAsync(
            string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioEncoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Configuration")]
        Task<AudioEncoderConfiguration> GetAudioEncoderConfigurationAsync(
            string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetVideoAnalyticsConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Configuration")]
        Task<VideoAnalyticsConfiguration> GetVideoAnalyticsConfigurationAsync(
            string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetMetadataConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Configuration")]
        Task<MetadataConfiguration> GetMetadataConfigurationAsync(string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioOutputConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Configuration")]
        Task<AudioOutputConfiguration> GetAudioOutputConfigurationAsync(
            string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioDecoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Configuration")]
        Task<AudioDecoderConfiguration> GetAudioDecoderConfigurationAsync(
            string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetCompatibleVideoEncoderConfigurations",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCompatibleVideoEncoderConfigurationsResponse>
            GetCompatibleVideoEncoderConfigurationsAsync(
                GetCompatibleVideoEncoderConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetCompatibleVideoSourceConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCompatibleVideoSourceConfigurationsResponse>
            GetCompatibleVideoSourceConfigurationsAsync(
                GetCompatibleVideoSourceConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetCompatibleAudioEncoderConfigurations",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCompatibleAudioEncoderConfigurationsResponse>
            GetCompatibleAudioEncoderConfigurationsAsync(
                GetCompatibleAudioEncoderConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetCompatibleAudioSourceConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCompatibleAudioSourceConfigurationsResponse>
            GetCompatibleAudioSourceConfigurationsAsync(
                GetCompatibleAudioSourceConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetCompatibleVideoAnalyticsConfigurations",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCompatibleVideoAnalyticsConfigurationsResponse>
            GetCompatibleVideoAnalyticsConfigurationsAsync(
                GetCompatibleVideoAnalyticsConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetCompatibleMetadataConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCompatibleMetadataConfigurationsResponse>
            GetCompatibleMetadataConfigurationsAsync(
                GetCompatibleMetadataConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetCompatibleAudioOutputConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCompatibleAudioOutputConfigurationsResponse>
            GetCompatibleAudioOutputConfigurationsAsync(
                GetCompatibleAudioOutputConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetCompatibleAudioDecoderConfigurations",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCompatibleAudioDecoderConfigurationsResponse>
            GetCompatibleAudioDecoderConfigurationsAsync(
                GetCompatibleAudioDecoderConfigurationsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/SetVideoSourceConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetVideoSourceConfigurationAsync(VideoSourceConfiguration Configuration,
            bool ForcePersistence);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/SetVideoEncoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetVideoEncoderConfigurationAsync(VideoEncoderConfiguration Configuration,
            bool ForcePersistence);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/SetAudioSourceConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetAudioSourceConfigurationAsync(AudioSourceConfiguration Configuration,
            bool ForcePersistence);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/SetAudioEncoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetAudioEncoderConfigurationAsync(AudioEncoderConfiguration Configuration,
            bool ForcePersistence);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/SetVideoAnalyticsConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetVideoAnalyticsConfigurationAsync(VideoAnalyticsConfiguration Configuration,
            bool ForcePersistence);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/SetMetadataConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetMetadataConfigurationAsync(MetadataConfiguration Configuration,
            bool ForcePersistence);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/SetAudioOutputConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetAudioOutputConfigurationAsync(AudioOutputConfiguration Configuration,
            bool ForcePersistence);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/SetAudioDecoderConfiguration", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetAudioDecoderConfigurationAsync(AudioDecoderConfiguration Configuration,
            bool ForcePersistence);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdlGetVideoSourceConfigurationOptions/", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Options")]
        Task<VideoSourceConfigurationOptions> GetVideoSourceConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetVideoEncoderConfigurationOptions", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Options")]
        Task<VideoEncoderConfigurationOptions> GetVideoEncoderConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioSourceConfigurationOptions", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Options")]
        Task<AudioSourceConfigurationOptions> GetAudioSourceConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioEncoderConfigurationOptions", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Options")]
        Task<AudioEncoderConfigurationOptions> GetAudioEncoderConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetMetadataConfigurationOptions", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Options")]
        Task<MetadataConfigurationOptions> GetMetadataConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioOutputConfigurationOptions", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Options")]
        Task<AudioOutputConfigurationOptions> GetAudioOutputConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetAudioDecoderConfigurationOptions", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Options")]
        Task<AudioDecoderConfigurationOptions> GetAudioDecoderConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetGuaranteedNumberOfVideoEncoderInstances",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetGuaranteedNumberOfVideoEncoderInstancesResponse>
            GetGuaranteedNumberOfVideoEncoderInstancesAsync(
                GetGuaranteedNumberOfVideoEncoderInstancesRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/GetStreamUri",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "MediaUri")]
        Task<MediaUri> GetStreamUriAsync(StreamSetup StreamSetup, string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/StartMulticastStreaming", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task StartMulticastStreamingAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/StopMulticastStreaming", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task StopMulticastStreamingAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/SetSynchronizationPoint", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetSynchronizationPointAsync(string ProfileToken);

        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/GetSnapshotUri",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "MediaUri")]
        Task<MediaUri> GetSnapshotUriAsync(string ProfileToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/GetVideoSourceModes", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetVideoSourceModesResponse> GetVideoSourceModesAsync(
            GetVideoSourceModesRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver10/media/wsdl/SetVideoSourceMode", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Reboot")]
        Task<bool> SetVideoSourceModeAsync(string VideoSourceToken, string VideoSourceModeToken);

        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/GetOSDs",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetOSDsResponse> GetOSDsAsync(
            GetOSDsRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/GetOSD",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetOSDResponse> GetOSDAsync(
            GetOSDRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/GetOSDOptions",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetOSDOptionsResponse> GetOSDOptionsAsync(
            GetOSDOptionsRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/SetOSD",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetOSDResponse> SetOSDAsync(
            SetOSDRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/CreateOSD",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<CreateOSDResponse> CreateOSDAsync(
            CreateOSDRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(Action = "http://www.onvif.org/ver10/media/wsdl/DeleteOSD",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<DeleteOSDResponse> DeleteOSDAsync(
            DeleteOSDRequest request);
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetVideoSources",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetVideoSourcesRequest
    {
        public GetVideoSourcesRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetVideoSourcesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetVideoSourcesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("VideoSources")]
        public VideoSource[] VideoSources;

        public GetVideoSourcesResponse()
        {
        }

        public GetVideoSourcesResponse(VideoSource[] VideoSources)
        {
            this.VideoSources = VideoSources;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioSources",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioSourcesRequest
    {
        public GetAudioSourcesRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioSourcesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioSourcesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("AudioSources")]
        public AudioSource[] AudioSources;

        public GetAudioSourcesResponse()
        {
        }

        public GetAudioSourcesResponse(AudioSource[] AudioSources)
        {
            this.AudioSources = AudioSources;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioOutputs",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioOutputsRequest
    {
        public GetAudioOutputsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioOutputsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioOutputsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("AudioOutputs")]
        public AudioOutput[] AudioOutputs;

        public GetAudioOutputsResponse()
        {
        }

        public GetAudioOutputsResponse(AudioOutput[] AudioOutputs)
        {
            this.AudioOutputs = AudioOutputs;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetProfiles",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetProfilesRequest
    {
        public GetProfilesRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetProfilesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetProfilesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Profiles")]
        public Profile[] Profiles;

        public GetProfilesResponse()
        {
        }

        public GetProfilesResponse(Profile[] Profiles)
        {
            this.Profiles = Profiles;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetVideoSourceConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetVideoSourceConfigurationsRequest
    {
        public GetVideoSourceConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetVideoSourceConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetVideoSourceConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public VideoSourceConfiguration[] Configurations;

        public GetVideoSourceConfigurationsResponse()
        {
        }

        public GetVideoSourceConfigurationsResponse(VideoSourceConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetVideoEncoderConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetVideoEncoderConfigurationsRequest
    {
        public GetVideoEncoderConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetVideoEncoderConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetVideoEncoderConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public VideoEncoderConfiguration[] Configurations;

        public GetVideoEncoderConfigurationsResponse()
        {
        }

        public GetVideoEncoderConfigurationsResponse(VideoEncoderConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioSourceConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioSourceConfigurationsRequest
    {
        public GetAudioSourceConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioSourceConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioSourceConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public AudioSourceConfiguration[] Configurations;

        public GetAudioSourceConfigurationsResponse()
        {
        }

        public GetAudioSourceConfigurationsResponse(AudioSourceConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioEncoderConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioEncoderConfigurationsRequest
    {
        public GetAudioEncoderConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioEncoderConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioEncoderConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public AudioEncoderConfiguration[] Configurations;

        public GetAudioEncoderConfigurationsResponse()
        {
        }

        public GetAudioEncoderConfigurationsResponse(AudioEncoderConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetVideoAnalyticsConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetVideoAnalyticsConfigurationsRequest
    {
        public GetVideoAnalyticsConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetVideoAnalyticsConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetVideoAnalyticsConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public VideoAnalyticsConfiguration[] Configurations;

        public GetVideoAnalyticsConfigurationsResponse()
        {
        }

        public GetVideoAnalyticsConfigurationsResponse(VideoAnalyticsConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetMetadataConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetMetadataConfigurationsRequest
    {
        public GetMetadataConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetMetadataConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetMetadataConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public MetadataConfiguration[] Configurations;

        public GetMetadataConfigurationsResponse()
        {
        }

        public GetMetadataConfigurationsResponse(MetadataConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioOutputConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioOutputConfigurationsRequest
    {
        public GetAudioOutputConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioOutputConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioOutputConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public AudioOutputConfiguration[] Configurations;

        public GetAudioOutputConfigurationsResponse()
        {
        }

        public GetAudioOutputConfigurationsResponse(AudioOutputConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioDecoderConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioDecoderConfigurationsRequest
    {
        public GetAudioDecoderConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetAudioDecoderConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetAudioDecoderConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public AudioDecoderConfiguration[] Configurations;

        public GetAudioDecoderConfigurationsResponse()
        {
        }

        public GetAudioDecoderConfigurationsResponse(AudioDecoderConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleVideoEncoderConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleVideoEncoderConfigurationsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ProfileToken;

        public GetCompatibleVideoEncoderConfigurationsRequest()
        {
        }

        public GetCompatibleVideoEncoderConfigurationsRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleVideoEncoderConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleVideoEncoderConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public VideoEncoderConfiguration[] Configurations;

        public GetCompatibleVideoEncoderConfigurationsResponse()
        {
        }

        public GetCompatibleVideoEncoderConfigurationsResponse(VideoEncoderConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleVideoSourceConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleVideoSourceConfigurationsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ProfileToken;

        public GetCompatibleVideoSourceConfigurationsRequest()
        {
        }

        public GetCompatibleVideoSourceConfigurationsRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleVideoSourceConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleVideoSourceConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public VideoSourceConfiguration[] Configurations;

        public GetCompatibleVideoSourceConfigurationsResponse()
        {
        }

        public GetCompatibleVideoSourceConfigurationsResponse(VideoSourceConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleAudioEncoderConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleAudioEncoderConfigurationsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ProfileToken;

        public GetCompatibleAudioEncoderConfigurationsRequest()
        {
        }

        public GetCompatibleAudioEncoderConfigurationsRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleAudioEncoderConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleAudioEncoderConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public AudioEncoderConfiguration[] Configurations;

        public GetCompatibleAudioEncoderConfigurationsResponse()
        {
        }

        public GetCompatibleAudioEncoderConfigurationsResponse(AudioEncoderConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleAudioSourceConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleAudioSourceConfigurationsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ProfileToken;

        public GetCompatibleAudioSourceConfigurationsRequest()
        {
        }

        public GetCompatibleAudioSourceConfigurationsRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleAudioSourceConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleAudioSourceConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public AudioSourceConfiguration[] Configurations;

        public GetCompatibleAudioSourceConfigurationsResponse()
        {
        }

        public GetCompatibleAudioSourceConfigurationsResponse(AudioSourceConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleVideoAnalyticsConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleVideoAnalyticsConfigurationsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ProfileToken;

        public GetCompatibleVideoAnalyticsConfigurationsRequest()
        {
        }

        public GetCompatibleVideoAnalyticsConfigurationsRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleVideoAnalyticsConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleVideoAnalyticsConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public VideoAnalyticsConfiguration[] Configurations;

        public GetCompatibleVideoAnalyticsConfigurationsResponse()
        {
        }

        public GetCompatibleVideoAnalyticsConfigurationsResponse(VideoAnalyticsConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleMetadataConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleMetadataConfigurationsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ProfileToken;

        public GetCompatibleMetadataConfigurationsRequest()
        {
        }

        public GetCompatibleMetadataConfigurationsRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleMetadataConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleMetadataConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public MetadataConfiguration[] Configurations;

        public GetCompatibleMetadataConfigurationsResponse()
        {
        }

        public GetCompatibleMetadataConfigurationsResponse(MetadataConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleAudioOutputConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleAudioOutputConfigurationsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ProfileToken;

        public GetCompatibleAudioOutputConfigurationsRequest()
        {
        }

        public GetCompatibleAudioOutputConfigurationsRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleAudioOutputConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleAudioOutputConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public AudioOutputConfiguration[] Configurations;

        public GetCompatibleAudioOutputConfigurationsResponse()
        {
        }

        public GetCompatibleAudioOutputConfigurationsResponse(AudioOutputConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleAudioDecoderConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleAudioDecoderConfigurationsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ProfileToken;

        public GetCompatibleAudioDecoderConfigurationsRequest()
        {
        }

        public GetCompatibleAudioDecoderConfigurationsRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleAudioDecoderConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetCompatibleAudioDecoderConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("Configurations")]
        public AudioDecoderConfiguration[] Configurations;

        public GetCompatibleAudioDecoderConfigurationsResponse()
        {
        }

        public GetCompatibleAudioDecoderConfigurationsResponse(AudioDecoderConfiguration[] Configurations)
        {
            this.Configurations = Configurations;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetGuaranteedNumberOfVideoEncoderInstances",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetGuaranteedNumberOfVideoEncoderInstancesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ConfigurationToken;

        public GetGuaranteedNumberOfVideoEncoderInstancesRequest()
        {
        }

        public GetGuaranteedNumberOfVideoEncoderInstancesRequest(string ConfigurationToken)
        {
            this.ConfigurationToken = ConfigurationToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetGuaranteedNumberOfVideoEncoderInstancesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetGuaranteedNumberOfVideoEncoderInstancesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 2)]
        public int H264;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 1)]
        public int JPEG;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 3)]
        public int MPEG4;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public int TotalNumber;

        public GetGuaranteedNumberOfVideoEncoderInstancesResponse()
        {
        }

        public GetGuaranteedNumberOfVideoEncoderInstancesResponse(int TotalNumber, int JPEG, int H264, int MPEG4)
        {
            this.TotalNumber = TotalNumber;
            this.JPEG = JPEG;
            this.H264 = H264;
            this.MPEG4 = MPEG4;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetVideoSourceModes",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetVideoSourceModesRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string VideoSourceToken;

        public GetVideoSourceModesRequest()
        {
        }

        public GetVideoSourceModesRequest(string VideoSourceToken)
        {
            this.VideoSourceToken = VideoSourceToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetVideoSourceModesResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetVideoSourceModesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("VideoSourceModes")]
        public VideoSourceMode[] VideoSourceModes;

        public GetVideoSourceModesResponse()
        {
        }

        public GetVideoSourceModesResponse(VideoSourceMode[] VideoSourceModes)
        {
            this.VideoSourceModes = VideoSourceModes;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetOSDs",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetOSDsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ConfigurationToken;

        public GetOSDsRequest()
        {
        }

        public GetOSDsRequest(string ConfigurationToken)
        {
            this.ConfigurationToken = ConfigurationToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetOSDsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetOSDsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        [XmlElement("OSDs")]
        public OSDConfiguration[] OSDs;

        public GetOSDsResponse()
        {
        }

        public GetOSDsResponse(OSDConfiguration[] OSDs)
        {
            this.OSDs = OSDs;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetOSD",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetOSDRequest
    {
        [MessageBodyMember(Namespace = "", Order = 1)]
        [XmlAnyElement()]
        public XElement[] Any;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string OSDToken;

        public GetOSDRequest()
        {
        }

        public GetOSDRequest(string OSDToken, XElement[] Any)
        {
            this.OSDToken = OSDToken;
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetOSDResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetOSDResponse
    {
        [MessageBodyMember(Namespace = "", Order = 1)]
        [XmlAnyElement()]
        public XElement[] Any;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public OSDConfiguration OSD;

        public GetOSDResponse()
        {
        }

        public GetOSDResponse(OSDConfiguration OSD, XElement[] Any)
        {
            this.OSD = OSD;
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetOSDOptions",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetOSDOptionsRequest
    {
        [MessageBodyMember(Namespace = "", Order = 1)]
        [XmlAnyElement()]
        public XElement[] Any;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string ConfigurationToken;

        public GetOSDOptionsRequest()
        {
        }

        public GetOSDOptionsRequest(string ConfigurationToken, XElement[] Any)
        {
            this.ConfigurationToken = ConfigurationToken;
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "GetOSDOptionsResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class GetOSDOptionsResponse
    {
        [MessageBodyMember(Namespace = "", Order = 1)]
        [XmlAnyElement()]
        public XElement[] Any;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public OSDConfigurationOptions OSDOptions;

        public GetOSDOptionsResponse()
        {
        }

        public GetOSDOptionsResponse(OSDConfigurationOptions OSDOptions, XElement[] Any)
        {
            this.OSDOptions = OSDOptions;
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "SetOSD",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class SetOSDRequest
    {
        [MessageBodyMember(Namespace = "", Order = 1)]
        [XmlAnyElement()]
        public XElement[] Any;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public OSDConfiguration OSD;

        public SetOSDRequest()
        {
        }

        public SetOSDRequest(OSDConfiguration OSD, XElement[] Any)
        {
            this.OSD = OSD;
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "SetOSDResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class SetOSDResponse
    {
        [MessageBodyMember(Namespace = "", Order = 0)]
        [XmlAnyElement()]
        public XElement[] Any;

        public SetOSDResponse()
        {
        }

        public SetOSDResponse(XElement[] Any)
        {
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "CreateOSD",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class CreateOSDRequest
    {
        [MessageBodyMember(Namespace = "", Order = 1)]
        [XmlAnyElement()]
        public XElement[] Any;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public OSDConfiguration OSD;

        public CreateOSDRequest()
        {
        }

        public CreateOSDRequest(OSDConfiguration OSD, XElement[] Any)
        {
            this.OSD = OSD;
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "CreateOSDResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class CreateOSDResponse
    {
        [MessageBodyMember(Namespace = "", Order = 1)]
        [XmlAnyElement()]
        public XElement[] Any;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string OSDToken;

        public CreateOSDResponse()
        {
        }

        public CreateOSDResponse(string OSDToken, XElement[] Any)
        {
            this.OSDToken = OSDToken;
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "DeleteOSD",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class DeleteOSDRequest
    {
        [MessageBodyMember(Namespace = "", Order = 1)]
        [XmlAnyElement()]
        public XElement[] Any;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver10/media/wsdl", Order = 0)]
        public string OSDToken;

        public DeleteOSDRequest()
        {
        }

        public DeleteOSDRequest(string OSDToken, XElement[] Any)
        {
            this.OSDToken = OSDToken;
            this.Any = Any;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "DeleteOSDResponse",
        WrapperNamespace = "http://www.onvif.org/ver10/media/wsdl", IsWrapped = true)]
    public partial class DeleteOSDResponse
    {
        [MessageBodyMember(Namespace = "", Order = 0)]
        [XmlAnyElement()]
        public XElement[] Any;

        public DeleteOSDResponse()
        {
        }

        public DeleteOSDResponse(XElement[] Any)
        {
            this.Any = Any;
        }
    }

    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    public interface MediaChannel : Media, IClientChannel
    {
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    public partial class MediaClient : ClientBase<Media>,
        Media
    {
        internal MediaClient(Binding binding,
            EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public Task<Capabilities> GetServiceCapabilitiesAsync()
        {
            return base.Channel.GetServiceCapabilitiesAsync();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetVideoSourcesResponse>
            Media.GetVideoSourcesAsync(
                GetVideoSourcesRequest request)
        {
            return base.Channel.GetVideoSourcesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetAudioSourcesResponse>
            Media.GetAudioSourcesAsync(
                GetAudioSourcesRequest request)
        {
            return base.Channel.GetAudioSourcesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetAudioOutputsResponse>
            Media.GetAudioOutputsAsync(
                GetAudioOutputsRequest request)
        {
            return base.Channel.GetAudioOutputsAsync(request);
        }

        public Task<Profile> CreateProfileAsync(string Name, string Token)
        {
            return base.Channel.CreateProfileAsync(Name, Token);
        }

        public Task<Profile> GetProfileAsync(string ProfileToken)
        {
            return base.Channel.GetProfileAsync(ProfileToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetProfilesResponse> Media
            .GetProfilesAsync(GetProfilesRequest request)
        {
            return base.Channel.GetProfilesAsync(request);
        }

        public Task AddVideoEncoderConfigurationAsync(string ProfileToken,
            string ConfigurationToken)
        {
            return base.Channel.AddVideoEncoderConfigurationAsync(ProfileToken, ConfigurationToken);
        }

        public Task RemoveVideoEncoderConfigurationAsync(string ProfileToken)
        {
            return base.Channel.RemoveVideoEncoderConfigurationAsync(ProfileToken);
        }

        public Task AddVideoSourceConfigurationAsync(string ProfileToken,
            string ConfigurationToken)
        {
            return base.Channel.AddVideoSourceConfigurationAsync(ProfileToken, ConfigurationToken);
        }

        public Task RemoveVideoSourceConfigurationAsync(string ProfileToken)
        {
            return base.Channel.RemoveVideoSourceConfigurationAsync(ProfileToken);
        }

        public Task AddAudioEncoderConfigurationAsync(string ProfileToken,
            string ConfigurationToken)
        {
            return base.Channel.AddAudioEncoderConfigurationAsync(ProfileToken, ConfigurationToken);
        }

        public Task RemoveAudioEncoderConfigurationAsync(string ProfileToken)
        {
            return base.Channel.RemoveAudioEncoderConfigurationAsync(ProfileToken);
        }

        public Task AddAudioSourceConfigurationAsync(string ProfileToken,
            string ConfigurationToken)
        {
            return base.Channel.AddAudioSourceConfigurationAsync(ProfileToken, ConfigurationToken);
        }

        public Task RemoveAudioSourceConfigurationAsync(string ProfileToken)
        {
            return base.Channel.RemoveAudioSourceConfigurationAsync(ProfileToken);
        }

        public Task AddPTZConfigurationAsync(string ProfileToken, string ConfigurationToken)
        {
            return base.Channel.AddPTZConfigurationAsync(ProfileToken, ConfigurationToken);
        }

        public Task RemovePTZConfigurationAsync(string ProfileToken)
        {
            return base.Channel.RemovePTZConfigurationAsync(ProfileToken);
        }

        public Task AddVideoAnalyticsConfigurationAsync(string ProfileToken,
            string ConfigurationToken)
        {
            return base.Channel.AddVideoAnalyticsConfigurationAsync(ProfileToken, ConfigurationToken);
        }

        public Task RemoveVideoAnalyticsConfigurationAsync(string ProfileToken)
        {
            return base.Channel.RemoveVideoAnalyticsConfigurationAsync(ProfileToken);
        }

        public Task AddMetadataConfigurationAsync(string ProfileToken, string ConfigurationToken)
        {
            return base.Channel.AddMetadataConfigurationAsync(ProfileToken, ConfigurationToken);
        }

        public Task RemoveMetadataConfigurationAsync(string ProfileToken)
        {
            return base.Channel.RemoveMetadataConfigurationAsync(ProfileToken);
        }

        public Task AddAudioOutputConfigurationAsync(string ProfileToken,
            string ConfigurationToken)
        {
            return base.Channel.AddAudioOutputConfigurationAsync(ProfileToken, ConfigurationToken);
        }

        public Task RemoveAudioOutputConfigurationAsync(string ProfileToken)
        {
            return base.Channel.RemoveAudioOutputConfigurationAsync(ProfileToken);
        }

        public Task AddAudioDecoderConfigurationAsync(string ProfileToken,
            string ConfigurationToken)
        {
            return base.Channel.AddAudioDecoderConfigurationAsync(ProfileToken, ConfigurationToken);
        }

        public Task RemoveAudioDecoderConfigurationAsync(string ProfileToken)
        {
            return base.Channel.RemoveAudioDecoderConfigurationAsync(ProfileToken);
        }

        public Task DeleteProfileAsync(string ProfileToken)
        {
            return base.Channel.DeleteProfileAsync(ProfileToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetVideoSourceConfigurationsResponse>
            Media.GetVideoSourceConfigurationsAsync(
                GetVideoSourceConfigurationsRequest request)
        {
            return base.Channel.GetVideoSourceConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetVideoEncoderConfigurationsResponse>
            Media.GetVideoEncoderConfigurationsAsync(
                GetVideoEncoderConfigurationsRequest request)
        {
            return base.Channel.GetVideoEncoderConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetAudioSourceConfigurationsResponse>
            Media.GetAudioSourceConfigurationsAsync(
                GetAudioSourceConfigurationsRequest request)
        {
            return base.Channel.GetAudioSourceConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetAudioEncoderConfigurationsResponse>
            Media.GetAudioEncoderConfigurationsAsync(
                GetAudioEncoderConfigurationsRequest request)
        {
            return base.Channel.GetAudioEncoderConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetVideoAnalyticsConfigurationsResponse>
            Media.GetVideoAnalyticsConfigurationsAsync(
                GetVideoAnalyticsConfigurationsRequest request)
        {
            return base.Channel.GetVideoAnalyticsConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetMetadataConfigurationsResponse>
            Media.GetMetadataConfigurationsAsync(
                GetMetadataConfigurationsRequest request)
        {
            return base.Channel.GetMetadataConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetAudioOutputConfigurationsResponse>
            Media.GetAudioOutputConfigurationsAsync(
                GetAudioOutputConfigurationsRequest request)
        {
            return base.Channel.GetAudioOutputConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetAudioDecoderConfigurationsResponse>
            Media.GetAudioDecoderConfigurationsAsync(
                GetAudioDecoderConfigurationsRequest request)
        {
            return base.Channel.GetAudioDecoderConfigurationsAsync(request);
        }

        public Task<VideoSourceConfiguration> GetVideoSourceConfigurationAsync(
            string ConfigurationToken)
        {
            return base.Channel.GetVideoSourceConfigurationAsync(ConfigurationToken);
        }

        public Task<VideoEncoderConfiguration> GetVideoEncoderConfigurationAsync(
            string ConfigurationToken)
        {
            return base.Channel.GetVideoEncoderConfigurationAsync(ConfigurationToken);
        }

        public Task<AudioSourceConfiguration> GetAudioSourceConfigurationAsync(
            string ConfigurationToken)
        {
            return base.Channel.GetAudioSourceConfigurationAsync(ConfigurationToken);
        }

        public Task<AudioEncoderConfiguration> GetAudioEncoderConfigurationAsync(
            string ConfigurationToken)
        {
            return base.Channel.GetAudioEncoderConfigurationAsync(ConfigurationToken);
        }

        public Task<VideoAnalyticsConfiguration> GetVideoAnalyticsConfigurationAsync(
            string ConfigurationToken)
        {
            return base.Channel.GetVideoAnalyticsConfigurationAsync(ConfigurationToken);
        }

        public Task<MetadataConfiguration> GetMetadataConfigurationAsync(
            string ConfigurationToken)
        {
            return base.Channel.GetMetadataConfigurationAsync(ConfigurationToken);
        }

        public Task<AudioOutputConfiguration> GetAudioOutputConfigurationAsync(
            string ConfigurationToken)
        {
            return base.Channel.GetAudioOutputConfigurationAsync(ConfigurationToken);
        }

        public Task<AudioDecoderConfiguration> GetAudioDecoderConfigurationAsync(
            string ConfigurationToken)
        {
            return base.Channel.GetAudioDecoderConfigurationAsync(ConfigurationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCompatibleVideoEncoderConfigurationsResponse>
            Media.GetCompatibleVideoEncoderConfigurationsAsync(
                GetCompatibleVideoEncoderConfigurationsRequest request)
        {
            return base.Channel.GetCompatibleVideoEncoderConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCompatibleVideoSourceConfigurationsResponse>
            Media.GetCompatibleVideoSourceConfigurationsAsync(
                GetCompatibleVideoSourceConfigurationsRequest request)
        {
            return base.Channel.GetCompatibleVideoSourceConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCompatibleAudioEncoderConfigurationsResponse>
            Media.GetCompatibleAudioEncoderConfigurationsAsync(
                GetCompatibleAudioEncoderConfigurationsRequest request)
        {
            return base.Channel.GetCompatibleAudioEncoderConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCompatibleAudioSourceConfigurationsResponse>
            Media.GetCompatibleAudioSourceConfigurationsAsync(
                GetCompatibleAudioSourceConfigurationsRequest request)
        {
            return base.Channel.GetCompatibleAudioSourceConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCompatibleVideoAnalyticsConfigurationsResponse>
            Media.GetCompatibleVideoAnalyticsConfigurationsAsync(
                GetCompatibleVideoAnalyticsConfigurationsRequest request)
        {
            return base.Channel.GetCompatibleVideoAnalyticsConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCompatibleMetadataConfigurationsResponse>
            Media.GetCompatibleMetadataConfigurationsAsync(
                GetCompatibleMetadataConfigurationsRequest request)
        {
            return base.Channel.GetCompatibleMetadataConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCompatibleAudioOutputConfigurationsResponse>
            Media.GetCompatibleAudioOutputConfigurationsAsync(
                GetCompatibleAudioOutputConfigurationsRequest request)
        {
            return base.Channel.GetCompatibleAudioOutputConfigurationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCompatibleAudioDecoderConfigurationsResponse>
            Media.GetCompatibleAudioDecoderConfigurationsAsync(
                GetCompatibleAudioDecoderConfigurationsRequest request)
        {
            return base.Channel.GetCompatibleAudioDecoderConfigurationsAsync(request);
        }

        public Task SetVideoSourceConfigurationAsync(VideoSourceConfiguration Configuration,
            bool ForcePersistence)
        {
            return base.Channel.SetVideoSourceConfigurationAsync(Configuration, ForcePersistence);
        }

        public Task SetVideoEncoderConfigurationAsync(VideoEncoderConfiguration Configuration,
            bool ForcePersistence)
        {
            return base.Channel.SetVideoEncoderConfigurationAsync(Configuration, ForcePersistence);
        }

        public Task SetAudioSourceConfigurationAsync(AudioSourceConfiguration Configuration,
            bool ForcePersistence)
        {
            return base.Channel.SetAudioSourceConfigurationAsync(Configuration, ForcePersistence);
        }

        public Task SetAudioEncoderConfigurationAsync(AudioEncoderConfiguration Configuration,
            bool ForcePersistence)
        {
            return base.Channel.SetAudioEncoderConfigurationAsync(Configuration, ForcePersistence);
        }

        public Task SetVideoAnalyticsConfigurationAsync(
            VideoAnalyticsConfiguration Configuration, bool ForcePersistence)
        {
            return base.Channel.SetVideoAnalyticsConfigurationAsync(Configuration, ForcePersistence);
        }

        public Task SetMetadataConfigurationAsync(MetadataConfiguration Configuration,
            bool ForcePersistence)
        {
            return base.Channel.SetMetadataConfigurationAsync(Configuration, ForcePersistence);
        }

        public Task SetAudioOutputConfigurationAsync(AudioOutputConfiguration Configuration,
            bool ForcePersistence)
        {
            return base.Channel.SetAudioOutputConfigurationAsync(Configuration, ForcePersistence);
        }

        public Task SetAudioDecoderConfigurationAsync(AudioDecoderConfiguration Configuration,
            bool ForcePersistence)
        {
            return base.Channel.SetAudioDecoderConfigurationAsync(Configuration, ForcePersistence);
        }

        public Task<VideoSourceConfigurationOptions> GetVideoSourceConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken)
        {
            return base.Channel.GetVideoSourceConfigurationOptionsAsync(ConfigurationToken, ProfileToken);
        }

        public Task<VideoEncoderConfigurationOptions> GetVideoEncoderConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken)
        {
            return base.Channel.GetVideoEncoderConfigurationOptionsAsync(ConfigurationToken, ProfileToken);
        }

        public Task<AudioSourceConfigurationOptions> GetAudioSourceConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken)
        {
            return base.Channel.GetAudioSourceConfigurationOptionsAsync(ConfigurationToken, ProfileToken);
        }

        public Task<AudioEncoderConfigurationOptions> GetAudioEncoderConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken)
        {
            return base.Channel.GetAudioEncoderConfigurationOptionsAsync(ConfigurationToken, ProfileToken);
        }

        public Task<MetadataConfigurationOptions> GetMetadataConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken)
        {
            return base.Channel.GetMetadataConfigurationOptionsAsync(ConfigurationToken, ProfileToken);
        }

        public Task<AudioOutputConfigurationOptions> GetAudioOutputConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken)
        {
            return base.Channel.GetAudioOutputConfigurationOptionsAsync(ConfigurationToken, ProfileToken);
        }

        public Task<AudioDecoderConfigurationOptions> GetAudioDecoderConfigurationOptionsAsync(
            string ConfigurationToken, string ProfileToken)
        {
            return base.Channel.GetAudioDecoderConfigurationOptionsAsync(ConfigurationToken, ProfileToken);
        }

        public
            Task<GetGuaranteedNumberOfVideoEncoderInstancesResponse>
            GetGuaranteedNumberOfVideoEncoderInstancesAsync(
                GetGuaranteedNumberOfVideoEncoderInstancesRequest request)
        {
            return base.Channel.GetGuaranteedNumberOfVideoEncoderInstancesAsync(request);
        }

        public Task<MediaUri> GetStreamUriAsync(StreamSetup StreamSetup, string ProfileToken)
        {
            return base.Channel.GetStreamUriAsync(StreamSetup, ProfileToken);
        }

        public Task StartMulticastStreamingAsync(string ProfileToken)
        {
            return base.Channel.StartMulticastStreamingAsync(ProfileToken);
        }

        public Task StopMulticastStreamingAsync(string ProfileToken)
        {
            return base.Channel.StopMulticastStreamingAsync(ProfileToken);
        }

        public Task SetSynchronizationPointAsync(string ProfileToken)
        {
            return base.Channel.SetSynchronizationPointAsync(ProfileToken);
        }

        public Task<MediaUri> GetSnapshotUriAsync(string ProfileToken)
        {
            return base.Channel.GetSnapshotUriAsync(ProfileToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetVideoSourceModesResponse>
            Media.GetVideoSourceModesAsync(
                GetVideoSourceModesRequest request)
        {
            return base.Channel.GetVideoSourceModesAsync(request);
        }

        public Task<bool> SetVideoSourceModeAsync(string VideoSourceToken,
            string VideoSourceModeToken)
        {
            return base.Channel.SetVideoSourceModeAsync(VideoSourceToken, VideoSourceModeToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetOSDsResponse> Media.
            GetOSDsAsync(GetOSDsRequest request)
        {
            return base.Channel.GetOSDsAsync(request);
        }

        public Task<GetOSDResponse> GetOSDAsync(
            GetOSDRequest request)
        {
            return base.Channel.GetOSDAsync(request);
        }

        public Task<GetOSDOptionsResponse> GetOSDOptionsAsync(
            GetOSDOptionsRequest request)
        {
            return base.Channel.GetOSDOptionsAsync(request);
        }

        public Task<SetOSDResponse> SetOSDAsync(
            SetOSDRequest request)
        {
            return base.Channel.SetOSDAsync(request);
        }

        public Task<CreateOSDResponse> CreateOSDAsync(
            CreateOSDRequest request)
        {
            return base.Channel.CreateOSDAsync(request);
        }

        public Task<DeleteOSDResponse> DeleteOSDAsync(
            DeleteOSDRequest request)
        {
            return base.Channel.DeleteOSDAsync(request);
        }

        public Task<GetVideoSourcesResponse> GetVideoSourcesAsync()
        {
            GetVideoSourcesRequest inValue =
                new GetVideoSourcesRequest();
            return ((Media) (this)).GetVideoSourcesAsync(inValue);
        }

        public Task<GetAudioSourcesResponse> GetAudioSourcesAsync()
        {
            GetAudioSourcesRequest inValue =
                new GetAudioSourcesRequest();
            return ((Media) (this)).GetAudioSourcesAsync(inValue);
        }

        public Task<GetAudioOutputsResponse> GetAudioOutputsAsync()
        {
            GetAudioOutputsRequest inValue =
                new GetAudioOutputsRequest();
            return ((Media) (this)).GetAudioOutputsAsync(inValue);
        }

        public Task<GetProfilesResponse> GetProfilesAsync()
        {
            GetProfilesRequest inValue =
                new GetProfilesRequest();
            return ((Media) (this)).GetProfilesAsync(inValue);
        }

        public Task<GetVideoSourceConfigurationsResponse>
            GetVideoSourceConfigurationsAsync()
        {
            GetVideoSourceConfigurationsRequest inValue =
                new GetVideoSourceConfigurationsRequest();
            return ((Media) (this)).GetVideoSourceConfigurationsAsync(inValue);
        }

        public Task<GetVideoEncoderConfigurationsResponse>
            GetVideoEncoderConfigurationsAsync()
        {
            GetVideoEncoderConfigurationsRequest inValue =
                new GetVideoEncoderConfigurationsRequest();
            return ((Media) (this)).GetVideoEncoderConfigurationsAsync(inValue);
        }

        public Task<GetAudioSourceConfigurationsResponse>
            GetAudioSourceConfigurationsAsync()
        {
            GetAudioSourceConfigurationsRequest inValue =
                new GetAudioSourceConfigurationsRequest();
            return ((Media) (this)).GetAudioSourceConfigurationsAsync(inValue);
        }

        public Task<GetAudioEncoderConfigurationsResponse>
            GetAudioEncoderConfigurationsAsync()
        {
            GetAudioEncoderConfigurationsRequest inValue =
                new GetAudioEncoderConfigurationsRequest();
            return ((Media) (this)).GetAudioEncoderConfigurationsAsync(inValue);
        }

        public Task<GetVideoAnalyticsConfigurationsResponse>
            GetVideoAnalyticsConfigurationsAsync()
        {
            GetVideoAnalyticsConfigurationsRequest inValue =
                new GetVideoAnalyticsConfigurationsRequest();
            return ((Media) (this)).GetVideoAnalyticsConfigurationsAsync(inValue);
        }

        public Task<GetMetadataConfigurationsResponse>
            GetMetadataConfigurationsAsync()
        {
            GetMetadataConfigurationsRequest inValue =
                new GetMetadataConfigurationsRequest();
            return ((Media) (this)).GetMetadataConfigurationsAsync(inValue);
        }

        public Task<GetAudioOutputConfigurationsResponse>
            GetAudioOutputConfigurationsAsync()
        {
            GetAudioOutputConfigurationsRequest inValue =
                new GetAudioOutputConfigurationsRequest();
            return ((Media) (this)).GetAudioOutputConfigurationsAsync(inValue);
        }

        public Task<GetAudioDecoderConfigurationsResponse>
            GetAudioDecoderConfigurationsAsync()
        {
            GetAudioDecoderConfigurationsRequest inValue =
                new GetAudioDecoderConfigurationsRequest();
            return ((Media) (this)).GetAudioDecoderConfigurationsAsync(inValue);
        }

        public Task<GetCompatibleVideoEncoderConfigurationsResponse>
            GetCompatibleVideoEncoderConfigurationsAsync(string ProfileToken)
        {
            GetCompatibleVideoEncoderConfigurationsRequest inValue =
                new GetCompatibleVideoEncoderConfigurationsRequest();
            inValue.ProfileToken = ProfileToken;
            return ((Media) (this)).GetCompatibleVideoEncoderConfigurationsAsync(inValue);
        }

        public Task<GetCompatibleVideoSourceConfigurationsResponse>
            GetCompatibleVideoSourceConfigurationsAsync(string ProfileToken)
        {
            GetCompatibleVideoSourceConfigurationsRequest inValue =
                new GetCompatibleVideoSourceConfigurationsRequest();
            inValue.ProfileToken = ProfileToken;
            return ((Media) (this)).GetCompatibleVideoSourceConfigurationsAsync(inValue);
        }

        public Task<GetCompatibleAudioEncoderConfigurationsResponse>
            GetCompatibleAudioEncoderConfigurationsAsync(string ProfileToken)
        {
            GetCompatibleAudioEncoderConfigurationsRequest inValue =
                new GetCompatibleAudioEncoderConfigurationsRequest();
            inValue.ProfileToken = ProfileToken;
            return ((Media) (this)).GetCompatibleAudioEncoderConfigurationsAsync(inValue);
        }

        public Task<GetCompatibleAudioSourceConfigurationsResponse>
            GetCompatibleAudioSourceConfigurationsAsync(string ProfileToken)
        {
            GetCompatibleAudioSourceConfigurationsRequest inValue =
                new GetCompatibleAudioSourceConfigurationsRequest();
            inValue.ProfileToken = ProfileToken;
            return ((Media) (this)).GetCompatibleAudioSourceConfigurationsAsync(inValue);
        }

        public Task<
                GetCompatibleVideoAnalyticsConfigurationsResponse>
            GetCompatibleVideoAnalyticsConfigurationsAsync(string ProfileToken)
        {
            GetCompatibleVideoAnalyticsConfigurationsRequest inValue =
                new GetCompatibleVideoAnalyticsConfigurationsRequest();
            inValue.ProfileToken = ProfileToken;
            return ((Media) (this))
                .GetCompatibleVideoAnalyticsConfigurationsAsync(inValue);
        }

        public Task<GetCompatibleMetadataConfigurationsResponse>
            GetCompatibleMetadataConfigurationsAsync(string ProfileToken)
        {
            GetCompatibleMetadataConfigurationsRequest inValue =
                new GetCompatibleMetadataConfigurationsRequest();
            inValue.ProfileToken = ProfileToken;
            return ((Media) (this)).GetCompatibleMetadataConfigurationsAsync(inValue);
        }

        public Task<GetCompatibleAudioOutputConfigurationsResponse>
            GetCompatibleAudioOutputConfigurationsAsync(string ProfileToken)
        {
            GetCompatibleAudioOutputConfigurationsRequest inValue =
                new GetCompatibleAudioOutputConfigurationsRequest();
            inValue.ProfileToken = ProfileToken;
            return ((Media) (this)).GetCompatibleAudioOutputConfigurationsAsync(inValue);
        }

        public Task<GetCompatibleAudioDecoderConfigurationsResponse>
            GetCompatibleAudioDecoderConfigurationsAsync(string ProfileToken)
        {
            GetCompatibleAudioDecoderConfigurationsRequest inValue =
                new GetCompatibleAudioDecoderConfigurationsRequest();
            inValue.ProfileToken = ProfileToken;
            return ((Media) (this)).GetCompatibleAudioDecoderConfigurationsAsync(inValue);
        }

        public Task<GetVideoSourceModesResponse>
            GetVideoSourceModesAsync(string VideoSourceToken)
        {
            GetVideoSourceModesRequest inValue =
                new GetVideoSourceModesRequest();
            inValue.VideoSourceToken = VideoSourceToken;
            return ((Media) (this)).GetVideoSourceModesAsync(inValue);
        }

        public Task<GetOSDsResponse> GetOSDsAsync(
            string ConfigurationToken)
        {
            GetOSDsRequest inValue = new GetOSDsRequest();
            inValue.ConfigurationToken = ConfigurationToken;
            return ((Media) (this)).GetOSDsAsync(inValue);
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
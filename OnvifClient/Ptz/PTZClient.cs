using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mictlanix.DotNet.Onvif.Common;

namespace Mictlanix.DotNet.Onvif.Ptz
{
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [ServiceContract(Namespace = "http://www.onvif.org/ver20/ptz/wsdl",
        ConfigurationName = "Mictlanix.DotNet.Onvif.Ptz.PTZ")]
    public interface PTZ
    {
        [OperationContract(
            Action = "http://www.onvif.org/ver20/ptz/wsdl/GetServiceCapabilities", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Capabilities")]
        Task<Capabilities> GetServiceCapabilitiesAsync();

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/GetNodes",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetNodesResponse> GetNodesAsync(
            GetNodesRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/GetNode",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "PTZNode")]
        Task<PTZNode> GetNodeAsync(string NodeToken);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/GetConfiguration",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "PTZConfiguration")]
        Task<PTZConfiguration> GetConfigurationAsync(string PTZConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver20/ptz/wsdl/GetConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetConfigurationsResponse> GetConfigurationsAsync(
            GetConfigurationsRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/SetConfiguration",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetConfigurationAsync(PTZConfiguration PTZConfiguration, bool ForcePersistence);

        [OperationContract(
            Action = "http://www.onvif.org/ver20/ptz/wsdl/GetConfigurationOptions", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "PTZConfigurationOptions")]
        Task<PTZConfigurationOptions> GetConfigurationOptionsAsync(string ConfigurationToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver20/ptz/wsdl/SendAuxiliaryCommand", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "AuxiliaryResponse")]
        Task<string> SendAuxiliaryCommandAsync(string ProfileToken, string AuxiliaryData);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/GetPresets",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetPresetsResponse> GetPresetsAsync(
            GetPresetsRequest request);

        // CODEGEN: Generating message contract since the operation has multiple return values.
        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/SetPreset",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<SetPresetResponse> SetPresetAsync(
            SetPresetRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/RemovePreset",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemovePresetAsync(string ProfileToken, string PresetToken);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/GotoPreset",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task GotoPresetAsync(string ProfileToken, string PresetToken, PTZSpeed Speed);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/GotoHomePosition",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task GotoHomePositionAsync(string ProfileToken, PTZSpeed Speed);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/SetHomePosition",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task SetHomePositionAsync(string ProfileToken);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/ContinuousMove",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<ContinuousMoveResponse> ContinuousMoveAsync(
            ContinuousMoveRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/RelativeMove",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RelativeMoveAsync(string ProfileToken, PTZVector Translation, PTZSpeed Speed);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/GetStatus",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "PTZStatus")]
        Task<PTZStatus> GetStatusAsync(string ProfileToken);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/AbsoluteMove",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task AbsoluteMoveAsync(string ProfileToken, PTZVector Position, PTZSpeed Speed);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/GeoMove",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task GeoMoveAsync(string ProfileToken, GeoLocation Target, PTZSpeed Speed,
            float AreaHeight, float AreaWidth);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/Stop",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task StopAsync(string ProfileToken, bool PanTilt, bool Zoom);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/GetPresetTours",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetPresetToursResponse> GetPresetToursAsync(
            GetPresetToursRequest request);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/GetPresetTour",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "PresetTour")]
        Task<PresetTour> GetPresetTourAsync(string ProfileToken, string PresetTourToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver20/ptz/wsdl/GetPresetTourOptions", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "Options")]
        Task<PTZPresetTourOptions> GetPresetTourOptionsAsync(string ProfileToken,
            string PresetTourToken);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/CreatePresetTour",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        [return: MessageParameter(Name = "PresetTourToken")]
        Task<string> CreatePresetTourAsync(string ProfileToken);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/ModifyPresetTour",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task ModifyPresetTourAsync(string ProfileToken, PresetTour PresetTour);

        [OperationContract(
            Action = "http://www.onvif.org/ver20/ptz/wsdl/OperatePresetTour", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task OperatePresetTourAsync(string ProfileToken, string PresetTourToken,
            PTZPresetTourOperation Operation);

        [OperationContract(Action = "http://www.onvif.org/ver20/ptz/wsdl/RemovePresetTour",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task RemovePresetTourAsync(string ProfileToken, string PresetTourToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver20/ptz/wsdl/GetCompatibleConfigurations", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof(ConfigurationEntity))]
        [ServiceKnownType(typeof(DeviceEntity))]
        Task<GetCompatibleConfigurationsResponse>
            GetCompatibleConfigurationsAsync(GetCompatibleConfigurationsRequest request);
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetNodes",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class GetNodesRequest
    {
        public GetNodesRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetNodesResponse",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class GetNodesResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        [XmlElement("PTZNode")]
        public PTZNode[] PTZNode;

        public GetNodesResponse()
        {
        }

        public GetNodesResponse(PTZNode[] PTZNode)
        {
            this.PTZNode = PTZNode;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class GetConfigurationsRequest
    {
        public GetConfigurationsRequest()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class GetConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        [XmlElement("PTZConfiguration")]
        public PTZConfiguration[] PTZConfiguration;

        public GetConfigurationsResponse()
        {
        }

        public GetConfigurationsResponse(PTZConfiguration[] PTZConfiguration)
        {
            this.PTZConfiguration = PTZConfiguration;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetPresets",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class GetPresetsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        public string ProfileToken;

        public GetPresetsRequest()
        {
        }

        public GetPresetsRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetPresetsResponse",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class GetPresetsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        [XmlElement("Preset")]
        public PTZPreset[] Preset;

        public GetPresetsResponse()
        {
        }

        public GetPresetsResponse(PTZPreset[] Preset)
        {
            this.Preset = Preset;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "SetPreset",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class SetPresetRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 1)]
        public string PresetName;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 2)]
        public string PresetToken;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        public string ProfileToken;

        public SetPresetRequest()
        {
        }

        public SetPresetRequest(string ProfileToken, string PresetName, string PresetToken)
        {
            this.ProfileToken = ProfileToken;
            this.PresetName = PresetName;
            this.PresetToken = PresetToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [MessageContract(WrapperName = "SetPresetResponse",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class SetPresetResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        public string PresetToken;

        public SetPresetResponse()
        {
        }

        public SetPresetResponse(string PresetToken)
        {
            this.PresetToken = PresetToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "ContinuousMove",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class ContinuousMoveRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        public string ProfileToken;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 2)]
        [XmlElement(DataType = "duration")]
        public string Timeout;

        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 1)]
        public PTZSpeed Velocity;

        public ContinuousMoveRequest()
        {
        }

        public ContinuousMoveRequest(string ProfileToken, PTZSpeed Velocity, string Timeout)
        {
            this.ProfileToken = ProfileToken;
            this.Velocity = Velocity;
            this.Timeout = Timeout;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "ContinuousMoveResponse",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class ContinuousMoveResponse
    {
        public ContinuousMoveResponse()
        {
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetPresetTours",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class GetPresetToursRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        public string ProfileToken;

        public GetPresetToursRequest()
        {
        }

        public GetPresetToursRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetPresetToursResponse",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class GetPresetToursResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        [XmlElement("PresetTour")]
        public PresetTour[] PresetTour;

        public GetPresetToursResponse()
        {
        }

        public GetPresetToursResponse(PresetTour[] PresetTour)
        {
            this.PresetTour = PresetTour;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleConfigurations",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class GetCompatibleConfigurationsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        public string ProfileToken;

        public GetCompatibleConfigurationsRequest()
        {
        }

        public GetCompatibleConfigurationsRequest(string ProfileToken)
        {
            this.ProfileToken = ProfileToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetCompatibleConfigurationsResponse",
        WrapperNamespace = "http://www.onvif.org/ver20/ptz/wsdl", IsWrapped = true)]
    public partial class GetCompatibleConfigurationsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", Order = 0)]
        [XmlElement("PTZConfiguration")]
        public PTZConfiguration[] PTZConfiguration;

        public GetCompatibleConfigurationsResponse()
        {
        }

        public GetCompatibleConfigurationsResponse(PTZConfiguration[] PTZConfiguration)
        {
            this.PTZConfiguration = PTZConfiguration;
        }
    }

    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    public interface PTZChannel : PTZ, IClientChannel
    {
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    public partial class PTZClient : ClientBase<PTZ>,
        PTZ
    {
        internal PTZClient(Binding binding,
            EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public Task<Capabilities> GetServiceCapabilitiesAsync()
        {
            return base.Channel.GetServiceCapabilitiesAsync();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetNodesResponse> PTZ.
            GetNodesAsync(GetNodesRequest request)
        {
            return base.Channel.GetNodesAsync(request);
        }

        public Task<PTZNode> GetNodeAsync(string NodeToken)
        {
            return base.Channel.GetNodeAsync(NodeToken);
        }

        public Task<PTZConfiguration> GetConfigurationAsync(string PTZConfigurationToken)
        {
            return base.Channel.GetConfigurationAsync(PTZConfigurationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetConfigurationsResponse> PTZ
            .GetConfigurationsAsync(GetConfigurationsRequest request)
        {
            return base.Channel.GetConfigurationsAsync(request);
        }

        public Task SetConfigurationAsync(PTZConfiguration PTZConfiguration,
            bool ForcePersistence)
        {
            return base.Channel.SetConfigurationAsync(PTZConfiguration, ForcePersistence);
        }

        public Task<PTZConfigurationOptions> GetConfigurationOptionsAsync(
            string ConfigurationToken)
        {
            return base.Channel.GetConfigurationOptionsAsync(ConfigurationToken);
        }

        public Task<string> SendAuxiliaryCommandAsync(string ProfileToken, string AuxiliaryData)
        {
            return base.Channel.SendAuxiliaryCommandAsync(ProfileToken, AuxiliaryData);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetPresetsResponse> PTZ.
            GetPresetsAsync(GetPresetsRequest request)
        {
            return base.Channel.GetPresetsAsync(request);
        }

        public Task<SetPresetResponse> SetPresetAsync(
            SetPresetRequest request)
        {
            return base.Channel.SetPresetAsync(request);
        }

        public Task RemovePresetAsync(string ProfileToken, string PresetToken)
        {
            return base.Channel.RemovePresetAsync(ProfileToken, PresetToken);
        }

        public Task GotoPresetAsync(string ProfileToken, string PresetToken, PTZSpeed Speed)
        {
            return base.Channel.GotoPresetAsync(ProfileToken, PresetToken, Speed);
        }

        public Task GotoHomePositionAsync(string ProfileToken, PTZSpeed Speed)
        {
            return base.Channel.GotoHomePositionAsync(ProfileToken, Speed);
        }

        public Task SetHomePositionAsync(string ProfileToken)
        {
            return base.Channel.SetHomePositionAsync(ProfileToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ContinuousMoveResponse> PTZ.
            ContinuousMoveAsync(ContinuousMoveRequest request)
        {
            return base.Channel.ContinuousMoveAsync(request);
        }

        public Task RelativeMoveAsync(string ProfileToken, PTZVector Translation, PTZSpeed Speed)
        {
            return base.Channel.RelativeMoveAsync(ProfileToken, Translation, Speed);
        }

        public Task<PTZStatus> GetStatusAsync(string ProfileToken)
        {
            return base.Channel.GetStatusAsync(ProfileToken);
        }

        public Task AbsoluteMoveAsync(string ProfileToken, PTZVector Position, PTZSpeed Speed)
        {
            return base.Channel.AbsoluteMoveAsync(ProfileToken, Position, Speed);
        }

        public Task GeoMoveAsync(string ProfileToken, GeoLocation Target, PTZSpeed Speed,
            float AreaHeight, float AreaWidth)
        {
            return base.Channel.GeoMoveAsync(ProfileToken, Target, Speed, AreaHeight, AreaWidth);
        }

        public Task StopAsync(string ProfileToken, bool PanTilt, bool Zoom)
        {
            return base.Channel.StopAsync(ProfileToken, PanTilt, Zoom);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetPresetToursResponse> PTZ.
            GetPresetToursAsync(GetPresetToursRequest request)
        {
            return base.Channel.GetPresetToursAsync(request);
        }

        public Task<PresetTour> GetPresetTourAsync(string ProfileToken, string PresetTourToken)
        {
            return base.Channel.GetPresetTourAsync(ProfileToken, PresetTourToken);
        }

        public Task<PTZPresetTourOptions> GetPresetTourOptionsAsync(string ProfileToken,
            string PresetTourToken)
        {
            return base.Channel.GetPresetTourOptionsAsync(ProfileToken, PresetTourToken);
        }

        public Task<string> CreatePresetTourAsync(string ProfileToken)
        {
            return base.Channel.CreatePresetTourAsync(ProfileToken);
        }

        public Task ModifyPresetTourAsync(string ProfileToken, PresetTour PresetTour)
        {
            return base.Channel.ModifyPresetTourAsync(ProfileToken, PresetTour);
        }

        public Task OperatePresetTourAsync(string ProfileToken, string PresetTourToken,
            PTZPresetTourOperation Operation)
        {
            return base.Channel.OperatePresetTourAsync(ProfileToken, PresetTourToken, Operation);
        }

        public Task RemovePresetTourAsync(string ProfileToken, string PresetTourToken)
        {
            return base.Channel.RemovePresetTourAsync(ProfileToken, PresetTourToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetCompatibleConfigurationsResponse>
            PTZ.GetCompatibleConfigurationsAsync(
                GetCompatibleConfigurationsRequest request)
        {
            return base.Channel.GetCompatibleConfigurationsAsync(request);
        }

        public Task<GetNodesResponse> GetNodesAsync()
        {
            GetNodesRequest inValue = new GetNodesRequest();
            return ((PTZ) (this)).GetNodesAsync(inValue);
        }

        public Task<GetConfigurationsResponse>
            GetConfigurationsAsync()
        {
            GetConfigurationsRequest inValue =
                new GetConfigurationsRequest();
            return ((PTZ) (this)).GetConfigurationsAsync(inValue);
        }

        public Task<GetPresetsResponse> GetPresetsAsync(
            string ProfileToken)
        {
            GetPresetsRequest inValue = new GetPresetsRequest();
            inValue.ProfileToken = ProfileToken;
            return ((PTZ) (this)).GetPresetsAsync(inValue);
        }

        public Task<ContinuousMoveResponse> ContinuousMoveAsync(
            string ProfileToken, PTZSpeed Velocity, string Timeout)
        {
            ContinuousMoveRequest inValue =
                new ContinuousMoveRequest();
            inValue.ProfileToken = ProfileToken;
            inValue.Velocity = Velocity;
            inValue.Timeout = Timeout;
            return ((PTZ) (this)).ContinuousMoveAsync(inValue);
        }

        public Task<GetPresetToursResponse> GetPresetToursAsync(
            string ProfileToken)
        {
            GetPresetToursRequest inValue =
                new GetPresetToursRequest();
            inValue.ProfileToken = ProfileToken;
            return ((PTZ) (this)).GetPresetToursAsync(inValue);
        }

        public Task<GetCompatibleConfigurationsResponse>
            GetCompatibleConfigurationsAsync(string ProfileToken)
        {
            GetCompatibleConfigurationsRequest inValue =
                new GetCompatibleConfigurationsRequest();
            inValue.ProfileToken = ProfileToken;
            return ((PTZ) (this)).GetCompatibleConfigurationsAsync(inValue);
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
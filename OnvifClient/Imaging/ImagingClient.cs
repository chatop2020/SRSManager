using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mictlanix.DotNet.Onvif.Common;

namespace Mictlanix.DotNet.Onvif.Imaging
{
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [ServiceContract(Namespace = "http://www.onvif.org/ver20/imaging/wsdl",
        ConfigurationName = "Mictlanix.DotNet.Onvif.Imaging.Imaging")]
    public interface Imaging
    {
        [OperationContract(
            Action = "http://www.onvif.org/ver20/imaging/wsdl/GetServiceCapabilities", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [return: MessageParameter(Name = "Capabilities")]
        Task<Capabilities> GetServiceCapabilitiesAsync();

        [OperationContract(
            Action = "http://www.onvif.org/ver20/imaging/wsdl/GetImagingSettings", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [return: MessageParameter(Name = "ImagingSettings")]
        Task<ImagingSettings20> GetImagingSettingsAsync(string VideoSourceToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver20/imaging/wsdl/SetImagingSettings", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        Task SetImagingSettingsAsync(string VideoSourceToken, ImagingSettings20 ImagingSettings,
            bool ForcePersistence);

        [OperationContract(Action = "http://www.onvif.org/ver20/imaging/wsdl/GetOptions",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [return: MessageParameter(Name = "ImagingOptions")]
        Task<ImagingOptions20> GetOptionsAsync(string VideoSourceToken);

        [OperationContract(Action = "http://www.onvif.org/ver20/imaging/wsdl/Move",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        Task MoveAsync(string VideoSourceToken, FocusMove Focus);

        [OperationContract(
            Action = "http://www.onvif.org/ver20/imaging/wsdl/GetMoveOptions", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [return: MessageParameter(Name = "MoveOptions")]
        Task<MoveOptions20> GetMoveOptionsAsync(string VideoSourceToken);

        [OperationContract(Action = "http://www.onvif.org/ver20/imaging/wsdl/FocusStop",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        Task StopAsync(string VideoSourceToken);

        [OperationContract(Action = "http://www.onvif.org/ver20/imaging/wsdl/GetStatus",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [return: MessageParameter(Name = "Status")]
        Task<ImagingStatus20> GetStatusAsync(string VideoSourceToken);

        [OperationContract(Action = "http://www.onvif.org/ver20/imaging/wsdl/GetPresets",
            ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        Task<GetPresetsResponse> GetPresetsAsync(
            GetPresetsRequest request);

        [OperationContract(
            Action = "http://www.onvif.org/ver20/imaging/wsdl/GetCurrentPreset", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        [return: MessageParameter(Name = "Preset")]
        Task<ImagingPreset> GetCurrentPresetAsync(string VideoSourceToken);

        [OperationContract(
            Action = "http://www.onvif.org/ver20/imaging/wsdl/SetCurrentPreset", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        Task SetCurrentPresetAsync(string VideoSourceToken, string PresetToken);
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetPresets",
        WrapperNamespace = "http://www.onvif.org/ver20/imaging/wsdl", IsWrapped = true)]
    public partial class GetPresetsRequest
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/imaging/wsdl",
            Order = 0)]
        public string VideoSourceToken;

        public GetPresetsRequest()
        {
        }

        public GetPresetsRequest(string VideoSourceToken)
        {
            this.VideoSourceToken = VideoSourceToken;
        }
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MessageContract(WrapperName = "GetPresetsResponse",
        WrapperNamespace = "http://www.onvif.org/ver20/imaging/wsdl", IsWrapped = true)]
    public partial class GetPresetsResponse
    {
        [MessageBodyMember(Namespace = "http://www.onvif.org/ver20/imaging/wsdl",
            Order = 0)]
        [XmlElement("Preset")]
        public ImagingPreset[] Preset;

        public GetPresetsResponse()
        {
        }

        public GetPresetsResponse(ImagingPreset[] Preset)
        {
            this.Preset = Preset;
        }
    }

    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    public interface ImagingChannel : Imaging, IClientChannel
    {
    }

    [DebuggerStepThrough()]
    [GeneratedCode("dotnet-svcutil", "1.0.3")]
    public partial class ImagingClient : ClientBase<Imaging>,
        Imaging
    {
        internal ImagingClient(Binding binding,
            EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public Task<Capabilities> GetServiceCapabilitiesAsync()
        {
            return base.Channel.GetServiceCapabilitiesAsync();
        }

        public Task<ImagingSettings20> GetImagingSettingsAsync(string VideoSourceToken)
        {
            return base.Channel.GetImagingSettingsAsync(VideoSourceToken);
        }

        public Task SetImagingSettingsAsync(string VideoSourceToken,
            ImagingSettings20 ImagingSettings, bool ForcePersistence)
        {
            return base.Channel.SetImagingSettingsAsync(VideoSourceToken, ImagingSettings, ForcePersistence);
        }

        public Task<ImagingOptions20> GetOptionsAsync(string VideoSourceToken)
        {
            return base.Channel.GetOptionsAsync(VideoSourceToken);
        }

        public Task MoveAsync(string VideoSourceToken, FocusMove Focus)
        {
            return base.Channel.MoveAsync(VideoSourceToken, Focus);
        }

        public Task<MoveOptions20> GetMoveOptionsAsync(string VideoSourceToken)
        {
            return base.Channel.GetMoveOptionsAsync(VideoSourceToken);
        }

        public Task StopAsync(string VideoSourceToken)
        {
            return base.Channel.StopAsync(VideoSourceToken);
        }

        public Task<ImagingStatus20> GetStatusAsync(string VideoSourceToken)
        {
            return base.Channel.GetStatusAsync(VideoSourceToken);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetPresetsResponse>
            Imaging.GetPresetsAsync(
                GetPresetsRequest request)
        {
            return base.Channel.GetPresetsAsync(request);
        }

        public Task<ImagingPreset> GetCurrentPresetAsync(string VideoSourceToken)
        {
            return base.Channel.GetCurrentPresetAsync(VideoSourceToken);
        }

        public Task SetCurrentPresetAsync(string VideoSourceToken, string PresetToken)
        {
            return base.Channel.SetCurrentPresetAsync(VideoSourceToken, PresetToken);
        }

        public Task<GetPresetsResponse> GetPresetsAsync(
            string VideoSourceToken)
        {
            GetPresetsRequest inValue =
                new GetPresetsRequest();
            inValue.VideoSourceToken = VideoSourceToken;
            return ((Imaging) (this)).GetPresetsAsync(inValue);
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
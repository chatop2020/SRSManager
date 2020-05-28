#nullable enable
using System;

namespace SRSCallBackManager.Structs
{
    [Serializable]
    public enum ClientType
    {
        Monitor,
        User
    }
    [Serializable]
    public class RemoteClient
    {
        private ushort? _clientId;
        private string? _clientIp;
        private ClientType _clientType;

        public ushort? ClientId
        {
            get => _clientId;
            set => _clientId = value;
        }

        public string? ClientIp
        {
            get => _clientIp;
            set => _clientIp = value;
        }

        public ClientType ClientType
        {
            get => _clientType;
            set => _clientType = value;
        }
    }
}
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
        private string _clientId;
        private string _clientIp;
        private ClientType _clientType;

        public ClientType ClientType
        {
            get => _clientType;
            set => _clientType = value;
        }


        public string ClientId
        {
            get => _clientId;
            set => _clientId = value;
        }

        public string ClientIp
        {
            get => _clientIp;
            set => _clientIp = value;
        }
    }
}
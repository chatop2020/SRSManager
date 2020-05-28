using System;
using System.Collections.Generic;
using SRSCallBackManager.Structs;

namespace SRSCallBackManager
{
    [Serializable]
    public class RemoteClientManager
    {
        private List<Client> _clientList;

        public List<Client> ClientList
        {
            get => _clientList;
            set => _clientList = value;
        }

        public RemoteClientManager()
        {
            ClientList= new List<Client>();
        }
    }
}
using System;
using System.Collections.Generic;
using SRSCallBackManager.Structs;

namespace SRSCallBackManager
{
    [Serializable]
    public class RemoteClientManager
    {
        private List<OnlineClient> _onlineClientList;

        public List<OnlineClient> OnlineClientList
        {
            get => _onlineClientList;
            set => _onlineClientList = value;
        }
    }
}
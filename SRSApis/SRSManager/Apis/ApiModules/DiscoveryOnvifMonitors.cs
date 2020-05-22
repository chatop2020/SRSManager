using System;
using System.Collections.Generic;
using System.Linq;

namespace SRSApis.SRSManager.Apis.ApiModules
{
    [Serializable]
    public class DiscoveryOnvifMonitors
    {
        private string ipAddrs;
        private string? username;
        private string? password;
        private List<string> ipAddrArray = new List<string>();

        public string IpAddrs
        {
            get => ipAddrs;
            set => ipAddrs = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? Username
        {
            get => username;
            set => username = value;
        }

        public string? Password
        {
            get => password;
            set => password = value;
        }

        public List<string> IpAddrArray
        {
            get => ipAddrArray;
            set => ipAddrArray = value ?? throw new ArgumentNullException(nameof(value));
        }


        public void GetIpArray()
        {
            if (!string.IsNullOrEmpty(IpAddrs))
            {
                ipAddrArray = ipAddrs.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }
    }
}
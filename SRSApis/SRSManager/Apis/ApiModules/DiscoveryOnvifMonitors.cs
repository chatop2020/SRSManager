using System;
using System.Collections.Generic;
using System.Linq;

namespace SRSApis.SRSManager.Apis.ApiModules
{
    [Serializable]
    public class DiscoveryOnvifMonitors
    {
        private List<string> _ipAddrArray = new List<string>();
        private string _ipAddrs = null!;
        private string? _password;
        private string? _username;

        public string IpAddrs
        {
            get => _ipAddrs;
            set => _ipAddrs = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? Username
        {
            get => _username;
            set => _username = value;
        }

        public string? Password
        {
            get => _password;
            set => _password = value;
        }

        public List<string> IpAddrArray
        {
            get => _ipAddrArray;
            set => _ipAddrArray = value ?? throw new ArgumentNullException(nameof(value));
        }


        public void GetIpArray()
        {
            if (!string.IsNullOrEmpty(IpAddrs))
            {
                _ipAddrArray = System.Text.RegularExpressions.Regex.Split(_ipAddrs,@"[\s]+").ToList();
                //_ipAddrArray = _ipAddrs.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }
    }
}
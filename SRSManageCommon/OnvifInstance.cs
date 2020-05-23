#nullable enable
using System;

namespace SRSManageCommon
{
    /// <summary>
    /// onvif实例结构
    /// </summary>
    [Serializable]
    public class OnvifInstance
    {
        private string _ipAddr = null!;
        private string? _username;
        private string? _password;
        private string _configPath = null!;
        private OnvifMonitor? _onvifMonitor;

        public string IpAddr
        {
            get => _ipAddr;
            set => _ipAddr = value ?? throw new ArgumentNullException(nameof(value));
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

        public string ConfigPath
        {
            get => _configPath;
            set => _configPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        public OnvifMonitor? OnvifMonitor
        {
            get => _onvifMonitor;
            set => _onvifMonitor = value;
        }
    }
}
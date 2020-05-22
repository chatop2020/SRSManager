using System;

namespace SRSManageCommon
{
    /// <summary>
    /// onvif实例结构
    /// </summary>
    [Serializable]
    public class OnvifInstance
    {
        private string ipAddr;
        private string? username;
        private string? password;
        private string configPath;
        private OnvifMonitor? onvifMonitor;

        public string IpAddr
        {
            get => ipAddr;
            set => ipAddr = value ?? throw new ArgumentNullException(nameof(value));
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

        public string ConfigPath
        {
            get => configPath;
            set => configPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        public OnvifMonitor? OnvifMonitor
        {
            get => onvifMonitor;
            set => onvifMonitor = value;
        }
    }
}
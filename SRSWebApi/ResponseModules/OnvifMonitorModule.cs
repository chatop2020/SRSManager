using System;
using System.Collections.Generic;
using OnvifManager;

namespace SRSWebApi.ResponseModules
{
[Serializable]
    public class ProfileLimit
    {
        private string profileToken;
        private string mediaUrl;
        private bool ptzMoveSupport = false;
        private bool absoluteMove = false;
        private bool relativeMove = false;
        private bool continuousMove = false;

        public string ProfileToken
        {
            get => profileToken;
            set => profileToken = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string MediaUrl
        {
            get => mediaUrl;
            set => mediaUrl = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool PtzMoveSupport
        {
            get => ptzMoveSupport;
            set => ptzMoveSupport = value;
        }

        public bool AbsoluteMove
        {
            get => absoluteMove;
            set => absoluteMove = value;
        }

        public bool RelativeMove
        {
            get => relativeMove;
            set => relativeMove = value;
        }

        public bool ContinuousMove
        {
            get => continuousMove;
            set => continuousMove = value;
        }
    }
    
    [Serializable]
    public class OnvifMonitorModule
    {
        private string host;
        private string username;
        private string password;
        private List<MediaSourceInfo> mediaSourceInfoList;
        private List<ProfileLimit> onvifProfileLimitList;
        private bool isInited = false;

        public string Host
        {
            get => host;
            set => host = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Username
        {
            get => username;
            set => username = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Password
        {
            get => password;
            set => password = value ?? throw new ArgumentNullException(nameof(value));
        }

        public List<MediaSourceInfo> MediaSourceInfoList
        {
            get => mediaSourceInfoList;
            set => mediaSourceInfoList = value ?? throw new ArgumentNullException(nameof(value));
        }

        public List<ProfileLimit> OnvifProfileLimitList
        {
            get => onvifProfileLimitList;
            set => onvifProfileLimitList = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool IsInited
        {
            get => isInited;
            set => isInited = value;
        }
    }
}
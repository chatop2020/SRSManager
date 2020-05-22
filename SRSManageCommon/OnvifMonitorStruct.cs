using System;
using System.Collections.Generic;
using Mictlanix.DotNet.Onvif.Common;


namespace SRSManageCommon
{
    /// <summary>
    /// ptz位置信息
    /// </summary>
    [Serializable]
    public class ResponsePosition
    {
        private float x; //水平方向位置
        private float y; //垂直方向位置
        private float z; //镜头聚焦

        public override string ToString()
        {
            return string.Format("[x={0:F5},y={1:F5},z={2:F5}]", X, Y, Z);
        }

        public float X
        {
            get => x;
            set => x = value;
        }

        public float Y
        {
            get => y;
            set => y = value;
        }

        public float Z
        {
            get => z;
            set => z = value;
        }
    }


    /// <summary>
    /// ptz profile结构
    /// </summary>
    [Serializable]
    public class OnvifProfile
    {
        private string profileToken;
        private Profile profile;
        private string mediaUrl;
        private bool ptzMoveSupport = false;
        private bool absoluteMove = false;
        private bool relativeMove = false;
        private bool continuousMove = false;

        public string ProfileToken
        {
            get => profileToken;
            set => profileToken = value;
        }

        public Profile Profile
        {
            get => profile;
            set => profile = value;
        }


        public string MediaUrl
        {
            get => mediaUrl;
            set => mediaUrl = value;
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

    /// <summary>
    /// media源结构
    /// </summary>
    [Serializable]
    public class MediaSourceInfo
    {
        private string source_token;
        private float framerate;
        private int width;
        private int height;

        public string SourceToken
        {
            get => source_token;
            set => source_token = value;
        }

        public float Framerate
        {
            get => framerate;
            set => framerate = value;
        }

        public int Width
        {
            get => width;
            set => width = value;
        }

        public int Height
        {
            get => height;
            set => height = value;
        }

        public override string ToString()
        {
            return "VideoSourceToken:" + this.source_token + "\tVideoSourceFrameRate:" + this.framerate.ToString() +
                   "\tVideoSourceResolution.Width:" + this.Width + "\tVideoSourceResolution.Height:" + this.Height;
        }
    }

    /// <summary>
    /// 简化的profile结构
    /// </summary>
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

    /// <summary>
    /// onvif摄像头简单结构
    /// </summary>
    [Serializable]
    public class OnvifMonitorStruct
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
using System;
using System.Collections.Generic;
using Mictlanix.DotNet.Onvif.Common;

namespace SRSManageCommon.ManageStructs
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

        public override string ToString()
        {
            return string.Format("[x={0:F5},y={1:F5},z={2:F5}]", X, Y, Z);
        }
    }


    /// <summary>
    /// ptz profile结构
    /// </summary>
    [Serializable]
    public class OnvifProfile
    {
        private bool _absoluteMove = false;
        private bool _continuousMove = false;
        private string? _mediaUrl;
        private Profile? _profile;
        private string? _profileToken;
        private bool _ptzMoveSupport = false;
        private bool _relativeMove = false;

        public string? ProfileToken
        {
            get => _profileToken;
            set => _profileToken = value;
        }

        public Profile? Profile
        {
            get => _profile;
            set => _profile = value;
        }


        public string? MediaUrl
        {
            get => _mediaUrl;
            set => _mediaUrl = value;
        }

        public bool PtzMoveSupport
        {
            get => _ptzMoveSupport;
            set => _ptzMoveSupport = value;
        }

        public bool AbsoluteMove
        {
            get => _absoluteMove;
            set => _absoluteMove = value;
        }

        public bool RelativeMove
        {
            get => _relativeMove;
            set => _relativeMove = value;
        }

        public bool ContinuousMove
        {
            get => _continuousMove;
            set => _continuousMove = value;
        }
    }

    /// <summary>
    /// media源结构
    /// </summary>
    [Serializable]
    public class MediaSourceInfo
    {
        private float _framerate;
        private int _height;
        private string? _sourceToken;
        private int _width;

        public string? SourceToken
        {
            get => _sourceToken;
            set => _sourceToken = value;
        }

        public float Framerate
        {
            get => _framerate;
            set => _framerate = value;
        }

        public int Width
        {
            get => _width;
            set => _width = value;
        }

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        public override string ToString()
        {
            return "VideoSourceToken:" + this._sourceToken + "\tVideoSourceFrameRate:" + this._framerate.ToString() +
                   "\tVideoSourceResolution.Width:" + this.Width + "\tVideoSourceResolution.Height:" + this.Height;
        }
    }

    /// <summary>
    /// 简化的profile结构
    /// </summary>
    [Serializable]
    public class ProfileLimit
    {
        private bool _absoluteMove = false;
        private bool _continuousMove = false;
        private string? _mediaUrl;
        private string? _profileToken;
        private bool _ptzMoveSupport = false;
        private bool _relativeMove = false;

        public string? ProfileToken
        {
            get => _profileToken;
            set => _profileToken = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? MediaUrl
        {
            get => _mediaUrl;
            set => _mediaUrl = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool PtzMoveSupport
        {
            get => _ptzMoveSupport;
            set => _ptzMoveSupport = value;
        }

        public bool AbsoluteMove
        {
            get => _absoluteMove;
            set => _absoluteMove = value;
        }

        public bool RelativeMove
        {
            get => _relativeMove;
            set => _relativeMove = value;
        }

        public bool ContinuousMove
        {
            get => _continuousMove;
            set => _continuousMove = value;
        }
    }

    /// <summary>
    /// onvif摄像头简单结构
    /// </summary>
    [Serializable]
    public class OnvifMonitorStruct
    {
        private string? _host;
        private bool _isInited = false;
        private List<MediaSourceInfo>? _mediaSourceInfoList;
        private List<ProfileLimit>? _onvifProfileLimitList;
        private string? _password;
        private string? _username;

        public string? Host
        {
            get => _host;
            set => _host = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? Username
        {
            get => _username;
            set => _username = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? Password
        {
            get => _password;
            set => _password = value ?? throw new ArgumentNullException(nameof(value));
        }

        public List<MediaSourceInfo>? MediaSourceInfoList
        {
            get => _mediaSourceInfoList;
            set => _mediaSourceInfoList = value ?? throw new ArgumentNullException(nameof(value));
        }

        public List<ProfileLimit>? OnvifProfileLimitList
        {
            get => _onvifProfileLimitList;
            set => _onvifProfileLimitList = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool IsInited
        {
            get => _isInited;
            set => _isInited = value;
        }
    }
}
using System;

namespace SRSManageCommon.ManageStructs
{
    /// <summary>
    /// ptz移动类型
    /// </summary>
    [Serializable]
    public enum PtzMoveType
    {
        RELATIVE,
        KEEP,
    }


    [Serializable]
    public enum PtzMoveDir
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        UPLEFT,
        UPRIGHT,
        DOWNLEFT,
        DOWNRIGHT
    }

    [Serializable]
    public class PtzMoveStruct
    {
        private string? _ipAddr;
        private PtzMoveDir _moveDir;
        private PtzMoveType _moveType;
        private string? _profileToken;

        public string? IpAddr
        {
            get => _ipAddr;
            set => _ipAddr = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? ProfileToken
        {
            get => _profileToken;
            set => _profileToken = value ?? throw new ArgumentNullException(nameof(value));
        }

        public PtzMoveDir MoveDir
        {
            get => _moveDir;
            set => _moveDir = value;
        }

        public PtzMoveType MoveType
        {
            get => _moveType;
            set => _moveType = value;
        }
    }
}
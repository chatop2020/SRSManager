using System;

namespace SRSManageCommon
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
        private string ipAddr;
        private PtzMoveDir moveDir;
        private PtzMoveType moveType;
        private string profileToken;

        public string IpAddr
        {
            get => ipAddr;
            set => ipAddr = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string ProfileToken
        {
            get => profileToken;
            set => profileToken = value ?? throw new ArgumentNullException(nameof(value));
        }

        public PtzMoveDir MoveDir
        {
            get => moveDir;
            set => moveDir = value;
        }

        public PtzMoveType MoveType
        {
            get => moveType;
            set => moveType = value;
        }
    }
}
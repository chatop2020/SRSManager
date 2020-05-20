using System;
using Newtonsoft.Json;

namespace SRSWebApi.RequestModules
{
    [Serializable]
    public enum ReqPtzMoveType
    {
        RELATIVE, 
        KEEP,
    }
    [Serializable]
    public enum ReqPtzMoveDir
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
    public class ReqPtzMove
    {
        private string ipAddr;
        private string profileToken;
        private ReqPtzMoveDir moveDir;
        private ReqPtzMoveType moveType;

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

        public ReqPtzMoveDir MoveDir
        {
            get => moveDir;
            set => moveDir = value;
        }

        public ReqPtzMoveType MoveType
        {
            get => moveType;
            set => moveType = value;
        }
    }
}
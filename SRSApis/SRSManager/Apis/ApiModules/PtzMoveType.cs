using System;

namespace SRSApis.SRSManager.Apis.ApiModules
{
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
}
using System;

namespace SRSManageCommon.ManageStructs
{
    [Serializable]
    public class SrsGb28181PtzControlResponseModule
    {
        private int _code;

        public int Code
        {
            get => _code;
            set => _code = value;
        }
    }
}
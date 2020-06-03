using System;

namespace SrsApis.SrsManager.Apis.ApiModules
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
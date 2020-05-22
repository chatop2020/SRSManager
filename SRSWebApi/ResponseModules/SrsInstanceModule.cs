using System;

namespace SRSWebApi.ResponseModules
{
    [Serializable]
    public class SrsInstanceModule
    {
        private string deviceId;
        private bool isInit;
        private bool isRunning;
        private string configPath;
        private string pidValue;
        private string srsProcessWorkPath;
        private string srsInstanceWorkPath;


        public string DeviceId
        {
            get => deviceId;
            set => deviceId = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool IsInit
        {
            get => isInit;
            set => isInit = value;
        }

        public bool IsRunning
        {
            get => isRunning;
            set => isRunning = value;
        }

        public string ConfigPath
        {
            get => configPath;
            set => configPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string PidValue
        {
            get => pidValue;
            set => pidValue = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string SrsProcessWorkPath
        {
            get => srsProcessWorkPath;
            set => srsProcessWorkPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string SrsInstanceWorkPath
        {
            get => srsInstanceWorkPath;
            set => srsInstanceWorkPath = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
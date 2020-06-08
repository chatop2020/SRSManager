using System;

namespace SRSManageCommon.ControllerStructs.ResponseModules
{
    /// <summary>
    /// SRS实例模型
    /// </summary>
    [Serializable]
    public class SrsInstanceModule
    {
        private string _configPath = null!;
        private string _deviceId = null!;
        private bool _isInit;
        private bool _isRunning;
        private string _pidValue = null!;
        private string _srsInstanceWorkPath = null!;
        private string _srsProcessWorkPath = null!;

        /// <summary>
        /// 设备ID
        /// </summary>
        public string DeviceId
        {
            get => _deviceId;
            set => _deviceId = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// 是否初始化
        /// </summary>
        public bool IsInit
        {
            get => _isInit;
            set => _isInit = value;
        }

        /// <summary>
        /// 是否正在运行中
        /// </summary>
        public bool IsRunning
        {
            get => _isRunning;
            set => _isRunning = value;
        }

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public string ConfigPath
        {
            get => _configPath;
            set => _configPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// pid值
        /// </summary>
        public string PidValue
        {
            get => _pidValue;
            set => _pidValue = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// srs进程运行目录
        /// </summary>
        public string SrsProcessWorkPath
        {
            get => _srsProcessWorkPath;
            set => _srsProcessWorkPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// srs实例运行目录
        /// </summary>
        public string SrsInstanceWorkPath
        {
            get => _srsInstanceWorkPath;
            set => _srsInstanceWorkPath = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
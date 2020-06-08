using System;

namespace SRSManageCommon.ControllerStructs.RequestModules
{
    /// <summary>
    /// 录制完成后的消息
    /// </summary>
    [Serializable]
    public class ReqSrsDvr
    {
        private ushort? _clientId;
        private string? _device_id;
        private string? _ip;
        private string? _vhost;
        private string? _app;
        private string? _stream;
        private string? _param;
        private string? _cwd;
        private string? _file;

        /// <summary>
        /// clientid
        /// </summary>
        public ushort? Client_Id
        {
            get => _clientId;
            set => _clientId = value;
        }

        /// <summary>
        /// srs实例id
        /// </summary>
        public string? Device_Id
        {
            get => _device_id;
            set => _device_id = value;
        }

        /// <summary>
        /// ip
        /// </summary>
        public string? Ip
        {
            get => _ip;
            set => _ip = value;
        }

        /// <summary>
        /// vhost
        /// </summary>
        public string? Vhost
        {
            get => _vhost;
            set => _vhost = value;
        }

        /// <summary>
        /// app
        /// </summary>
        public string? App
        {
            get => _app;
            set => _app = value;
        }

        /// <summary>
        /// stream
        /// </summary>
        public string? Stream
        {
            get => _stream;
            set => _stream = value;
        }

        /// <summary>
        /// param
        /// </summary>
        public string? Param
        {
            get => _param;
            set => _param = value;
        }

        /// <summary>
        /// cwd
        /// </summary>
        public string? Cwd
        {
            get => _cwd;
            set => _cwd = value;
        }

        /// <summary>
        /// file
        /// </summary>
        public string? File
        {
            get => _file;
            set => _file = value;
        }
    }
}
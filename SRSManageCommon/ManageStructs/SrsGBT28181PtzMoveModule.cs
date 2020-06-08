namespace SRSManageCommon.ManageStructs
{
    public class SrsGBT28181PtzMoveModule
    {
        private string? _deviceId;
        private string? _stream;
        private PtzMoveDir? _ptzMoveDir;
        private ushort? _speed;
        private bool? _stop;

        public string? DeviceId
        {
            get => _deviceId;
            set => _deviceId = value;
        }

        public string? Stream
        {
            get => _stream;
            set => _stream = value;
        }

        public PtzMoveDir? PtzMoveDir
        {
            get => _ptzMoveDir;
            set => _ptzMoveDir = value;
        }

        public ushort? Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public bool? Stop
        {
            get => _stop;
            set => _stop = value;
        }
    }
}
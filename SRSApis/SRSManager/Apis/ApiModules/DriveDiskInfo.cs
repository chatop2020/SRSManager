namespace SRSApis.SRSManager.Apis.ApiModules
{
    public class DriveDiskInfo
    {
        private string? devicePath;
        private string? format;
        private ulong? free;
        private string? path;
        private string? rootDirectory;
        private ulong? size;
        private string? volumeLabel;

        public string? DevicePath
        {
            get => devicePath;
            set => devicePath = value;
        }

        public string? Path
        {
            get => path;
            set => path = value;
        }

        public ulong? Size
        {
            get => size;
            set => size = value;
        }

        public ulong? Free
        {
            get => free;
            set => free = value;
        }

        public string? Format
        {
            get => format;
            set => format = value;
        }

        public string? VolumeLabel
        {
            get => volumeLabel;
            set => volumeLabel = value;
        }

        public string? RootDirectory
        {
            get => rootDirectory;
            set => rootDirectory = value;
        }
    }
}
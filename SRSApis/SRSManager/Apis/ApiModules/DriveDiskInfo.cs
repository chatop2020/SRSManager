namespace SRSApis.SRSManager.Apis.ApiModules
{
    public class DriveDiskInfo
    {
        private string? path;
        private ulong? size;
        private ulong? free;
        private string? format;
        private string? volumeLabel;
        private string? rootDirectory;
        private string? devicePath;

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
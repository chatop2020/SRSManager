namespace SRSApis.SRSManager.Apis.ApiModules
{
    public class NetworkInterfaceModule
    {
        private ushort? index;
        private string? name;
        private string? mac;

        private string? type;

        //  private string? speed; //linux not Supported
        private string? ipaddr;

        public ushort? Index
        {
            get => index;
            set => index = value;
        }

        public string? Name
        {
            get => name;
            set => name = value;
        }

        public string? Mac
        {
            get => mac;
            set => mac = value;
        }

        public string? Type
        {
            get => type;
            set => type = value;
        }

        /*public string? Speed //linux not Supported
        {
            get => speed;
            set => speed = value;
        }*/

        public string? Ipaddr
        {
            get => ipaddr;
            set => ipaddr = value;
        }
    }
}
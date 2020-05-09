namespace SRSWebApi.RequestModules
{
    public class ReqSetOrAddAllow
    {
        private string password;
        private AllowKey allowkey;

        public string Password
        {
            get => password;
            set => password = value;
        }

        public AllowKey Allowkey
        {
            get => allowkey;
            set => allowkey = value;
        }
    }
}
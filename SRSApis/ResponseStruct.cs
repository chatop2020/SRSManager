namespace SRSApis
{
    public class ResponseStruct
    {
        public ErrorNumber Code { get; set; }
        public string Message { get; set; } = null;

        public ResponseStruct(ErrorNumber code, string message)
        {
            Code = code;
            Message = message;
        }

        public ResponseStruct()
        {
        }
    }
}
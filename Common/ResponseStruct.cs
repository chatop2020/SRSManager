using System;

namespace Common
{
    [Serializable]
    public class ResponseStruct
    {
        private ErrorNumber code;
        private string message = null!;

        public ErrorNumber Code
        {
            get => code;
            set => code = value;
        }

        public string Message
        {
            get => message;
            set => message = value;
        }

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
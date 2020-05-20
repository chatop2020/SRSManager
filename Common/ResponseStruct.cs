using System;

namespace Common
{
    [Serializable]
    public class ResponseStruct
    {
        public ErrorNumber Code;
        public string Message = null!;

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
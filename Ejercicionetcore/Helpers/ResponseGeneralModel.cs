namespace Ejercicionetcore.Helpers
{
    public class ResponseGeneralModel <T>
    {
        public int Code { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
       

        public ResponseGeneralModel (int code, T data, string message)
        {
            Code = code;
            Data = data;
            Message = message;
        }


    }
}

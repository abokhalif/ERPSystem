namespace HRSystem
{
    public class ResponseResult
    {
        public bool Success { get; private set; }
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
    }
}

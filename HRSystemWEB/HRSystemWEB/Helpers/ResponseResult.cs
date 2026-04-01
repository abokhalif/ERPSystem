namespace HRSystemWEB.Helpers
{
    public class ResponseResult
    {
        public bool Success { get; private set; }
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }  // To hold response data

        private ResponseResult(bool success, string message, int statusCode, object data = null)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }

        public static ResponseResult SuccessResult(object data = null, string message = "Operation Successful", int statusCode = 200)
        {
            return new ResponseResult(true, message, statusCode, data);
        }

        public static ResponseResult ErrorResult(string message, int statusCode)
        {
            return new ResponseResult(false, message, statusCode);
        }
    }

}

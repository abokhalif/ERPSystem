namespace UltimateAPI.Errors
{
    public class ApiExceptionErrorResponse:ResponseModel
    {
        public string? Details { get; set; }
        public static ApiExceptionErrorResponse Fail(string? message = null, int statusCode = 400, string? details = null)
        {
            return new ApiExceptionErrorResponse
            {
                StatusCode = statusCode,
                Message = message,
                Details = details
            };
        }
    }
}

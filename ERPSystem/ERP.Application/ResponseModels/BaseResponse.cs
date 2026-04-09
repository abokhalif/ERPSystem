namespace ERP.API.ResponseModels
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public List<string> Errors { get; set; } = new();
        protected static List<string> ExtractErrors(Exception ex)
        {
            var errors = new List<string> { ex.Message };

            if (ex.InnerException != null)
                errors.Add(ex.InnerException.Message);

            return errors;
        }
        protected static string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                200 => "Request succeeded.",
                201 => "Resource created successfully.",
                204 => "No content.",
                400 => "Bad request.",
                401 => "Unauthorized access.",
                403 => "Forbidden.",
                404 => "Resource not found.",
                422 => "Unprocessable entity.",
                500 => "Internal server error.",
                _ => "Unexpected error."
            };
        }
    }
}

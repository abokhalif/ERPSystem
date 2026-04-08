using ERP.Application.ResponseModels;

namespace ERP.API.ResponseModels
{
    public class ApiResponse<T> : BaseResponse
    {
        public T? Data { get; set; }

       
        public static ApiResponse<T> SuccessResponse(T data, string? message = null, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Success = true,
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                Data = data,

            };
        }

        public static ApiResponse<T> FailureResponse(string? message = null, List<string>? errors = null, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                Data = default,
                Errors = errors ?? new()

            };
        }
        public static ApiResponse<T> ErrorResponse(Exception ex, int statusCode = 500)
        {
            var errors = new List<string> { ex.Message };
            if (ex.InnerException != null)
                errors.Add(ex.InnerException.Message);

            return new ApiResponse<T>
            {
                Success = false,
                Message = "An error occurred",
                Data = default,
                StatusCode = statusCode,
                Errors = errors
            };
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

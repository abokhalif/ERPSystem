using ERP.Application.Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ERP.API.ResponseModels
{
    public class ApiResponse<T> : BaseResponse
    {
        public IReadOnlyList<T>? ListedData { get; set; }
        public T? Data { get; set; }
        public PagingMetaData? MetaData { get; set; } = new PagingMetaData();
        public static ApiResponse<T> SuccessWithPagingMetaData(IReadOnlyList<T> data, PagingMetaData? metaData = null, string? message = null, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                MetaData = metaData ?? new PagingMetaData(),
                ListedData = data,
            };
        }
        public static ApiResponse<T> SuccessListedData(IReadOnlyList<T> data, string? message = null, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                ListedData = data,
            };
        }
        public static ApiResponse<T> SuccessResponse(T data, string? message = null, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                Data = data,

            };
        }

        public static ApiResponse<T> FailureResponse(string? message = null, List<string>? errors = null, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                Data = default,
                MetaData = default,
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
                Message = "An error occurred",
                Data = default,
                StatusCode = statusCode,
                Errors = errors
            };
        }

        private static string GetDefaultMessage(int statusCode)
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

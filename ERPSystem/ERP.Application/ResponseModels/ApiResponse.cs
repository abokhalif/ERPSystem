using ERP.Application.Shared;

namespace ERP.API.ResponseModels
{
    public class ApiResponse<T> : BaseResponse
    {
        public T? Data { get; set; }

        public PagingMetaData? MetaData { get; set; } = new PagingMetaData();
        public static ApiResponse<T> SuccessWithPagingMetaData(T data, PagingMetaData? metaData = null, string? message = null)
        {
            return new ApiResponse<T>
            {
                StatusCode = 200,
                Message = message ?? GetDefaultMessage(200),
                MetaData = metaData ?? new PagingMetaData(),
                Data = data,
            };
        }
        public static ApiResponse<T> Success(T data, string? message = null)
        {
            return new ApiResponse<T>
            {
                StatusCode = 200,
                Message = message ?? GetDefaultMessage(200),
                Data = data,
            };
        }

        public static ApiResponse<T> Fail(string? message = null, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                Data = default,
                MetaData = default

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

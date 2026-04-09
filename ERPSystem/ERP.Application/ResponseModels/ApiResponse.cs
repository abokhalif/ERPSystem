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

        public static ApiResponse<T> FailureResponse(List<string>? errors = null, string? message = null, int statusCode = 400)
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
        public static ApiResponse<T> ErrorResponse(Exception ex,string? message= "Internal server error.", int statusCode = 500)
        {

            return new ApiResponse<T>
            {
                Success = false,
                Message = message?? GetDefaultMessage(statusCode),
                StatusCode = statusCode,
                Data = default,
                Errors = ExtractErrors(ex)

            };
        }

        
        

    }
}

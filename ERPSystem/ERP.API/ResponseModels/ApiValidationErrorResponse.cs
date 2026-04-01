namespace ERP.API.ResponseModels
{
    public class ApiValidationErrorResponse : BaseResponse
    {

        public List<string>? Errors { get; set; }
        public static ApiValidationErrorResponse Fail(string? message = null, int statusCode = 400, List<string>? errors = null)
        {
            return new ApiValidationErrorResponse
            {
                StatusCode = statusCode,
                Message = message,
                Errors = errors
            };
        }
    }

}

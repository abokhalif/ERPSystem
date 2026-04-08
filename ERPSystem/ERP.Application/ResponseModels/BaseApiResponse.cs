using ERP.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.ResponseModels
{
    public class BaseApiResponse:BaseResponse
    {

        /// <summary>
        /// Creates a success response.
        /// </summary>
        public static BaseApiResponse SuccessResponse(string message = "Operation successful", int statusCode = 200)
        {
            return new BaseApiResponse
            {
                Success = true, 
                Message = message,
                StatusCode = statusCode,
                Errors = new()
            };
        }

        /// <summary>
        /// Creates a failure response.
        /// </summary>
        public static BaseApiResponse FailureResponse(string message, List<string>? errors = null, int statusCode = 400)
        {
            return new BaseApiResponse
            {
                Success = false,
                Message = message,
                StatusCode = statusCode,
                Errors = errors ?? new()
            };
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        public static BaseApiResponse ErrorResponse(Exception ex, int statusCode = 500)
        {
            var errors = new List<string> { ex.Message };
            if (ex.InnerException != null)
                errors.Add(ex.InnerException.Message);

            return new BaseApiResponse
            {
                Success = false,
                Message = "An error occurred",
                StatusCode = statusCode,
                Errors = errors
            };
        }
        public static BaseApiResponse ErrorResponseDetailedEx(Exception ex,string details=null, int statusCode = 500)
        {
            var errors = new List<string> { ex.Message };
            if (ex.InnerException != null)
                errors.Add(ex.InnerException.Message);

            return new BaseApiResponse
            {
                Success = false,
                Message = details,
                StatusCode = statusCode,
                Errors = errors,
            };
        }
    }
}

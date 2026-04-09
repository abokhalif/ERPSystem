using ERP.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.ResponseModels
{
    public class PagedApiResponse<T>: BaseResponse
    {
        public PagingMetaData? MetaData { get; set; } = new PagingMetaData();
        public IReadOnlyList<T> Data;
        public static PagedApiResponse<T> SuccessWithMetaData(IReadOnlyList<T> data, PagingMetaData? metaData = null, string? message = null, int statusCode = 200)
        {
            return new PagedApiResponse<T>
            {
                Success = true,
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                MetaData = metaData ?? new PagingMetaData(),
                Data = data,
            };

        }
        public static PagedApiResponse<T> FailureResponse(List<string>? errors = null, string? message = null, int statusCode = 400)
        {
            return new PagedApiResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                Data = default,
                Errors = errors ?? new()

            };
        }
        public static PagedApiResponse<T> ErrorResponse(Exception ex, string? message = "Internal server error.", int statusCode = 500)
        {

            return new PagedApiResponse<T>
            {
                Success = false,
                Message = message ?? GetDefaultMessage(statusCode),
                StatusCode = statusCode,
                Data = default,
                Errors = ExtractErrors(ex)

            };
        }




    }
}

using ERP.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.ResponseModels
{
    public class PagedApiResponse<T>: ApiResponse<T>
    {
        public PagingMetaData? MetaData { get; set; } = new PagingMetaData();
        public IReadOnlyList<T>? ListedData { get; set; }

        public static PagedApiResponse<T> SuccessWithPagingMetaData(IReadOnlyList<T> data, PagingMetaData? metaData = null, string? message = null, int statusCode = 200)
        {
            return new PagedApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                MetaData = metaData ?? new PagingMetaData(),
                ListedData = data,
            };

        }
        public static PagedApiResponse<T> SuccessListedData(IReadOnlyList<T> data, string? message = null, int statusCode = 200)
        {
            return new PagedApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessage(statusCode),
                ListedData = data,
            };
        }


    }
}

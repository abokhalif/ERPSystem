using ERP.API.ResponseModels;
using ERP.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.IGenericServices
{
    public interface IBaseService<T> where T : class
    {
        Task<ApiResponse<T>> GetByIdAsync(int id);

        Task<ApiResponse<T>> GetAllAsync();

        Task<BaseApiResponse> CreateAsync(T entity);

       
        Task<ApiResponse<T>> UpdateAsync(T entity);

        
        Task<BaseApiResponse> DeleteAsync(int id);
    }
}

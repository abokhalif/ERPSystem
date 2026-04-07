using ERP.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.IGenericServices
{
    public interface IService<T> : IBaseService<T> where T : class
    {
        /// <summary>
        /// Gets entities with specification asynchronously.
        /// </summary>
        Task<ApiResponse<T>> GetEntitiesWithSpecAsync(ISpecification<T> spec);

        /// <summary>
        /// Gets a single entity matching the specification asynchronously.
        /// </summary>
        Task<ApiResponse<T>> GetEntityWithSpecAsync(ISpecification<T> spec);

        /// <summary>
        /// Counts entities matching the specification asynchronously.
        /// </summary>
        Task<ApiResponse<int>> CountAsync(ISpecification<T> spec);

        /// <summary>
        /// Checks if any entity exists matching the specification.
        /// </summary>
        Task<ApiResponse<bool>> AnyAsync(ISpecification<T> spec);
    }
}

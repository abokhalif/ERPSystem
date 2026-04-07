using ERP.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces
{
    public interface IRepository<T>:IBaseRepository<T> where T : class
    {
       
        Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<(IReadOnlyList<T> Data, PagingMetaData? Meta)> GetPagedWithMetaAsync(ISpecification<T> spec);
    }
}

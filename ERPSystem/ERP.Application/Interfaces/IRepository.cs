using ERP.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
        Task<int> GetCountAsync(ISpecification<T> spec);
        Task<(IReadOnlyList<T> Data, PagingMetaData? Meta)> GetPagedWithMetaAsync(ISpecification<T> spec);
    }
}

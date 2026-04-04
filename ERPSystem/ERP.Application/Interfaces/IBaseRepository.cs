using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();

    }
}

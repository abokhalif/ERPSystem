using ERP.Application.Interfaces;
using ERP.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public async Task<T?> GetAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }
    }
}

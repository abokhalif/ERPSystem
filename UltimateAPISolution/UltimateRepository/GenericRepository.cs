using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCore.Entities;
using UltimateCore.IRepositories;
using UltimateCore.Shared;
using UltimateCore.Specifications;
using UltimateRepository.Data;

namespace UltimateRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly Context dbContext;

        public GenericRepository(Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public  async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }
        public async Task<(IReadOnlyList<T> Data, PagingMetaData? Meta)> GetPagedWithMetaAsync(ISpecifications<T> spec)
        {
            var baseQuery = ApplySpecifications(spec).AsNoTracking();
            var totalCount = await baseQuery.CountAsync();

            var pagedQuery = spec.IsPagingEnabled
                ? baseQuery.Skip(spec.Skip).Take(spec.Take)
                : baseQuery;


            var data = await pagedQuery.ToListAsync();

            PagingMetaData? meta = null;

            if (spec.IsPagingEnabled)
            {
                meta = new PagingMetaData
                {
                    TotalCount = totalCount,
                    PageSize = spec.Take,
                    CurrentPage = (spec.Skip / spec.Take) + 1,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)spec.Take),
                  
                };
            }

            return (data, meta);
        }

        


        public async Task<int> GetCountAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
            IQueryable<T> query= SpecificationsEvaluator<T>.GetQuery(dbContext.Set<T>().AsQueryable(), spec);
           
            return query;
        }
    }
}

using ERP.Application.Interfaces;
using ERP.Application.ResponseModels;
using ERP.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Implementation.Shared
{
    public class Repository<T> : BaseRepository<T> , IRepository<T> where T : class
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec)
        {
            var query = ApplySpecifications(spec);
            return await query.FirstOrDefaultAsync();
        }

       
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }
        public async Task<(IReadOnlyList<T> Data, PagingMetaData? Meta)> GetPagedWithMetaAsync(ISpecification<T> spec)
        {
            var baseQuery = SpecificationEvaluator<T>.GetQuery(dbContext.Set<T>().AsQueryable(), spec, ignorePaging: true);
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
                    CurrentPage = spec.Skip / spec.Take + 1,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)spec.Take),

                };
            }
            return (data, meta);
        }
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            IQueryable<T> query =SpecificationEvaluator<T>.GetQuery(dbContext.Set<T>().AsQueryable(), spec);

            return query;
        }
       
    }
}

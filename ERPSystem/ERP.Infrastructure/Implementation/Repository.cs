using ERP.Application.Interfaces;
using ERP.Application.Shared;
using ERP.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Implementation
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

        public async Task<T?> GetWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }
        public async Task<(IReadOnlyList<T> Data, PagingMetaData? Meta)> GetPagedWithMetaAsync(ISpecification<T> spec)
        {
            var baseQuery = GetQuery(dbContext.Set<T>().AsQueryable(), spec, ignorePaging: true);
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
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            IQueryable<T> query = GetQuery(dbContext.Set<T>().AsQueryable(), spec);

            return query;
        }
        public static IQueryable<T> GetQuery( IQueryable<T> inputQuery, ISpecification<T> spec, bool ignorePaging = false)
        {
            var query = inputQuery;

            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            query = spec.Includes.Aggregate(query,
                (current, include) => current.Include(include));

            if (spec.OrderExpressions != null && spec.OrderExpressions.Any())
            {
                IOrderedQueryable<T>? orderedQuery = null;

                for (int i = 0; i < spec.OrderExpressions.Count; i++)
                {
                    var order = spec.OrderExpressions[i];

                    if (i == 0)
                    {
                        orderedQuery = order.Descending
                            ? query.OrderByDescending(order.KeySelector)
                            : query.OrderBy(order.KeySelector);
                    }
                    else
                    {
                        orderedQuery = order.Descending
                            ? orderedQuery!.ThenByDescending(order.KeySelector)
                            : orderedQuery!.ThenBy(order.KeySelector);
                    }
                }
                query = orderedQuery!;
            }

            // ✅ Apply paging only if NOT ignored
            if (!ignorePaging && spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            return query;
        }
    }
}

using ERP.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Implementation.Shared
{
    public static class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery( IQueryable<T> inputQuery,ISpecification<T> spec,bool ignorePaging = false)
        {
            var query = inputQuery;

            // Filtering
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            // Includes
            query = spec.Includes.Aggregate(query,
                (current, include) => current.Include(include));

            // Sorting
            if (spec.OrderExpressions.Any())
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

            // Paging
            if (!ignorePaging && spec.IsPagingEnabled)
                query = query.Skip(spec.Skip).Take(spec.Take);

            return query;
        }
    }

}

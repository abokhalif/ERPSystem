using EcommerceApplication.Specifications;
using EcommerceCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceInfrastructure.SpecEvaluator
{
    internal static class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec)
        {
            var query = inputQuery;
            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria); // dbContext.Set<Product>().Where(p=>p.Id==1)
                                                    // Order by multiple fields
            bool firstOrder = true;
            foreach (var order in spec.OrderExpressions)
            {
                if (firstOrder)
                {
                    query = order.Descending
                        ? query.OrderByDescending(order.KeySelector)
                        : query.OrderBy(order.KeySelector);
                    firstOrder = false;
                }
                else
                {
                    query = order.Descending
                        ? ((IOrderedQueryable<T>)query).ThenByDescending(order.KeySelector)
                        : ((IOrderedQueryable<T>)query).ThenBy(order.KeySelector);
                }
            }







            query = spec.Includes.Aggregate(query, (currentQuery, includeExp) => currentQuery.Include(includeExp));
            // dbContext.Set<Product>().Where(p=>p.Id==1).Include(B=>B.Brand);
            // dbContext.Set<Product>().Where(p=>p.Id==1).Include(B=>B.Brand).Include(C=>C.Category);
            return query;
        }
    }
}

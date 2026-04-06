using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces
{
    public interface ISpecification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }

      List<(Expression<Func<T, object>> KeySelector, bool Descending)> OrderExpressions { get; }

     int Skip { get; }
    int Take { get; }
    bool IsPagingEnabled { get; }
        bool AsNoTracking { get; }  
        protected void AddInclude(Expression<Func<T, object>> include);

        protected void AddOrderBy(Expression<Func<T, object>> keySelector);

        protected void AddOrderByDesc(Expression<Func<T, object>> keySelector);

    }


}

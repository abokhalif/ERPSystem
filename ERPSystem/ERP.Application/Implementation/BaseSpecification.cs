using ERP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Implementation
{
    using System.Linq.Expressions;

public abstract class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>>? Criteria { get; protected set; }

    public List<Expression<Func<T, object>>> Includes { get; } = new();

    public List<(Expression<Func<T, object>> KeySelector, bool Descending)> OrderExpressions { get; } = new();

    public int Skip { get; protected set; }
    public int Take { get; protected set; }
    public bool IsPagingEnabled { get; protected set; }

    public bool AsNoTracking { get; protected set; } = true;
        public void AddInclude(Expression<Func<T, object>> include)
        => Includes.Add(include);

        public void AddOrderBy(Expression<Func<T, object>> keySelector)
        => OrderExpressions.Add((keySelector, false));

        public void AddOrderByDesc(Expression<Func<T, object>> keySelector)
        => OrderExpressions.Add((keySelector, true));

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }
        protected void EnableTracking()
        => AsNoTracking = false;
    }

}

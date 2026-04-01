using EcommerceCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Specifications
{
    public class BaseSpecifications<T> : ISpecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; } = null;
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<(Expression<Func<T, object>> KeySelector, bool Descending)> OrderExpressions { get; } = new();

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; } = false;

        public BaseSpecifications()
        {

        }
        public BaseSpecifications(Expression<Func<T, bool>> expression)
        {
            Criteria = expression;// As --> o => o.id==1
        }
        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        public void AddOrderBy(Expression<Func<T, object>> keySelector, bool descending = false)
        {
            OrderExpressions.Add((keySelector, descending));
        }

        public void ApplyPaging(int pageNumber, int pageSize)
        {
            Skip = (pageNumber - 1) * pageSize;
            Take = pageSize;
            IsPagingEnabled = true;
        }
    }
    }

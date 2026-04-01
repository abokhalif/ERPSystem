using RepositoryPatternWithUOWCore.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOWCore.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();

        T Find(Expression<Func<T, bool>> criteria);
        T Find(Expression<Func<T, bool>> criteria, string[] Includes =null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] Includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria,int skip,int take);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria,int? skip,int? take,
            Expression<Func<T,object>>? orderBy =null,string orderByDirection =OrderBy.Ascending );

        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        T Update(T entity);
        void Delete(T entity);
        void Attach(T entity);
        int Count();
        int Count(Expression<Func<T, bool>> criteria);

    }
}

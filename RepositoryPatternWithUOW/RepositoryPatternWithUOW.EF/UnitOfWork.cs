using RepositoryPatternWithUOW.EF.Repositories;
using RepositoryPatternWithUOWCore;
using RepositoryPatternWithUOWCore.Models;
using RepositoryPatternWithUOWCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Author> Authors { get; private set; }

        public IBookRepo Books { get; private set; }
        public ApplicationDbContext Context { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
            Authors=new GenericRepository<Author>(Context);
            Books=new BookRepo(Context);
        }
        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

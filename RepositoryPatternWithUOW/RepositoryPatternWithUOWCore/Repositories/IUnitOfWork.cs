using RepositoryPatternWithUOWCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOWCore.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Author> Authors { get; }
        IBookRepo Books { get; }
        int Complete();
    }
}

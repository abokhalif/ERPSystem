using RepositoryPatternWithUOWCore.Models;
using RepositoryPatternWithUOWCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOWCore
{
    public interface IBookRepo:IGenericRepository<Book>
    {
        //too add a method that spetial with book Repo
        IEnumerable<Book> SpecialMethod();
    }
}

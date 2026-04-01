using RepositoryPatternWithUOWCore;
using RepositoryPatternWithUOWCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BookRepo : GenericRepository<Book>, IBookRepo
    {
        //too add a method that spetial with book Repo

        public ApplicationDbContext Context { get; }

        public BookRepo(ApplicationDbContext context) : base(context)
        {
        }


        public IEnumerable<Book> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}

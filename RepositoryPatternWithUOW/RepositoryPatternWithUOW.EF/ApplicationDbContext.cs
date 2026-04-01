using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOWCore.Models;

namespace RepositoryPatternWithUOW.EF
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext():base()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }

       

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RepositoryPattern ;Integrated Security=True;TrustServerCertificate=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}

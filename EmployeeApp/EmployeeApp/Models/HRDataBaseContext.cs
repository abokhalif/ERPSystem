using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeApp.Models
{
    public class HRDataBaseContext:DbContext
    {
        //public HRDataBaseContext() : base()
        //{

        //}
        //public HRDataBaseContext(DbContextOptions<HRDataBaseContext> options): base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }




    }
}

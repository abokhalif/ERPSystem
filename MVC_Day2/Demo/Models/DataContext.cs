using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Demo.Models;

namespace Demo.Models
{
	public class DataContext : IdentityDbContext<ApplicationUser>
	{
		public DataContext():base()
		{

		}
		// this ctor using in injection
		public DataContext(DbContextOptions options):base(options)
		{

		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MVCD2;Integrated Security=True;TrustServerCertificate=True;");
		//	base.OnConfiguring(optionsBuilder);
		//}
		public DbSet<Demo.Models.RegisterUserViewModel>? RegisterUserViewModel { get; set; }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MVCD2;Integrated Security=True;TrustServerCertificate=True;");
		//	base.OnConfiguring(optionsBuilder);
		//}
		public DbSet<Demo.Models.LogInViewModel>? LogInViewModel { get; set; }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MVCD2;Integrated Security=True;TrustServerCertificate=True;");
		//	base.OnConfiguring(optionsBuilder);
		//}
		public DbSet<Demo.Models.RoleViewModel>? RoleViewModel { get; set; }
	}
}

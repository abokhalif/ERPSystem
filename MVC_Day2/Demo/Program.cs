using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();//.AddCookieTempDataProvider();// default
                                                       // builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();// if u want change the cookies to sessionstate

            // Custom Service => Register the service(class) in IoC Container
            //builder.Services.AddTransient<IEmployeeRepo, EmployeeRepo>();// create object per each inject
            builder.Services.AddScoped<IEmployeeRepo,EmployeeRepo>();// create object per request
            //builder.Services.AddSingleton<IEmployeeRepo,EmployeeRepo>();// create only one object per all request and all clients

            builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();

            
            //ask(resolve) injection of DB
            builder.Services.AddDbContext<DataContext>(options => { options
				.UseSqlServer(builder.Configuration.GetConnectionString("DB")); }) ;

            //ask(resolve) injection of Identity Lib.
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength =3;
			})//resolve of injection the User and role classes
                .AddEntityFrameworkStores<DataContext>();// to resolve the managers and stores classes of Identity

            //to add filter on the all project
            //builder.Services.AddControllersWithViews(conf=>conf.Filters.Add(Authorize));//pipeline filter
            builder.Services.AddSession(); // add session with default configuration (u can modify the default)

            var app = builder.Build();
			#region Custom Middleware [Use,Run,Map]

			//Use=> go to the next
			//app.Use(async(httpContext, next) =>
			//{
			//	await httpContext.Response.WriteAsync("1) Middleware 1\n");//write response
			//	await next.Invoke();// call the next
			//	await httpContext.Response.WriteAsync("5) Middleware 5\n");//write response

			//});

			//app.Use(async (httpContext, next) =>
			//{
			//	await httpContext.Response.WriteAsync("2) Middleware 2\n");//write response
			//	await next.Invoke();// call the next
			//	await httpContext.Response.WriteAsync("4) Middleware 4\n");//write response

			//});

			////Run => Terminte
			//app.Run(async httpContext => await httpContext.Response.WriteAsync("3) terminate 3\n"));
			
			//Map => go to the url
			//app.Map("/Employee/index",async (httpContext) =>
			//{
			//	await httpContext.Response.WriteAsync("2) Middleware 2\n");//write response
			//}
			//);
            #endregion
            // Configure the HTTP request pipeline.
            #region Buit in Middleware

            if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();// select the user to the Authorization check its cookies to select its role of the account

			app.UseAuthorization();

			app.UseSession();
			//u can add other ControllerRoute
			//app.MapControllerRoute("Route1", "{controller=Home}/{action=Index}");
			//app.MapControllerRoute("Route2", "emp/id", new { controller = "Employee", action = "Details" });//if in url wrote emp/id match to Employee/Dtails/id

           app.MapControllerRoute(
				name: "default",//{controller=Home //default}/{action=Index//default}/{id?=>optional}
                pattern: "{controller=Home}/{action=Index}/{id?}");
			#endregion

			app.Run();
		}
	}
}
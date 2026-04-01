
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Win32;
using UltimateAPI.Extensions;
using UltimateRepository.Data;
using static System.Net.WebRequestMethods;

namespace UltimateAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);// return WebApplicationBuilder object with pre configured defaults and to can add new configs 

            ///Add services to the container.

            builder.Services.AddControllers(); //registers only the controllers in IServiceCollection and not Views or Pages because they are not required in the Web API project

            // Learn more about configuring Swagger/OpenAPI 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // register services
            builder.Services.AddCORSConfiguration();

            builder.Services.AddDbContext<Context>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
          });


            // Register Migration Service insteadof Update-database in CLS
            builder.Services.AddHostedService<MigrationService>();
            builder.Services.AddHostedService<JsonSeederService>();
            builder.Services.RegisterServices();

            var app = builder.Build(); // build the configured builder app  creating the app variable of the type WebApplication

            // Configure the HTTP request pipeline.
            app.UseExceptionErrorMiddleware();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithReExecute("/errors/{0}");//for handling NotFound error to return ApiResponse object

            app.UseHttpsRedirection();// used to add the middleware for the redirection from HTTP to HTTPS

            // app.UseAuthorization();
            app.UseStaticFiles();


            app.MapControllers(); // Works with attribute-based routing ([Route], [HttpGet], etc.)

            app.Run();
        }
    }
}

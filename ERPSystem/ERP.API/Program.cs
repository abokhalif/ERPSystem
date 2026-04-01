
using ERP.API.Extentions;
using ERP.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ERP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.RegisterService();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseExceptionErrorMiddleware();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithReExecute("/errors/{0}");//for handling NotFound error to return ApiResponse object

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.Run(async context =>
            //{
            //    await context.Request.ReadFormAsync();
            //});


            app.MapControllers();

            app.Run();
        }
    }
}

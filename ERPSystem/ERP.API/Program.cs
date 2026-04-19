
using AutoMapper;
using ERP.API.Extentions;
using ERP.API.Filters;
using ERP.Application.Shared;
using ERP.Persistence.Entities;
using FluentValidation;
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

            builder.Services.AddControllers(option=> option.Filters.Add<LogActivityFilter>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            builder.Services.AddHostedService<MigrationService>();

            builder.Services.RegisterService();
            // 1. Register FluentValidation
            //builder.Services.AddAutoMapper(typeof(Program));
            //builder.Services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithReExecute("/errors/{0}");//for handling NotFound error to return ApiResponse object

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
           
            // Configure the HTTP request pipeline.
            app.UseExceptionErrorMiddleware();
            app.UseProfilingMiddleware();
            app.UseRateLimitingMiddleware();
            app.MapControllers();

            app.Run();
        }
    }
}

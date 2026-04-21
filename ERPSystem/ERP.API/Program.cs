
using AutoMapper;
using ERP.API.Extentions;
using ERP.API.Filters;
using ERP.Application.Shared;
using ERP.Persistence.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERPSystem", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            builder.Services.AddHostedService<MigrationService>();

            builder.Services.RegisterService(builder.Configuration);
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

            app.UseExceptionErrorMiddleware();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseJwtMiddleware();
           // app.UseProfilingMiddleware();
           // app.UseRateLimitingMiddleware();
            //app.UseStatusCodePagesWithReExecute("/errors/{0}");//for handling NotFound error to return ApiResponse object

            app.MapControllers();

           
            // Configure the HTTP request pipeline.
           

            app.Run();
        }
    }
}

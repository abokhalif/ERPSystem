
using Application.IServices;
using Application.Validation;
using DataAccess;
using DataAccess.Services;
using Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Controllers;
using System.Reflection;

namespace MinimalAPI
{
    public class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient();
            //Db Setting
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b =>
            b.MigrationsAssembly(typeof(Context).Assembly.FullName));
            }
           );


            //Fluent Validation Integration
             builder.Services.AddControllers().AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<PostValidator>());           // builder.Services.AddScoped<IValidator<Post>, PostValidator>();
           // builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddScoped<IPostServices,PostServices>();
            builder.Services.AddTransient<IPy,Py>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPostController();


            app.Run();
        }
    }
}

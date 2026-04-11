using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // 🔹 AutoMapper
            services.AddAutoMapper(assembly);

            // 🔹 FluentValidation
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}

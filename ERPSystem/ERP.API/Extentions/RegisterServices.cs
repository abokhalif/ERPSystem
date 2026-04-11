using ERP.API.ResponseModels;
using ERP.Application.Features.ProductFeatures.Implementation;
using ERP.Application.Features.ProductFeatures.Interface;
using ERP.Application.Implementation.GenericService;
using ERP.Application.Interfaces;
using ERP.Application.ResponseModels;
using ERP.Infrastructure.Implementation.Shared;
using ERP.Infrastructure.Interface;
using ERP.Persistence.Entities;
using ERP.Persistence.Entities.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ERP.API.Extentions
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options=>
            { 
                options.User.RequireUniqueEmail= true; 
                options.Password.RequireDigit= false;
                options.Password.RequiredUniqueChars= 0;
                options.Password.RequireNonAlphanumeric= false;
                options.Password.RequireLowercase= false;
                options.Password.RequireUppercase= false;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

           services.AddScoped<IAuthService, AuthService>();
           services.AddScoped<IJwtService, JwtService>();
            //configure validation error on global
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return new Microsoft.AspNetCore.Mvc.BadRequestObjectResult(BaseApiResponse.FailureResponse("Validation failed", errors, 400));
                };
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IVariantOptionService, VariantOptionService>();


            return services;

        }
    }
}

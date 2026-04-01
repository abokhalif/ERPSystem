using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UltimateAPI.Errors;
using UltimateAPI.Helpers;
using UltimateCore.IRepositories;
using UltimateRepository;

namespace UltimateAPI.Extensions
{
    public static class RegisterationService
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MappingProfiles));
            //configure validation error on global
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return new BadRequestObjectResult(ApiValidationErrorResponse.Fail("Validation failed", 400, errors));
                };
            });
            return services;
        }
    }
}

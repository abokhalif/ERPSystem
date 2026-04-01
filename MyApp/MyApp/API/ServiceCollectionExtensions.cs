using BLL.Helper;
using BLL.Services.UserService;

namespace API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}

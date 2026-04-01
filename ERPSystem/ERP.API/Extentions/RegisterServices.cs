using ERP.Persistence.Entities;
using ERP.Persistence.Entities.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ERP.API.Extentions
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services
            .AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<AppDbContext>()
             .AddDefaultTokenProviders();
            return services;
        }
    }
}

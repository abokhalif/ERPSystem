using BLL.Helper;
using DAL.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, UserManager<ApplicationUser> userManager)
        {
            var jwtHelper = context.RequestServices.GetRequiredService<IJwtHelper>();
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer".Length).Trim();
                if (!string.IsNullOrEmpty(token))
                {
                    await AttachUserToContext(context, userManager, jwtHelper, token);
                }
            }

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, UserManager<ApplicationUser> userManager, IJwtHelper jwtHelper, string token)
        {
            var principal = jwtHelper.ValidateJwtToken(token);
            if (principal != null)
            {
                var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await userManager.FindByIdAsync(userId);
                context.Items["User"] = user;
            }
        }
    }
}

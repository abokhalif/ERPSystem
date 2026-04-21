using ERP.Infrastructure.Implementation.Shared;
using ERP.Persistence.Entities.Authentication;
using ERP.Persistence.Interface;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ERP.API.Extentions
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
            var jwtservice = context.RequestServices.GetRequiredService<IJwtService>();
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer".Length).Trim();
                if (!string.IsNullOrEmpty(token))
                {
                    await AttachUserToContext(context, userManager, jwtservice, token);
                }
            }

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, UserManager<ApplicationUser> userManager, IJwtService jwtservice, string token)
        {
            var principal = jwtservice.ValidateJwtToken(token);
            if (principal != null)
            {
                var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await userManager.FindByIdAsync(userId);
                context.Items["User"] = user;
            }
        }
    }
}

using ERP.API.Middlewares;

namespace ERP.API.Extentions
{
    public static class MiddlewareRegisteration
    {
        public static IApplicationBuilder UseExceptionErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionErrorMiddleware>();
        }
        public static IApplicationBuilder UseProfilingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ProfilingMiddleware>();
        }
        public static IApplicationBuilder UseRateLimitingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RateLimitingMiddleware>();
        }
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}

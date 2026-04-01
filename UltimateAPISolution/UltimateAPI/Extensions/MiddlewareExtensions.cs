using UltimateAPI.Middlewares;

namespace UltimateAPI.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionErrorMiddleware>();
        }
    }
}

using ERP.API.Middlewares;

namespace ERP.API.Extentions
{
    public static class MiddlewareRegisteration
    {
        public static IApplicationBuilder UseExceptionErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionErrorMiddleware>();
        }
    }
}

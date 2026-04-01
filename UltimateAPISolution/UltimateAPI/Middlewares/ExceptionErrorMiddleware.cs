using System.Net;
using UltimateAPI.Errors;

namespace UltimateAPI.Middlewares
{
    public class ExceptionErrorMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionErrorMiddleware> logger;
        private readonly IHostEnvironment environment;

        public ExceptionErrorMiddleware(RequestDelegate next, ILogger<ExceptionErrorMiddleware> logger, IHostEnvironment environment)
        {
            this.next = next;
            this.logger = logger;
            this.environment = environment;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);

            }
            catch (Exception ex)
            {
                // in case development mode => return the developer ex page as json object
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = environment.IsDevelopment()
                    ? ApiExceptionErrorResponse.Fail(ex.Message, (int)HttpStatusCode.InternalServerError, ex.StackTrace.ToString())
                    : ApiExceptionErrorResponse.Fail(statusCode: (int)HttpStatusCode.InternalServerError);
                await context.Response.WriteAsJsonAsync(response);

                //in case production mode => log ex in database or files using serilog [later]

            }


        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Middlewares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static int _counter= 0;
        private static DateTime _lastRequestDate = DateTime.Now;
        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _counter++;
            if (DateTime.Now.Subtract(_lastRequestDate).Seconds > 10)
            {
                _counter=1; 
                _lastRequestDate = DateTime.Now;
                await _next(context);
            }
            else
            {
                _lastRequestDate = DateTime.Now;
                if (_counter>6)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Rate limit exceeded");
                }
                else
                {
                    await _next(context);
                }
            }

        }
    }
}

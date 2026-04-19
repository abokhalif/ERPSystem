using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ERP.API.Filters
{
    public class LogSevsitiveAttribute:ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Debug.WriteLine($"device IP = {context.HttpContext.Connection?.LocalIpAddress?.ToString()}");
            return Task.CompletedTask;
        }
    }
}

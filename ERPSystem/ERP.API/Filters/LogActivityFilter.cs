using Microsoft.AspNetCore.Mvc.Filters;

namespace ERP.API.Filters
{
    public class LogActivityFilter : IActionFilter
    {
        private readonly ILogger<LogActivityFilter> _logger;

        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Executing Action{context.ActionDescriptor.DisplayName}on controller {context.Controller.ToString()}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"ExecutedAction{context.ActionDescriptor.DisplayName}on controller {context.Controller.ToString()}");
        }
    }
}

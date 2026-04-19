//namespace ERP.API.Middlewares
//{
//   public class ValidationMiddleware
//{
//    private readonly RequestDelegate _next;

//    public ValidationMiddleware(RequestDelegate next)
//    {
//        _next = next;
//    }

//    public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
//    {
//        var endpoint = context.GetEndpoint();

//        if (endpoint == null)
//        {
//            await _next(context);
//            return;
//        }

//        var requestType = endpoint.Metadata
//            .OfType<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>()
//            .FirstOrDefault()?.Parameters.FirstOrDefault()?.ParameterType;

//        if (requestType == null)
//        {
//            await _next(context);
//            return;
//        }

//        var validatorType = typeof(IValidator<>).MakeGenericType(requestType);
//        var validator = serviceProvider.GetService(validatorType) as dynamic;

//        if (validator == null)
//        {
//            await _next(context);
//            return;
//        }

//        var request = context.Items["__request"];

//        if (request == null)
//        {
//            await _next(context);
//            return;
//        }

//        var result = await validator.ValidateAsync((dynamic)request);

//        if (!result.IsValid)
//        {
//            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

//            var response = ApiResponse<object>.FailureResponse(
//                "Validation failed",
//                errors,
//                400);

//            context.Response.StatusCode = 400;
//            await context.Response.WriteAsJsonAsync(response);
//            return;
//        }

//        await _next(context);
//    }
//}

//}

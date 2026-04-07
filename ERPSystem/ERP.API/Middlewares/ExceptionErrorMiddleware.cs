using ERP.API.ResponseModels;
using ERP.Application.ResponseModels;
using System.Net;

namespace ERP.API.Middlewares
{
        /// <summary>
        /// Global exception handling middleware.
        /// </summary>
        public class ExceptionErrorMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILogger<ExceptionErrorMiddleware> _logger;
            private readonly IHostEnvironment _environment;

            public ExceptionErrorMiddleware(
                RequestDelegate next,
                ILogger<ExceptionErrorMiddleware> logger,
                IHostEnvironment environment)
            {
                _next = next ?? throw new ArgumentNullException(nameof(next));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            }

            /// <summary>
            /// Processes the HTTP request and handles exceptions.
            /// </summary>
            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next.Invoke(context);
                }
                catch (ArgumentNullException ex)
                {
                    _logger.LogError(ex, "Argument null exception occurred");
                    await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest, "Invalid request parameters");
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex, "Argument exception occurred");
                    await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest, "Invalid argument provided");
                }
                catch (UnauthorizedAccessException ex)
                {
                    _logger.LogError(ex, "Unauthorized access exception occurred");
                    await HandleExceptionAsync(context, ex, HttpStatusCode.Unauthorized, "Unauthorized access");
                }
                catch (KeyNotFoundException ex)
                {
                    _logger.LogError(ex, "Resource not found");
                    await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound, "Resource not found");
                }
                catch (InvalidOperationException ex)
                {
                    _logger.LogError(ex, "Invalid operation exception occurred");
                    await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest, "Invalid operation");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unhandled exception occurred: {ExceptionMessage}", ex.Message);
                    await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError, "An error occurred while processing your request");
                }
            }

            /// <summary>
            /// Handles exceptions and writes response to context.
            /// </summary>
            private Task HandleExceptionAsync(
                HttpContext context,
                Exception exception,
                HttpStatusCode statusCode,
                string message)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                BaseApiResponse response;

                if (_environment.IsDevelopment())
                {
                    // In development: provide detailed stack trace and inner exceptions
                    response = BaseApiResponse.ErrorResponseDetailedEx(
                        exception,
                        details: $"{message}\n\nStack Trace: {exception.StackTrace}",
                        statusCode: (int)statusCode);
                }
                else
                {
                    // In production: provide generic message without sensitive details
                    response = BaseApiResponse.ErrorResponse(
                        exception,
                        statusCode: (int)statusCode);

                    // Override message for production
                    response.Message = message;
                }

                return context.Response.WriteAsJsonAsync(response);
            }
        }
    }

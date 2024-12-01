using Amazon.Core.Errors;
using Newtonsoft.Json;

namespace Amazon.Apis.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred");

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case ServiceException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case DataAccessException:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var response = new ErrorResponse
            {
                Message = exception.Message,
                Details = exception.InnerException?.Message
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }

    public class ErrorResponse
    {
        public string Message { get; set; }
        public string Details { get; set; }
    }

}

using BugTracking.Api.Common.Exceptions;
using Serilog;

namespace BugTracking.Api.Common.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseExceptionHandler ex)
            {
                Log.Error(ex, "BadRequestException occurred: {Message}", ex.Message);

                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsJsonAsync(new
                {
                    Status = ex.StatusCode,
                    Message = ex.Message,
                    Error = ex.GetType().Name.Replace("Exception", "")
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unexpected error occurred");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "An unexpected error occurred",
                    Error = ex.GetType().Name.Replace("Exception", "")
                });
            }
        }
    }
}

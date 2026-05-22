using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PruebaTecnica.Infrastructure.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var method = context.Request.Method;

            var path = context.Request.Path;

            var timestamp = DateTime.UtcNow;

            _logger.LogInformation(
                "HTTP Request Information: Method={Method}, Path={Path}, Timestamp={Timestamp}",
                method,
                path,
                timestamp);

            await _next(context);
        }
    }
}

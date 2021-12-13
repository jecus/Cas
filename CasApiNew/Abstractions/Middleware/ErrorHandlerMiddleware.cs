using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Abstractions.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlerMiddleware> logger)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Неопознанная ошибка!");

                if (string.IsNullOrEmpty(context.Response.ContentType))
                    context.Response.ContentType = "application/json";

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { Error = ex.Message, InnerError = ex.InnerException?.Message });
            }
        }

    }
}

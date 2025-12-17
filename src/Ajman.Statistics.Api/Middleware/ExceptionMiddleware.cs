using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Ajman.Statistics.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // now _next exists
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    error = "INTERNAL_ERROR",
                    message = ex.Message,
                    traceId = context.TraceIdentifier
                });
            }
        }
    }
}

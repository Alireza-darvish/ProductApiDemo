using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            bool unauthorized = true;
            if (httpContext.Request.Headers.TryGetValue("Authorization", out StringValues authHeader) && authHeader.Count == 1 && authHeader[0].StartsWith("Basic "))
            {
                var userandpass = authHeader[0][5..];
                var up = Encoding.UTF8.GetString(Convert.FromBase64String(userandpass)).Split(':');
                string username = up[0];
                string password = up[1];
                if (username.Equals("abc") && password.Equals("123")) unauthorized = false;
            }
            else unauthorized = true;
            if (unauthorized)
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await httpContext.Response.WriteAsync("401 - Unauthorized");
            }
            else await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BasicAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}

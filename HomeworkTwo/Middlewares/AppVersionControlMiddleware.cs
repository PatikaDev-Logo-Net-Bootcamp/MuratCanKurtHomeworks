using HomeworkTwo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace HomeworkTwo.Middlewares
{
    public class AppVersionControlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppOptions _option;

        public AppVersionControlMiddleware(RequestDelegate next, AppOptions option)
        {
            _next = next;
            _option = option;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var req = httpContext.Request.Path.ToString().ToLower();
            if (!(req.Contains("login") || req.Contains("register")))
            {
                httpContext.Request.Headers.TryGetValue("AppVersion", out var requestVersion);
                if (double.Parse(requestVersion) > double.Parse(_option.AppVersion))
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }

            return _next(httpContext);

        }
    }

    public static class AppVersionControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseAppVersionControlMiddleware(this IApplicationBuilder builder, AppOptions option)
        {
            return builder.UseMiddleware<AppVersionControlMiddleware>(option);
        }
    }
}

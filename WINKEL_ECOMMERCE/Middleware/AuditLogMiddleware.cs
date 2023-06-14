using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuditLogMiddleware
    {
        private readonly RequestDelegate _next;

        public AuditLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            using(var scope = httpContext.RequestServices.CreateScope())
            {
                WINKEL_ApplicationDbContext _context = scope.ServiceProvider.GetRequiredService<WINKEL_ApplicationDbContext>();

                var routeData = httpContext.GetRouteData();
                string area = "", controller = "", action = "", queryString = "";
                if (routeData.Values.TryGetValue("area", out object oArea))
                    area = oArea.ToString();
                if (routeData.Values.TryGetValue("controller", out object oController))
                    controller = oController.ToString();
                if (routeData.Values.TryGetValue("action", out object oAction))
                    action = oAction.ToString();
                if (string.IsNullOrWhiteSpace(httpContext.Request.QueryString.Value))
                {
                    queryString = httpContext.Request.QueryString.Value;
                }
                var log = new AuditLog()
                {
                    Username = httpContext.User.Identity?.Name,
                    Path = httpContext.Request.Path,
                    IsHttps = httpContext.Request.IsHttps,
                    Area = area,
                    Controller = controller,
                    Action = action,
                    Method = httpContext.Request.Method,
                    QueryString = queryString,
                    RequestTime = DateTime.Now
            };
                await _next(httpContext);
                log.StatusCode = httpContext.Response.StatusCode.ToString();
                log.ResponseTime = DateTime.Now;
                await _context.AuditLogs.AddAsync(log);
                await _context.SaveChangesAsync();
                //httpContext.Request.Headers.
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuditLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuditLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuditLogMiddleware>();
        }
    }
}

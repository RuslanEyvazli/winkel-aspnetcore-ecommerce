 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WINKEL_ECOMMERCE.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyLogging
    {
        private readonly RequestDelegate _next;

        public MyLogging(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var routeData = httpContext.GetRouteData();
            //string action = routeData.Values["action"].ToString();
            string controller = "" , action = "";
            if(routeData.Values.TryGetValue("axtion", out object act))
            {
                action = act.ToString();
            }
            if (routeData.Values.TryGetValue("controller",out object ctor))
            {
                controller = ctor.ToString();
            }
            using (var log = new StreamWriter("log.txt", true))
            {
                log.WriteLine($"[{DateTime.Now:dd.MM.yyyy HH:mm:ss:ffffff}]: {controller}/{action}");
                await _next(httpContext);
            }
                //yield return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyLoggingExtensions
    {
        public static IApplicationBuilder UseMyLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyLogging>();
        }
    }
}

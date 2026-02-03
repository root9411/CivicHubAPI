using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace APIGateway.Middlewares
{
    
    public class InterceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public InterceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            context.Request.Headers["Referrer"] = "Api-Gateway";

            await _next(context);
        }
    }

}

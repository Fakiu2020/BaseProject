using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Whoever.Web.Middlewares
{
    public class NoServerHttpHeaderMiddleware
    {
        private const string ServerHttpHeaderName = "Server";

        private readonly RequestDelegate next;

        public NoServerHttpHeaderMiddleware(RequestDelegate next) => this.next = next;

        public Task Invoke(HttpContext context)
        {
            // TODO: Check version
            context.Response.Headers.Remove(ServerHttpHeaderName);
            return this.next.Invoke(context);
        }
    }
}

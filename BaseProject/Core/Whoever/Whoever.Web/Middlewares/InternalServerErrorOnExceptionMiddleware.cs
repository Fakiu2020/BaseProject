using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Whoever.Web.Middlewares
{
    public class InternalServerErrorOnExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public InternalServerErrorOnExceptionMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context).ConfigureAwait(false);
            }
            catch
            {
                //var factory = context.RequestServices.GetRequiredService<ILoggerFactory>();
                //var logger = factory.CreateLogger<InternalServerErrorOnExceptionMiddleware>();
                //logger.LogInformation(
                //    "Executing InternalServerErrorOnExceptionMiddleware, setting HTTP status code {0}.",
                //    StatusCodes.Status500InternalServerError);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}

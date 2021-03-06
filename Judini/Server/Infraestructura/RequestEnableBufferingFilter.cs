using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Judini.Server.Infraestructura
{
    public class RequestEnableBufferingFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Request.EnableBuffering();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // no hace falta implementacion
        }
    }
}

using System.Net;
using Judini.Shared;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Judini.Server.Infraestructura
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly TelemetryClient telemetryClient;

        public ExceptionFilter(TelemetryClient telemetryClient)
        {
            this.telemetryClient = telemetryClient;
        }

        public void OnException(ExceptionContext context)
        {
            var code = HttpStatusCode.InternalServerError;

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new ExceptionDto(context.Exception));
        }
    }
}

using Microsoft.ApplicationInsights;
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
            this.telemetryClient.TrackException(context.Exception);
        }
    }
}

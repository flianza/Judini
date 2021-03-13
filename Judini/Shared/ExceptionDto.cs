using System;

namespace Judini.Shared
{
    public class ExceptionDto
    {
        public string Mensaje { get; }
        public string Tipo { get; }
        public string StackTrace { get; }
        public ExceptionDto(Exception exception)
        {
            this.Mensaje = exception.Message;
            this.Tipo = exception.GetType().Name;
            this.StackTrace = exception.StackTrace;
        }
    }
}

using System;

namespace Judini.Client.Infraestructura
{
    public class DateProvider : IDateProvider
    {
        readonly TimeZoneInfo zona = TimeZoneInfo.FindSystemTimeZoneById("America/Argentina/Catamarca");
        public DateTime Now => TimeZoneInfo.ConvertTime(DateTime.Now, this.zona);
    }
}

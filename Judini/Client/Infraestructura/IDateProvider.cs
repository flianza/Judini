using System;

namespace Judini.Client.Infraestructura
{
    public interface IDateProvider
    {
        DateTime Now { get; }
    }
}

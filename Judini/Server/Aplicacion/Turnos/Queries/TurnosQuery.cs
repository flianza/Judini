using System.Collections.Generic;
using Judini.Shared.Turnos;
using MediatR;

namespace Judini.Server.Aplicacion.Turnos.Queries
{
    public class TurnosQuery : IRequest<IEnumerable<Turno>>
    {
    }
}

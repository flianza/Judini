using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Judini.Shared.Turnos;

namespace Judini.Client.Servicios.Turnos.Contratos
{
    public interface ITurnosApi
    {
        Task<IEnumerable<Turno>> Todos(CancellationToken cancellationToken = default);
        Task<int> Crear(Turno turno, CancellationToken cancellationToken = default);
    }
}

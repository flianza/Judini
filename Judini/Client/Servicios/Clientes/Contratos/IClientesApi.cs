using System.Threading;
using System.Threading.Tasks;
using Judini.Shared.Clientes;

namespace Judini.Client.Servicios.Clientes.Contratos
{
    public interface IClientesApi
    {
        Task<int> Crear(CrearClienteRequest request, CancellationToken cancellationToken = default);
    }
}

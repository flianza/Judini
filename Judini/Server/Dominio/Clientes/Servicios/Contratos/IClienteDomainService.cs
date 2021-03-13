using System.Threading.Tasks;
using Judini.Shared.Clientes;

namespace Judini.Server.Dominio.Clientes.Servicios.Contratos
{
    public interface IClienteDomainService
    {
        Task<Cliente> Crear(ClienteDto clienteDto);
    }
}

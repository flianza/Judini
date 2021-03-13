using System.Linq;
using System.Threading.Tasks;
using Judini.Server.Dominio.Clientes.Excepciones;
using Judini.Server.Dominio.Clientes.Servicios.Contratos;
using Judini.Shared.Clientes;

namespace Judini.Server.Dominio.Clientes.Servicios.Implementaciones
{
    public class ClienteDomainService : IClienteDomainService
    {
        private readonly IRepository<Cliente> repository;

        public ClienteDomainService(IRepository<Cliente> repository)
        {
            this.repository = repository;
        }

        public Task<Cliente> Crear(ClienteDto clienteDto)
        {
            var clienteExiste = this.repository.All().Any(c => c.Dni == clienteDto.Dni);

            if (!clienteExiste)
            {
                return Task.FromResult(new Cliente(clienteDto));
            }

            throw new ClienteYaExisteException(clienteDto.Dni.ToString());
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Judini.Server.Dominio;
using Judini.Server.Dominio.Clientes;
using Judini.Server.Dominio.Clientes.Servicios.Contratos;
using Judini.Shared;
using MediatR;

namespace Judini.Server.Aplicacion.Clientes.Commands
{
    public class CrearClienteCommandHandler : IRequestHandler<CrearClienteCommand, IdResponse>
    {
        private readonly IClienteDomainService clienteDomainService;
        private readonly IRepository<Cliente> repository;

        public CrearClienteCommandHandler(IClienteDomainService clienteDomainService, IRepository<Cliente> repository)
        {
            this.clienteDomainService = clienteDomainService;
            this.repository = repository;
        }

        public async Task<IdResponse> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await this.clienteDomainService.Crear(request.ClienteDto);

            this.repository.Add(cliente);

            await this.repository.SaveAsync();

            return new IdResponse { Id = cliente.Id };
        }
    }
}

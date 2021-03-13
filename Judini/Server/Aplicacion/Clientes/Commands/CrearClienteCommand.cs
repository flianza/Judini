using Judini.Shared;
using Judini.Shared.Clientes;
using MediatR;

namespace Judini.Server.Aplicacion.Clientes.Commands
{
    public class CrearClienteCommand : IRequest<IdResponse>
    {
        public ClienteDto ClienteDto { get; }

        public CrearClienteCommand(ClienteDto clienteDto)
        {
            this.ClienteDto = clienteDto;
        }
    }
}

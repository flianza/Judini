using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Judini.Server.Aplicacion.Clientes.Commands;
using Judini.Shared.Clientes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Judini.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClientesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<CreatedResult> PostCrearCliente([FromBody, Required] CrearClienteRequest request)
        {
            var command = new CrearClienteCommand(request.Cliente);

            var response = await this.mediator.Send(command);

            return this.Created("/clientes", response.Id);
        }
    }
}

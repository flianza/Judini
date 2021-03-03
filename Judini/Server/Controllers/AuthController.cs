using System.Threading.Tasks;
using Judini.Server.Commands;
using Judini.Server.Queries;
using Judini.Shared.Requests;
using Judini.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Judini.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("iniciar-sesion")]
        public async Task<IActionResult> PostIniciarSesion(IniciarSesionRequest request)
        {
            var command = new IniciarSesionCommand(request.NombreDeUsuario, request.Contrasenia, request.Recordarme);

            await this.mediator.Send(command);

            return this.Ok();
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> PostRegistrar(RegistrarUsuarioRequest request)
        {
            var command = new RegistrarUsuarioCommand(request.NombreDeUsuario, request.Contrasenia, request.Nombre, request.Apellido, request.Email);

            await this.mediator.Send(command);

            return this.Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("cerrar-sesion")]
        public async Task<IActionResult> PostCerrarSesion()
        {
            var command = new CerrarSesionCommand();

            await this.mediator.Send(command);

            return this.Ok();
        }

        [HttpGet]
        [Route("sesion")]
        public async Task<ActionResult<SesionActualResponse>> GetSesionActual()
        {
            var query = new SesionActualQuery(this.User);

            var response = await this.mediator.Send(query);

            return this.Ok(response);
        }
    }
}

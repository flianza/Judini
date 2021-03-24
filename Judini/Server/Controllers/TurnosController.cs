using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Judini.Server.Aplicacion.Turnos.Commands;
using Judini.Server.Aplicacion.Turnos.Queries;
using Judini.Shared.Turnos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Judini.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly IMediator mediator;

        public TurnosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnos()
        {
            var query = new TurnosQuery();

            var response = await this.mediator.Send(query);

            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<CreatedResult> PostCrearTurno([FromBody, Required] Turno turno)
        {
            var command = new CrearTurnoCommand(turno);

            var response = await this.mediator.Send(command);

            return this.Created("/turnos", response.Id);
        }
    }
}

using Judini.Shared;
using Judini.Shared.Turnos;
using MediatR;

namespace Judini.Server.Aplicacion.Turnos.Commands
{
    public class CrearTurnoCommand : IRequest<IdResponse>
    {
        public Turno Turno { get; }

        public CrearTurnoCommand(Turno turno)
        {
            this.Turno = turno;
        }
    }
}

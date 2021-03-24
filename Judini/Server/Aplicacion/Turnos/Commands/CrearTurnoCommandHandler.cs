using System.Threading;
using System.Threading.Tasks;
using Judini.Server.Dominio;
using Judini.Server.Dominio.Turnos;
using Judini.Shared;
using MediatR;

namespace Judini.Server.Aplicacion.Turnos.Commands
{
    public class CrearTurnoCommandHandler : IRequestHandler<CrearTurnoCommand, IdResponse>
    {
        private readonly IRepository<Turno> repository;

        public CrearTurnoCommandHandler(IRepository<Turno> repository)
        {
            this.repository = repository;
        }

        public async Task<IdResponse> Handle(CrearTurnoCommand request, CancellationToken cancellationToken)
        {
            var turno = new Turno(request.Turno);

            this.repository.Add(turno);

            await this.repository.SaveAsync();

            return new IdResponse { Id = turno.Id };
        }
    }
}

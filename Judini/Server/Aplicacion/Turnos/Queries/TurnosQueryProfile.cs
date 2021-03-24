using AutoMapper;

namespace Judini.Server.Aplicacion.Turnos.Queries
{
    public class TurnosQueryProfile : Profile
    {
        public TurnosQueryProfile()
        {
            this.CreateMap<Dominio.Turnos.Turno, Shared.Turnos.Turno>();
        }
    }
}

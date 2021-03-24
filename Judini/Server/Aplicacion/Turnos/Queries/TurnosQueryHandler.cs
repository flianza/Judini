using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Judini.Server.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Judini.Server.Aplicacion.Turnos.Queries
{
    public class TurnosQueryHandler : IRequestHandler<TurnosQuery, IEnumerable<Shared.Turnos.Turno>>
    {
        private readonly IRepository<Dominio.Turnos.Turno> repository;
        private readonly IMapper mapper;

        public TurnosQueryHandler(IRepository<Dominio.Turnos.Turno> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Shared.Turnos.Turno>> Handle(TurnosQuery request, CancellationToken cancellationToken)
        {
            return await this.repository.All()
                             .ProjectTo<Shared.Turnos.Turno>(this.mapper.ConfigurationProvider)
                             .ToListAsync(cancellationToken);
        }
    }
}

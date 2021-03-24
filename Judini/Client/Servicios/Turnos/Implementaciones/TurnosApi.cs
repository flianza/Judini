using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Judini.Client.Infraestructura;
using Judini.Client.Servicios.Turnos.Contratos;
using Judini.Shared.Turnos;

namespace Judini.Client.Servicios.Turnos.Implementacioens
{
    public class TurnosApi : ITurnosApi
    {
        private readonly HttpClient httpClient;

        public TurnosApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Turno>> Todos(CancellationToken cancellationToken = default)
        {
            return await this.httpClient.GetAsync<IEnumerable<Turno>>("api/turnos", cancellationToken);
        }

        public async Task<int> Crear(Turno turno, CancellationToken cancellationToken = default)
        {
            return await this.httpClient.PostAsync<Turno, int>("api/turnos", turno, cancellationToken);
        }
    }
}

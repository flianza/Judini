using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Judini.Client.Infraestructura;
using Judini.Client.Servicios.Clientes.Contratos;
using Judini.Shared.Clientes;

namespace Judini.Client.Servicios.Clientes.Implementacioens
{
    public class ClientesApi : IClientesApi
    {
        private readonly HttpClient httpClient;

        public ClientesApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> Crear(CrearClienteRequest request, CancellationToken cancellationToken = default)
        {
            return await this.httpClient.PostAsync<CrearClienteRequest, int>("api/clientes", request, cancellationToken);
        }
    }
}

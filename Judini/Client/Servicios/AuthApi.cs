using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Judini.Shared.Requests;
using Judini.Shared.Responses;

namespace Judini.Client.Servicios
{
    public class AuthApi : IAuthApi
    {
        private readonly HttpClient httpClient;

        public AuthApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task IniciarSesion(IniciarSesionRequest iniciarSesionRequest)
        {
            var resultado = await this.httpClient.PostAsJsonAsync("api/auth/iniciar-sesion", iniciarSesionRequest);

            if (resultado.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await resultado.Content.ReadAsStringAsync());
            }

            resultado.EnsureSuccessStatusCode();
        }

        public async Task CerrarSesion()
        {
            var resultado = await this.httpClient.PostAsync("api/auth/cerrar-sesion", null);

            resultado.EnsureSuccessStatusCode();
        }

        public async Task RegistrarUsuario(RegistrarUsuarioRequest registrarUsuarioRequest)
        {
            var resultado = await this.httpClient.PostAsJsonAsync("api/auth/registrar", registrarUsuarioRequest);

            if (resultado.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await resultado.Content.ReadAsStringAsync());
            }

            resultado.EnsureSuccessStatusCode();
        }

        public async Task<SesionActualResponse> ObtenerSesion()
        {
            return await this.httpClient.GetFromJsonAsync<SesionActualResponse>("api/auth/sesion");
        }
    }
}

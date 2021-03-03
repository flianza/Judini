using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Judini.Client.Servicios;
using Judini.Shared.Requests;
using Judini.Shared.Responses;
using Microsoft.AspNetCore.Components.Authorization;

namespace Judini.Client.Infraestructura
{
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private SesionActualResponse datosSesion;
        private readonly IAuthApi authApi;

        public IdentityAuthenticationStateProvider(IAuthApi authApi)
        {
            this.authApi = authApi;
        }

        public async Task IniciarSesion(IniciarSesionRequest loginParameters)
        {
            await this.authApi.IniciarSesion(loginParameters);

            this.NotifyAuthenticationStateChanged(this.GetAuthenticationStateAsync());
        }

        public async Task RegistrarUsuario(RegistrarUsuarioRequest registerParameters)
        {
            await this.authApi.RegistrarUsuario(registerParameters);
            
            this.NotifyAuthenticationStateChanged(this.GetAuthenticationStateAsync());
        }

        public async Task CerrarSesion()
        {
            await this.authApi.CerrarSesion();
            
            this.datosSesion = null;
            
            this.NotifyAuthenticationStateChanged(this.GetAuthenticationStateAsync());
        }

        public async Task<SesionActualResponse> ObtenerSesionActual()
        {
            if (this.datosSesion == null || !this.datosSesion.IsAuthenticated)
            {
                this.datosSesion = await this.authApi.ObtenerSesion();
            }
            
            return this.datosSesion;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await this.ObtenerSesionActual();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] 
                    { 
                        new Claim(ClaimTypes.Name, userInfo.UserName) 
                    }.Concat(userInfo.Claims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}

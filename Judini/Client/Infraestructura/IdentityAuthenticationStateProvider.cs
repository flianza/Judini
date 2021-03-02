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
        private SesionResponse datosSesion;
        private readonly IAuthApi authApi;

        public IdentityAuthenticationStateProvider(IAuthApi authApi)
        {
            this.authApi = authApi;
        }

        public async Task Login(IniciarSesionRequest loginParameters)
        {
            await this.authApi.IniciarSesion(loginParameters);

            this.NotifyAuthenticationStateChanged(this.GetAuthenticationStateAsync());
        }

        public async Task Register(RegistrarUsuarioRequest registerParameters)
        {
            await this.authApi.RegistrarUsuario(registerParameters);
            
            this.NotifyAuthenticationStateChanged(this.GetAuthenticationStateAsync());
        }

        public async Task Logout()
        {
            await this.authApi.CerrarSesion();
            
            this.datosSesion = null;
            
            this.NotifyAuthenticationStateChanged(this.GetAuthenticationStateAsync());
        }

        private async Task<SesionResponse> ObtenerSesion()
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
                var userInfo = await this.ObtenerSesion();
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

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Judini.Server.Dominio;
using Judini.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Judini.Server.Aplication.Queries
{
    public class SesionActualQueryHandler : IRequestHandler<SesionActualQuery, SesionActualResponse>
    {
        private readonly UserManager<Usuario> userManager;

        public SesionActualQueryHandler(UserManager<Usuario> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<SesionActualResponse> Handle(SesionActualQuery request, CancellationToken cancellationToken)
        {
            var response = new SesionActualResponse
            {
                IsAuthenticated = request.User.Identity.IsAuthenticated,
                UserName = request.User.Identity.Name,
                Claims = request.User.Claims.ToDictionary(c => c.Type, c => c.Value),
            };

            if (response.IsAuthenticated)
            {
                var usuario = await this.userManager.GetUserAsync(request.User);

                response.Nombre = usuario.Nombre;
                response.Apellido = usuario.Apellido;
                response.Email = usuario.Email;
            }

            return response;
        }
    }
}

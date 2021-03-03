using System.Threading;
using System.Threading.Tasks;
using Judini.Server.Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Judini.Server.Aplication.Commands
{
    public class CerrarSesionCommandHandler : IRequestHandler<CerrarSesionCommand>
    {
        private readonly SignInManager<Usuario> signInManager;

        public CerrarSesionCommandHandler(SignInManager<Usuario> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<Unit> Handle(CerrarSesionCommand request, CancellationToken cancellationToken)
        {
            await this.signInManager.SignOutAsync();

            return Unit.Value;
        }
    }
}

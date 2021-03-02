using System;
using System.Threading;
using System.Threading.Tasks;
using Judini.Server.Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Judini.Server.Commands
{
    public class IniciarSesionCommandHandler : IRequestHandler<IniciarSesionCommand>
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;

        public IniciarSesionCommandHandler(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Unit> Handle(IniciarSesionCommand request, CancellationToken cancellationToken)
        {
            var usuario = await this.userManager.FindByNameAsync(request.NombreDeUsuario);

            if (usuario == null)
            {
                throw new Exception("Usuario y/o contraseña incorrectos");
            }

            var resultadoCheckeoContrasenia = await this.signInManager.CheckPasswordSignInAsync(usuario, request.Contrasenia, false);

            if (!resultadoCheckeoContrasenia.Succeeded)
            {
                throw new Exception("Usuario y/o contraseña incorrectos");
            }

            await this.signInManager.SignInAsync(usuario, request.Recordarme);

            return Unit.Value;
        }
    }
}

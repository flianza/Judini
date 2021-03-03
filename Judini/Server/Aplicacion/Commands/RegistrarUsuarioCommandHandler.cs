using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Judini.Server.Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Judini.Server.Aplication.Commands
{
    public class RegistrarUsuarioCommandHandler : IRequestHandler<RegistrarUsuarioCommand>
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;

        public RegistrarUsuarioCommandHandler(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Unit> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.NombreDeUsuario, request.Nombre, request.Apellido, request.Email);

            var resultadoCrearUsuario = await this.userManager.CreateAsync(usuario, request.Contrasenia);
            
            if (!resultadoCrearUsuario.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, resultadoCrearUsuario.Errors.Select(e => e.Description)));
            }

            await this.signInManager.SignInAsync(usuario, true);

            return Unit.Value;
        }
    }
}

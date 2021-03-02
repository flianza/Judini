using MediatR;

namespace Judini.Server.Commands
{
    public class RegistrarUsuarioCommand : IRequest
    {
        public string NombreDeUsuario { get; }
        public string Contrasenia { get; }

        public RegistrarUsuarioCommand(string nombreDeUsuario, string contrasenia)
        {
            this.NombreDeUsuario = nombreDeUsuario;
            this.Contrasenia = contrasenia;
        }
    }
}

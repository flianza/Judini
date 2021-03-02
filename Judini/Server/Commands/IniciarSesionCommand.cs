using MediatR;

namespace Judini.Server.Commands
{
    public class IniciarSesionCommand : IRequest
    {
        public string NombreDeUsuario { get; }
        public string Contrasenia { get; }
        public bool Recordarme { get; }

        public IniciarSesionCommand(string nombreDeUsuario, string contrasenia, bool recordarme)
        {
            this.NombreDeUsuario = nombreDeUsuario;
            this.Contrasenia = contrasenia;
            this.Recordarme = recordarme;
        }
    }
}

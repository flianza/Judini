using MediatR;

namespace Judini.Server.Commands
{
    public class RegistrarUsuarioCommand : IRequest
    {
        public string NombreDeUsuario { get; }
        public string Contrasenia { get; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public RegistrarUsuarioCommand(string nombreDeUsuario, string contrasenia, string nombre, string apellido, string email)
        {
            this.NombreDeUsuario = nombreDeUsuario;
            this.Contrasenia = contrasenia;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
        }
    }
}

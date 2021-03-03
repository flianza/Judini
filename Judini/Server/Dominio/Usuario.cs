using System;
using Microsoft.AspNetCore.Identity;

namespace Judini.Server.Dominio
{
    public class Usuario : IdentityUser<Guid>
    {
        public string Nombre { get; protected set; }
        public string Apellido { get; protected set; }

        public Usuario() : base() 
        {
        }

        public Usuario(string nombreDeUsuario, string nombre, string apellido, string email) : base(nombreDeUsuario)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
        }
    }
}

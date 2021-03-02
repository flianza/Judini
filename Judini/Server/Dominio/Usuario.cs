using System;
using Microsoft.AspNetCore.Identity;

namespace Judini.Server.Dominio
{
    public class Usuario : IdentityUser<Guid>
    {
        public Usuario() : base() 
        {
        }

        public Usuario(string nombreDeUsuario) : base(nombreDeUsuario)
        {
        }
    }
}

using System;
using Judini.Server.Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Judini.Server.AccesoDatos
{
    public class ContextoBd : IdentityDbContext<Usuario, IdentityRole<Guid>, Guid>
    {
        public ContextoBd(DbContextOptions<ContextoBd> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Judini.Server.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Judini.Server.AccesoDatos
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly ContextoBd contexto;

        public Repository(ContextoBd contexto)
        {
            this.contexto = contexto;
        }

        public void Add(T entity)
        {
            if (this.contexto.Entry(entity).State == EntityState.Detached)
            {
                this.contexto.Add(entity);
            }
        }

        public IEnumerable<T> All()
        {
            return this.contexto.Set<T>();
        }

        public async Task SaveAsync()
        {
            await this.contexto.SaveChangesAsync();
        }
    }
}

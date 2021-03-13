using System.Collections.Generic;
using System.Threading.Tasks;

namespace Judini.Server.Dominio
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> All();
        void Add(T entity);
        Task SaveAsync();
    }
}

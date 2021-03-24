using System.Linq;
using System.Threading.Tasks;

namespace Judini.Server.Dominio
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();
        void Add(T entity);
        Task SaveAsync();
    }
}

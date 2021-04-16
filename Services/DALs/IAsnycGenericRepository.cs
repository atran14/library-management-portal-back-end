using System.Linq;
using System.Threading.Tasks;
using back_end.Models;

namespace back_end.Services.DALs
{
    public interface IAsyncGenericRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
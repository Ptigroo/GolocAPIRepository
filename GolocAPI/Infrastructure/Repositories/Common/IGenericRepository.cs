using GolocAPI.Entities;
using GolocAPI.Entities.Common;

namespace GolocAPI.Infrastructure.Repositories.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}

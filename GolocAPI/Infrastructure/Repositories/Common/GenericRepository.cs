using Infrastructure;
using GolocAPI.Entities.Common;
using Microsoft.EntityFrameworkCore;
using GolocAPI.Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly GolocDbContext golocDbContext;

        public GenericRepository(GolocDbContext golocDbContext)
        {
            this.golocDbContext = golocDbContext;
        }
        public virtual async Task Create(T entity)
        {
               await golocDbContext.AddAsync(entity);
        }

        public virtual async Task Delete(T entity)
        {
            golocDbContext.Remove(entity);
        }

        public virtual async Task<T> GetById(int id)
        {
            return await golocDbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task Update(T entity)
        {
            golocDbContext.Update(entity);
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return golocDbContext.Set<T>().AsEnumerable();
        }
    }
}

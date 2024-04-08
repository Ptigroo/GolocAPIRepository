using GolocAPI;
using GolocAPI.Entities.Common;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories.Common;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetById(Guid id);
    Task<List<T>> GetAll();
    PaginatedList<T> GetPaginated(int pageNumber, int pageSize);
}
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly GolocDbContext golocDbContext;

    public GenericRepository(GolocDbContext golocDbContext)
    {
        this.golocDbContext = golocDbContext;
    }
    public virtual async Task<T> Create(T entity)
    {
        entity.CreationDate = DateTime.Now;
        await golocDbContext.AddAsync(entity);
        return entity;
    }
    public virtual void Delete(T entity)
    {
        golocDbContext.Remove(entity);
    }
    public virtual async Task<T> GetById(Guid id)
    {
        T? entity = await golocDbContext.Set<T>().FindAsync(id);
        if (entity == null)
        {
            throw new Exception("Entity not found");
        }
        return entity;
    }
    public virtual void Update(T entity)
    {
        entity.ModifiedDate = DateTime.Now;
        golocDbContext.Update(entity);
    }
    public virtual async Task<List<T>> GetAll()
    {
        return await golocDbContext.Set<T>().ToListAsync();
    }
    public PaginatedList<T> GetPaginated(int pageNumber, int pageSize)
    {
        return PaginatedList<T>.ToPaginatedList(golocDbContext.Set<T>(), pageNumber, pageSize);
    }
}

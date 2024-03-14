using GolocAPI.Entities.Common;
namespace Infrastructure.Repositories.Common;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetById(Guid id);
    IEnumerable<T> GetAll();
}
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly GolocDbContext golocDbContext;

    public GenericRepository(GolocDbContext golocDbContext)
    {
        this.golocDbContext = golocDbContext;
    }
    public virtual async Task Create(T entity)
    {
        entity.CreationDate = DateTime.Now;
           await golocDbContext.AddAsync(entity);
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
    public virtual IEnumerable<T> GetAll()
    {
        return golocDbContext.Set<T>().AsEnumerable();
    }
}

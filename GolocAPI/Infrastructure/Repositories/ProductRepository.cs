using GolocAPI.Entities;
using Infrastructure;
using Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
namespace GolocAPI.Infrastructure.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        PaginatedList<Product> GetAllPaginated(int pageNumber, int pageSize);
    }
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly GolocDbContext golocDbContext;

        public ProductRepository(GolocDbContext golocDbContext) : base(golocDbContext)
        {
            this.golocDbContext = golocDbContext;
        }
        public override async Task<List<Product>> GetAll()
        {
            return await golocDbContext.Products.Include(product => product.Owner).ToListAsync();
        }
        public PaginatedList<Product> GetAllPaginated(int pageNumber, int pageSize)
        {
            return PaginatedList<Product>.ToPaginatedList(golocDbContext.Products.Include(product => product.Owner), pageNumber, pageSize);
        }
        public override async Task<Product> GetById(Guid id)
        {
            return await golocDbContext.Products.Include(product => product.Owner).FirstAsync(product => product.Id == id);
        }
    }
}

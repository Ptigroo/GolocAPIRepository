using GolocAPI.Entities;
using Infrastructure;
using Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
namespace GolocAPI.Infrastructure.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly GolocDbContext golocDbContext;

        public ProductRepository(GolocDbContext golocDbContext) : base(golocDbContext)
        {
            this.golocDbContext = golocDbContext;
        }
        public override IEnumerable<Product> GetAll()
        {
            return golocDbContext.Products.Include(product => product.Owner).AsEnumerable();
        }
        public override async Task<Product> GetById(Guid id)
        {
            return await golocDbContext.Products.Include(product => product.Owner).FirstAsync(product => product.Id == id);
        }

    }
}

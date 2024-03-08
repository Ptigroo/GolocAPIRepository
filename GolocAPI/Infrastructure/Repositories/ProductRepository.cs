using GolocAPI.Entities;
using GolocAPI.Infrastructure.Repositories.Common;
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

    }
}

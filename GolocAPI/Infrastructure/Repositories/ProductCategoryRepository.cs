using GolocAPI.Entities;
using Infrastructure.Repositories.Common;
using Infrastructure;

namespace GolocAPI.Infrastructure.Repositories
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
    }
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly GolocDbContext golocDbContext;

        public ProductCategoryRepository(GolocDbContext golocDbContext) : base(golocDbContext)
        {
            this.golocDbContext = golocDbContext;
        }
    }
}

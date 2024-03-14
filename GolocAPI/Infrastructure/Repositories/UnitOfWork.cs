using GolocAPI.Entities;
using GolocAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IRentRepository RentRepository { get; }
        Task Save();
    }
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly GolocDbContext golocDbContext;
        private readonly UserManager<User> _manager;
        private IUserRepository userRepository;
        private IProductRepository productRepository;
        private IProductCategoryRepository productCategoryRepository;
        private IRentRepository rentRepository;

        public UnitOfWork(GolocDbContext golocDbContext, UserManager<User> manager)
        {
            this.golocDbContext = golocDbContext;
            _manager = manager;
        }
        public IUserRepository UserRepository => userRepository ??= new UserRepository(_manager ,golocDbContext);
        public IProductRepository ProductRepository => productRepository ??= new ProductRepository(golocDbContext);
        public IProductCategoryRepository ProductCategoryRepository => productCategoryRepository ??= new ProductCategoryRepository(golocDbContext);
        public IRentRepository RentRepository => rentRepository ??= new RentRepository(golocDbContext);

        public void Dispose()
        {
            golocDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await golocDbContext.SaveChangesAsync();
        }
    }
}

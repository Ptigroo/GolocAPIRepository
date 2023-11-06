using GolocAPI.Entities;
using GolocAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly GolocDbContext golocDbContext;
        private readonly UserManager<User> _manager;
        private IUserRepository userRepository;

        public UnitOfWork(GolocDbContext golocDbContext, UserManager<User> manager)
        {
            this.golocDbContext = golocDbContext;
            _manager = manager;
        }
        public IUserRepository UserRepository => userRepository ??= new UserRepository(_manager ,golocDbContext);

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

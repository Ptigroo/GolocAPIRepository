using GolocAPI.Entities;
using GolocAPI.Infrastructure.Repositories;
using GolocAPI.Services;
using Infrastructure.Repositories.Common;
using GolocSharedLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        private readonly UserManager<User> _manager;
        public UserRepository(UserManager<User> manager, GolocDbContext golocDbContext) : base(golocDbContext)
        {
            _manager = manager;
        }
        public async Task Register(User entity, string password)
        {
            var result = await _manager.CreateAsync(entity, password);

            
            await _manager.AddToRoleAsync(entity, "Member");
        }
        public async Task<User> Login(LoginModel login)
        {
            return await _manager.FindByNameAsync(login.Login);
        }


    }
}

using GolocAPI.CommandsAndQueries.Authentication;
using GolocAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task Register(User entity, string password);
        Task<User> Login(LoginQuery login);
        IEnumerable<User> GetAll();
    }
    internal class UserRepository : IUserRepository
    {

        private readonly UserManager<User> _manager;
        private readonly GolocDbContext golocDbContext;

        public UserRepository(UserManager<User> manager, GolocDbContext golocDbContext)
        {
            _manager = manager;
            this.golocDbContext = golocDbContext;
        }
        public async Task Register(User entity, string password)
        {
                IdentityResult result = await _manager.CreateAsync(entity, password);
                if (result.Succeeded)
                {
                    await _manager.AddToRoleAsync(entity, "Member");
                }
                else
                {
                    throw new Exception(result.Errors.First().Description);
                }
        }
        public async Task<User> Login(LoginQuery login)
        {
            var user = await _manager.FindByNameAsync(login.Login);
            if (user == null)
                throw new Exception("Login failed");
            return user;
        }
        public IEnumerable<User> GetAll()
        {
            return  golocDbContext.Set<User>().AsEnumerable();
        }


    }
}

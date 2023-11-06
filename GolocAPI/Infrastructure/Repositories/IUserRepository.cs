using GolocAPI.Entities;
using GolocAPI.Infrastructure.Repositories.Common;
using GolocSharedLibrary.Models;

namespace GolocAPI.Infrastructure.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task Register(User entity, string password);
        Task<User> Login(LoginModel login);
    }
}

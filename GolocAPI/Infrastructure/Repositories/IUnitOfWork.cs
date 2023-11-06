namespace GolocAPI.Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        Task Save();
    }
}

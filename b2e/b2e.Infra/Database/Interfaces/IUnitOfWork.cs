using b2e.Infra.Repositories.Interfaces;

namespace b2e.Infra.Database.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<int> SaveAsync();
    }
}

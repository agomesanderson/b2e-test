using b2e.Domain.Entities;
using b2e.Infra.Database.Interfaces;
using b2e.Shared;

namespace b2e.Infra.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<Result<User?>> GetUserByLogin(
            string login,
            CancellationToken cancellationToken = default);
    }
}

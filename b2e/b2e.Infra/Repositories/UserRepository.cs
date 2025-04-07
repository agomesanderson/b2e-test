using b2e.Domain.Entities;
using b2e.Infra.Database;
using b2e.Infra.Repositories.Interfaces;
using b2e.Shared;
using Microsoft.EntityFrameworkCore;

namespace b2e.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(b2eContext context) : base(context) { }

        public async Task<Result<User?>> GetUserByLogin(
            string login,
            CancellationToken cancellationToken = default)
        {
            return Result<User?>.Ok(
                    await _dbSet.FirstOrDefaultAsync(x => x.Login == login, cancellationToken)
                );
        }
    }
}

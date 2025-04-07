using b2e.Domain.Entities.Base;
using b2e.Infra.Database.Interfaces;
using b2e.Shared;
using Microsoft.EntityFrameworkCore;

namespace b2e.Infra.Database
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly b2eContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(b2eContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<Result<T?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(id, cancellationToken);
            return Result<T?>.Ok(entity);
        }

        public async Task<Result<IEnumerable<T>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _dbSet.ToListAsync(cancellationToken);
            return Result<IEnumerable<T>>.Ok(entities);
        }

        public async Task<Result<T>> InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return Result<T>.Ok(entity);
        }

        public Result<T> Update(T entity)
        {
            _dbSet.Update(entity);
            return Result<T>.Ok(entity);
        }

        public Result<T> Remove(T entity)
        {
            _dbSet.Remove(entity);
            return Result<T>.Ok(entity);
        }
    }
}

using b2e.Infra.Database.Interfaces;
using b2e.Infra.Repositories;
using b2e.Infra.Repositories.Interfaces;

namespace b2e.Infra.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly b2eContext _context;

        public IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get; }

        public UnitOfWork(b2eContext context)
        {
            _context = context;
            UserRepository = new UserRepository(context);
            ProductRepository = new ProductRepository(context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}

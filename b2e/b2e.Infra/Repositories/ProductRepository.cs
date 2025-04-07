using b2e.Domain.Entities;
using b2e.Infra.Database;
using b2e.Infra.Repositories.Interfaces;

namespace b2e.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(b2eContext context) : base(context) { }
    }
}

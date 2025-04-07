using b2e.App.Contracts.Responses.Products;
using b2e.Shared;

namespace b2e.App.Services.Interfaces.Products
{
    public interface IDeleteProductService
    {
        Task<Result<DeleteProductReponse>> Execute(Guid id, CancellationToken cancellationToken = default);
    }
}

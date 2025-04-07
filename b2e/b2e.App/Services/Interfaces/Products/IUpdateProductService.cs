using b2e.App.Contracts.Requests.Products;
using b2e.App.Contracts.Responses.Products;
using b2e.Shared;

namespace b2e.App.Services.Interfaces.Products
{
    public interface IUpdateProductService
    {
        Task<Result<UpdateProductReponse>> Execute(Guid id, UpdateProductRequest request, CancellationToken cancellationToken = default);
    }
}

using b2e.App.Contracts.Requests.Products;
using b2e.App.Contracts.Responses.Products;
using b2e.Shared;

namespace b2e.App.Services.Interfaces.Products
{
    public interface ICreateProductService
    {
        Task<Result<CreateProductReponse>> Execute(Guid id, CreateProductRequest request, CancellationToken cancellationToken = default);
    }
}

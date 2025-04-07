using b2e.App.Contracts.Responses.Products;
using b2e.Shared;

namespace b2e.App.Services.Interfaces.Products
{
    public interface IGetProductsService
    {
        Task<Result<List<GetProductReponse>>> Execute(CancellationToken cancellationToken = default);
    }
}

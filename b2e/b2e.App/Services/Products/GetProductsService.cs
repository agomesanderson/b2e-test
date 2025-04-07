using b2e.App.Contracts.Responses.Products;
using b2e.App.Services.Errors;
using b2e.App.Services.Interfaces.Products;
using b2e.Infra.Database.Interfaces;
using b2e.Shared;
using Microsoft.Extensions.Logging;

namespace b2e.App.Services.Products
{
    public class GetProductsService : IGetProductsService
    {
        private readonly ILogger<GetProductsService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetProductsService(
            ILogger<GetProductsService> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetProductReponse>>> Execute(
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"{nameof(GetProductsService)} start");

            var productsResult = await _unitOfWork.ProductRepository.GetAllAsync(cancellationToken);

            if (productsResult.IsFailure)
                return Result<List<GetProductReponse>>.Fail(productsResult.Errors);

            var hasData = productsResult.Data.Match(
                  some:
                    value => value.ToList().Count > 0,
                  none:
                    () => false
                );

            if (!hasData)
                return Result<List<GetProductReponse>>.Fail(new NotFoundError("Sem produtos cadastrados."));

            var dataResult = productsResult.Data!.Value;

            var products = dataResult.Select(x =>
                new GetProductReponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                }).ToList();

            _logger.LogInformation($"{nameof(GetProductsService)} end");

            return Result<List<GetProductReponse>>.Ok(products);
        }
    }
}

using b2e.App.Contracts.Requests.Products;
using b2e.App.Contracts.Responses.Products;
using b2e.App.Services.Interfaces.Products;
using b2e.Domain.Entities;
using b2e.Infra.Database.Interfaces;
using b2e.Shared;
using Microsoft.Extensions.Logging;

namespace b2e.App.Services.Products
{
    public class CreateProductService : ICreateProductService
    {
        private readonly ILogger<CreateProductService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductService(
            ILogger<CreateProductService> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateProductReponse>> Execute(
            Guid id,
            CreateProductRequest request,
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"{nameof(CreateProductService)} start");

            var productResult = await _unitOfWork.ProductRepository.GetByIdAsync(id, cancellationToken);

            if (productResult.IsFailure)
                return Result<CreateProductReponse>.Fail(productResult.Errors);

            var idempotence = productResult.Data.HasValue;

            if (idempotence)
                return Result<CreateProductReponse>.Ok(new CreateProductReponse { Id = id });

            var product = Product.Create(
                id,
                request.Name,
                request.Price
            );

            await _unitOfWork.ProductRepository.InsertAsync(product, cancellationToken);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"{nameof(CreateProductService)} end");

            return Result<CreateProductReponse>.Ok(new CreateProductReponse { Id = id });
        }
    }
}

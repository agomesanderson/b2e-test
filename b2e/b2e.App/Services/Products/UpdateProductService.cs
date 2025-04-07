using b2e.App.Contracts.Requests.Products;
using b2e.App.Contracts.Responses.Products;
using b2e.App.Services.Errors;
using b2e.App.Services.Interfaces.Products;
using b2e.Domain.Entities;
using b2e.Infra.Database.Interfaces;
using b2e.Shared;
using Microsoft.Extensions.Logging;

namespace b2e.App.Services.Products
{
    public class UpdateProductService : IUpdateProductService
    {
        private readonly ILogger<UpdateProductService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductService(
            ILogger<UpdateProductService> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UpdateProductReponse>> Execute(
            Guid id,
            UpdateProductRequest request,
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"{nameof(UpdateProductService)} start");

            var productResult = await _unitOfWork.ProductRepository.GetByIdAsync(id, cancellationToken);

            if (productResult.IsFailure)
                return Result<UpdateProductReponse>.Fail(productResult.Errors);

            var productExists = productResult.Data.HasValue;

            if (!productExists)
                return Result<UpdateProductReponse>.Fail(new NotFoundError("Produto não encontrado."));

            var product = productResult.Data.Value;

            Product.Update(product!, request.Name, request.Price);

            _unitOfWork.ProductRepository.Update(product!);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"{nameof(UpdateProductService)} end");

            return Result<UpdateProductReponse>.Ok(new UpdateProductReponse { Id = id });
        }
    }
}

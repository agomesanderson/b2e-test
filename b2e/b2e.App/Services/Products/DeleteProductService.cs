using b2e.App.Contracts.Responses.Products;
using b2e.App.Services.Errors;
using b2e.App.Services.Interfaces.Products;
using b2e.Infra.Database.Interfaces;
using b2e.Shared;
using Microsoft.Extensions.Logging;

namespace b2e.App.Services.Products
{
    public class DeleteProductService : IDeleteProductService
    {
        private readonly ILogger<DeleteProductService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductService(
            ILogger<DeleteProductService> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DeleteProductReponse>> Execute(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"{nameof(DeleteProductService)} start");

            var productResult = await _unitOfWork.ProductRepository.GetByIdAsync(id, cancellationToken);

            if (productResult.IsFailure)
                return Result<DeleteProductReponse>.Fail(productResult.Errors);

            var productExists = productResult.Data.HasValue;

            if (!productExists)
                return Result<DeleteProductReponse>.Fail(new NotFoundError("Produto não encontrado."));

            var product = productResult.Data.Value;

            _unitOfWork.ProductRepository.Remove(product!);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"{nameof(DeleteProductService)} end");

            return Result<DeleteProductReponse>.Ok(new DeleteProductReponse { Success = true });
        }
    }
}

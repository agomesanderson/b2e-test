using b2e.App.Contracts.Requests.Products;
using b2e.App.Services.Interfaces.Products;
using b2e.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace b2e.Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [SwaggerTag("Cadastro de produtos")]
    [Route("v1/products")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Criar produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <param name="service"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(
            [FromRoute, Required] Guid id,
            [FromBody, Required] CreateProductRequest request,
            [FromServices] ICreateProductService service,
            CancellationToken cancellationToken
        )
        {
            var result = await service.Execute(id, request, cancellationToken);

            return result.Match<IActionResult>(
              onSuccess: response => Ok(response.Value),
              onFailure: errors => errors.ToHttpErrors());
        }

        /// <summary>
        /// Atualizar produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <param name="service"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(
            [FromRoute, Required] Guid id,
            [FromBody, Required] UpdateProductRequest request,
            [FromServices] IUpdateProductService service,
            CancellationToken cancellationToken
        )
        {
            var result = await service.Execute(id, request, cancellationToken);

            return result.Match<IActionResult>(
              onSuccess: response => Ok(response.Value),
              onFailure: errors => errors.ToHttpErrors());
        }

        /// <summary>
        /// Deletar produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(
            [FromRoute, Required] Guid id,
            [FromServices] IDeleteProductService service,
            CancellationToken cancellationToken
        )
        {
            var result = await service.Execute(id, cancellationToken);

            return result.Match<IActionResult>(
              onSuccess: response => Ok(response.Value),
              onFailure: errors => errors.ToHttpErrors());
        }

        /// <summary>
        /// Obter todos os produtos
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetProductsService service,
            CancellationToken cancellationToken
        )
        {
            var result = await service.Execute(cancellationToken);

            return result.Match<IActionResult>(
              onSuccess: response => Ok(response.Value),
              onFailure: errors => errors.ToHttpErrors());
        }
    }
}

using b2e.App.Contracts.Requests.Users;
using b2e.App.Services.Interfaces.Users;
using b2e.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace b2e.Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [SwaggerTag("Login de usuário")]
    [Route("v1/users")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Login de usuário
        /// </summary>
        /// <param name="request"></param>
        /// <param name="service"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(
            [FromBody, Required] LoginUserRequest request,
            [FromServices] ILoginUserService service,
            CancellationToken cancellationToken
        )
        {
            var result = await service.Execute(request, cancellationToken);

            return result.Match<IActionResult>(
              onSuccess: response => Ok(response.Value),
              onFailure: errors => errors.ToHttpErrors());
        }
    }
}

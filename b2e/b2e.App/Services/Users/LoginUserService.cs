using b2e.App.Contracts.Requests.Users;
using b2e.App.Contracts.Responses.Users;
using b2e.App.Services.Errors;
using b2e.App.Services.Interfaces.Users;
using b2e.Infra.Database.Interfaces;
using b2e.Shared;
using Microsoft.Extensions.Logging;

namespace b2e.App.Services.Users
{
    public class LoginUserService : ILoginUserService
    {
        private readonly ILogger<LoginUserService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public LoginUserService(
            ILogger<LoginUserService> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<LoginUserReponse>> Execute(
            LoginUserRequest request,
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"{nameof(LoginUserService)} start");

            var userResult = await _unitOfWork.UserRepository.GetUserByLogin(request.Login, cancellationToken);

            var userExists = userResult.IsSuccess && userResult.Data.HasValue;

            if (!userExists)
                return Result<LoginUserReponse>.Fail(new UserForbiddenError("Acesso negado."));

            var user = userResult.Data.Value;

            var validLogin = user!.VerifyPassword(request.Password);

            if (!validLogin)
                return Result<LoginUserReponse>.Fail(new UserForbiddenError("Acesso negado."));

            _logger.LogInformation($"{nameof(LoginUserService)} end");

            return Result<LoginUserReponse>.Ok(new LoginUserReponse { Success = true });
        }
    }
}

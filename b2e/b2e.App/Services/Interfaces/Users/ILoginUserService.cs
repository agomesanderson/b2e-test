using b2e.App.Contracts.Requests.Users;
using b2e.App.Contracts.Responses.Users;
using b2e.Shared;

namespace b2e.App.Services.Interfaces.Users
{
    public interface ILoginUserService
    {
        Task<Result<LoginUserReponse>> Execute(LoginUserRequest request, CancellationToken cancellationToken = default);
    }
}

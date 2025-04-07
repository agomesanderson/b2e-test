using b2e.Shared;
using b2e.Shared.Constants;

namespace b2e.App.Services.Errors
{
    public class UserForbiddenError(string Msg) : Error(Code, Msg)
    {
        private new const string Code = ErrorCodes.UserForbidden;
    }
}

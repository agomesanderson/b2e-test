namespace b2e.App.Contracts.Requests.Users
{
    public record LoginUserRequest
    {
        public string Login { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}

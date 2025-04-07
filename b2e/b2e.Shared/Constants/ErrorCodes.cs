namespace b2e.Shared.Constants
{
    public static class ErrorCodes
    {
        private const string Prefix = "TTT";
        public const string UnexpectedError = $"{Prefix}001";
        public const string NotFound = $"{Prefix}002";
        public const string UserForbidden = $"{Prefix}003";
    }
}

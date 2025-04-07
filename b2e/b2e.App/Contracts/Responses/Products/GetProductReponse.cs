namespace b2e.App.Contracts.Responses.Products
{
    public record GetProductReponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public decimal Price { get; init; }
    }
}

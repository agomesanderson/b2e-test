using System.ComponentModel.DataAnnotations;

namespace b2e.App.Contracts.Requests.Products
{
    public record UpdateProductRequest
    {
        [Required]
        public string Name { get; init; } = null!;

        [Required]
        public decimal Price { get; init; }
    }
}

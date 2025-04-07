using b2e.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b2e.Domain.Entities
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; private set; } = null!;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; private set; }

        public static Product Create(Guid id, string name, decimal price) => new()
        {
            Id = id,
            Name = name,
            Price = price
        };

        public static Product Update(Product product, string name, decimal price)
        {
            product.Name = name;
            product.Price = price;

            return product;
        }
    }
}

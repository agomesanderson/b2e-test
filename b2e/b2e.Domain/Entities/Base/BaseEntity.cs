using System.ComponentModel.DataAnnotations;

namespace b2e.Domain.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
    }
}

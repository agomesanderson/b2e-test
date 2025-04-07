using Microsoft.AspNetCore.Identity;
using b2e.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b2e.Domain.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Login { get; private init; } = null!;

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; private set; } = null!;

        public static User Create(string login, string password)
        {
            var hasher = new PasswordHasher<User>();
            var user = new User
            {
                Login = login
            };
            user.PasswordHash = hasher.HashPassword(user, password);
            return user;
        }

        public bool VerifyPassword(string password)
        {
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(this, PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}

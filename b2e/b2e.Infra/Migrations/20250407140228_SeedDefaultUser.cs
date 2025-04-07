using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace b2e.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<object>();
            var passwordHash = hasher.HashPassword(null, "xpto");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "PasswordHash" },
                values: new object[] { Guid.NewGuid(), "admin", passwordHash }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace b2e.Infra.Database.Extensions
{
    public static class AddMigrations
    {
        public static WebApplication AddMigration<TContext>(this WebApplication host) where TContext : DbContext
        {
            using var scope = host.Services.CreateScope();

            scope.ServiceProvider.GetService<TContext>()!.Database.Migrate();
            return host;
        }
    }
}

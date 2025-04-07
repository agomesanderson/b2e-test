using Microsoft.EntityFrameworkCore;

namespace b2e.Infra.Database.Extensions
{
    public static class AddDatabase
    {
        public static IServiceCollection AddSqlServerDbContext<TContext>(this IServiceCollection services, IConfiguration configuration)
                    where TContext : DbContext
        {
            services.AddDbContext<TContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionDb"));
            });

            return services;
        }
    }
}

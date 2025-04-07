using Microsoft.AspNetCore.Mvc;

namespace b2e.Api.Configurations
{
    public static class AddApiVersioning
    {
        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options => {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }
    }
}

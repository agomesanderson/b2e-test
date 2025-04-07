using b2e.App.Services.Interfaces.Products;
using b2e.App.Services.Interfaces.Users;
using b2e.App.Services.Products;
using b2e.App.Services.Users;
using b2e.Infra.Repositories;
using b2e.Infra.Repositories.Interfaces;

namespace b2e.Api.Configurations
{
    public static class AddDependencies
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginUserService, LoginUserService>();
            services.AddScoped<ICreateProductService, CreateProductService>();
            services.AddScoped<IUpdateProductService, UpdateProductService>();
            services.AddScoped<IDeleteProductService, DeleteProductService>();
            services.AddScoped<IGetProductsService, GetProductsService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}

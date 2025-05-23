﻿using Microsoft.OpenApi.Models;

namespace b2e.Api.Configurations
{
    public static class AddSwagger
    {
        public static void AddDocs(this IServiceCollection services)
        {
            services.AddSwaggerGen(settings =>
            {
                settings.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "0.0.1",
                    Title = "Api B2E",
                    Description = "Seja bem-vindo à documentação",
                    Contact = new OpenApiContact
                    {
                        Name = "Anderson",
                        Email = "anderson@gmail.com",
                        Url = new Uri("https://www.anderson.com.br")
                    },
                });
            });
        }

        public static void UseDocs(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api B2E v1");
            });
        }
    }
}

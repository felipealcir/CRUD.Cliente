using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace CRUD.Cliente.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CRUD.Cliente",
                    Description = "API do site CRUD.Cliente",                    
                    Contact = new OpenApiContact { Name = "Felipe Ferreira de Souza", Email = "s.ferreirafelipe@live.com" },
                    License = new OpenApiLicense { Name = "MIT" }
                });                
            });           
        }
    }
}


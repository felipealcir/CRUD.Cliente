using CRUD.Clientes.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Cliente.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}

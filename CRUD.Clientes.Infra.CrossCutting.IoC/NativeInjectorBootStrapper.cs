using AutoMapper;
using CRUD.Cliente.Domain.Clientes.IRepository;
using CRUD.Cliente.Domain.Core.Notifications;
using CRUD.Cliente.Domain.Core.Notifications.Interface;
using CRUD.Cliente.Infra.Context;
using CRUD.Cliente.Infra.Repository.Clientes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Clientes.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();            
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
                        
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<INotification<DomainNotification>, Notification>();
            services.AddScoped<Context>();

        }
    }
}

using CRUD.Cliente.Domain.Clientes;
using CRUD.Cliente.Infra.Extensions;
using CRUD.Cliente.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CRUD.Cliente.Infra.Context
{
    public class Context : DbContext
    {
        public DbSet<Domain.Clientes.Cliente> Clientes { get; set; }      
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ClienteMapping());         
            modelBuilder.AddConfiguration(new EnderecoMapping());           

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("ConnectionDB"));
        }

    }
}

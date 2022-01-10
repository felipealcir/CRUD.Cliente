using CRUD.Cliente.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Cliente.Infra.Mappings
{
    public class ClienteMapping : EntityTypeConfiguration<Cliente.Domain.Clientes.Cliente>
    {
        public override void Map(EntityTypeBuilder<Domain.Clientes.Cliente> builder)
        {
            builder.Property(e => e.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.DataNascimento)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.Documento)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(e => e.Ativo)
               .HasColumnType("int(1)")
               .IsRequired();

            builder.Property(e => e.DataCadastro)
             .HasColumnType("datetime")
             .IsRequired();                

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Clientes");
        }
    }
}

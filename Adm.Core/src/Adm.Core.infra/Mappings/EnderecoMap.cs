using Adm.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adm.Core.infra.Mappings
{
    class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(keyExpression: e => e.Id);

            builder.Property(e => e.Largradouro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Numero)
              .IsRequired()
              .HasColumnType("varchar(100)");

            builder.Property(e => e.Cep)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(e => e.Bairro)
           .IsRequired()
           .HasColumnType("varchar(100)");

            builder.Property(e => e.Cidade)
           .IsRequired()
           .HasColumnType("varchar(100)");

            builder.Property(e => e.Estado)
           .IsRequired()
           .HasColumnType("varchar(100)");

            builder.ToTable("Endereco");
        }
    }
}

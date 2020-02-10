using Adm.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adm.Core.infra.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
       

        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(keyExpression: p => p.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Descricao)
              .IsRequired()
              .HasColumnType("varchar(100)");

            builder.Property(f => f.Imagem)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.ToTable("Produtos");
        }
    }
}

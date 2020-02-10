using Adm.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adm.Core.infra.Mappings
{
    public class FornecedortMap : IEntityTypeConfiguration<Fornecedor>
    {
       
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(keyExpression: f => f.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Documento)
              .IsRequired()
              .HasColumnType("varchar(100)");

            /*1 : 1 FORNECEDOR TEM 1  ENDERECO*/
            builder.HasOne(navigationExpression: f => f.Endereco)
                .WithOne(navigationExpression: e => e.Fornecedor);

            /*1 : 1 FORNECEDOR TEM N  Produtos*/
            builder.HasMany(navigationExpression: f => f.Produtos)
               .WithOne(navigationExpression: p => p.Fornecedor)

               /*CHAVE ESTRANGEIRA  DO FORNECEDOR NA  TABELA PRODUTO*/
               .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Fornecedores");
               



        }
    }
}

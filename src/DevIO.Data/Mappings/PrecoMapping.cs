using DevIo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DevIO.Data.Mappings
{
    public class PrecoMapping : IEntityTypeConfiguration<Preco>
    {
        public void Configure(EntityTypeBuilder<Preco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeTipoPreco)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Valor)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.DataCadastro)
                .IsRequired();

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.ToTable("TbPrecos");
        }
    }
}

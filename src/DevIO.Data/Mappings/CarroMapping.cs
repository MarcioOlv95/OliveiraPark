using DevIo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class CarroMapping : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Modelo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Placa)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.TipoVeiculo)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.DataCadastro)
                .IsRequired();

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.ToTable("TbCarros");
        }
    }
}

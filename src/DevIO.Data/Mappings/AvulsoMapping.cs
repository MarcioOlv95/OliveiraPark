using DevIo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class AvulsoMapping : IEntityTypeConfiguration<Avulso>
    {
        public void Configure(EntityTypeBuilder<Avulso> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Placa)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.HrEntrada)
                .IsRequired();

            builder.Property(p => p.HrSaida)
                .IsRequired();

            builder.Property(p => p.PrecoFinal)
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .IsRequired();

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.ToTable("TbAvulsos");
        }
    }
}

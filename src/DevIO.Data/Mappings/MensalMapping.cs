using DevIo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class MensalMapping : IEntityTypeConfiguration<Mensal>
    {
        public void Configure(EntityTypeBuilder<Mensal> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ValidadeContrato)
                .IsRequired();

            builder.Property(p => p.ValorPrecoMensal)
                .IsRequired();

            builder.Property(p => p.DataPagamento)
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .IsRequired();

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.HasOne(f => f.Carro)
                .WithOne(e => e.Mensal);

            builder.HasOne(f => f.Cliente)
                .WithOne(e => e.Mensal);

            builder.HasMany(f => f.Pagamentos)
                .WithOne(e => e.Mensal)
                .HasForeignKey(e => e.MensalId);

            builder.ToTable("TbMensais");
        }
    }
}

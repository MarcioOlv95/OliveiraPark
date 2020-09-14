using DevIo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Endereco)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(p => p.DataCadastro)
                .IsRequired();

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.ToTable("TbClientes");
        }
    }
}

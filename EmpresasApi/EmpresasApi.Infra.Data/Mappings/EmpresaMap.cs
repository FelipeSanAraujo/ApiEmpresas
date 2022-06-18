using EmpresasApi.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpresasApi.Infra.Data.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("EMPRESA");

            builder.HasKey(e => e.IdEmpresa);

            builder.Property(e => e.IdEmpresa)
                .HasColumnName("IDEMPRESA")
                .IsRequired();

            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NOMEFANTASIA")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RAZAOSOCIAL")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(25)
                .IsRequired();

            builder.HasIndex(e => e.Cnpj)
                .IsUnique();
        }
    }
}




using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class ConfiguracionCreditoServicio : IEntityTypeConfiguration<CreditoServicio>
    {
        public void Configure(EntityTypeBuilder<CreditoServicio> builder)
        {
            builder.ToTable("CreditoServicios");

            builder.HasKey(e => e.IdCreditos)
                    .HasName("PK__CreditoS__BEF75FDA31E31A30");

            builder.Property(e => e.IdCreditos).HasColumnName("idCreditos");

            builder.Property(e => e.Abono)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("abono");

            builder.Property(e => e.Deuda)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("deuda");

            builder.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");

            builder.Property(e => e.IdServicios).HasColumnName("idServicios");

            builder.HasOne(d => d.Servicios)
                .WithMany(p => p.CreditoServicios)
                .HasForeignKey(d => d.IdServicios)
                .HasConstraintName("fk_Creditos");
        }
    }
}

using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class ConfiguracionCreditoServicio : IEntityTypeConfiguration<CreditoServicios>
    {
        public void Configure(EntityTypeBuilder<CreditoServicios> builder)
        {
            builder.ToTable("CreditoServicios");

            builder.HasKey(e => e.IdCreditos);

            builder.Property(e => e.IdCreditos).HasColumnName("idCreditos");

            builder.Property(e => e.Abono)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("abono");

            builder.Property(e => e.Deuda)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("deuda");

            builder.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");

            builder.Property(e => e.IdServicio).HasColumnName("idServicio");

            builder.HasOne(d => d.Servicio)
                .WithMany(p => p.CreditoServicios)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Creditos");
        }
    }
}

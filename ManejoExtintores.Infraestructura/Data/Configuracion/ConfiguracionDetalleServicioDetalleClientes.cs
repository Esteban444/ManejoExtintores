using ManejoExtintores.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion
{
    public class ConfiguracionDetalleServicioDetalleClientes : IEntityTypeConfiguration<DetalleServicioDetalleClientes>
    {
        public void Configure(EntityTypeBuilder<DetalleServicioDetalleClientes> builder)
        {
            builder.HasKey(e => e.IdDetalleCliente)
                   .HasName("PK_DetalleServicioDetalleClentes");

            builder.Property(e => e.IdDetalleCliente).HasColumnName("IdDetalle_Cliente");

            builder.HasOne(d => d.DetalleExtintorCliente)
                .WithMany(p => p.DetalleServicioDetalleClientes)
                .HasForeignKey(d => d.IdDetalleExtintorCliente)
                .HasConstraintName("FK_DetalleServicioDetalleClientes_DetalleExtintorClientes");

            builder.HasOne(d => d.DetalleServicios)
                .WithMany(p => p.DetalleServicioDetalleClientes)
                .HasForeignKey(d => d.IdDetalleServicios)
                .HasConstraintName("FK_DetalleServicioDetalleClientes_DetalleServicios");
        }
    }
}

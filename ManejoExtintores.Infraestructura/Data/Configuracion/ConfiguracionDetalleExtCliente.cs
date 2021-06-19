using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class ConfiguracionDetalleExtCliente : IEntityTypeConfiguration<DetalleExtClientes>
    {
        public void Configure(EntityTypeBuilder<DetalleExtClientes> builder)
        {
            builder.ToTable("DetalleExtClientes");

            builder.HasKey(e => e.IdDetalleCliente);

            builder.Property(e => e.IdDetalleCliente).HasColumnName("idDetalleCliente");

            builder.Property(e => e.Cantidad).HasColumnName("cantidad");

            builder.Property(e => e.FechaMantenimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaMantenimiento");

            builder.Property(e => e.FechaServicio)
                .HasColumnType("datetime")
                .HasColumnName("fechaServicio");

            builder.Property(e => e.FechaVencimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaVencimiento");

            builder.Property(e => e.IdClientes).HasColumnName("idClientes");

            builder.Property(e => e.IdServicio).HasColumnName("idServicio");

            builder.Property(e => e.Pesoextintor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pesoextintor");

            builder.Property(e => e.TipoExtintor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoExtintor");

            builder.HasOne(d => d.Clientes)
                .WithMany(p => p.DetalleExtClientes)
                .HasForeignKey(d => d.IdClientes)
                .HasConstraintName("FK_DetalleExtClientes_Clientes");

            builder.HasOne(d => d.Servicios)
                .WithMany(p => p.DetalleExtClientes)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK_DetalleExtCliente_Servicios");
        }
    }
}

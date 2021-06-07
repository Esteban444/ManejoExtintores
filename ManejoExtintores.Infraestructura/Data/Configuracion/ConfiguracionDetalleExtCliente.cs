using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class ConfiguracionDetalleExtCliente : IEntityTypeConfiguration<DetalleExtCliente>
    {
        public void Configure(EntityTypeBuilder<DetalleExtCliente> builder)
        {
            builder.ToTable("DetalleExtCliente");

            builder.HasKey(e => e.IdDetalleCliente)
                     .HasName("PK__DetalleE__E0CA4893B1C20026");

            builder.Property(e => e.IdDetalleCliente).HasColumnName("idDetalleCliente");

            builder.Property(e => e.Cantidad).HasColumnName("cantidad");

            builder.Property(e => e.FechaMantenimiento)
                .HasColumnType("date")
                .HasColumnName("fechaMantenimiento");

            builder.Property(e => e.FechaServicio)
                .HasColumnType("date")
                .HasColumnName("fechaServicio");

            builder.Property(e => e.FechaVencimiento)
                .HasColumnType("date")
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
                .HasConstraintName("fk_DetalleCliente");

            builder.HasOne(d => d.Servicios)
                .WithMany(p => p.DetalleExtClientes)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK_DetalleExtCliente_Servicios");
        }
    }
}

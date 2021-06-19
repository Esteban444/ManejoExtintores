using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion
{
    class Configuracion_Inventario : IEntityTypeConfiguration<Inventarios>
    {
        public void Configure(EntityTypeBuilder<Inventarios> builder)
        {
            builder.ToTable("Inventarios");

            builder.HasKey(e => e.IdInventario);

            builder.HasIndex(e => e.DetalleServId);

            builder.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Fecha).HasColumnType("datetime");

            builder.Property(e => e.FechaVencimiento).HasColumnType("datetime");

            builder.HasOne(d => d.DetalleServ)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.DetalleServId)
                .HasConstraintName("FK_Inventarios_DetalleServicios");

            builder.HasOne(d => d.PesoExtintor)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdPesoExtintor)
                .HasConstraintName("FK_Inventarios_PesoExtintors");

            builder.HasOne(d => d.Producto)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdProductos)
                .HasConstraintName("fk_Inventario");

            builder.HasOne(d => d.TipoExtintor)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdTipoExtintor)
                .HasConstraintName("FK_Inventarios_TipoExtintors");
        }
    }
}

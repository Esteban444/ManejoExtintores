using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion
{
    class Configuracion_Inventario : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventarios");

            builder.HasKey(e => e.IdInventario);

            builder.HasIndex(e => e.DetalleServId);

            builder.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Fecha).HasColumnType("datetime");

            builder.Property(e => e.FechaVencimiento).HasColumnType("datetime");

            builder.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.DetalleServ)
                .WithMany(p => p.Inventario)
                .HasForeignKey(d => d.DetalleServId)
                .HasConstraintName("FK_Inventario_DetalleServicio");

            builder.HasOne(d => d.Productos)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdProductos)
                .HasConstraintName("fk_Inventario");
        }
    }
}

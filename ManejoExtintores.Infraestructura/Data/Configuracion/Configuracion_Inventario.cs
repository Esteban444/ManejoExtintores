using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion
{
    class Configuracion_Inventario : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventario");

            builder.HasKey(e => e.IdInventario)
                    .HasName("PK__Inventar__8F145B0DB90E4F9B");


            builder.Property(e => e.IdInventario).HasColumnName("idInventario");

            builder.Property(e => e.Cantidad).HasColumnName("cantidad");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            builder.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");

            builder.Property(e => e.FechaVencimiento)
                    .HasColumnName("fechaVencimiento")
                    .HasColumnType("date");

            builder.Property(e => e.DetalleServId).HasColumnName("detalleServId");

            builder.Property(e => e.IdProductos).HasColumnName("idProductos");

            builder.Property(e => e.PesoXlibras).HasColumnName("pesoXlibras");

            builder.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

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

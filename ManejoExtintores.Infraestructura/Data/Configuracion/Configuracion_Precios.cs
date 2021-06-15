using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion 
{
    public class Configuracion_Precios : IEntityTypeConfiguration<Precios>
    {
        public void Configure(EntityTypeBuilder<Precios> builder)
        {
            builder.ToTable("Precios");

            builder.HasKey(e => e.IdPrecios)
                    .HasName("PK__Precios__C65E7C9ACF75FE56");

            builder.Property(e => e.IdPrecios).HasColumnName("idPrecios");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            builder.Property(e => e.IdDetalleServ).HasColumnName("idDetalleServ");

            builder.Property(e => e.IdProductos).HasColumnName("idProductos");

            builder.Property(e => e.Iva)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("iva");

            builder.Property(e => e.Valor)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("valor");

            builder.HasOne(d => d.DetalleServicio)
                .WithMany(p => p.Precios)
                .HasForeignKey(d => d.IdDetalleServ)
                .HasConstraintName("fk_Productos_DetalleS");

            builder.HasOne(d => d.Producto)
                .WithMany(p => p.Precios)
                .HasForeignKey(d => d.IdProductos)
                .HasConstraintName("fk_Precios");
        }
    }
}

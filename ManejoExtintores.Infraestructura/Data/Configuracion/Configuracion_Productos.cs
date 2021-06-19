using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion 
{
    public class Configuracion_Productos : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.ToTable("Productos");

            builder.HasKey(e => e.IdProductos);

            builder.Property(e => e.IdProductos).HasColumnName("idProductos");

            builder.Property(e => e.TipoProducto)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("tipoProducto");

            builder.HasOne(d => d.PesoExtintor)
                .WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdPesoExtintor)
                .HasConstraintName("Fk_Productos_Peso");

            builder.HasOne(d => d.TipoExtintor)
                .WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdTipoExtintor)
                .HasConstraintName("fk_Productos_Tipo");
        }
    }
}

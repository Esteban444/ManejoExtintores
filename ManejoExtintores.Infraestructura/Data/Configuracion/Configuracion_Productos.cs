using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion 
{
    public class Configuracion_Productos : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");

            builder.HasKey(e => e.IdProductos)
                    .HasName("PK__Producto__A26E462D14299951");

            builder.Property(e => e.IdProductos).HasColumnName("idProductos");

            builder.Property(e => e.IdPesoExtintor).HasColumnName("idPesoExtintor");

            builder.Property(e => e.IdTipoExtintor).HasColumnName("idTipoExtintor");

            builder.Property(e => e.PesoXlibras).HasColumnName("pesoXLibras");

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

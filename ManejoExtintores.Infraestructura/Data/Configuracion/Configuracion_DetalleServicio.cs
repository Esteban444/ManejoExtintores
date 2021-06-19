using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class Configuracion_DetalleServicio : IEntityTypeConfiguration<DetalleServicios>
    {
        public void Configure(EntityTypeBuilder<DetalleServicios> builder)
        {
            builder.ToTable("DetalleServicios");

            builder.HasKey(e => e.IdDetalleServ);

            builder.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Total).HasColumnType("decimal(18, 4)");

            builder.Property(e => e.Valor).HasColumnType("decimal(18, 4)");

            builder.HasOne(d => d.PesoExtintor)
                .WithMany(p => p.DetalleServicios)
                .HasForeignKey(d => d.IdPesoExtintor)
                .HasConstraintName("FK_DetalleServicios_PesoExtintors");

            builder.HasOne(d => d.Servicios)
                .WithMany(p => p.DetalleServicios)
                .HasForeignKey(d => d.IdServicios) 
                .HasConstraintName("FK_DetalleServicios_Servicio");

            builder.HasOne(d => d.TipoExtintors)
                .WithMany(p => p.DetalleServicios)
                .HasForeignKey(d => d.IdTipoExtintor)
                .HasConstraintName("FK_DetalleServicios_TipoExtintors");
        }
    }
}

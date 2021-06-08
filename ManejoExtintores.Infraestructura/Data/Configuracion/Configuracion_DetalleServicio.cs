using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class Configuracion_DetalleServicio : IEntityTypeConfiguration<DetalleServicio>
    {
        public void Configure(EntityTypeBuilder<DetalleServicio> builder)
        {

            builder.HasKey(e => e.IdDetalleServ);


            builder.Property(e => e.IdDetalleServ).HasColumnName("idDetalleServ");

            builder.Property(e => e.Cantidad).HasColumnName("cantidad");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            builder.Property(e => e.IdServicio).HasColumnName("idServicios");

            builder.Property(e => e.PesoXlibras).HasColumnName("pesoXLibras");

            builder.Property(e => e.TipoExtintor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipoExtintor");

            builder.Property(e => e.Total)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total");

            builder.Property(e => e.Valor)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("valor");

            builder.HasOne(d => d.Servicios)
                .WithMany(p => p.DetalleServicios)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("fk_Detalleservicios");
        }
    }
}

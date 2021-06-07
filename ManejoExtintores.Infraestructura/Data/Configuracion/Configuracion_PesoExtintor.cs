using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class Configuracion_PesoExtintor : IEntityTypeConfiguration<PesoExtintor>
    {
        public void Configure(EntityTypeBuilder<PesoExtintor> builder)
        {
            builder.HasKey(e => e.IdPesoExtintor)
                    .HasName("PK__PesoExti__202D2BB874D54491");

            builder.ToTable("PesoExtintor");

            builder.Property(e => e.IdPesoExtintor).HasColumnName("idPesoExtintor");

            builder.Property(e => e.IdDetalleServ).HasColumnName("idDetalleServ");

            builder.Property(e => e.PesoXlibras).HasColumnName("pesoXLibras");

            builder.HasOne(d => d.DetalleServ)
                .WithMany(p => p.PesoExtintors)
                .HasForeignKey(d => d.IdDetalleServ)
                .HasConstraintName("fk_pesoExtintor");
        }
    }
}

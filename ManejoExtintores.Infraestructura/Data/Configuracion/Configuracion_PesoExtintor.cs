using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class Configuracion_PesoExtintor : IEntityTypeConfiguration<PesoExtintor>
    {
        public void Configure(EntityTypeBuilder<PesoExtintor> builder)
        {
            builder.HasKey(e => e.IdPesoExtintor);

            builder.HasOne(d => d.DetalleServ)
                .WithMany(p => p.PesoExtintors)
                .HasForeignKey(d => d.IdDetalleServ)
                .HasConstraintName("fk_pesoExtintor");
        }
    }
}

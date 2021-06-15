using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class Configuracion_PesoExtintor : IEntityTypeConfiguration<PesoExtintors>
    {
        public void Configure(EntityTypeBuilder<PesoExtintors> builder)
        {
            builder.HasKey(e => e.IdPesoExtintor);

            builder.HasOne(d => d.DetalleServicio)
                .WithMany(p => p.PesoExtintors)
                .HasForeignKey(d => d.IdDetalleServ)
                .HasConstraintName("fk_pesoExtintor");
        }
    }
}

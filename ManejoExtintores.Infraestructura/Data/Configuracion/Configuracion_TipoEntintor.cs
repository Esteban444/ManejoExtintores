using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion 
{
    public class Configuracion_TipoEntintor : IEntityTypeConfiguration<TipoExtintor>
    {
        public void Configure(EntityTypeBuilder<TipoExtintor> builder)
        {
            builder.ToTable("TipoExtintor");

            builder.HasKey(e => e.IdTipoExtintor)
                    .HasName("PK__TipoExti__9F047CB9DF24BB1F");


            builder.Property(e => e.IdTipoExtintor).HasColumnName("idTipoExtintor");

            builder.Property(e => e.IdDetalleServ).HasColumnName("idDetalleServ");

            builder.Property(e => e.Tipo_Extintor)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("tipoExtintor");

            builder.HasOne(d => d.DetalleServ)
                .WithMany(p => p.TipoExtintors)
                .HasForeignKey(d => d.IdDetalleServ)
                .HasConstraintName("fk_TipoExtintor");
        }
    }
}

﻿using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion 
{
    public class Configuracion_TipoEntintor : IEntityTypeConfiguration<TipoExtintor>
    {
        public void Configure(EntityTypeBuilder<TipoExtintor> builder)
        {
            builder.ToTable("TipoExtintors");

            builder.HasKey(e => e.IdTipoExtintor);

            builder.Property(e => e.Tipo_Extintor) 
                .HasColumnName("Tipo_Extintor")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.DetalleServ)
                .WithMany(p => p.TipoExtintors)
                .HasForeignKey(d => d.IdDetalleServ)
                .HasConstraintName("fk_TipoExtintor");
        }
    }
}
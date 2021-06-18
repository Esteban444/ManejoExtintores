﻿using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class ConfiguracionCreditoServicio : IEntityTypeConfiguration<CreditoServicios>
    {
        public void Configure(EntityTypeBuilder<CreditoServicios> builder)
        {
            builder.ToTable("CreditoServicios");

            builder.HasKey(e => e.IdCreditos)
                    .HasName("PK__CreditoS__BEF75FDA31E31A30");

            builder.Property(e => e.IdCreditos).HasColumnName("idCreditos");

            builder.Property(e => e.Abono)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("abono");

            builder.Property(e => e.Deuda)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("deuda");

            builder.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");

            builder.Property(e => e.IdServicio).HasColumnName("idServicio");

            builder.HasOne(d => d.Servicio)
                .WithMany(p => p.CreditoServicios)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("fk_Creditos");
        }
    }
}

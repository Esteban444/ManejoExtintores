using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion 
{
    public class Configuracion_Gastos : IEntityTypeConfiguration<Gastos>
    {
        public void Configure(EntityTypeBuilder<Gastos> builder)
        {
            builder.ToTable("Gastos");

            builder.HasKey(e => e.IdGastos) 
                    .HasName("PK__Gastos__9C14561A356457B5");

            builder.Property(e => e.IdGastos).HasColumnName("idGastos");

            builder.Property(e => e.Cantidad).HasColumnName("cantidad");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            builder.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");

            builder.Property(e => e.Total).HasColumnType("decimal(18, 0)");
        }
    }
}

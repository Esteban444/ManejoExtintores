using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion 
{
    class Configuracion_Servicios : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.ToTable("Servicios");

            builder.HasKey(e => e.IdServicios);

            builder.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.FechaServicio).HasColumnType("datetime");

            builder.Property(e => e.Valor).HasColumnType("decimal(18, 4)");

            builder.Property(e => e.Abono).HasColumnType("decimal(18, 4)");

            builder.HasOne(d => d.Cliente)
                .WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdClientes)
                .HasConstraintName("fk_serviciosC");

            builder.HasOne(d => d.Empleado)
                .WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdEmpleados)
                .HasConstraintName("fk_serviciosE");

        }
    }
}

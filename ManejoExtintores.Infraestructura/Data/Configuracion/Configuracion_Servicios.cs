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

            builder.HasKey(e => e.IdServicios)
                    .HasName("PK__Servicio__185EC2A048493B79");

            builder.Property(e => e.IdServicios).HasColumnName("idServicios");

            builder.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");

            builder.Property(e => e.FechaServicio)
                .HasColumnType("date")
                .HasColumnName("fechaServicio");

            builder.Property(e => e.IdClientes).HasColumnName("idClientes");

            builder.Property(e => e.IdEmpleados).HasColumnName("idEmpleados");

            builder.Property(e => e.Valor)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("valor");

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

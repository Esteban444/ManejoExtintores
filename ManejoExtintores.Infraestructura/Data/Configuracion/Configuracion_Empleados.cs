using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion 
{
    class Configuracion_Empleados : IEntityTypeConfiguration<Empleados>
    {
    
        public void Configure(EntityTypeBuilder<Empleados> builder)
        {
            builder.ToTable("Empleados");

            builder.HasKey(e => e.IdEmpleados);

            builder.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.Empresa)
                .WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("fk_Empleado");
        }
    }
}

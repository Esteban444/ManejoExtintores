using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion 
{
    class Configuracion_Empleados : IEntityTypeConfiguration<Empleado>
    {
    
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleados");

            builder.HasKey(e => e.IdEmpleados)
                   .HasName("PK__Empleado__42034B0E6EB4FAAF");

            builder.Property(e => e.IdEmpleados).HasColumnName("idEmpleados");

            builder.Property(e => e.Apellido)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("apellido");

            builder.Property(e => e.Direccion)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("direccion");

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");

            builder.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

            builder.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombre");

            builder.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");

            builder.HasOne(d => d.Empresa)
                .WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("fk_Empleado");
        }
    }
}

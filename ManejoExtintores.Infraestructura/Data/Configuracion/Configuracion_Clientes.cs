using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manejo_Extintores.Infraestructura.Data.Configuracion
{
    public class Configuracion_Clientes : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(e => e.IdCliente);

            builder.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DocCliente).HasColumnType("decimal(18, 0)");

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Nit)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false);
        }
    }
}

using ManejoExtintores.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManejoExtintores.Infraestructura.Data.Configuracion 
{
    public class Configuracion_Empresa : IEntityTypeConfiguration<Empresas>
    {
        public void Configure(EntityTypeBuilder<Empresas> builder)
        {
            builder.ToTable("Empresas");

            builder.HasKey(e => e.IdEmpresa);

            builder.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

            builder.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");

            builder.Property(e => e.Nit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nit");

            builder.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");

            builder.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        }
    }
}

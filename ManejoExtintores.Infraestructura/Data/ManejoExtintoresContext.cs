using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ManejoExtintores.Infraestructura.Data
{
    public partial class ManejoExtintoresContext : IdentityDbContext<Usuarios>
    {

        public ManejoExtintoresContext(DbContextOptions<ManejoExtintoresContext> options)
            : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<CreditoServicios> CreditoServicios { get; set; }
        public DbSet<DetalleExtintorClientes> DetalleExtClientes { get; set; }
        public DbSet<DetalleServicioDetalleClientes> DetalleServicioDetalleClientes { get; set; }
        public DbSet<DetalleServicios> DetalleServicios { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Gastos> Gastos { get; set; }
        public DbSet<Inventarios> Inventarios { get; set; }
        public DbSet<PesoExtintors> PesoExtintors { get; set; }
        public DbSet<Precios> Precios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<TipoExtintors> TipoExtintors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}

using ManejoExtintores.Core.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ManejoExtintores.Infraestructura.Data
{
    public partial class ManejoExtintoresContext : IdentityDbContext<Usuario>
    {

        public ManejoExtintoresContext(DbContextOptions<ManejoExtintoresContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CreditoServicio> CreditoServicios { get; set; }
        public DbSet<DetalleExtCliente> DetalleExtClientes { get; set; }
        public DbSet<DetalleServicio> DetalleServicios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<PesoExtintor> PesoExtintors { get; set; }
        public DbSet<Precio> Precios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<TipoExtintor> TipoExtintors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}

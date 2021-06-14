using FluentValidation;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Servicios;
using ManejoExtintores.Infraestructura.Repositorios;
using ManejoExtintores.Infraestructura.Validaciones;
using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ManejoExtintores.Core.DTOs.Request;
using ManejoExtintores.Core.Interfaces.Repositorios;

namespace ManejoExtintores.Infraestructura.Extensiones
{
    public static class ServiciosExtension
    {
        public static IServiceCollection AgregarContexto(this IServiceCollection services, IConfiguration Configuracion) 
        {
            services.AddDbContext<ManejoExtintoresContext>(options => options.UseSqlServer(Configuracion.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static IServiceCollection AgregarOpsiones(this IServiceCollection services, IConfiguration Configuration ) 
        {
            services.AddControllers(option =>
            {
                

            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
            return services;
        }
        public static IServiceCollection AgregarServicios(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IRepositorio<Cliente>), typeof(RepositorioBase<Cliente>));
            services.AddTransient<IRepositorioClientes, RepositorioClientes>();
            services.AddScoped(typeof(IRepositorio<DetalleServicio>), typeof(RepositorioBase<DetalleServicio>));
            services.AddScoped(typeof(IRepositorio<Empresa>), typeof(RepositorioBase<Empresa>));
            services.AddScoped(typeof(IRepositorio<Empleado>), typeof(RepositorioBase<Empleado>));
            services.AddTransient<IRepositorioEmpleado, RepositorioEmpleado>();
            services.AddScoped(typeof(IRepositorio<Gasto>), typeof(RepositorioBase<Gasto>));
            services.AddScoped(typeof(IRepositorio<Inventario>), typeof(RepositorioBase<Inventario>));
            services.AddScoped(typeof(IRepositorio<PesoExtintor>), typeof(RepositorioBase<PesoExtintor>));
            services.AddScoped(typeof(IRepositorio<Precio>), typeof(RepositorioBase<Precio>));
            services.AddScoped(typeof(IRepositorio<Producto>), typeof(RepositorioBase<Producto>));
            services.AddScoped(typeof(IRepositorio<TipoExtintor>), typeof(RepositorioBase<TipoExtintor>));
            services.AddScoped(typeof(IRepositorio<Servicio>), typeof(RepositorioBase<Servicio>));
            services.AddTransient<IRepositorioServicio, RepositorioServicio>();

            services.AddTransient<IValidator<ClientesBase>, ValidacionClientes>();
            services.AddTransient<IValidator<EmpresaBase>, ValidacionesEmpresas>();
            services.AddTransient<IValidator<EmpleadoBase>, ValidacionEmpleados>();
            services.AddTransient<IValidator<GastosBase>, ValidacionesGastos>();
            services.AddTransient<IValidator<InventarioBase>, ValidacionInventario>();
            services.AddTransient<IValidator<PesoExtintorBase>, ValidacionPesoExtintor>();
            services.AddTransient<IValidator<PrecioBase>, ValidacionesPrecios>();  
            services.AddTransient<IValidator<ProductoBase>, ValidacionesProducto>();   
            services.AddTransient<IValidator<TipoExtintorBase>, ValidacionTipoExtintor>();   
            services.AddTransient<IValidator<ServicioBase>, ValidacionServicios>();   
            services.AddTransient<IValidator<AutenticacionUsuarioDTO>, ValidacionAutenticacionUsuario>();   
            services.AddTransient<IValidator<VerificacionDosPasosDTO>, ValidacionVerificacionDosPasos>();   

            services.AddTransient<IServicioCliente, ServicioCliente>();
            services.AddTransient<IDetalleServicio, ServicioDetalleServicio>();
            services.AddTransient<IServicioGasto, ServicioGasto>();
            services.AddTransient<IServicio_Empresa, Servicio_Empresa>();
            services.AddTransient<IServicioEmpleado, ServicioEmpleado>();
            services.AddTransient<IServicioInventario, ServicioInventario>();
            services.AddTransient<IServicioPrecios, ServicioPrecios>();
            services.AddTransient<IServicioProducto, ServicioProducto>();
            services.AddTransient<IServicioPesoExtintor, ServicioPesoExtintor>();
            services.AddTransient<IServicioTipoExtintor, ServicioTipoExtintor>();
            services.AddTransient<IServicioDeServicios, ServicioDeServicios>(); 

            return services;
        }
    }
}

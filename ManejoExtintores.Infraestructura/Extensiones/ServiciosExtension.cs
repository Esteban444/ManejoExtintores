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
using ManejoExtintores.Core.Interfaces.Servicios;

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
            services.AddScoped(typeof(IRepositorio<Clientes>), typeof(RepositorioBase<Clientes>));
            services.AddTransient<IRepositorioClientes, RepositorioClientes>();

            services.AddScoped(typeof(IRepositorio<CreditoServicios>), typeof(RepositorioBase<CreditoServicios>));
            services.AddTransient<IRepositorioCreditos, RepositorioCreditos>();

            services.AddScoped(typeof(IRepositorio<DetalleServicios>), typeof(RepositorioBase<DetalleServicios>));
            services.AddTransient<IRepositorioDetalleServicio, RepositorioDetalleServicio>();
            
            services.AddScoped(typeof(IRepositorio<DetalleExtintorClientes>), typeof(RepositorioBase<DetalleExtintorClientes>));
            services.AddTransient<IRepositorioDetalleExtClientes,RepositorioDetalleExtClientes>();

            services.AddScoped(typeof(IRepositorio<Empresas>), typeof(RepositorioBase<Empresas>));

            services.AddScoped(typeof(IRepositorio<Empleados>), typeof(RepositorioBase<Empleados>));
            services.AddTransient<IRepositorioEmpleado, RepositorioEmpleado>();

            services.AddScoped(typeof(IRepositorio<Gastos>), typeof(RepositorioBase<Gastos>));
            services.AddTransient<IRepositorioGastos, RepositorioGastos>();

            services.AddScoped(typeof(IRepositorio<Inventarios>), typeof(RepositorioBase<Inventarios>));
            services.AddTransient<IRepositorioInventario, RepositorioInventario>();

            services.AddScoped(typeof(IRepositorio<PesoExtintors>), typeof(RepositorioBase<PesoExtintors>));

            services.AddScoped(typeof(IRepositorio<Precios>), typeof(RepositorioBase<Precios>));
            services.AddTransient<IRepositorioPrecios, RepositorioPrecios>();

            services.AddScoped(typeof(IRepositorio<Productos>), typeof(RepositorioBase<Productos>));
            services.AddTransient<IRepositorioProducto, RepositorioProductos>();

            services.AddScoped(typeof(IRepositorio<TipoExtintors>), typeof(RepositorioBase<TipoExtintors>));

            services.AddScoped(typeof(IRepositorio<Servicio>), typeof(RepositorioBase<Servicio>));
            services.AddTransient<IRepositorioServicio, RepositorioServicio>();

            services.AddTransient<IValidator<ClientesBase>, ValidacionClientes>();
            services.AddTransient<IValidator<CreditoServicioBase>, ValidacionCreditos>();
            services.AddTransient<IValidator<DetalleExtintorClienteBase>, ValidacionDetalleExtintorClientes>();
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
            services.AddTransient<IServicioCreditos, ServicioCreditos>();
            services.AddTransient<IDetalleServicio, ServicioDetalleServicios>();
            services.AddTransient<IServicioDetalleExtClientes, ServicioDetalleExtClientes>();
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

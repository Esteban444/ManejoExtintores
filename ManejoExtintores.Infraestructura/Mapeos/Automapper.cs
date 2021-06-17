using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.DTOs.Request;
using ManejoExtintores.Core.Modelos;

namespace ManejoExtintores.Infraestructura.Mapeos 
{
    public class Automapper: Profile
    {
        public Automapper()
        {
            CreateMap<Usuarios, RegistroUsuarioDTO >().ReverseMap();

            CreateMap<Clientes, ClienteDTO>().ReverseMap();
            CreateMap<Clientes, ClientesBase>().ReverseMap();

            CreateMap<CreditoServicios, CreditoServicioBase>().ReverseMap();
            CreateMap<CreditoServicios, CreditoServiciosDTO>().ReverseMap();

            CreateMap<DetalleServicios, DetalleServicioDTO>().ReverseMap();
            CreateMap<DetalleServicios, DetalleServicioBase>().ReverseMap(); 

            CreateMap<DetalleExtClientes, DetalleExtClienteBase>().ReverseMap(); 
            CreateMap<DetalleExtClientes, DetalleExtClienteDTO>().ReverseMap(); 

            CreateMap<Empresas, EmpresaDTO>().ReverseMap();
            CreateMap<Empresas, EmpresaBase>().ReverseMap();

            CreateMap<Empleados, EmpleadosDTO>().ReverseMap();
            CreateMap<Empleados, EmpleadoBase>().ReverseMap();

            CreateMap<Inventarios, InventarioDTO>()
                .ForMember(x => x.Produto, y => y.MapFrom(z => z.Producto));
            CreateMap<Inventarios, InventarioBase>().ReverseMap();


            CreateMap<Gastos, GastosBase>().ReverseMap();
            CreateMap<Gastos, GastosDTO>().ReverseMap();

            CreateMap<Precios, PrecioBase>().ReverseMap(); 
            CreateMap<Precios, PrecioDTO>().ReverseMap();

            CreateMap<Productos, ProductoBase>().ReverseMap(); 
            CreateMap<Productos, ProductoDTO>()
                .ForMember(x => x.TipoExtintors,y => y.MapFrom(z => z.TipoExtintor))
                .ForMember(x => x.PesoExtintors,y => y.MapFrom(z => z.PesoExtintor));

            CreateMap<PesoExtintors, PesoExtintorBase>().ReverseMap();
            CreateMap<PesoExtintors, PesoExtintorDTO>().ReverseMap();

            CreateMap<TipoExtintors, TipoExtintorBase>().ReverseMap();
            CreateMap<TipoExtintors, TipoExtintorDTO>().ReverseMap();

            CreateMap<Servicio, ServicioBase>().ReverseMap();
            CreateMap<Servicio, ServicioDTO>()
                .ForMember(x => x.Clientes,y => y.MapFrom(z => z.Cliente))
                .ForMember(x => x.Empleados, y => y.MapFrom(z => z.Empleado));
        }
    }
}

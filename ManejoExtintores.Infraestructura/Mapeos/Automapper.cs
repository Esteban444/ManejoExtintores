using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Modelos;

namespace ManejoExtintores.Infraestructura.Mapeos 
{
    public class Automapper: Profile
    {
        public Automapper()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClientesBase>().ReverseMap();

            CreateMap<DetalleServicio, DetalleServicioDTO>().ReverseMap();
            CreateMap<DetalleServicio, DetalleServicioBase>().ReverseMap(); 

            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaBase>().ReverseMap();

            CreateMap<Empleado, EmpleadosDTO>().ReverseMap();
            CreateMap<Empleado, EmpleadoBase>().ReverseMap();

            CreateMap<Inventario, InventarioDTO>().ReverseMap();
            CreateMap<Inventario, InventarioBase>().ReverseMap();


            CreateMap<Gasto, GastosBase>().ReverseMap();
            CreateMap<Gasto, GastosDTO>().ReverseMap();

            CreateMap<Precio, PrecioBase>().ReverseMap(); 
            CreateMap<Precio, PrecioDTO>().ReverseMap();

            CreateMap<Producto, ProductoBase>().ReverseMap(); 
            CreateMap<Producto, ProductoDTO>().ReverseMap();

            CreateMap<PesoExtintor, PesoExtintorBase>().ReverseMap();
            CreateMap<PesoExtintor, PesoExtintorDTO>().ReverseMap();

            CreateMap<TipoExtintor, TipoExtintorBase>().ReverseMap();
            CreateMap<TipoExtintor, TipoExtintorDTO>().ReverseMap();

            CreateMap<Servicio, ServicioBase>().ReverseMap();
            CreateMap<Servicio, ServicioDTO>().ReverseMap();
        }
    }
}

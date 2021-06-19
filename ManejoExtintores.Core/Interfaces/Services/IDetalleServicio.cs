using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IDetalleServicio
    {
        Task<List<DetalleServicioDTO>> ConsultaDetalles(FiltroDetalleServicio filtro); 
        DetalleServicioDTO ConsultaDetallePorId(int id); 
        Task<DetalleServicioBase> CrearDetalles(DetalleServicioBase detalle);  
        Task<DetalleServicioBase> ActualizarDetalle(int id,DetalleServicioBase detalle);
        Task<DetalleServicioDTO> EliminarDetalle(int id);
    }
}

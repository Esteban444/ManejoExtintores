using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IDetalleServicio
    {
        IEnumerable<DetalleServicios> GetDetalles();
        DetalleServicios GetDetalle(int id);
        Task CrearDetalle(DetalleServicios detalle); 
        Task<bool> ActualizarDetalle(DetalleServicios detalle);
        Task<bool> EliminarDetalle(int id);
    }
}

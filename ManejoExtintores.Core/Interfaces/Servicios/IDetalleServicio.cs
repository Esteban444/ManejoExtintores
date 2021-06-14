using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IDetalleServicio
    {
        IEnumerable<DetalleServicio> GetDetalles();
        DetalleServicio GetDetalle(int id);
        Task CrearDetalle(DetalleServicio detalle); 
        Task<bool> ActualizarDetalle(DetalleServicio detalle);
        Task<bool> EliminarDetalle(int id);
    }
}

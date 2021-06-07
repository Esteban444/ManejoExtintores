using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioProducto
    {
        IEnumerable<Producto> GetProductos(FiltroProductos filtros);
        Producto GetProducto(int id);
        Task CrearProducto(Producto producto);
        Task<bool> ActualizarProducto(Producto producto); 
        Task<bool> EliminarProducto(int id); 
    }
}

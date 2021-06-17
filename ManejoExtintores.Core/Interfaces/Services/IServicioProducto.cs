using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioProducto
    {
        Task<IEnumerable<ProductoDTO>> ConsultaProductos(FiltroProductos filtros);
        ProductoDTO ConsultaPorId(int id); 
        Task<ProductoBase> CrearProducto(ProductoBase producto);
        Task<ProductoBase> ActualizarProducto(int id,ProductoBase producto); 
        Task<ProductoBase> EliminarProducto(int id); 
    }
}

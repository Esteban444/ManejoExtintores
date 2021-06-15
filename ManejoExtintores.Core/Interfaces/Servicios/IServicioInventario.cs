using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces
{
    public interface IServicioInventario
    {
        Task<IEnumerable<InventarioDTO>> ConsultaInventarios(FiltroInventario filtro);  
        InventarioDTO ConsultaInventarioPorId(int id);  
        Task<InventarioBase> CrearInventario(InventarioBase inventario);
        Task<InventarioBase> ActualizarInventario(int id,InventarioBase inventario);
        Task<InventarioBase> EliminarInventario(int id); 
    }
}

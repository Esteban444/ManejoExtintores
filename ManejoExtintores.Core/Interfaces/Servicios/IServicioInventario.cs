using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces
{
    public interface IServicioInventario
    {
        IEnumerable<Inventario> GetInventarios(FiltroInventario filtro); 
        Inventario GetInventario(int id); 
        Task CrearInventario(Inventario inventario);
        Task<bool> ActualizarInventario(Inventario inventario);
        Task<bool> EliminarInventario(int id); 
    }
}

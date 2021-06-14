using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces
{
    public interface IServicioPrecios
    {
        IEnumerable<Precio> GetPrecios(FiltroPrecios filtro);
        Precio GetPrecio(int id);
        Task CrearPrecio(Precio precio);
        Task<bool> ActualizarPrecio(Precio precio);
        Task<bool> EliminarPrecio(int id); 
    }
}

using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces
{
    public interface IServicioPrecios
    {
        Task<IEnumerable<PrecioDTO>> ConsultaPrecios(FiltroPrecios filtro);
        PrecioDTO ConsultaPorId(int id); 
        Task<PrecioBase> CrearPrecio(PrecioBase precio);
        Task<PrecioBase> ActualizarPrecio(int id,PrecioBase precio);
        Task<PrecioDTO> EliminarPrecio(int id); 
    }
}

using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public  interface IServicioGasto
    {
        Task<IEnumerable<GastosDTO>> GetGastos(FiltrosGastos filtros);
        GastosDTO GetGasto(int id);
        Task<GastosBase> CrearGasto(GastosBase gasto);
        Task<GastosBase> ActualizarGasto(int id,GastosBase gasto); 
        Task<GastosDTO> EliminarGasto(int id);

    }
}
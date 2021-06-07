using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public  interface IServicioGasto
    {
        IEnumerable<Gasto> GetGastos(Filtros_Cargos filtros);
        Task<Gasto> GetGasto(int id);
        Task CrearGasto(Gasto gasto);
        Task<bool> ActualizarGasto(Gasto gasto); 
        Task<bool> EliminarGasto(int id);

    }
}
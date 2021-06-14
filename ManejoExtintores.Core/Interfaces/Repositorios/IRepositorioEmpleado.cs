using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces
{
    public interface IRepositorioEmpleado: IRepositorio<Empleado>
    {
        Task<IEnumerable<Empleado>> ConsultaData(FiltroEmpleados filtro); 
    }
}

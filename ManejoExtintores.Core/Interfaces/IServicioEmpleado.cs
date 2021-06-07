using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioEmpleado
    {
        IEnumerable<Empleado> GetEmpleados( FiltroEmpleados filtros); 
        Empleado GetEmpleado(int id);
        Task CrearEmpleado(Empleado empleado);
        Task<bool> ActualizarEmpleado(Empleado empleado );
        Task<bool> EliminarEmpleado(int id); 
    }
}

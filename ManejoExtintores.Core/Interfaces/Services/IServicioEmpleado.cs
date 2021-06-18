using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioEmpleado
    {
        Task<IEnumerable<EmpleadosDTO>> ConsultaEmpleados( FiltroEmpleados filtros); 
        Task<EmpleadosDTO> ConsultaEmpleadoPorId(int id); 
        Task<EmpleadoBase> CrearEmpleado(EmpleadoBase empleado);
        Task<EmpleadoBase> ActualizarEmpleado(int id,EmpleadoBase empleado );
        Task<EmpleadosDTO> EliminarEmpleado(int id); 
    }
}

using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioEmpleado : IServicioEmpleado
    {
        private readonly IRepositorio<Empleado> _repositorio;

        public ServicioEmpleado(IRepositorio<Empleado> repositorio)  
        {
            _repositorio = repositorio;
        }
        
        public IEnumerable<Empleado> GetEmpleados(FiltroEmpleados filtros) 
        {

            var empleado = _repositorio.Consultas();

            if (filtros.Nombres != null)
            {
                empleado = empleado.Where(x => x.Nombre.ToLower().Contains(filtros.Nombres.ToLower()));
            }

            if (filtros.Apellidos != null)
            {
                empleado = empleado.Where(x => x.Apellido.ToLower().Contains(filtros.Apellidos.ToLower()));
            }


            return empleado;
        }

        public Empleado GetEmpleado(int id) 
        {
            var empleado = _repositorio.ConsultaPorId(e => e.IdEmpleados == id);
            if (empleado != null)
            {
                return empleado;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El empleado que solicita no existe en la base de datos" }); 
            }
        }

        public async Task CrearEmpleado(Empleado empleado)  
        {
           await _repositorio.Crear(empleado); 
        }

        public async Task<bool> ActualizarEmpleado(Empleado empleado) 
        {
            var empleados = _repositorio.ConsultaPorId(e => e.IdEmpleados == empleado.IdEmpleados);
            if (empleados != null)
            {
                empleados.IdEmpresa = empleado.IdEmpresa;
                empleados.Nombre = empleado.Nombre;
                empleados.Apellido = empleado.Apellido;
                empleados.Direccion = empleado.Direccion;
                empleados.Telefono = empleado.Telefono;
                empleados.Email = empleado.Email;

                await _repositorio.Actualizar(empleados);
                return true;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El empleado que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<bool> EliminarEmpleado(int id) 
        {
            var empleadobd =  _repositorio.ConsultaPorId(e => e.IdEmpleados == id);
            if (empleadobd != null)
            {
               
                await _repositorio.Eliminar(empleadobd);
                return true;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El empleado no existe en la base de datos" });
            }
        }
    }
}

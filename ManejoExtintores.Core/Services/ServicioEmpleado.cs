using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioEmpleado : IServicioEmpleado
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioEmpleado _repositorio;

        public ServicioEmpleado(IRepositorioEmpleado repositorio,IMapper mapper)  
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<EmpleadosDTO>> ConsultaEmpleados(FiltroEmpleados filtros) 
        {
            var empleado =  await _repositorio.ConsultaData(filtros);  
            return _mapper.Map<IEnumerable<EmpleadosDTO>>(empleado);
        }

        public async Task<EmpleadosDTO> ConsultaEmpleadoPorId(int id)  
        {
            var empleado = await _repositorio.ConsultaDataPorId( id);
            if (empleado != null)
            {
                return  _mapper.Map<EmpleadosDTO>(empleado);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El empleado que solicita no existe en la base de datos" }); 
            }
        }

        public async Task<EmpleadoBase> CrearEmpleado(EmpleadoBase empleadob)  
        {
            var empleado = _mapper.Map<Empleados>(empleadob);
            await _repositorio.Crear(empleado);
            empleadob = _mapper.Map<EmpleadoBase>(empleado);
            return empleadob;
        }

        public async Task<EmpleadoBase> ActualizarEmpleado(int id,EmpleadoBase empleadod) 
        {
            var empleadobd = _repositorio.ConsultaPorId(e => e.IdEmpleados == id);
            if (empleadobd != null)
            {
                empleadobd.IdEmpresa = empleadod.IdEmpresa;
                empleadobd.Nombre = empleadod.Nombre;
                empleadobd.Apellido = empleadod.Apellido;
                empleadobd.Direccion = empleadod.Direccion;
                empleadobd.Telefono = empleadod.Telefono;
                empleadobd.Email = empleadod.Email;

                await _repositorio.Actualizar(empleadobd);
                empleadod = _mapper.Map<EmpleadoBase>(empleadobd);
                return empleadod;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El empleado que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<EmpleadosDTO> EliminarEmpleado(int id) 
        {
            var empleadobd =  _repositorio.ConsultaPorId(e => e.IdEmpleados == id);
            if (empleadobd != null)
            { 
                await _repositorio.Eliminar(empleadobd);
                var empleadoE = _mapper.Map<EmpleadosDTO>(empleadobd);
                return empleadoE; 
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El empleado no existe en la base de datos" });
            }
        }
    }
}

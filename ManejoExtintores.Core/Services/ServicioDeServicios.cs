using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioDeServicios : IServicioDeServicios
    {
        private readonly IRepositorioServicio _repositorio;

        private readonly IMapper _mapper;
        public ServicioDeServicios(IRepositorioServicio repositorio,IMapper mapper) 
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServicioDTO>> ConsultarServicios(FiltroServicios filtros) 
        {
            var servicios =  await _repositorio.ConsultaData(filtros); 
            var serviciosdt = _mapper.Map<IEnumerable<ServicioDTO>>(servicios);
            return serviciosdt;
        }

        public ServicioDTO ConsultaServicio(int id) 
        {
            var serviciobd = _repositorio.ConsultaPorId(s => s.IdServicios == id);
            if (serviciobd != null)
            {
                return _mapper.Map<ServicioDTO>(serviciobd);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El servicio que solicita no existe en la base de datos." });
            }
        }

        public ServicioBase CrearServicioDetalle(ServicioBase serviciob) 
        {
             var serviciodetalle = _repositorio.CrearServicioDetalle(serviciob);
            serviciob = _mapper.Map<ServicioBase>(serviciodetalle);
            return serviciob;
        }

        public async Task<ServicioBase> CrearServicios(ServicioBase crearserviciob)
        {
            var crearservicios = _mapper.Map<Servicio>(crearserviciob);
            await _repositorio.Crear(crearservicios);
            var serviciob = _mapper.Map<ServicioBase>(crearservicios);
            return serviciob;
        }

        public async Task<ServicioBase> ActualizarServicios(int id,ServicioBase servicio)
        {
            var serviciobd = _repositorio.ConsultaPorId(s => s.IdServicios == id);
            if (serviciobd != null)
            {
                serviciobd.IdClientes = servicio.IdClientes;
                serviciobd.IdEmpleados = servicio.IdEmpleados;
                serviciobd.FechaServicio = servicio.FechaServicio ?? serviciobd.FechaServicio;
                serviciobd.Valor = servicio.Valor ?? serviciobd.Valor;
                serviciobd.Estado = servicio.Estado ?? serviciobd.Estado;
                
                await _repositorio.Actualizar(serviciobd);
                var servicioAct = _mapper.Map<ServicioBase>(serviciobd);
                return servicioAct;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El servicio que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<ServicioDTO> EliminarServicios(int id)
        {
            var serviciobd = _repositorio.ConsultaPorId(s => s.IdServicios == id);
            if (serviciobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(serviciobd);
                    var servicioEliminado = _mapper.Map<ServicioDTO>(serviciobd);
                    return servicioEliminado;
                }
                catch (Exception)
                {
                    throw new ManejoExcepciones(HttpStatusCode.InternalServerError, new { Mensaje = "El servicio tiene relaciones con otros datos no se puede borrar." });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El servicio no existe en la base de datos." });
            }
        }
    }
}

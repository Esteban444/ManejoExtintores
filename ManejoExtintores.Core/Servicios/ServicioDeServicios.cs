using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioDeServicios : IServicioDeServicios
    {
        private readonly IRepositorio<Servicio> _repositorio;

        public ServicioDeServicios(IRepositorio<Servicio> repositorio) 
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Servicio> GetServicios(FiltroServicios filtros)
        {
            var servicios = _repositorio.Consultas();

            if (filtros.FechaServicio != null)
            {
                servicios = servicios.Where(x => x.FechaServicio == filtros.FechaServicio);
            }

            return servicios;
        }

        public Servicio GetServicio(int id)
        {
            var servicio = _repositorio.ConsultaPorId(s => s.IdServicios == id);
            if (servicio != null)
            {
                return servicio;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El servicio que solicita no existe en la base de datos" });
            }
        }

        public async Task<Servicio> CrearServicioDetalle(Servicio servicio) 
        {
            await _repositorio.Crear(servicio);
            
            return servicio;
        }

        public async Task CrearServicios(Servicio servicio)
        { 
           await _repositorio.Crear(servicio);
        }

        public async Task<bool> ActualizarServicios(Servicio servicio)
        {
            var servicios = _repositorio.ConsultaPorId(s => s.IdServicios == servicio.IdServicios);
            if (servicios != null)
            {
                servicios.IdClientes = servicio.IdClientes;
                servicios.IdEmpleados = servicio.IdEmpleados;
                servicios.FechaServicio = servicio.FechaServicio;
                servicios.Valor = servicio.Valor;
                servicios.Estado = servicio.Estado;
                
                await _repositorio.Actualizar(servicios);
                return true;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El servicio que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<bool> EliminarServicios(int id)
        {
            var serviciobd = _repositorio.ConsultaPorId(s => s.IdServicios == id);
            if (serviciobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(serviciobd);
                    return true;
                }
                catch (Exception)
                {

                    throw new ManejoExcepciones(HttpStatusCode.InternalServerError, new { Mensaje = "El servicio tiene relaciones con otros datos no se puede borrar" });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El servicio no existe en la base de datos" });
            }
        }
    }
}

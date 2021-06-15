using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioDetalleServicio : IDetalleServicio
    {
        private readonly IRepositorio<DetalleServicios> _repositorio;

        public ServicioDetalleServicio(IRepositorio<DetalleServicios> repositorio) 
        {
           _repositorio = repositorio;
        }
        
        public IEnumerable<DetalleServicios> GetDetalles()
        {
            var detalles = _repositorio.Consultas();

            /*if (filtros.FechaServicio != null)
            {
                servicios = servicios.Where(x => x.FechaServicio?.ToShortDateString() == filtros.FechaServicio?.ToShortDateString());
            }*/

            return detalles;
        }

        public DetalleServicios GetDetalle(int id)
        {
            var detalle = _repositorio.ConsultaPorId(d => d.IdDetalleServ == id);
            if (detalle != null)
            {
                return detalle;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El  detalle  de servicio que solicita no existe en la base de datos" });
            }
        }

        public async Task CrearDetalle(DetalleServicios detalle)
        {
            
            await _repositorio.Crear(detalle);
        }

        public async Task<bool> ActualizarDetalle(DetalleServicios detalle)
        {
            var detalles = _repositorio.ConsultaPorId(d => d.IdDetalleServ == detalle.IdDetalleServ);
            if (detalles != null)
            {
                detalles.IdServicio = detalle.IdServicio;
                detalles.Descripcion = detalle.Descripcion;
                detalles.TipoExtintor = detalle.TipoExtintor;
                detalles.PesoXlibras = detalle.PesoXlibras;
                detalles.Valor = detalle.Valor;
                detalles.Cantidad = detalle.Cantidad;
                detalles.Total = detalle.Total;

                await _repositorio.Actualizar(detalles);
                return true;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El detalle de servicio que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<bool> EliminarDetalle(int id)
        {
            var detallebd = _repositorio.ConsultaPorId(d => d.IdDetalleServ == id);
            if (detallebd != null)
            {
                try
                {
                    await _repositorio.Eliminar(detallebd);
                    return true;
                }
                catch (Exception)
                {

                    throw new ManejoExcepciones(HttpStatusCode.InternalServerError, new { Mensaje = "El detalle de  servicio tiene relaciones con otros datos no se puede borrar" });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El detalle de servicio no existe en la base de datos" });
            }
        }
    }
}

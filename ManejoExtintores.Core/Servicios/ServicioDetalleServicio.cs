using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioDetalleServicio : IDetalleServicio
    {
        private readonly IRepositorio<DetalleServicio> _repositorio;

        public ServicioDetalleServicio(IRepositorio<DetalleServicio> repositorio) 
        {
           _repositorio = repositorio;
        }
        
        public IEnumerable<DetalleServicio> GetDetalles()
        {
            var detalles = _repositorio.Consultas();

            /*if (filtros.FechaServicio != null)
            {
                servicios = servicios.Where(x => x.FechaServicio?.ToShortDateString() == filtros.FechaServicio?.ToShortDateString());
            }*/

            return detalles;
        }

        public DetalleServicio GetDetalle(int id)
        {
            var detalle = _repositorio.ConsultaPorId(d => d.IdDetalleServ == id);
            if (detalle != null)
            {
                return detalle;
            }
            else
            {
                throw new Excepcion_Servidor("El  detalle  de servicio que solicita no existe en la base de datos");
            }
        }

        public async Task CrearDetalle(DetalleServicio detalle)
        {
            
            await _repositorio.Crear(detalle);
        }

        public async Task<bool> ActualizarDetalle(DetalleServicio detalle)
        {
            var detalles = _repositorio.ConsultaPorId(d => d.IdDetalleServ == detalle.IdDetalleServ);
            if (detalles != null)
            {
                detalles.IdServicios = detalle.IdServicios;
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
                throw new Excepcion_Servidor("El detalle de servicio que desea actualizar no existe en la base de datos");
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

                    throw new Excepcion_Servidor("El detalle de  servicio tiene relaciones con otros datos no se puede borrar");
                }
            }
            else
            {
                throw new Excepcion_Servidor("El detalle de servicio no existe en la base de datos");
            }
        }
    }
}

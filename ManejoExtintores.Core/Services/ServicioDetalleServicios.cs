using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Interfaces.Repositorios;
using ManejoExtintores.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioDetalleServicios : IDetalleServicio
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioDetalleServicio _repositorio;

        public ServicioDetalleServicios(IRepositorioDetalleServicio repositorio,IMapper mapper) 
        {
           _repositorio = repositorio;
            _mapper = mapper;
        }
        
        public async Task<List<DetalleServicioDTO>> ConsultaDetalles(FiltroDetalleServicio filtro) 
        {
            var detalles = await _repositorio.ConsultaData(filtro);
            var detalledt = _mapper.Map<List<DetalleServicioDTO>>(detalles);
            return detalledt;
        }

        public DetalleServicioDTO ConsultaDetallePorId(int id) 
        {
            var detallebd = _repositorio.ConsultaPorId(d => d.IdDetalleServ == id);
            if (detallebd != null)
            {
                return _mapper.Map<DetalleServicioDTO>(detallebd); 
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El  detalle  de servicio que solicita no existe en la base de datos" });
            }
        }

        public async Task<DetalleServicioBase> CrearDetalles(DetalleServicioBase detalleb)
        {
            var detalle =  _mapper.Map<DetalleServicios>(detalleb); 
            await _repositorio.Crear(detalle);
            var detalledt = _mapper.Map<DetalleServicioBase>(detalle);
            return detalledt;
        }

        public async Task<DetalleServicioBase> ActualizarDetalle(int id,DetalleServicioBase detalle)
        {
            var detallesbd = _repositorio.ConsultaPorId(d => d.IdDetalleServ == id);
            if (detallesbd != null)
            {
                detallesbd.IdServicios = detalle.IdServicios;
                detallesbd.Descripcion = detalle.Descripcion;
                detallesbd.IdTipoExtintor = detalle.IdTipoExtintor;
                detallesbd.IdPesoExtintor = detalle.IdPesoExtintor;
                detallesbd.Valor = detalle.Valor;
                detallesbd.Cantidad = detalle.Cantidad;
                detallesbd.Total = detalle.Total;

                await _repositorio.Actualizar(detallesbd);
                var detalleAct = _mapper.Map<DetalleServicioBase>(detallesbd);
                return detalleAct;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El detalle de servicio que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<DetalleServicioDTO> EliminarDetalle(int id)
        {
            var detallebd = _repositorio.ConsultaPorId(d => d.IdDetalleServ == id);
            if (detallebd != null)
            {
                try
                {
                    await _repositorio.Eliminar(detallebd);
                    var detalleEli = _mapper.Map<DetalleServicioDTO>(detallebd);
                    return detalleEli;
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

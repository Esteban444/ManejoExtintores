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
    public class ServicioPrecios : IServicioPrecios
    {
        private readonly IRepositorioPrecios _repositorio;
        private readonly IMapper _mapper;
        public ServicioPrecios(IRepositorioPrecios repositorio,IMapper mapper) 
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<PrecioDTO>> ConsultaPrecios(FiltroPrecios filtro)
        {
            var precios = await _repositorio.ConsultaData(filtro); 
            var preciodt = _mapper.Map<IEnumerable<PrecioDTO>>(precios);
            return preciodt;
        }

        public PrecioDTO ConsultaPor(int id)  
        {
            var preciobd = _repositorio.ConsultaPorId(p => p.IdPrecios == id);
            if (preciobd != null)
            {
                return _mapper.Map<PrecioDTO>(preciobd); 
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El precio que solicita no existe en la base de datos" });
            }
        }

        public async Task<PrecioBase> CrearPrecio(PrecioBase preciobase)
        {
            var precio = _mapper.Map<Precios>(preciobase); 
            await _repositorio.Crear(precio);
            preciobase = _mapper.Map<PrecioBase>(precio);
            return preciobase;
        }


        public async Task<PrecioBase> ActualizarPrecio(int id,PrecioBase precioAct)
        {
            var precios = _repositorio.ConsultaPorId(p => p.IdPrecios == id);
            if (precios != null)
            {
                precios.IdProductos = precioAct.IdProductos;
                precios.Descripcion = precioAct.Descripcion;
                precios.Valor = precioAct.Valor;
                precios.Iva = precioAct.Iva;
                
                await _repositorio.Actualizar(precios);
                precioAct = _mapper.Map<PrecioBase>(precios);
                return precioAct;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El precio que desea actualizar no existe en la base de datos" });
            }
        }
         
        public async Task<PrecioDTO> EliminarPrecio(int id) 
        {
            var preciobd = _repositorio.ConsultaPorId(p => p.IdPrecios == id);
            if (preciobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(preciobd);
                    var precioE = _mapper.Map<PrecioDTO>(preciobd);
                    return precioE;
                }
                catch (Exception)
                {
                    throw new ManejoExcepciones(HttpStatusCode.InternalServerError, new { Mensaje = "El Precio tiene relacion con productos o detalle de servicio no se puede borrar" });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El Precio no existe en la base de datos" });
            }
        }
    }
}

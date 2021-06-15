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
    public class ServicioPrecios : IServicioPrecios
    {
        private readonly IRepositorio<Precios> _repositorio;

        public ServicioPrecios(IRepositorio<Precios> repositorio) 
        {
            _repositorio = repositorio;
        }
        
        public IEnumerable<Precios> GetPrecios(FiltroPrecios filtro)
        {
            var precios = _repositorio.Consultas();

            if (filtro.Descripcion != null)
            {
                precios = precios.Where(x => x.Descripcion.ToLower().Contains(filtro.Descripcion.ToLower()));
            }

            return precios;
        }

        public Precios GetPrecio(int id)
        {
            var precio = _repositorio.ConsultaPorId(p => p.IdPrecios == id);
            if (precio != null)
            {
                return precio;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El precio que solicita no existe en la base de datos" });
            }
        }

        public async Task CrearPrecio(Precios precio)
        {
            await _repositorio.Crear(precio);
        }


        public async Task<bool> ActualizarPrecio(Precios precio)
        {
            var precios = _repositorio.ConsultaPorId(p => p.IdPrecios == precio.IdPrecios);
            if (precios != null)
            {
                precios.IdProductos = precio.IdProductos;
                precios.Descripcion = precio.Descripcion;
                precios.Valor = precio.Valor;
                precios.Iva = precio.Iva;
                

                await _repositorio.Actualizar(precios);
                return true;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El precio que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<bool> EliminarPrecio(int id)
        {
            var preciobd = _repositorio.ConsultaPorId(p => p.IdPrecios == id);
            if (preciobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(preciobd);
                    return true;
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

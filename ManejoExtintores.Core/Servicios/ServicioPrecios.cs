using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioPrecios : IServicioPrecios
    {
        private readonly IRepositorio<Precio> _repositorio;

        public ServicioPrecios(IRepositorio<Precio> repositorio) 
        {
            _repositorio = repositorio;
        }
        
        public IEnumerable<Precio> GetPrecios(FiltroPrecios filtro)
        {
            var precios = _repositorio.Consultas();

            if (filtro.Descripcion != null)
            {
                precios = precios.Where(x => x.Descripcion.ToLower().Contains(filtro.Descripcion.ToLower()));
            }

            return precios;
        }

        public Precio GetPrecio(int id)
        {
            var precio = _repositorio.ConsultaPorId(p => p.IdPrecios == id);
            if (precio != null)
            {
                return precio;
            }
            else
            {
                throw new Excepcion_Servidor("El precio que solicita no existe en la base de datos");
            }
        }

        public async Task CrearPrecio(Precio precio)
        {
            await _repositorio.Crear(precio);
        }


        public async Task<bool> ActualizarPrecio(Precio precio)
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
                throw new Excepcion_Servidor("El precio que desea actualizar no existe en la base de datos");
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
                    throw new Excepcion_Servidor("El Precio tiene relacion con productos o detalle de servicio no se puede borrar");
                }
            }
            else
            {
                throw new Excepcion_Servidor("El Precio no existe en la base de datos");
            }
        }
    }
}

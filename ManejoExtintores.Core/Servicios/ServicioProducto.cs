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
    public class ServicioProducto : IServicioProducto
    {
        private readonly IRepositorio<Producto> _repositorio;

        public ServicioProducto(IRepositorio<Producto> repositorio) 
        {
            _repositorio = repositorio;
        }
        
        public IEnumerable<Producto> GetProductos(FiltroProductos filtros)
        {
            var productos = _repositorio.Consultas();

            if (filtros.TipoProducto != null)
            {
                productos = productos.Where(x => x.TipoProducto.ToLower().Contains(filtros.TipoProducto.ToLower()));
            }

            return productos;
        }
         
        public Producto GetProducto(int id)
        {
            var producto = _repositorio.ConsultaPorId(p => p.IdProductos == id);
            if (producto != null)
            {
                return producto;
            }
            else
            {
                throw new Excepcion_Servidor("El producto que solicita no existe en la base de datos");
            }
        }

        public async Task CrearProducto(Producto producto)
        {
                await _repositorio.Crear(producto);
            
        }

        public async Task<bool> ActualizarProducto(Producto producto)
        {
            var productos = _repositorio.ConsultaPorId(p => p.IdProductos == producto.IdProductos);
            if (productos != null)
            {
                productos.IdTipoExtintor = producto.IdTipoExtintor;
                productos.IdPesoExtintor = producto.IdPesoExtintor;
                productos.TipoProducto = producto.TipoProducto;
                productos.PesoXlibras = producto.PesoXlibras;
                productos.PesoXlibras = producto.PesoXlibras;


                await _repositorio.Actualizar(productos);
                return true;
            }
            else
            {
                throw new Excepcion_Servidor("El producto que desea actualizar no existe en la base de datos");
            }
        }

        public async Task<bool> EliminarProducto(int id)
        {
            var productobd = _repositorio.ConsultaPorId(p => p.IdProductos == id);
            if (productobd != null)
            {
                try
                {
              
                    await _repositorio.Eliminar(productobd);
                    return true;
                }
                catch (Exception) { 
                
                    throw new Excepcion_Servidor("El producto tiene relacion con inventario no se puede borrar");
                }
            }
            else
            {
                throw new Excepcion_Servidor("El producto no existe en la base de datos");
            }
        }
    }
}

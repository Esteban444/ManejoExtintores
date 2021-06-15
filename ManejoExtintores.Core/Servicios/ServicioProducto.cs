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
    public class ServicioProducto : IServicioProducto
    {
        private readonly IRepositorioProducto _repositorio;
        private readonly IMapper _mapper;
        public ServicioProducto(IRepositorioProducto repositorio,IMapper mapper) 
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ProductoDTO>> ConsultaProductos(FiltroProductos filtros)
        {
            var productos = await _repositorio.ConsultaData(filtros);
            var productodt = _mapper.Map<IEnumerable<ProductoDTO>>(productos);
            return productodt;
        }
         
        public ProductoDTO ConsultaPorId(int id) 
        {
            var productobd = _repositorio.ConsultaPorId(p => p.IdProductos == id);
            if (productobd != null)
            {
                return _mapper.Map<ProductoDTO>(productobd);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "El producto que solicita no existe en la base de datos" });
            }
        }

        public async Task<ProductoBase> CrearProducto(ProductoBase productobase)
        {
            var producto = _mapper.Map<Productos>(productobase);
            await _repositorio.Crear(producto);
            productobase = _mapper.Map<ProductoBase>(producto);
            return productobase;
        }

        public async Task<ProductoBase> ActualizarProducto(int id,ProductoBase productobs)
        {
            var productosbd = _repositorio.ConsultaPorId(p => p.IdProductos == id);
            if (productosbd != null)
            {
                productosbd.IdTipoExtintor = productobs.IdTipoExtintor;
                productosbd.IdPesoExtintor = productobs.IdPesoExtintor;
                productosbd.TipoProducto = productobs.TipoProducto;
                productosbd.PesoXlibras = productobs.PesoXlibras;
                productosbd.PesoXlibras = productobs.PesoXlibras;

                await _repositorio.Actualizar(productosbd);
                productobs = _mapper.Map<ProductoBase>(productosbd);
                return productobs;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "El producto que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<ProductoBase> EliminarProducto(int id)
        {
            var productobd = _repositorio.ConsultaPorId(p => p.IdProductos == id);
            if (productobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(productobd);
                    var productoE = _mapper.Map<ProductoBase>(productobd);
                    return productoE;
                }
                catch (Exception) { 
                
                    throw new ManejoExcepciones(HttpStatusCode.InternalServerError, new { mensaje = "El producto tiene relacion con inventario no se puede borrar" });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "El producto no existe en la base de datos" });
            }
        }
    }
}

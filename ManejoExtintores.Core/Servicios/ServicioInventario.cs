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
    public class ServicioInventario : IServicioInventario
    {
        private readonly IRepositorio<Inventario> _repositorio;

        public ServicioInventario(IRepositorio<Inventario> repositorio) 
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Inventario> GetInventarios(FiltroInventario filtro)
        {
            var inventario = _repositorio.Consultas();

            if (filtro.Fecha != null)
            {
                inventario = inventario.Where(x => x.Fecha == filtro.Fecha);
            }

            if (filtro.Descripcion != null)
            {
                inventario = inventario.Where(x => x.Descripcion.ToLower().Contains(filtro.Descripcion.ToLower()));
            }

            if (filtro.Tipo != null)
            {
                inventario = inventario.Where(x => x.Tipo.ToLower().Contains(filtro.Tipo.ToLower()));
            }

            if (filtro.FechaVencimiento != null)
            {
                inventario = inventario.Where(x => x.FechaVencimiento == filtro.FechaVencimiento);
            }
            return inventario;
        }

        public Inventario GetInventario(int id)
        {
            var inventario = _repositorio.ConsultaPorId(i => i.IdInventario == id);
            if (inventario != null)
            {
                return inventario;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El inventario que solicita no existe en la base de datos" });
            }
        }

        public async Task CrearInventario(Inventario inventario)
        {
            
           await _repositorio.Crear(inventario);
        }

        public async Task<bool> ActualizarInventario(Inventario inventario)
        {
            var inventarios = _repositorio.ConsultaPorId(i => i.IdInventario == inventario.IdInventario);
            if (inventarios != null)
            {
                inventarios.IdProductos = inventario.IdProductos;
                inventarios.Fecha = inventario.Fecha;
                inventarios.Descripcion = inventario.Descripcion;
                inventarios.Tipo = inventario.Tipo;
                inventarios.PesoXlibras = inventario.PesoXlibras;
                inventarios.Cantidad = inventario.Cantidad;
                inventarios.FechaVencimiento = inventario.FechaVencimiento;

                await _repositorio.Actualizar(inventarios);
                
                return true;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El inventario que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<bool> EliminarInventario(int id)
        {
            var inventariobd = _repositorio.ConsultaPorId(i => i.IdInventario == id);
            if (inventariobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(inventariobd);
                    return true;
                }
                catch (Exception)
                {
                    throw new ManejoExcepciones(HttpStatusCode.InternalServerError, new { Mensaje = "El inventario tiene relacion con productos no se puede borrar" });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El inventario no existe en la base de datos" });
            }
        }

    }
}

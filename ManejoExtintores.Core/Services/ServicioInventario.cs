using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Interfaces.Repositorios;
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
        private readonly IMapper _mapper;
        private readonly IRepositorioInventario _repositorio;

        public ServicioInventario(IRepositorioInventario repositorio,IMapper mapper) 
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventarioDTO>> ConsultaInventarios(FiltroInventario filtro) 
        {
            var inventarios = await _repositorio.ConsultaData(filtro); 
            var inventariosdt = _mapper.Map<IEnumerable<InventarioDTO>>(inventarios);
            return inventariosdt;
        }

        public InventarioDTO ConsultaInventarioPorId(int id) 
        {
            var inventario = _repositorio.ConsultaPorId(i => i.IdInventario == id);
            if (inventario != null)
            {
                return _mapper.Map<InventarioDTO>( inventario);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El inventario que solicita no existe en la base de datos" });
            }
        }

        public async Task<InventarioBase> CrearInventario(InventarioBase inventario)
        {
            var invent = _mapper.Map<Inventarios>(inventario);
            await _repositorio.Crear(invent);
            var inventariob = _mapper.Map<InventarioBase>(invent);
            return inventariob;
        }

        public async Task<InventarioBase> ActualizarInventario(int id,InventarioBase inventario)
        {
            var inventarios = _repositorio.ConsultaPorId(i => i.IdInventario == id);
            if (inventarios != null)
            {
                inventarios.IdProductos = inventario.IdProductos;
                inventarios.Fecha = inventario.Fecha;
                inventarios.Descripcion = inventario.Descripcion;
                inventarios.IdTipoExtintor = inventario.IdTipoExtintor;
                inventarios.IdPesoExtintor = inventario.IdPesoExtintor; 
                inventarios.Cantidad = inventario.Cantidad;
                inventarios.FechaVencimiento = inventario.FechaVencimiento;

                await _repositorio.Actualizar(inventarios);
                var inventariAct = _mapper.Map<InventarioBase>(inventarios);
                return inventariAct;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El inventario que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<InventarioBase> EliminarInventario(int id)
        {
            var inventariobd = _repositorio.ConsultaPorId(i => i.IdInventario == id);
            if (inventariobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(inventariobd);
                    var inventarioE = _mapper.Map<InventarioBase>(inventariobd);
                    return inventarioE;
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

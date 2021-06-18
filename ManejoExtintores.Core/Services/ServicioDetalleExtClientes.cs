using AutoMapper;
using ManejoExtintores.Core.DTOs.Request;
using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces.Repositorios;
using ManejoExtintores.Core.Interfaces.Servicios;
using ManejoExtintores.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios
{
    public class ServicioDetalleExtClientes : IServicioDetalleExtClientes
    {
        private readonly IRepositorioDetalleExtClientes _repositorioDetalleExtClientes;
        private readonly IMapper _mapper;
        public ServicioDetalleExtClientes(IRepositorioDetalleExtClientes repositorio,IMapper mapper)
        {
            _repositorioDetalleExtClientes = repositorio;
            _mapper = mapper;
        }

        public async Task<List<DetalleExtClienteDTO>> ConsultaDetalleClientes(FiltroDetalleExtClientes filtro)
        {
            var detalleextClientes =  await _repositorioDetalleExtClientes.ConsultaData(filtro);
            var detalleextclientesdt = _mapper.Map<List<DetalleExtClienteDTO>>(detalleextClientes);
            return detalleextclientesdt;
        }

        public async Task<DetalleExtClienteDTO> ConsultaDetalleExtClientePorId(int id)
        {
            var detalleextintorCliente = await _repositorioDetalleExtClientes.ConsultaDataPorId(id);
            if(detalleextintorCliente != null)
            {
                return _mapper.Map<DetalleExtClienteDTO>(detalleextintorCliente);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new {mensaje = "El detalle de extintor de cliente no existe en la base de datos." });
            }
        }

        public async Task<DetalleExtClienteBase> CrearDetalleExtCliente(DetalleExtClienteBase detalleExtCliente)
        {
            var detalleextintorcliente = _mapper.Map<DetalleExtClientes>(detalleExtCliente);
            await _repositorioDetalleExtClientes.Crear(detalleextintorcliente); ;
            detalleExtCliente = _mapper.Map<DetalleExtClienteBase>(detalleextintorcliente);
            return detalleExtCliente;
        }

        public async Task<DetalleExtClienteBase> ActualizarDetalleExtCliente(int id, DetalleExtClienteBase detalleExtCliente)
        {
            var detalleactualizarbd = _repositorioDetalleExtClientes.ConsultaPorId(x => x.IdDetalleCliente == id);
            if(detalleactualizarbd != null)
            {
                detalleactualizarbd.IdClientes = detalleExtCliente.IdClientes;
                detalleactualizarbd.IdServicio = detalleExtCliente.IdServicio;
                detalleactualizarbd.TipoExtintor = detalleExtCliente.TipoExtintor ?? detalleactualizarbd.TipoExtintor;
                detalleactualizarbd.Pesoextintor = detalleExtCliente.Pesoextintor ?? detalleactualizarbd.Pesoextintor;
                detalleactualizarbd.Cantidad = detalleExtCliente.Cantidad ?? detalleactualizarbd.Cantidad;
                detalleactualizarbd.FechaServicio = detalleExtCliente.FechaServicio ?? detalleactualizarbd.FechaServicio;
                detalleactualizarbd.FechaMantenimiento = detalleExtCliente.FechaMantenimiento ?? detalleactualizarbd.FechaMantenimiento;
                detalleactualizarbd.FechaVencimiento = detalleExtCliente.FechaVencimiento ?? detalleactualizarbd.FechaVencimiento;

                await _repositorioDetalleExtClientes.Actualizar(detalleactualizarbd);
                var detalleExtclienteactualizado = _mapper.Map<DetalleExtClienteBase>(detalleactualizarbd);
                return detalleExtclienteactualizado;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "El detalle extintor del cliente que desea actualizar no existe en la base de datos." });
            }
        }

        public async Task<DetalleExtClienteDTO> EliminarDetalleExtCliente(int id)
        {
            var detalleExtclientebd =   _repositorioDetalleExtClientes.ConsultaPorId(e => e.IdDetalleCliente == id);
            if (detalleExtclientebd != null)
            {
                try
                {
                    await _repositorioDetalleExtClientes.Eliminar(detalleExtclientebd);
                    var detalleExtClienteE = _mapper.Map<DetalleExtClienteDTO>(detalleExtclientebd);
                    return detalleExtClienteE;
                }
                catch (Exception)
                {
                    throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "La detalle extintor de este cliente tiene relaciones con otras tablas no se puede borrar." });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "La detalle extintor de cliente no existe en la base de datos." });
            }

        }
    }
}

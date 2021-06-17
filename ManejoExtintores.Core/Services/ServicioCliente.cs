using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Interfaces.Repositorios;
using ManejoExtintores.Core.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly IRepositorioClientes _repositorio;
        private readonly IMapper _mapper;
        public ServicioCliente(IRepositorioClientes repositorio,IMapper mapper) 
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientes(FiltroClientes filtro)
        {
            var clientes =  await _repositorio.ConsultaData(filtro); 
            var clientesdto = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return clientesdto;
        }

        public  ClienteDTO GetCliente(int id)
        {
            var cliente = _repositorio.ConsultaPorId(c => c.IdCliente == id);
            if (cliente != null)
            {
                return _mapper.Map<ClienteDTO>(cliente);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El cliente que solicita no existe en la base de datos" });
            }
        }

        public async Task<ClientesBase> CrearCliente(ClientesBase clienteb) 
        {
            var cliente = _mapper.Map<Clientes>(clienteb);
            await _repositorio.Crear(cliente);
            clienteb = _mapper.Map<ClientesBase>(cliente);
            return clienteb;

        }

        public async Task<ClientesBase> ActualizarCliente(int id,ClientesBase cliente)
        {
            var clientes = _repositorio.ConsultaPorId(c => c.IdCliente == id);
            if (clientes != null)
            {
                clientes.DocCliente = cliente.DocCliente;
                clientes.Nombre = cliente.Nombre;
                clientes.Apellido = cliente.Apellido;
                clientes.Descripcion = cliente.Descripcion;
                clientes.Direccion = cliente.Direccion;
                clientes.Telefono = cliente.Telefono;
                clientes.Email = cliente.Email;
                clientes.Nit = cliente.Nit;

                await _repositorio.Actualizar(clientes);
                var clientedt = _mapper.Map<ClientesBase>(clientes);
                return clientedt;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El cliente que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<ClienteDTO> EliminarCliente(int id)
        {
            var clientebd = _repositorio.ConsultaPorId(c => c.IdCliente == id);
            if (clientebd != null)
            {
                try
                {
                    await _repositorio.Eliminar(clientebd);
                    var clienteE = _mapper.Map<ClienteDTO>(clientebd);
                    return clienteE;
                }
                catch (Exception)
                {
                    throw new ManejoExcepciones(HttpStatusCode.InternalServerError, new { Mensaje = "El cliente tiene relacion con un servicio no se puede borrar" });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound,new { Mensaje = "El cliente no existe en la base de datos" });
            }
        }
    }
}

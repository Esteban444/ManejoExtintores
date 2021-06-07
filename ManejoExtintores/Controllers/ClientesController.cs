using AutoMapper;
using FluentValidation;
using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.DTOs.Responce;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IServicioCliente _servicioCliente;
        private readonly IMapper _mapper;
        private readonly IValidator<ClientesBase> _validator;
        public ClientesController(IServicioCliente cliente, IMapper mapper,IValidator<ClientesBase> validator)
        {
            _servicioCliente = cliente;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Consultas([FromQuery] FiltroClientes filtro)
        {
            var clientes = _servicioCliente.GetClientes(filtro);
            var cliente = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            var response = new Respuesta<IEnumerable<ClienteDTO>>(cliente);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {

            var cliente =  _servicioCliente.GetCliente(id);
            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

            var response = new Respuesta<ClienteDTO>(clienteDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ClientesBase clienteb)
        {
            var Validacion = _validator.Validate(clienteb);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaCliente { Errors = errors });
            }
            else
            {
                var cliente = _mapper.Map<Cliente>(clienteb);

                await _servicioCliente.CrearCliente(cliente);

                clienteb = _mapper.Map<ClientesBase>(cliente);
                var response = new Respuesta<ClientesBase>(clienteb);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, ClientesBase actualizar) 
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaCliente { Errors = errors });
            }
            else
            {
                var cliente = _mapper.Map<Cliente>(actualizar);
                cliente.IdCliente = id;
                var result = await _servicioCliente.ActualizarCliente(cliente);
                var response = new Respuesta<bool>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioCliente.EliminarCliente(id);
            var response = new Respuesta<bool>(result);
            return Ok(response);

        }
    }
}

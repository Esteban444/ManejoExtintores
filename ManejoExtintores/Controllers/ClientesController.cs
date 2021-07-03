using FluentValidation;
using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.DTOs.Responce;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IServicioCliente _servicioCliente;
        private readonly IValidator<ClientesBase> _validator;
        public ClientesController(IServicioCliente cliente,IValidator<ClientesBase> validator)
        {
            _servicioCliente = cliente;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Consultas([FromQuery] FiltroClientes filtro)
        {
            var clientes = await _servicioCliente.GetClientes(filtro);
            var response = new Respuesta<IEnumerable<ClienteDTO>>(clientes);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            var cliente =  _servicioCliente.GetCliente(id);
            var response = new Respuesta<ClienteDTO>(cliente);
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
                await _servicioCliente.CrearCliente(clienteb);
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
                var result = await _servicioCliente.ActualizarCliente(id,actualizar);
                var response = new Respuesta<ClientesBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioCliente.EliminarCliente(id);
            var response = new Respuesta<ClienteDTO>(result);
            return Ok(response);

        }
    }
}

using FluentValidation;
using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs.Request;
using ManejoExtintores.Core.DTOs.Responce;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleExtintorClientesController : ControllerBase
    {
        private readonly IServicioDetalleExtClientes _servicioDetalleExtClientes;
        private readonly IValidator<DetalleExtClienteBase> _validator;
        public DetalleExtintorClientesController( IServicioDetalleExtClientes servicioDetalleExtClientes,
            IValidator<DetalleExtClienteBase> validator)
        {
            _servicioDetalleExtClientes = servicioDetalleExtClientes;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaDetalleExtClientes([FromQuery]FiltroDetalleExtClientes filtro)
        {
            var detalleextintorclientes = await _servicioDetalleExtClientes.ConsultaDetalleClientes(filtro);
            var resultado = new Respuesta<List<DetalleExtClienteDTO>>(detalleextintorclientes);
            return Ok(resultado); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaDetalleExtclientePorId(int id)
        {
            var detalleExtintorCliente =  await _servicioDetalleExtClientes.ConsultaDetalleExtClientePorId(id);
            var resultado = new Respuesta<DetalleExtClienteDTO>(detalleExtintorCliente);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> CrearDetalleExtintorCliente([FromBody] DetalleExtClienteBase crear) 
        {
            var Validacion = _validator.Validate(crear);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaDetalleExtCliente { Errors = errors });
            }
            else
            {
                var creardetalleExtintorcliente = await _servicioDetalleExtClientes.CrearDetalleExtCliente(crear);
                var resultado = new Respuesta<DetalleExtClienteBase>(creardetalleExtintorcliente);
                return Ok(resultado);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCredito(int id, DetalleExtClienteBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaCredito { Errors = errors });
            }
            else
            {
                var actualizardetalleextintorcliente = await _servicioDetalleExtClientes.ActualizarDetalleExtCliente(id, actualizar);
                var detalleextCliAct = new Respuesta<DetalleExtClienteBase>(actualizardetalleextintorcliente);
                return Ok(detalleextCliAct);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCredito(int id)
        {
            var resultado = await _servicioDetalleExtClientes.EliminarDetalleExtCliente(id);
            var respuesta = new Respuesta<DetalleExtClienteDTO>(resultado);
            return Ok(respuesta);
        }

    }
}

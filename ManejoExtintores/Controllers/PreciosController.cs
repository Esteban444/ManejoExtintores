using FluentValidation;
using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.DTOs.Responce;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreciosController : ControllerBase
    {
        private readonly IServicioPrecios _servicioPrecios;
        private readonly IValidator<PrecioBase> _validator;

        public PreciosController(IServicioPrecios servicioPrecio,IValidator<PrecioBase> validator) 
        {
            _servicioPrecios = servicioPrecio;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultasPrecios([FromQuery] FiltroPrecios filtro)
        {
            var precios =  await _servicioPrecios.ConsultaPrecios(filtro); 
            var response = new Respuesta<IEnumerable<PrecioDTO>>(precios);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultaPrecio(int id)   
        {
            var precio = _servicioPrecios.ConsultaPor(id);
            var response = new Respuesta<PrecioDTO>(precio);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPrecios(PrecioBase preciobase)
        {
            var Validacion = _validator.Validate(preciobase); 
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaPrecios { Errors = errors });
            }
            else
            {
                await _servicioPrecios.CrearPrecio(preciobase);
                var response = new Respuesta<PrecioBase>(preciobase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPrecios(int id, PrecioBase actualizar) 
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaPrecios { Errors = errors });
            }
            else
            {
                var result = await _servicioPrecios.ActualizarPrecio(id,actualizar);
                var response = new Respuesta<PrecioBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPrecios(int id) 
        {
            var result = await _servicioPrecios.EliminarPrecio(id);
            var response = new Respuesta<PrecioDTO>(result);
            return Ok(response);

        }
    }
}

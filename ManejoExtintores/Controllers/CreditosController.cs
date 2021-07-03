using FluentValidation;
using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs.Request;
using ManejoExtintores.Core.DTOs.Responce;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CreditosController : ControllerBase
    {
        private readonly IServicioCreditos _serviciCreditos;
        private readonly IValidator<CreditoServicioBase> _validator;

        public CreditosController(IServicioCreditos servicioCreditos, IValidator<CreditoServicioBase> validator)
        {
            _serviciCreditos = servicioCreditos;
            _validator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> ConsultaCreditos([FromQuery] FiltroCreditos filtro)
        {
            var creditos =   await _serviciCreditos.ConsultaCreditos(filtro);
            var respuesta = new Respuesta<List<CreditoServiciosDTO>>(creditos);
            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaporId(int id) 
        {
            var credito =  await _serviciCreditos.ConsultaCreditoPorId(id);
            var respuesta = new Respuesta<CreditoServiciosDTO>(credito);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCredito(CreditoServicioBase crearcredito)
        {
            var Validacion = _validator.Validate(crearcredito);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaCredito { Errors = errors });
            }
            else
            {
                var creditoC = await _serviciCreditos.CrearCredito(crearcredito);
                var respueta = new Respuesta<CreditoServicioBase>(creditoC);
                return Ok(respueta);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCredito(int id, CreditoServicioBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaCredito { Errors = errors });
            }
            else
            {
                var creditoAc = await _serviciCreditos.ActualizarCredito(id, actualizar);
                var creditoAdt = new Respuesta<CreditoServicioBase>(creditoAc);
                return Ok(creditoAdt);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCredito(int id)
        {
            var result = await _serviciCreditos.EliminarCredito(id);
            var response = new Respuesta<CreditoServiciosDTO>(result);
            return Ok(response);
        }
    }
}

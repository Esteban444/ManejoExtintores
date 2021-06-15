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
    public class GastosController : ControllerBase
    {

        private readonly IServicioGasto _servicioGasto; 
        private readonly IValidator<GastosBase > _validator; 

        public GastosController(IServicioGasto servicioGasto,IValidator<GastosBase> validator)
        {
            _servicioGasto = servicioGasto;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaGastos([FromQuery] FiltrosGastos filtros)  
        {
            var gastos = await _servicioGasto.GetGastos(filtros);
            var response = new Respuesta<IEnumerable<GastosDTO>>(gastos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultaGastoPorId(int id)  
        {
            var gasto =  _servicioGasto.GetGasto(id);
            var response = new Respuesta<GastosDTO>(gasto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearGasto(GastosBase gastosbase)  
        {
            var Validacion = _validator.Validate(gastosbase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaGasto { Errors = errors });
            }
            else
            {
                await _servicioGasto.CrearGasto(gastosbase);
                var response = new Respuesta<GastosBase>(gastosbase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarGasto(int id, GastosBase actualizar) 
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaGasto { Errors = errors });
            }
            else
            {
                var result = await _servicioGasto.ActualizarGasto(id,actualizar);
                var response = new Respuesta<GastosBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioGasto.EliminarGasto(id);
            var response = new Respuesta<GastosDTO>(result);
            return Ok(response);
         
        }
    }
}

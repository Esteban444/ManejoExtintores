using FluentValidation;
using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.DTOs.Request;
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
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioDeServicios _serviciodeServicio;
        private readonly IValidator<ServicioBase> _validator;

        public ServiciosController(IServicioDeServicios serviciodeservicio,IValidator<ServicioBase> validator ) 
        {
            _serviciodeServicio = serviciodeservicio;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaServicios([FromQuery] FiltroServicios filtros)
        {
            var servicios = await _serviciodeServicio.ConsultarServicios(filtros);  
            var response = new Respuesta<IEnumerable<ServicioDTO>>(servicios);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultaPorId(int id)  
        {
            var servicio =  _serviciodeServicio.ConsultaServicio(id);
            var response = new Respuesta<ServicioDTO>(servicio);
            return Ok(response);
        }

        [HttpPost("Crear-Servicio-Detalle")]
        public IActionResult CreacionDetalleServicio(ServicioBase serviciobase)  
        {
            var Validacion = _validator.Validate(serviciobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage); 

                return BadRequest(new RespuestaServicios { Errors = errors });
            }
            else
            {
                 _serviciodeServicio.CrearServicioDetalle(serviciobase);
                var respuesta = new Respuesta<ServicioBase>(serviciobase);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ServicioBase serviciob)
        {
            var Validacion = _validator.Validate(serviciob);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaServicios { Errors = errors });
            }
            else
            {
                await _serviciodeServicio.CrearServicios(serviciob);
                var response = new Respuesta<ServicioBase>(serviciob);
                return Ok(response);
            }
        }

        [HttpPut ("modificar-estado")]
        public async Task<IActionResult> ModificarEstado(int id, ModificarEstado modificar)
        {
           var resultado = await _serviciodeServicio.ActualizarEstado(id, modificar);
            var respuesta = new Respuesta<ModificarEstado>(resultado);
            return Ok(respuesta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarServicios(int id, ServicioBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaServicios { Errors = errors });
            }
            else
            {
                var resultado = await _serviciodeServicio.ActualizarServicios(id,actualizar);
                var respuesta = new Respuesta<ServicioBase>(resultado);
                return Ok(respuesta);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _serviciodeServicio.EliminarServicios(id);
            var respuesta = new Respuesta<ServicioDTO>(resultado);
            return Ok(respuesta);
        }
    }
}

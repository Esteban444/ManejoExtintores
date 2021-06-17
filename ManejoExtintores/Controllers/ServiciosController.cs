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
    public class ServiciosController : ControllerBase
    {
        private readonly IRepositorioServicio _Repositorioservicio; 
        private readonly IServicioDeServicios _serviciodeServicio;
        private readonly IMapper _mapper;
        private readonly IValidator<ServicioBase> _validator;

        public ServiciosController(IServicioDeServicios serviciodeservicio, IMapper mapper,IRepositorioServicio repositorioServicio,
             IValidator<ServicioBase> validator ) 
        {
            _Repositorioservicio = repositorioServicio;
            _serviciodeServicio = serviciodeservicio;
            _mapper = mapper;
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
        public async Task<IActionResult> CreacionDetalleServicio(ServicioBase serviciobase)  
        {
            var Validacion = _validator.Validate(serviciobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage); 

                return BadRequest(new RespuestaServicios { Errors = errors });
            }
            else
            {
                await _serviciodeServicio.CrearServicioDetalle(serviciobase);
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

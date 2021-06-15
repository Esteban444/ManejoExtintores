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
        public IActionResult Consultas([FromQuery] FiltroServicios filtros)
        {
            var servicios = _serviciodeServicio.GetServicios(filtros);
            var servicioDTO = _mapper.Map<IEnumerable<ServicioDTO>>(servicios);
            var response = new Respuesta<IEnumerable<ServicioDTO>>(servicioDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {

            var servicio =  _serviciodeServicio.GetServicio(id);
            var servicioDTO = _mapper.Map<ServicioDTO>(servicio);

            var response = new Respuesta<ServicioDTO>(servicioDTO);
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
                //var serviciodetalle =  _mapper.Map<Servicio>(serviciobase);
                await _Repositorioservicio.CrearServicioDetalle(serviciobase);

                return Ok(serviciobase);
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
                var servicio = _mapper.Map<Servicios>(serviciob);

                await _serviciodeServicio.CrearServicios(servicio);

                serviciob = _mapper.Map<ServicioBase>(servicio);
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
                var servicio = _mapper.Map<Servicios>(actualizar);
                servicio.IdServicios = id;
                var result = await _serviciodeServicio.ActualizarServicios(servicio);
                var response = new Respuesta<bool>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _serviciodeServicio.EliminarServicios(id);
            var response = new Respuesta<bool>(result);
            return Ok(response);

        }
    }
}

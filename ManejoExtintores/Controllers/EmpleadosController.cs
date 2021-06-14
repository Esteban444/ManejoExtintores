using AutoMapper;
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
    public class EmpleadosController : ControllerBase
    {
        private readonly IServicioEmpleado _servicioEmpleado;
        private readonly IMapper _mapper;
        private readonly IValidator<EmpleadoBase> _validator;
         
        public EmpleadosController(IServicioEmpleado servicioEmpleado, IMapper mapper,IValidator<EmpleadoBase> validator) 
        {
            _servicioEmpleado = servicioEmpleado;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Consultas([FromQuery] FiltroEmpleados filtros)
        {
            var empleados = await _servicioEmpleado.GetEmpleados(filtros);
            
            var response = new Respuesta<IEnumerable<EmpleadosDTO>>(empleados);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {

            var empleado =   _servicioEmpleado.GetEmpleado(id);
            
            var response = new Respuesta<EmpleadosDTO>(empleado);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(EmpleadoBase empleadob)
        {
            var Validacion = _validator.Validate(empleadob);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaEmpleado { Errors = errors });
            }
            else
            { 
                await _servicioEmpleado.CrearEmpleado(empleadob);
                var response = new Respuesta<EmpleadoBase>(empleadob);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEmpleado(int id,EmpleadoBase actualizar) 
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaEmpleado { Errors = errors });
            }
            else
            {
                var result = await _servicioEmpleado.ActualizarEmpleado(id,actualizar);
                var response = new Respuesta<EmpleadoBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id) 
        {
            var result = await _servicioEmpleado.EliminarEmpleado(id);
            var response = new Respuesta<EmpleadosDTO>(result);
            return Ok(response);

        }
    }
}

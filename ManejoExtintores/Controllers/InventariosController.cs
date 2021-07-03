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
    public class InventariosController : ControllerBase
    {
        private readonly IServicioInventario _servicioInventario;
        private readonly IValidator<InventarioBase> _validator;

        public InventariosController(IServicioInventario servicioInventario,IValidator<InventarioBase> validator) 
        {
            _servicioInventario = servicioInventario;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaInventarios([FromQuery] FiltroInventario filtro)
        {
            var inventarios = await _servicioInventario.ConsultaInventarios(filtro);
            var response = new Respuesta<IEnumerable<InventarioDTO>>(inventarios);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultaPorId(int id) 
        {

            var inventario =  _servicioInventario.ConsultaInventarioPorId(id);
            var response = new Respuesta<InventarioDTO>(inventario);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(InventarioBase inventariob)
        {
            var Validacion = _validator.Validate(inventariob);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaInventario { Errors = errors });
            }
            else
            {
                await _servicioInventario.CrearInventario(inventariob);
                var response = new Respuesta<InventarioBase>(inventariob);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarInventario(int id, InventarioBase actualizar) 
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaInventario { Errors = errors });
            }
            else
            {
                var result = await _servicioInventario.ActualizarInventario(id,actualizar);
                var response = new Respuesta<InventarioBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioInventario.EliminarInventario(id);
            var response = new Respuesta<InventarioBase>(result);
            return Ok(response);

        }
    }
}

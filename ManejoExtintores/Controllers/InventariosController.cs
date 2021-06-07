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
    public class InventariosController : ControllerBase
    {
        private readonly IServicioInventario _servicioInventario;
        private readonly IMapper _mapper;
        private readonly IValidator<InventarioBase> _validator;

        public InventariosController(IServicioInventario servicioInventario, IMapper mapper,IValidator<InventarioBase> validator) 
        {
            _servicioInventario = servicioInventario;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Consultas([FromQuery] FiltroInventario filtro)
        {
            var inventarios = _servicioInventario.GetInventarios(filtro);
            var consulta = _mapper.Map<IEnumerable<InventarioDTO>>(inventarios);
            var response = new Respuesta<IEnumerable<InventarioDTO>>(consulta);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {

            var inventario =  _servicioInventario.GetInventario(id);
            var inventarioDTO = _mapper.Map<InventarioDTO>(inventario);

            var response = new Respuesta<InventarioDTO>(inventarioDTO);
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
                var invent = _mapper.Map<Inventario>(inventariob);

                await _servicioInventario.CrearInventario(invent);

                inventariob = _mapper.Map<InventarioBase>(invent);
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
                var inventario = _mapper.Map<Inventario>(actualizar);
                inventario.IdInventario = id;
                var result = await _servicioInventario.ActualizarInventario(inventario);
                var response = new Respuesta<bool>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioInventario.EliminarInventario(id);
            var response = new Respuesta<bool>(result);
            return Ok(response);

        }
    }
}

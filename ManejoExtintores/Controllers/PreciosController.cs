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
    public class PreciosController : ControllerBase
    {
        private readonly IServicioPrecios _servicioPrecios;
        private readonly IMapper _mapper;
        private readonly IValidator<PrecioBase> _validator;

        public PreciosController(IServicioPrecios servicioPrecio, IMapper mapper,IValidator<PrecioBase> validator) 
        {
            _servicioPrecios = servicioPrecio;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Consultas([FromQuery] FiltroPrecios filtro)
        {
            var precios = _servicioPrecios.GetPrecios(filtro);
            var precio = _mapper.Map<IEnumerable<PrecioDTO>>(precios);
            var response = new Respuesta<IEnumerable<PrecioDTO>>(precio);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {

            var precio = _servicioPrecios.GetPrecio(id);
            var precioDTO = _mapper.Map<PrecioDTO>(precio);

            var response = new Respuesta<PrecioDTO>(precioDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PrecioBase preciobase)
        {
            var Validacion = _validator.Validate(preciobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaPrecios { Errors = errors });
            }
            else
            {
                var precio = _mapper.Map<Precio>(preciobase);

                await _servicioPrecios.CrearPrecio(precio);

                preciobase = _mapper.Map<PrecioBase>(precio);
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
                var precio = _mapper.Map<Precio>(actualizar);
                precio.IdPrecios = id;
                var result = await _servicioPrecios.ActualizarPrecio(precio);
                var response = new Respuesta<bool>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioPrecios.EliminarPrecio(id);
            var response = new Respuesta<bool>(result);
            return Ok(response);

        }
    }
}

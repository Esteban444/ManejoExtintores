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
    public class ProductosController : ControllerBase
    {
        private readonly IServicioProducto _servicioProducto;
        private readonly IValidator<ProductoBase> _validator;

        public ProductosController(IServicioProducto servicioProducto,IValidator<ProductoBase> validator)  
        {
            _servicioProducto = servicioProducto;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaProductos([FromQuery] FiltroProductos filtros)
        {
            var productos = await _servicioProducto.ConsultaProductos(filtros);
            var response = new Respuesta<IEnumerable<ProductoDTO>>(productos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultaProductoPorId(int id) 
        {
            var producto = _servicioProducto.ConsultaPorId(id);
            var response = new Respuesta<ProductoDTO>(producto); 
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> CrearProductos(ProductoBase productobase) 
        {
            var Validacion = _validator.Validate(productobase); 
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaProductos { Errors = errors });
            }
            else
            {
                await _servicioProducto.CrearProducto(productobase);
                var response = new Respuesta<ProductoBase>(productobase);
                return Ok(response);
            }
        }
         
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProductos(int id, ProductoBase actualizar) 
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaProductos { Errors = errors });
            }
            else
            {
                var result = await _servicioProducto.ActualizarProducto(id,actualizar);
                var response = new Respuesta<ProductoBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioProducto.EliminarProducto(id);
            var response = new Respuesta<ProductoBase>(result);
            return Ok(response);

        }
    }
}

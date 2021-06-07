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
    public class ProductosController : ControllerBase
    {
        private readonly IServicioProducto _servicioProducto;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductoBase> _validator;

        public ProductosController(IServicioProducto servicioProducto, IMapper mapper,IValidator<ProductoBase> validator)  
        {
            _servicioProducto = servicioProducto;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Consultas([FromQuery] FiltroProductos filtros)
        {
            var productos = _servicioProducto.GetProductos(filtros);
            var productoDTO = _mapper.Map<IEnumerable<ProductoDTO>>(productos);
            var response = new Respuesta<IEnumerable<ProductoDTO>>(productoDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {

            var producto = _servicioProducto.GetProducto(id);
            var productoDTO = _mapper.Map<ProductoDTO>(producto);

            var response = new Respuesta<ProductoDTO>(productoDTO); 
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Crear(ProductoBase productobase) 
        {
            var Validacion = _validator.Validate(productobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaProductos { Errors = errors });
            }
            else
            {
                var producto = _mapper.Map<Producto>(productobase);

                await _servicioProducto.CrearProducto(producto);

                productobase = _mapper.Map<ProductoBase>(producto);
                var response = new Respuesta<ProductoBase>(productobase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, ProductoBase actualizar) 
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaProductos { Errors = errors });
            }
            else
            {
                var producto = _mapper.Map<Producto>(actualizar);
                producto.IdProductos = id;
                var result = await _servicioProducto.ActualizarProducto(producto);
                var response = new Respuesta<bool>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioProducto.EliminarProducto(id);
            var response = new Respuesta<bool>(result);
            return Ok(response);

        }
    }
}

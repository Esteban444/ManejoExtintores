using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleServicioController : ControllerBase
    {
        private readonly IDetalleServicio _servicioDetalle; 

        public DetalleServicioController(IDetalleServicio serviciodetalle) 
        {
            _servicioDetalle = serviciodetalle;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaDetalles([FromQuery] FiltroDetalleServicio filtro)
        {
            var detalles = await _servicioDetalle.ConsultaDetalles(filtro);
            var response = new Respuesta<IEnumerable<DetalleServicioDTO>>(detalles); 
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultaPorId(int id) 
        {
            var detalle =  _servicioDetalle.ConsultaDetallePorId(id);
            var response = new Respuesta<DetalleServicioDTO>(detalle);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearDetalle(DetalleServicioBase creardetalle)  
        { 
            var detallecreado = await _servicioDetalle.CrearDetalles(creardetalle); 
            var response = new Respuesta<DetalleServicioBase>(detallecreado);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDetalles(int id, DetalleServicioBase actualizar)
        {
            var result = await _servicioDetalle.ActualizarDetalle(id,actualizar);
            var response = new Respuesta<DetalleServicioBase>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioDetalle.EliminarDetalle(id);
            var response = new Respuesta<DetalleServicioDTO>(result);
            return Ok(response);

        }

    }
}

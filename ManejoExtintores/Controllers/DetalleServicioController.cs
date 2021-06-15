using AutoMapper;
using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
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
        private readonly IMapper _mapper;

        public DetalleServicioController(IDetalleServicio serviciodetalle, IMapper mapper) 
        {
            _servicioDetalle = serviciodetalle;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Consultas()
        {
            var detalles = _servicioDetalle.GetDetalles();
            var detalleDTO = _mapper.Map<IEnumerable<DetalleServicioDTO>>(detalles);
            var response = new Respuesta<IEnumerable<DetalleServicioDTO>>(detalleDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {

            var detalle = _servicioDetalle.GetDetalle(id);
            var detalleDTO = _mapper.Map<DetalleServicioDTO>(detalle);

            var response = new Respuesta<DetalleServicioDTO>(detalleDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(DetalleServicioBase detalleb)
        {
            var detalle = _mapper.Map<DetalleServicios>(detalleb);

            await _servicioDetalle.CrearDetalle(detalle);

            detalleb = _mapper.Map<DetalleServicioBase>(detalle);
            var response = new Respuesta<DetalleServicioBase>(detalleb);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDetalles(int id, DetalleServicioBase actualizar)
        {
            var detalle = _mapper.Map<DetalleServicios>(actualizar);
            detalle.IdDetalleServ = id;
            var result = await _servicioDetalle.ActualizarDetalle(detalle);
            var response = new Respuesta<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioDetalle.EliminarDetalle(id);
            var response = new Respuesta<bool>(result);
            return Ok(response);

        }

    }
}

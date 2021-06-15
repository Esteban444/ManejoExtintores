using FluentValidation;
using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.DTOs.Responce;
using ManejoExtintores.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manejo_Extintores.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoExtintoresController : ControllerBase
    {
        private readonly IServicioTipoExtintor _servicioTExtintor; 
        private readonly IValidator<TipoExtintorBase> _validator;

        public TipoExtintoresController(IServicioTipoExtintor servicioTipo,IValidator<TipoExtintorBase> validator) 
        {
            _servicioTExtintor = servicioTipo;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Consultas()
        {
            var tipos = _servicioTExtintor.ConsultaTipoExtintor();
            var response = new Respuesta<IEnumerable<TipoExtintorDTO>>(tipos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultaTipoExtPorId(int id) 
        {
            var tipo =  _servicioTExtintor.ConsultaTipoId(id);
            var response = new Respuesta<TipoExtintorDTO>(tipo);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearTipoExtintor(TipoExtintorBase tipobase)
        {
            var Validacion = _validator.Validate(tipobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaTipoExtintor { Errors = errors });
            }
            else
            {
                await _servicioTExtintor.CrearTipoExtintor(tipobase);
                var response = new Respuesta<TipoExtintorBase>(tipobase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTipo(int id, TipoExtintorBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaTipoExtintor { Errors = errors });
            }
            else
            {
                var result = await _servicioTExtintor.ActualizarTipoExtintor(id,actualizar);
                var response = new Respuesta<TipoExtintorBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTipoExt(int id) 
        {
            var result = await _servicioTExtintor.EliminarTipoExtintor(id);
            var response = new Respuesta<TipoExtintorDTO>(result);
            return Ok(response);

        }
    }
}

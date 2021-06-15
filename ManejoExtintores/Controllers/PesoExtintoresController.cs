using FluentValidation;
using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.DTOs.Responce;
using ManejoExtintores.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesoExtintoresController : ControllerBase
    {
        private readonly IServicioPesoExtintor _servicioPesoExtintor;
        private readonly IValidator<PesoExtintorBase> _validator;

        public PesoExtintoresController(IServicioPesoExtintor servicioPeso,IValidator<PesoExtintorBase> validator) 
        {
            _servicioPesoExtintor = servicioPeso;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Consultas()
        {
            var pesos = _servicioPesoExtintor.ConsultaPesoExtintor();
            var response = new Respuesta<IEnumerable<PesoExtintorDTO>>(pesos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            var peso =  _servicioPesoExtintor.ConsultaPorId(id);
            var response = new Respuesta<PesoExtintorDTO>(peso);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PesoExtintorBase pesobase)
        {
            var Validacion = _validator.Validate(pesobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaPesoExtintor { Errors = errors });
            }
            else
            {
                await _servicioPesoExtintor.CrearPesoExtintor(pesobase);
                var response = new Respuesta<PesoExtintorBase>(pesobase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPeso(int id, PesoExtintorBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaPesoExtintor { Errors = errors });
            }
            else
            {
                var result = await _servicioPesoExtintor.ActualizarPesoExtintor(id,actualizar);
                var response = new Respuesta<PesoExtintorBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioPesoExtintor.EliminarPesoExtintor(id);
            var response = new Respuesta<PesoExtintorDTO>(result);
            return Ok(response);

        }
    }
}

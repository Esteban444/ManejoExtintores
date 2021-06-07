using AutoMapper;
using FluentValidation;
using ManejoExtintores.Api.Respuestas;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.DTOs.Responce;
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
    public class PesoExtintoresController : ControllerBase
    {
        private readonly IServicioPesoExtintor _servicioPesoExtintor;
        private readonly IMapper _mapper;
        private readonly IValidator<PesoExtintorBase> _validator;

        public PesoExtintoresController(IServicioPesoExtintor servicioPeso, IMapper mapper,IValidator<PesoExtintorBase> validator) 
        {
            _servicioPesoExtintor = servicioPeso;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Consultas()
        {
            var pesos = _servicioPesoExtintor.GetPesoExts();
            var pesoDTO = _mapper.Map<IEnumerable<PesoExtintorDTO>>(pesos);
            var response = new Respuesta<IEnumerable<PesoExtintorDTO>>(pesoDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {

            var peso =  _servicioPesoExtintor.GetPesoExt(id);
            var pesoDTO = _mapper.Map<PesoExtintorDTO>(peso);

            var response = new Respuesta<PesoExtintorDTO>(pesoDTO);
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
                var peso = _mapper.Map<PesoExtintor>(pesobase);

                await _servicioPesoExtintor.CrearPesoExt(peso);

                pesobase = _mapper.Map<PesoExtintorBase>(peso);
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
                var peso = _mapper.Map<PesoExtintor>(actualizar);
                peso.IdPesoExtintor = id;
                var result = await _servicioPesoExtintor.ActualizarPesoExt(peso);
                var response = new Respuesta<bool>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioPesoExtintor.EliminarPesoExt(id);
            var response = new Respuesta<bool>(result);
            return Ok(response);

        }
    }
}

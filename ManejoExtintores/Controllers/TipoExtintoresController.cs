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

namespace Manejo_Extintores.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoExtintoresController : ControllerBase
    {
        private readonly IServicioTipoExtintor _servicioTExtintor; 
        private readonly IMapper _mapper;
        private readonly IValidator<TipoExtintorBase> _validator;

        public TipoExtintoresController(IServicioTipoExtintor servicioTipo, IMapper mapper,IValidator<TipoExtintorBase> validator) 
        {
            _servicioTExtintor = servicioTipo;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Consultas()
        {
            var tipos = _servicioTExtintor.GetTipoExts();
            var tipoDTO = _mapper.Map<IEnumerable<TipoExtintorDTO>>(tipos);
            var response = new Respuesta<IEnumerable<TipoExtintorDTO>>(tipoDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {

            var tipo =  _servicioTExtintor.GetTipoExt(id);
            var tipoDTO = _mapper.Map<TipoExtintorDTO>(tipo);

            var response = new Respuesta<TipoExtintorDTO>(tipoDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoExtintorBase tipobase)
        {
            var Validacion = _validator.Validate(tipobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaTipoExtintor { Errors = errors });
            }
            else
            {
                var tipo = _mapper.Map<TipoExtintor>(tipobase);

                await _servicioTExtintor.CrearTipoExt(tipo);

                tipobase = _mapper.Map<TipoExtintorBase>(tipo);
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
                var tipo = _mapper.Map<TipoExtintor>(actualizar);
                tipo.IdTipoExtintor = id;
                var result = await _servicioTExtintor.ActualizarTipoExt(tipo);
                var response = new Respuesta<bool>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioTExtintor.EliminarTipoExt(id);
            var response = new Respuesta<bool>(result);
            return Ok(response);

        }
    }
}

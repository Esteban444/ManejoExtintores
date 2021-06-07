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
    public class GastosController : ControllerBase
    {

        private readonly IServicioGasto _servicioGasto;
        private readonly IMapper _mapper; 
        private readonly IValidator<GastosBase > _validator; 

        public GastosController(IServicioGasto servicioGasto, IMapper mapper,IValidator<GastosBase> validator)
        {
            _servicioGasto = servicioGasto;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public  IActionResult Consultas([FromQuery] Filtros_Cargos filtros) 
        {
            var gastos = _servicioGasto.GetGastos(filtros);
            var consulta = _mapper.Map<List<GastosDTO>>(gastos);
            var response = new Respuesta<List<GastosDTO>>(consulta);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {

            var gasto = await _servicioGasto.GetGasto(id);
            var gastoDTO = _mapper.Map<GastosDTO>(gasto);

            var response = new Respuesta<GastosDTO>(gastoDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(GastosBase gastosbase) 
        {
            var Validacion = _validator.Validate(gastosbase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaGasto { Errors = errors });
            }
            else
            {
                var gasto = _mapper.Map<Gasto>(gastosbase);

                await _servicioGasto.CrearGasto(gasto);

                gastosbase = _mapper.Map<GastosBase>(gasto);
                var response = new Respuesta<GastosBase>(gastosbase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarGasto(int id, GastosBase actualizar) 
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaGasto { Errors = errors });
            }
            else
            {
                var gasto = _mapper.Map<Gasto>(actualizar);
                gasto.IdGastos = id;
                var result = await _servicioGasto.ActualizarGasto(gasto);
                var response = new Respuesta<bool>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioGasto.EliminarGasto(id);
            var response = new Respuesta<bool>(result);
            return Ok(response);
         
        }
    }
}

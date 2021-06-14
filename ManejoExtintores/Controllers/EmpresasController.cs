using AutoMapper;
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
    public class EmpresasController : ControllerBase
    {
        private readonly IServicio_Empresa _servicioEmpresa; 
        private readonly IMapper _mapper;
        private readonly IValidator<EmpresaBase> _validator;

        public EmpresasController(IServicio_Empresa servicioEmpresa, IMapper mapper,IValidator<EmpresaBase> validator) 
        {
            _servicioEmpresa = servicioEmpresa;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public  IActionResult Consultas()
        {
            var empresas =  _servicioEmpresa.GetEmpresas();
            var response = new Respuesta<IEnumerable<EmpresaDTO>>(empresas);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            var empresa =  _servicioEmpresa.GetEmpresa(id);
            var response =  new Respuesta<EmpresaDTO>(empresa);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(EmpresaBase empresabase)
        {
            var Validacion = _validator.Validate(empresabase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaEmpresa { Errors = errors });
            }
            else
            {
                await _servicioEmpresa.CrearEmpresa(empresabase);
                var response = new Respuesta<EmpresaBase>(empresabase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEmpresa(int id, EmpresaBase actualizar) 
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaEmpresa { Errors = errors });
            }
            else
            {
                var result = await _servicioEmpresa.ActualizarEmpresa(id,actualizar);
                var response = new Respuesta<EmpresaBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioEmpresa.EliminarEmpresa(id);
            var response = new Respuesta<EmpresaDTO>(result);
            return Ok(response);

        }
    }
}

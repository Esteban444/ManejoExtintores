using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class Servicio_Empresa : IServicio_Empresa
    {
        private readonly IRepositorio<Empresas> _repositorio;
        private readonly IMapper _mapper;

        public Servicio_Empresa(IRepositorio<Empresas> repositorio,IMapper mapper)  
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        
        public IEnumerable<EmpresaDTO> GetEmpresas()
        {
            var empresa = _repositorio.Consultas();
            var empresaDTO = _mapper.Map<IEnumerable<EmpresaDTO>>(empresa);
            return empresaDTO;
        }

        public  EmpresaDTO GetEmpresa(int id)
        {
            var empresa =  _repositorio.ConsultaPorId(c => c.IdEmpresa == id);
            if (empresa != null)
            {
                return _mapper.Map<EmpresaDTO>(empresa);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "La empresa que solicita no existe en la base de datos" });
            }
        }

        public async Task<EmpresaBase> CrearEmpresa(EmpresaBase empresabase)
        {
            var empresa = _mapper.Map<Empresas>(empresabase);
            await _repositorio.Crear(empresa);
            empresabase = _mapper.Map<EmpresaBase>(empresa);
            return empresabase;
        }

        public async Task<EmpresaBase> ActualizarEmpresa(int id,EmpresaBase empresa)
        {
            var empresasbd = _repositorio.ConsultaPorId(e => e.IdEmpresa == id);
            if (empresasbd != null)
            {
                empresasbd.Nombre = empresa.Nombre;
                empresasbd.Direccion = empresa.Direccion;
                empresasbd.Telefono = empresa.Telefono;
                empresasbd.Email = empresa.Email;
                empresasbd.Nit = empresa.Nit;

                await _repositorio.Actualizar(empresasbd);
                empresa = _mapper.Map<EmpresaBase>(empresasbd);
                return empresa;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "La empresa que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<EmpresaDTO> EliminarEmpresa(int id)
        {
            var empresabd = _repositorio.ConsultaPorId(e => e.IdEmpresa == id);
            if (empresabd != null)
            {
                try
                {
                    await _repositorio.Eliminar(empresabd);
                    var empresaE = _mapper.Map<EmpresaDTO>(empresabd);
                    return empresaE; 
                }
                catch (Exception)
                {
                    throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "La empresa tiene relacion con empleados no se puede borrar" });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "La empresa no existe en la base de datos" });
            }
        }
    }
}

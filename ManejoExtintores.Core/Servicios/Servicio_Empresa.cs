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
        private readonly IRepositorio<Empresa> _repositorio;

        public Servicio_Empresa(IRepositorio<Empresa> repositorio)  
        {
            _repositorio = repositorio;
        }
        
        public IEnumerable<Empresa> GetEmpresas()
        {
            var empresa = _repositorio.Consultas();
            return empresa;
        }

        public  Empresa GetEmpresa(int id)
        {
            var empresa =  _repositorio.ConsultaPorId(c => c.IdEmpresa == id);
            if (empresa != null)
            {
                return empresa;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "La empresa que solicita no existe en la base de datos" });
            }
        }

        public async Task CrearEmpresa(Empresa empresa)
        {
            await _repositorio.Crear(empresa);
        }

        public async Task<bool> ActualizarEmpresa(Empresa empresa)
        {
            var empresas = _repositorio.ConsultaPorId(e => e.IdEmpresa == empresa.IdEmpresa);
            if (empresas != null)
            {
                empresas.Nombre = empresa.Nombre;
                empresas.Direccion = empresa.Direccion;
                empresas.Telefono = empresa.Telefono;
                empresas.Email = empresa.Email;
                empresas.Nit = empresa.Nit;

                await _repositorio.Actualizar(empresas);
                return true;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "La empresa que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<bool> EliminarEmpresa(int id)
        {
            var empresabd = _repositorio.ConsultaPorId(e => e.IdEmpresa == id);
            if (empresabd != null)
            {
                try
                {
                    await _repositorio.Eliminar(empresabd);
                    return true;
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

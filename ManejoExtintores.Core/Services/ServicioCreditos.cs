using AutoMapper;
using ManejoExtintores.Core.DTOs.Request;
using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces.Repositorios;
using ManejoExtintores.Core.Interfaces.Servicios;
using ManejoExtintores.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios
{
    public class ServicioCreditos : IServicioCreditos
    {
        private readonly IRepositorioCreditos _repositorio;
        private readonly IMapper _mapper;
        public ServicioCreditos(IRepositorioCreditos repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<CreditoServiciosDTO>> ConsultaCreditos(FiltroCreditos filtros)
        {
            var creditos =  await _repositorio.ConsultaData(filtros);
            var creditosdt = _mapper.Map<List<CreditoServiciosDTO>>(creditos);
            return creditosdt;
        }

        public async Task<CreditoServiciosDTO> ConsultaCreditoPorId(int id)
        {
            var creditobd =  await _repositorio.ConsultaDataPorId(id);
            if(creditobd != null)
            {
                return _mapper.Map<CreditoServiciosDTO>(creditobd);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "El credito no existe en la base de datos." });
            }
        }

        public async Task<CreditoServicioBase> CrearCredito(CreditoServicioBase credito)
        {
            var creditoc = _mapper.Map<CreditoServicios>(credito);
            await _repositorio.Crear(creditoc);
            credito = _mapper.Map<CreditoServicioBase>(creditoc);
            return credito;
        }

        public async Task<CreditoServicioBase> ActualizarCredito(int id, CreditoServicioBase credito)
        {
            var creditobd = _repositorio.ConsultaPorId(x => x.IdCreditos == id);
            if(creditobd != null)
            {
                creditobd.IdServicio = credito.IdServicio;
                creditobd.Abono = credito.Abono;
                creditobd.Deuda = credito.Deuda;
                creditobd.Fecha = credito.Fecha;

                await _repositorio.Actualizar(creditobd);
                var creditoAct = _mapper.Map<CreditoServicioBase>(creditobd);
                return creditoAct;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "El credito que desea actualizar no existe en la base de datos." });
            }
        }

        public async Task<CreditoServiciosDTO> EliminarCredito(int id)
        {
            var creditobd = _repositorio.ConsultaPorId(e => e.IdCreditos == id);
            if (creditobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(creditobd);
                    var creditoE = _mapper.Map<CreditoServiciosDTO>(creditobd);
                    return creditoE;
                }
                catch (Exception)
                {
                    throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "La credito tiene relacion con servicios no se puede borrar." });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "La credito no existe en la base de datos." });
            }
        
        }
    }
}

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
    public class ServicioTipoExtintor : IServicioTipoExtintor
    {
        private readonly IRepositorio<TipoExtintors> _repositorio;
        private readonly IMapper _mapper;
        public ServicioTipoExtintor(IRepositorio<TipoExtintors> repositorio,IMapper mapper) 
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        
        public IEnumerable<TipoExtintorDTO> ConsultaTipoExtintor() 
        {
            var tipos = _repositorio.Consultas();
            var tiposdt = _mapper.Map<IEnumerable<TipoExtintorDTO>>(tipos);
            return tiposdt;
        }

        public TipoExtintorDTO ConsultaTipoId(int id)  
        {
            var tipobd = _repositorio.ConsultaPorId(t => t.IdTipoExtintor == id);
            if (tipobd != null)
            {
                return _mapper.Map<TipoExtintorDTO>(tipobd);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "El tipo de extintor que solicita no existe en la base de datos" });
            }
        }

        public async Task<TipoExtintorBase> CrearTipoExtintor(TipoExtintorBase tipob)
        {
            var tipo = _mapper.Map<TipoExtintors>(tipob);
            await _repositorio.Crear(tipo);
            var tipoba = _mapper.Map<TipoExtintorBase>(tipo);
            return tipoba;
        }

        public async Task<TipoExtintorBase> ActualizarTipoExtintor(int id,TipoExtintorBase tipo)
        {
            var tipobd = _repositorio.ConsultaPorId(t => t.IdTipoExtintor == id);
            if (tipobd != null)
            {
                //tipobd.IdDetalleServ = tipo.IdDetalleServ;
                tipobd.Tipo_Extintor = tipo.Tipo_Extintor;

                await _repositorio.Actualizar(tipobd);
                var tipoAct = _mapper.Map<TipoExtintorBase>(tipobd);
                return tipoAct;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NoContent, new { mensaje = "El tipo de extintor que desea actualizar no existe en la base de datos" });
            }
        }


        public async Task<TipoExtintorDTO> EliminarTipoExtintor(int id) 
        {
            var tipobd = _repositorio.ConsultaPorId(t => t.IdTipoExtintor == id);
            if (tipobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(tipobd);
                    var tipoEli = _mapper.Map<TipoExtintorDTO>(tipobd);
                    return tipoEli;
                }
                catch (Exception)
                {
                    throw new ManejoExcepciones(HttpStatusCode.InternalServerError, new { mensaje = "El tipo de extintor tiene relacion con productos o detalle de servicio no se puede borrar" });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "El tipo de extintor no existe en la base de datos" });
            }
        }

    }
}

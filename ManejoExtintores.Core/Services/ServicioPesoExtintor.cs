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
    public class ServicioPesoExtintor : IServicioPesoExtintor
    {
        private readonly IRepositorio<PesoExtintors> _repositorio;
        private readonly IMapper _mapper;
        public ServicioPesoExtintor(IRepositorio<PesoExtintors> repositorio,IMapper mapper) 
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        
        public IEnumerable<PesoExtintorDTO> ConsultaPesoExtintor()
        {
            var peso =  _repositorio.Consultas();
            var pesodt = _mapper.Map<IEnumerable<PesoExtintorDTO>>(peso);
            return pesodt;
        }

        public PesoExtintorDTO ConsultaPorId(int id) 
        {
            var pesobd = _repositorio.ConsultaPorId(p => p.IdPesoExtintor == id);
            if (pesobd != null)
            {
                return _mapper.Map<PesoExtintorDTO>(pesobd); ;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El peso de extintor que solicita no existe en la base de datos" });
            }
        }

        public async Task<PesoExtintorBase> CrearPesoExtintor(PesoExtintorBase pesobase)
        {
            var peso = _mapper.Map<PesoExtintors>(pesobase);
            await _repositorio.Crear(peso);
            pesobase = _mapper.Map<PesoExtintorBase>(peso);
            return pesobase;
        }

        public async Task<PesoExtintorBase> ActualizarPesoExtintor(int id,PesoExtintorBase pesoba)
        {
            var pesobd = _repositorio.ConsultaPorId(p => p.IdPesoExtintor == id);
            if (pesobd != null)
            {
                //pesobd.IdDetalleServ = pesoba.IdDetalleServ;
                pesobd.PesoXlibras   = pesoba.PesoXlibras;

                await _repositorio.Actualizar(pesobd);
                var pesoA = _mapper.Map<PesoExtintorBase>(pesobd);
                return pesoA;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El peso de extintor que desea actualizar no existe en la base de datos" });
            }
        }


        public async Task<PesoExtintorDTO> EliminarPesoExtintor(int id) 
        {
            var pesobd = _repositorio.ConsultaPorId(p => p.IdPesoExtintor == id);
            if (pesobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(pesobd);
                    var pesoE = _mapper.Map<PesoExtintorDTO>(pesobd);
                    return pesoE;
                }
                catch (Exception)
                {
                    throw new ManejoExcepciones(HttpStatusCode.InternalServerError, new { Mensaje = "El peso de extintor tiene relacion con productos o detalle de servicio no se puede borrar" });
                }
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El peso de extintor no existe en la base de datos" });
            }
        }

    }
}

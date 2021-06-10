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
        private readonly IRepositorio<PesoExtintor> _repositorio;

        public ServicioPesoExtintor(IRepositorio<PesoExtintor> repositorio) 
        {
            _repositorio = repositorio;
        }
        
        public IEnumerable<PesoExtintor> GetPesoExts()
        {
            var peso = _repositorio.Consultas(); 
            return peso;
        }

        public PesoExtintor GetPesoExt(int id)
        {
            var peso = _repositorio.ConsultaPorId(p => p.IdPesoExtintor == id);
            if (peso != null)
            {
                return peso;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El peso de extintor que solicita no existe en la base de datos" });
            }
        }

        public async Task CrearPesoExt(PesoExtintor peso)
        {   
          await _repositorio.Crear(peso);
        }

        public async Task<bool> ActualizarPesoExt(PesoExtintor peso)
        {
            var pesos = _repositorio.ConsultaPorId(p => p.IdPesoExtintor == peso.IdPesoExtintor);
            if (pesos != null)
            {
                //pesos.IdDetalleServ = peso.IdDetalleServ;
                pesos.PesoXlibras   = peso.PesoXlibras;

                await _repositorio.Actualizar(pesos);
                return true;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El peso de extintor que desea actualizar no existe en la base de datos" });
            }
        }


        public async Task<bool> EliminarPesoExt(int id)
        {
            var pesobd = _repositorio.ConsultaPorId(p => p.IdPesoExtintor == id);
            if (pesobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(pesobd);
                    return true;
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

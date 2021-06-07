using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioTipoExtintor : IServicioTipoExtintor
    {
        private readonly IRepositorio<TipoExtintor> _repositorio;

        public ServicioTipoExtintor(IRepositorio<TipoExtintor> repositorio) 
        {
            _repositorio = repositorio;
        }
        
        public IEnumerable<TipoExtintor> GetTipoExts()
        {
            var tipos = _repositorio.Consultas();
            return tipos;
        }

        public TipoExtintor GetTipoExt(int id)
        {
            var tipo = _repositorio.ConsultaPorId(t => t.IdTipoExtintor == id);
            if (tipo != null)
            {
                return tipo;
            }
            else
            {
                throw new Excepcion_Servidor("El tipo de extintor que solicita no existe en la base de datos");
            }
        }

        public async Task CrearTipoExt(TipoExtintor tipo)
        {
            
             await _repositorio.Crear(tipo);
            
        }

        public async Task<bool> ActualizarTipoExt(TipoExtintor tipo)
        {
            var tipos = _repositorio.ConsultaPorId(t => t.IdTipoExtintor == tipo.IdTipoExtintor);
            if (tipos != null)
            {
                //tipos.IdDetalleServ = tipo.IdDetalleServ;
                tipos.Tipo_Extintor = tipo.Tipo_Extintor;

                await _repositorio.Actualizar(tipos);
                
                return true;
            }
            else
            {
                throw new Excepcion_Servidor("El tipo de extintor que desea actualizar no existe en la base de datos");
            }
        }


        public async Task<bool> EliminarTipoExt(int id)
        {
            var tipobd = _repositorio.ConsultaPorId(t => t.IdTipoExtintor == id);
            if (tipobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(tipobd);
                    return true;
                }
                catch (Exception)
                {
                    throw new Excepcion_Servidor("El tipo de extintor tiene relacion con productos o detalle de servicio no se puede borrar");
                }
            }
            else
            {
                throw new Excepcion_Servidor("El tipo de extintor no existe en la base de datos");
            }
        }

    }
}

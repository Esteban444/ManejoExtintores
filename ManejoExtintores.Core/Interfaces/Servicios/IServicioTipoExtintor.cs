using ManejoExtintores.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioTipoExtintor
    {
        IEnumerable<TipoExtintorDTO> ConsultaTipoExtintor();  
        TipoExtintorDTO ConsultaTipoId(int id);  
        Task<TipoExtintorBase> CrearTipoExtintor(TipoExtintorBase tipo); 
        Task<TipoExtintorBase> ActualizarTipoExtintor(int id,TipoExtintorBase tipo);
        Task<TipoExtintorDTO> EliminarTipoExtintor(int id);  
    }
}

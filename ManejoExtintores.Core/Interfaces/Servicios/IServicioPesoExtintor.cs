using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioPesoExtintor
    {
        IEnumerable<PesoExtintorDTO> ConsultaPesoExtintor(); 
        PesoExtintorDTO ConsultaPorId(int id);   
        Task<PesoExtintorBase> CrearPesoExtintor(PesoExtintorBase peso);
        Task<PesoExtintorBase> ActualizarPesoExtintor(int id,PesoExtintorBase peso);
        Task<PesoExtintorDTO> EliminarPesoExtintor(int id);  
    }
}

using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioPesoExtintor
    {
        IEnumerable<PesoExtintor> GetPesoExts();
        PesoExtintor GetPesoExt(int id); 
        Task CrearPesoExt(PesoExtintor peso);
        Task<bool> ActualizarPesoExt(PesoExtintor peso);
        Task<bool> EliminarPesoExt(int id); 
    }
}

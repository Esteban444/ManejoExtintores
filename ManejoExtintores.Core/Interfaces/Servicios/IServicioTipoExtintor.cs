using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioTipoExtintor
    {
        IEnumerable<TipoExtintor> GetTipoExts();  
        TipoExtintor GetTipoExt(int id);
        Task CrearTipoExt(TipoExtintor tipo); 
        Task<bool> ActualizarTipoExt(TipoExtintor tipo);
        Task<bool> EliminarTipoExt(int id); 
    }
}

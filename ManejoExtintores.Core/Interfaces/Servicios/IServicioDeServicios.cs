using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioDeServicios
    {
        IEnumerable<Servicio> GetServicios(FiltroServicios filtros);
        Servicio GetServicio(int id); 
        Task CrearServicios(Servicio servicio);
        Task<Servicio> CrearServicioDetalle(Servicio servicio);   
        Task<bool> ActualizarServicios(Servicio servicio);
        Task<bool> EliminarServicios(int id); 
    }
}

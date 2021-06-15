using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioDeServicios
    {
        IEnumerable<Modelos.Servicios> GetServicios(FiltroServicios filtros);
        Modelos.Servicios GetServicio(int id); 
        Task CrearServicios(Modelos.Servicios servicio);
        Task<Modelos.Servicios> CrearServicioDetalle(Modelos.Servicios servicio);   
        Task<bool> ActualizarServicios(Modelos.Servicios servicio);
        Task<bool> EliminarServicios(int id); 
    }
}

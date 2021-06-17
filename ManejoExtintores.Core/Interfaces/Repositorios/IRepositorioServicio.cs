using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IRepositorioServicio: IRepositorio<Servicio>
    {
        Task<IEnumerable<Servicio>> ConsultaData(FiltroServicios filtro);
        public Servicio CrearServicioDetalle(ServicioBase servicio);
    }
}

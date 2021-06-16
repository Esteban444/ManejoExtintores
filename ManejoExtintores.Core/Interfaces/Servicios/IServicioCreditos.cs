using ManejoExtintores.Core.DTOs.Request;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces.Servicios
{
    public interface IServicioCreditos
    {
        Task<IEnumerable<CreditoServiciosDTO>> ConsultaCreditos(FiltroCreditos filtros);
        CreditoServiciosDTO ConsultaCreditoPorId(int id);
        Task<CreditoServicioBase> CrearCredito(CreditoServicioBase credito);
        Task<CreditoServicioBase> ActualizarCredito(int id, CreditoServicioBase credito);
        Task<CreditoServiciosDTO> EliminarCredito(int id); 
    }
}

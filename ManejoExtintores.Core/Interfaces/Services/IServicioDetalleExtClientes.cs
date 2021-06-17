using ManejoExtintores.Core.DTOs.Request;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces.Servicios
{
    public interface IServicioDetalleExtClientes
    {
        Task<IEnumerable<DetalleExtClienteDTO>> ConsultaDetalleClientes(FiltroDetalleExtClientes filtro);
        DetalleExtClienteDTO ConsultaDetalleExtClientePorId(int id); 
        Task<DetalleExtClienteBase> CrearDetalleExtCliente(DetalleExtClienteBase detalleExtCliente);
        Task<DetalleExtClienteBase> ActualizarDetalleExtCliente(int id, DetalleExtClienteBase detalleExtCliente);
        Task<DetalleExtClienteDTO> EliminarDetalleExtCliente(int id); 
    }
}

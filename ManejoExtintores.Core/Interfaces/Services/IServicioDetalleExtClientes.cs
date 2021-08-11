using ManejoExtintores.Core.DTOs.Request;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces.Servicios
{
    public interface IServicioDetalleExtClientes
    {
        Task<List<DetalleExtintorClienteDTO>> ConsultaDetalleClientes(FiltroDetalleExtClientes filtro);
        Task<DetalleExtintorClienteDTO> ConsultaDetalleExtClientePorId(int id); 
        Task<DetalleExtintorClienteBase> CrearDetalleExtCliente(DetalleExtintorClienteBase detalleExtCliente);
        Task<DetalleExtintorClienteBase> ActualizarDetalleExtCliente(int id, DetalleExtintorClienteBase detalleExtCliente);
        Task<DetalleExtintorClienteDTO> EliminarDetalleExtCliente(int id); 
    }
}

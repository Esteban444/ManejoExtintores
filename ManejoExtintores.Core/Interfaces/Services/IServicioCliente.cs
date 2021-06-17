using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioCliente
    {
        Task<IEnumerable<ClienteDTO>> GetClientes(FiltroClientes filtro);
        ClienteDTO GetCliente(int id);
        Task<ClientesBase> CrearCliente(ClientesBase cliente);
        Task<ClientesBase> ActualizarCliente(int id,ClientesBase cliente);
        Task<ClienteDTO> EliminarCliente(int id); 
    }
}

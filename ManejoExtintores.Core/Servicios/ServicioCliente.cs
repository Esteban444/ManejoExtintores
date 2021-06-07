using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly IRepositorio<Cliente> _repositorio;

        public ServicioCliente(IRepositorio<Cliente> repositorio) 
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Cliente> GetClientes(FiltroClientes filtro)
        {
            var clientes = _repositorio.Consultas();

            if (filtro.Documento != null)
            {
                clientes = clientes.Where(x => x.DocCliente == filtro.Documento);
            }

            if (filtro.Nombres != null)
            {
                clientes = clientes.Where(x => x.Nombre.ToLower().Contains(filtro.Nombres.ToLower()));
            }

            if (filtro.Apellidos != null)
            {
                clientes = clientes.Where(x => x.Apellido.ToLower().Contains(filtro.Apellidos.ToLower()));
            }

            if (filtro.Nit != null)
            {
                clientes = clientes.Where(x => x.Nit == filtro.Nit);
            }

            return clientes;
        }

        public  Cliente GetCliente(int id)
        {
            var cliente = _repositorio.ConsultaPorId(c => c.IdCliente == id);
            if (cliente != null)
            {
                return cliente;
            }
            else
            {
                throw new Excepcion_Servidor("El cliente que solicita no existe en la base de datos");
            }
        }

        public async Task CrearCliente(Cliente cliente)
        {
            await _repositorio.Crear(cliente);
            
        }

        public async Task<bool> ActualizarCliente(Cliente cliente)
        {
            var clientes = _repositorio.ConsultaPorId(c => c.IdCliente == cliente.IdCliente);
            if (clientes != null)
            {
                clientes.DocCliente = cliente.DocCliente;
                clientes.Nombre = cliente.Nombre;
                clientes.Apellido = cliente.Apellido;
                clientes.Descripcion = cliente.Descripcion;
                clientes.Direccion = cliente.Direccion;
                clientes.Telefono = cliente.Telefono;
                clientes.Email = cliente.Email;
                clientes.Nit = cliente.Nit;

                await _repositorio.Actualizar(clientes);
                return true;
            }
            else
            {
                throw new Excepcion_Servidor("El cliente que desea actualizar no existe en la base de datos");
            }
        }

        public async Task<bool> EliminarCliente(int id)
        {
            var clientebd = _repositorio.ConsultaPorId(c => c.IdCliente == id);
            if (clientebd != null)
            {

                await _repositorio.Eliminar(clientebd);
                return true;
            }
            else
            {
                throw new Excepcion_Servidor("El cliente no existe en la base de datos");
            }
        }
    }
}

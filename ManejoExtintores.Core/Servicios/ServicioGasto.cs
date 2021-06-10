using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioGasto : IServicioGasto
    {
        private readonly IRepositorio<Gasto> _repositorio;

        public ServicioGasto(IRepositorio<Gasto> repositorio)
        {
            _repositorio = repositorio;
        }
        public IEnumerable<Gasto> GetGastos(Filtros_Cargos filtros)
        {
            var gastos = _repositorio.Consultas();
            
            if (filtros.Descripcion != null )
            {
                gastos = gastos.Where(x => x.Descripcion.ToLower().Contains( filtros.Descripcion.ToLower()));
            }

            if (filtros.Fecha != null)
            {
                gastos = gastos.Where(x => x.Fecha == filtros.Fecha); 
            }
            return gastos;
        }

        public async Task<Gasto> GetGasto(int id)
        {
            var gastos =  _repositorio.ConsultaPorId(c => c.IdGastos == id);
            if (gastos != null)
            {
                return gastos;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El registro de gasto no existe en la base de datos" });
            }
        }

        public async Task CrearGasto(Gasto gasto)
        {
            await _repositorio.Crear(gasto);
        }

        public async Task<bool> ActualizarGasto(Gasto gasto) 
        {
            var gastos =  _repositorio.ConsultaPorId(c => c.IdGastos == gasto.IdGastos);
            if (gastos != null)
            {
                gastos.Descripcion = gasto.Descripcion;
                gastos.Fecha = gasto.Fecha;
                gastos.Cantidad = gasto.Cantidad;
                gastos.Total = gasto.Total;
                await _repositorio.Actualizar(gastos);
                
                return true;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El registro de gasto que desea actualizar no existe en la base de datos" }); 
            }
        }

        public async Task<bool> EliminarGasto(int id)
        {
            var gastobd =  _repositorio.ConsultaPorId(c => c.IdGastos == id);
            if (gastobd != null)
            {
                await _repositorio.Eliminar(gastobd);
                return true;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El gasto no existe en la base de datos" });
            }
        }
    }
}

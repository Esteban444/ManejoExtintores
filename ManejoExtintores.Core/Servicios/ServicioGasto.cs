using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Interfaces.Repositorios;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Servicios 
{
    public class ServicioGasto : IServicioGasto
    {
        private readonly IRepositorioGastos _repositorio;
        private readonly IMapper _mapper;

        public ServicioGasto(IRepositorioGastos repositorio,IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GastosDTO>> GetGastos(FiltrosGastos filtros)
        {
            var gastos = await _repositorio.ConsultaData(filtros);
            var gastosdt = _mapper.Map<IEnumerable<GastosDTO>>(gastos);
            return gastosdt; 
        }

        public GastosDTO GetGasto(int id)
        {
            var gastobd =  _repositorio.ConsultaPorId(c => c.IdGastos == id);
            if (gastobd != null)
            {
                return _mapper.Map<GastosDTO>(gastobd);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El registro de gasto no existe en la base de datos" });
            }
        }

        public async Task<GastosBase> CrearGasto(GastosBase gastobs)
        {
            var gasto = _mapper.Map<Gastos>(gastobs);
            await _repositorio.Crear(gasto);
            gastobs = _mapper.Map<GastosBase>(gasto);
            return gastobs;
        }

        public async Task<GastosBase> ActualizarGasto(int id,GastosBase gastoac) 
        {
            var gastobd =  _repositorio.ConsultaPorId(c => c.IdGastos == id);
            if (gastobd != null)
            {
                gastobd.Descripcion = gastoac.Descripcion;
                gastobd.Fecha = gastoac.Fecha;
                gastobd.Cantidad = gastoac.Cantidad;
                gastobd.Total = gastoac.Total;

                await _repositorio.Actualizar(gastobd);
                var gastoA = _mapper.Map<GastosBase>(gastobd);
                return gastoA;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El registro de gasto que desea actualizar no existe en la base de datos" }); 
            }
        }

        public async Task<GastosDTO> EliminarGasto(int id)
        {
            var gastobd =  _repositorio.ConsultaPorId(c => c.IdGastos == id);
            if (gastobd != null)
            {
                await _repositorio.Eliminar(gastobd);
                var gastoE = _mapper.Map<GastosDTO>(gastobd);
                return gastoE;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El gasto no existe en la base de datos" });
            }
        }
    }
}

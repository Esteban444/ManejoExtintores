using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces.Repositorios
{
    public interface IRepositorioDetalleServicio : IRepositorio<DetalleServicios>
    {
        Task<List<DetalleServicios>> ConsultaData(FiltroDetalleServicio filtro);
    }
}

using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces.Repositorios
{
    public interface IRepositorioDetalleExtClientes: IRepositorio<DetalleExtClientes>
    {
        Task<List<DetalleExtClientes>> ConsultaData(FiltroDetalleExtClientes filtro);
        Task<DetalleExtClientes> ConsultaDataPorId(int id); 
    }
}

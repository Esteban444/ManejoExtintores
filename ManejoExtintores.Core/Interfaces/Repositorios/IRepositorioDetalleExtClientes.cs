using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces.Repositorios
{
    public interface IRepositorioDetalleExtClientes: IRepositorio<DetalleExtintorClientes>
    {
        Task<List<DetalleExtintorClientes>> ConsultaData(FiltroDetalleExtClientes filtro);
        Task<DetalleExtintorClientes> ConsultaDataPorId(int id); 
    }
}

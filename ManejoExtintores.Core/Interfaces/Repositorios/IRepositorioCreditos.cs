using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces.Repositorios
{
    public interface IRepositorioCreditos: IRepositorio<CreditoServicios>
    {
        Task<List<CreditoServicios>> ConsultaData(FiltroCreditos filtro);
        Task<CreditoServicios> ConsultaDataPorId(int id);
    }
}

using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces.Repositorios
{
    public interface IRepositorioProducto: IRepositorio<Productos>
    {
        Task<IEnumerable<Productos>> ConsultaData(FiltroProductos filtro);
    }
}

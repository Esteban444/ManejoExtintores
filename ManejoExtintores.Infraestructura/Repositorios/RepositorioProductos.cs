using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces.Repositorios;
using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Repositorios
{
    public class RepositorioProductos : RepositorioBase<Productos>, IRepositorioProducto
    {
        public ManejoExtintoresContext ExtintoresContext { get; set; }
        public RepositorioProductos(ManejoExtintoresContext context): base(context)
        {
            ExtintoresContext = context;
        }
        public async Task<IEnumerable<Productos>> ConsultaData(FiltroProductos filtro)
        {
            var productos = await ExtintoresContext.Productos
                .Include(x => x.PesoExtintor)
                .Include(y => y.TipoExtintor).ToListAsync();
            if (filtro.TipoProducto != null)
            {
                productos = productos.Where(x => x.TipoProducto.ToLower().Contains(filtro.TipoProducto.ToLower())).ToList();
            }

            return productos;
        }
    }
}

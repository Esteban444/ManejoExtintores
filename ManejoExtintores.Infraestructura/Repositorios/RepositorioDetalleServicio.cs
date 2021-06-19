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
    public class RepositorioDetalleServicio : RepositorioBase<DetalleServicios>, IRepositorioDetalleServicio
    {
        public ManejoExtintoresContext ExtintoreContext { get; set; }

        public RepositorioDetalleServicio(ManejoExtintoresContext context): base(context)
        {
            ExtintoreContext = context;
        }
        public async Task<List<DetalleServicios>> ConsultaData(FiltroDetalleServicio filtro)
        {
            var detalles = await ExtintoreContext.DetalleServicios
                .Include(x => x.Inventarios).Include(x => x.PesoExtintor)
                .Include(x => x.Precios).Include(x => x.TipoExtintors).ToListAsync();
            if (filtro.Descripcion != null)
            {
                detalles = detalles.Where(x => x.Descripcion.ToLower().Contains(filtro.Descripcion.ToLower())).ToList();
            }
            return detalles;
        }
    }
}

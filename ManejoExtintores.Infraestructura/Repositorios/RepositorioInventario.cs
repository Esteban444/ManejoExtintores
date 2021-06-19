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
    public class RepositorioInventario : RepositorioBase<Inventarios>, IRepositorioInventario
    {
        public ManejoExtintoresContext ExtintoresContext { get; set; }
        
        public RepositorioInventario(ManejoExtintoresContext context): base(context)
        {
            ExtintoresContext = context;
        }
        public async Task<IEnumerable<Inventarios>> ConsultaData(FiltroInventario filtro)
        {
            var inventarios = await ExtintoresContext.Inventarios.Include(x => x.Producto)
                .Include(x => x.PesoExtintor).Include(x => x.TipoExtintor).ToListAsync();
            if (filtro.Fecha != null)
            {
                inventarios = inventarios.Where(x => x.Fecha == filtro.Fecha).ToList();
            }

            if (filtro.Descripcion != null)
            {
                inventarios = inventarios.Where(x => x.Descripcion.ToLower().Contains(filtro.Descripcion.ToLower())).ToList();
            }

            if (filtro.FechaVencimiento != null)
            {
                inventarios = inventarios.Where(x => x.FechaVencimiento == filtro.FechaVencimiento).ToList();
            }
            return inventarios;
        }
    }
}

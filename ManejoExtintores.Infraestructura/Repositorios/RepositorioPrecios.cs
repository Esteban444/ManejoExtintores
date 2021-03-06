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
    public class RepositorioPrecios : RepositorioBase<Precios>, IRepositorioPrecios
    {
        public ManejoExtintoresContext ExtintoresContext { get; set; }

        public RepositorioPrecios(ManejoExtintoresContext context): base(context)
        {
            ExtintoresContext = context;
        }
        public async Task<IEnumerable<Precios>> ConsultaData(FiltroPrecios filtro)
        {
            var precios = await ExtintoresContext.Precios.Include(x => x.Producto).ToListAsync();

            if (filtro.Descripcion != null)
            {
                precios = precios.Where(x => x.Descripcion.ToLower().Contains(filtro.Descripcion.ToLower())).ToList();
            }

            return precios;
        }
    }
}

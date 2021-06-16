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
    public class RepositorioCreditos : RepositorioBase<CreditoServicios>, IRepositorioCreditos
    {
        public ManejoExtintoresContext ExtintoresContext { get; set; }
        public RepositorioCreditos(ManejoExtintoresContext context): base(context)
        {
            ExtintoresContext = context;
        }
        public async Task<IEnumerable<CreditoServicios>> ConsultaData(FiltroCreditos filtro)
        {
            var creditos = await ExtintoresContext.CreditoServicios.ToListAsync();

            if (filtro.Fecha != null)
            {
                creditos = creditos.Where(x => x.Fecha == filtro.Fecha).ToList();
            }
            return creditos;
        }
    }
}

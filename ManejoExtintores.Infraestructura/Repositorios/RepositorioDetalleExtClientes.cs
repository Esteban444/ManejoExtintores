using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces.Repositorios;
using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManejoExtintores.Core.Excepciones;
using System.Net;

namespace ManejoExtintores.Infraestructura.Repositorios
{
    public class RepositorioDetalleExtClientes : RepositorioBase<DetalleExtClientes>, IRepositorioDetalleExtClientes
    {
        public ManejoExtintoresContext ExtintoresContext { get; set; }

        public RepositorioDetalleExtClientes(ManejoExtintoresContext context): base(context)
        {
            ExtintoresContext = context;
        }
        public async Task<List<DetalleExtClientes>> ConsultaData(FiltroDetalleExtClientes filtro)
        {
            var detalleextclientes = await ExtintoresContext.DetalleExtClientes
                .Include(x => x.Clientes).Include(z => z.Servicios).ToListAsync();

            if (filtro.TipoExtintor != null)
            {
                detalleextclientes = detalleextclientes.Where(x => x.TipoExtintor.ToLower().Contains(filtro.TipoExtintor.ToLower())).ToList();
            }

            if (filtro.FechaServicio != null)
            {
                detalleextclientes = detalleextclientes.Where(x => x.FechaServicio == filtro.FechaServicio).ToList();
            }
            if (filtro.FechaMantenimiento != null)
            {
                detalleextclientes = detalleextclientes.Where(x => x.FechaMantenimiento == filtro.FechaMantenimiento).ToList();
            }
            if (filtro.FechaVencimiento != null)
            {
                detalleextclientes = detalleextclientes.Where(x => x.FechaVencimiento == filtro.FechaVencimiento).ToList();
            }
            return detalleextclientes;
        }

        public Task<DetalleExtClientes> ConsultaDataPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces.Repositorios;
using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<List<CreditoServicios>> ConsultaData(FiltroCreditos filtro)
        {
            var creditos = await ExtintoresContext.CreditoServicios.Include(x => x.Servicio).Where(z => z.Servicio.Estado == "Pendiente").ToListAsync();

            if (filtro.Fecha != null)
            {
                creditos = creditos.Where(x => x.Fecha == filtro.Fecha).ToList();
            }
            return creditos;
        }

        public async Task<CreditoServicios> ConsultaDataPorId(int id)
        {
            var credito = ExtintoresContext.CreditoServicios.Find(id);
            if (credito != null)
            {
                await ExtintoresContext.CreditoServicios.Include(x => x.Servicio).FirstOrDefaultAsync(c => c.IdServicio == id);
                return credito;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { mensaje = "El credito no existe en la base de datos." });
            }
        }
    }
}

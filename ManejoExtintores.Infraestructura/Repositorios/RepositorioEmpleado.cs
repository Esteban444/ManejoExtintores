using ManejoExtintores.Core.Excepciones;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Repositorios
{
    public class RepositorioEmpleado : RepositorioBase<Empleados>, IRepositorioEmpleado
    {
        public ManejoExtintoresContext ExtintoresContext { get; set; }
        public RepositorioEmpleado(ManejoExtintoresContext context): base(context)
        {
            ExtintoresContext = context;
        }
        public async Task<IEnumerable<Empleados>> ConsultaData(FiltroEmpleados filtro)
        {
            var empleados = await ExtintoresContext.Empleados.Include(x => x.Empresa).ToListAsync();

            if (filtro.Nombres != null)
            {
                empleados = empleados.Where(x => x.Nombre.ToLower().Contains(filtro.Nombres.ToLower())).ToList();
            }

            if (filtro.Apellidos != null)
            {
                empleados = empleados.Where(x => x.Apellido.ToLower().Contains(filtro.Apellidos.ToLower())).ToList();
            }
            
            return empleados; 
        }

        public async Task<Empleados> ConsultaDataPorId(int id) 
        {
            var empleado = ExtintoresContext.Empleados.Find(id);
            if (empleado != null)
            {
                await ExtintoresContext.Empleados.Include(x => x.Empresa).FirstOrDefaultAsync(c => c.IdEmpleados == id);
                return empleado;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new {mensaje = "El empleado no existe en la base de datos."});
            }
        }
    }
}

using AutoMapper;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Repositorios
{
    public class RepositorioEmpleado : RepositorioBase<Empleados>, IRepositorioEmpleado
    {
        private readonly IMapper _mapper;
        public ManejoExtintoresContext ExtintoresContext { get; set; }
        public RepositorioEmpleado(ManejoExtintoresContext context, IMapper mapper): base(context)
        {
            ExtintoresContext = context;
            _mapper = mapper;
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
    }
}

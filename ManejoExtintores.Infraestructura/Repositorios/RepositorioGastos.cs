using AutoMapper;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces.Repositorios;
using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Repositorios
{
    public class RepositorioGastos : RepositorioBase<Gastos>, IRepositorioGastos
    {
        private readonly IMapper _mapper;
        public ManejoExtintoresContext ExtintoresContext { get; set; }
        public RepositorioGastos(ManejoExtintoresContext context, IMapper mapper) : base(context)
        {
            ExtintoresContext = context; 
            _mapper = mapper;
        }
        public async Task<IEnumerable<Gastos>> ConsultaData(FiltrosGastos filtro)
        {
            var gastos =  await ExtintoresContext.Gastos.ToListAsync();
            if (filtro.Descripcion != null)
            {
                gastos = gastos.Where(x => x.Descripcion.ToLower().Contains(filtro.Descripcion.ToLower())).ToList();
            }

            if (filtro.Fecha != null)
            {
                gastos = gastos.Where(x => x.Fecha == filtro.Fecha).ToList();
            }
            return gastos;
        }
    }
}

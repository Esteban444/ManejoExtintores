using AutoMapper;
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
    public class RepositorioClientes : RepositorioBase<Cliente>, IRepositorioClientes
    {


        private readonly IMapper _mapper;
        public ManejoExtintoresContext ExtintoresContext { get; set; }
        public RepositorioClientes(ManejoExtintoresContext context, IMapper mapper) : base(context)
        {
            ExtintoresContext = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Cliente>> ConsultaData(FiltroClientes filtro)
        {
            var clientes = await ExtintoresContext.Clientes.ToListAsync();

            if (filtro.Nombres != null)
            {
                clientes = clientes.Where(x => x.Nombre.ToLower().Contains(filtro.Nombres.ToLower())).ToList();
            }

            if (filtro.Apellidos != null)
            {
                clientes = clientes.Where(x => x.Apellido.ToLower().Contains(filtro.Apellidos.ToLower())).ToList();
            }

            return clientes;
        }
    }
}

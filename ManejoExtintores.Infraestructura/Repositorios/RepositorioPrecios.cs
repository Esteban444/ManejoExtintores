using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces.Repositorios;
using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Infraestructura.Data;
using System;
using System.Collections.Generic;
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
        public Task<IEnumerable<Precios>> ConsultaData(FiltroPrecios filtro)
        {
            throw new NotImplementedException();
        }
    }
}

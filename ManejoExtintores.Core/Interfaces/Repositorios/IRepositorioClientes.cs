﻿using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces.Repositorios
{
    public interface IRepositorioClientes: IRepositorio<Cliente>
    {
        Task<IEnumerable<Cliente>> ConsultaData(FiltroClientes filtro);
    }
}

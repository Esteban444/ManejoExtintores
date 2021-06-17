﻿using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicioDeServicios 
    {
        Task<IEnumerable<ServicioDTO>> ConsultarServicios(FiltroServicios filtros); 
        ServicioDTO ConsultaServicio(int id);  
        Task<ServicioBase> CrearServicios(ServicioBase servicio);
        Task<ServicioBase> CrearServicioDetalle(ServicioBase servicio);   
        Task<ServicioBase> ActualizarServicios(int id,ServicioBase servicio);
        Task<ServicioDTO> EliminarServicios(int id); 
    }
}

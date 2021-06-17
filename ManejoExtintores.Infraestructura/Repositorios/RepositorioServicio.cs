using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Filtros_Busqueda;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Repositorios 
{
    public class RepositorioServicio: RepositorioBase<Servicio>, IRepositorioServicio
    {
        public ManejoExtintoresContext ExtintoresContext { get; set; }
        private readonly IMapper _mapper;

        public RepositorioServicio(ManejoExtintoresContext context,IMapper mapper) : base(context)
        {
            ExtintoresContext = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Servicio>> ConsultaData(FiltroServicios filtro)
        {
            var servicios = await ExtintoresContext.Servicios
              .Include(x => x. Empleado)
              .Include(x => x.Cliente).ToListAsync();

            if (filtro.FechaServicio != null)
            {
                servicios = servicios.Where(x => x.FechaServicio == filtro.FechaServicio).ToList();
            }

            return servicios;
        }
        public Servicio CrearServicioDetalle(ServicioBase servicio)
        {
            using var transaction = ExtintoresContext.Database.BeginTransaction();

            var tablaservicio = new Servicio();
            try
            {
                tablaservicio = _mapper.Map<Servicio>(servicio);


                ExtintoresContext.Servicios.Add(tablaservicio);
                ExtintoresContext.SaveChanges();

                foreach (var item in servicio.DetalleServicios)
                {
                    var detalle = _mapper.Map<DetalleServicios>(item);

                    detalle.IdServicio = tablaservicio.IdServicios;
                    ExtintoresContext.DetalleServicios.Add(detalle);
                }
                //DatabaseContext.SaveChanges();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("No se guardaron los cambios",ex);
            }
            return tablaservicio;

        }
    }
}

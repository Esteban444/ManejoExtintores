using AutoMapper;
using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Core.Modelos;
using ManejoExtintores.Infraestructura.Data;
using System;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Repositorios 
{
    public class RepositorioServicio: RepositorioBase<Servicios>, IRepositorioServicio
    {
        public ManejoExtintoresContext ExtintoresContext { get; set; }
        private readonly IMapper _mapper;

        public RepositorioServicio(ManejoExtintoresContext optionsContext,IMapper mapper) : base(optionsContext)
        {
            ExtintoresContext = optionsContext;
            _mapper = mapper;
        }

        public async Task<Servicios> CrearServicioDetalle(ServicioBase servicio)
        {
            using var transaction = ExtintoresContext.Database.BeginTransaction();

            var tablaservicio = new Servicios();
            try
            {
                tablaservicio = _mapper.Map<Servicios>(servicio);


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
                // TODO: Handle failure
                throw ex;
            }
            return tablaservicio;

        }
    }
}

using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Modelos;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IRepositorioServicio: IRepositorio<Modelos.Servicios>
    {
        public Task<Modelos.Servicios> CrearServicioDetalle(ServicioBase servicio);
    }
}

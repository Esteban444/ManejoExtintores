using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Modelos;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IRepositorioServicio: IRepositorio<Servicio>
    {
        public Task<Servicio> CrearServicioDetalle(ServicioBase servicio);
    }
}

using ManejoExtintores.Core.Modelos;

namespace ManejoExtintores.Core.DTOs 
{
    public class ServicioDTO: ServicioBase
    {
        public int IdServicios { get; set; }

        public Clientes Clientes { get; set; }
        public Empleados Empleados { get; set; } 
    }
}

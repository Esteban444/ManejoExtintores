
namespace ManejoExtintores.Core.DTOs 
{
    public class ServicioDTO: ServicioBase
    {
        public int IdServicios { get; set; }

        public ClienteDTO Cliente { get; set; }
        public EmpleadosDTO Empleado { get; set; }  
    }
}

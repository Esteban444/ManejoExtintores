using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.Modelos   
{
    public class Empleado
    {
        public int IdEmpleados { get; set; }
        public int? IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual Empresa Empresa { get; set; } 
        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}

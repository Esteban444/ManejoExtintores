
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.Modelos   
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Nit { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}

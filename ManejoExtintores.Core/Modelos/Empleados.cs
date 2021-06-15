using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos   
{
    public class Empleados
    {
        public int IdEmpleados { get; set; }
        public int? IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Empresas Empresa { get; set; } 
        public ICollection<Servicios> Servicios { get; set; }
    }
}

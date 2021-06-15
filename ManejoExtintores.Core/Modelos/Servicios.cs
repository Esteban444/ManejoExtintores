using System;
using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos   
{
    public class Servicios
    {
        public int IdServicios { get; set; }
        public int? IdClientes { get; set; }
        public int? IdEmpleados { get; set; }
        public DateTime? FechaServicio { get; set; }
        public decimal? Valor { get; set; }
        public string Estado { get; set; }

        public  Clientes Cliente { get; set; } 
        public  Empleados Empleado { get; set; }  
        public  ICollection<CreditoServicios> CreditoServicios { get; set; }
        public  ICollection<DetalleExtClientes> DetalleExtClientes { get; set; }
        public  ICollection<DetalleServicios> DetalleServicios { get; set; }
    }
}

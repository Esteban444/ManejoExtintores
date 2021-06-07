using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManejoExtintores.Core.Modelos   
{
    public class Servicio
    {
        public int IdServicios { get; set; }
        public int? IdClientes { get; set; }
        public int? IdEmpleados { get; set; }
        public DateTime? FechaServicio { get; set; }
        public decimal? Valor { get; set; }
        public string Estado { get; set; }

        public  Cliente Clientes { get; set; }
        public  Empleado Empleados { get; set; } 
        public  ICollection<CreditoServicio> CreditoServicios { get; set; }
        public  ICollection<DetalleExtCliente> DetalleExtClientes { get; set; }
        public  ICollection<DetalleServicio> DetalleServicios { get; set; }
    }
}

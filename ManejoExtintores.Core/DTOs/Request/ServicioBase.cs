using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.DTOs 
{
    public class ServicioBase
    {
        public int? IdClientes { get; set; }
        public int? IdEmpleados { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaServicio { get; set; }
        public decimal? Valor { get; set; }
        public string Estado { get; set; }

        public List<DetalleServicioBase> DetalleServicios { get; set; }  
    }
}

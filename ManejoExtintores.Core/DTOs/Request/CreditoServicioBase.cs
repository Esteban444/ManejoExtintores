using System;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.DTOs.Request
{
    public class CreditoServicioBase
    {
        public int? IdServicio { get; set; } 
        public decimal? Abono { get; set; }
        public decimal? Deuda { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
    }
}

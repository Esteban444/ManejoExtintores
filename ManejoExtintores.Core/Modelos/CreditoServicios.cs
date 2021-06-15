using System;

namespace ManejoExtintores.Core.Modelos   
{
    public class CreditoServicios
    {
        public int IdCreditos { get; set; }
        public int? IdServicios { get; set; }
        public decimal? Abono { get; set; }
        public decimal? Deuda { get; set; }
        public DateTime? Fecha { get; set; }

        public Servicios Servicios { get; set; } 
    }
}

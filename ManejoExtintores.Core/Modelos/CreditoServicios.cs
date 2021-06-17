using System;

namespace ManejoExtintores.Core.Modelos   
{
    public class CreditoServicios
    {
        public int IdCreditos { get; set; }
        public int? IdServicio { get; set; } 
        public decimal? Abono { get; set; }
        public decimal? Deuda { get; set; }
        public DateTime? Fecha { get; set; }

        public Servicio Servicios { get; set; } 
    }
}

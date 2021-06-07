using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManejoExtintores.Core.Modelos   
{
    public partial class CreditoServicio
    {
        public int IdCreditos { get; set; }
        public int? IdServicios { get; set; }
        public decimal? Abono { get; set; }
        public decimal? Deuda { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Servicio Servicios { get; set; } 
    }
}

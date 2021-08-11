using System;

namespace ManejoExtintores.Core.DTOs.Request
{
    public class DetalleExtintorClienteBase 
    {
        public int? IdClientes { get; set; }
        public string TipoExtintor { get; set; }
        public string Pesoextintor { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaMantenimiento { get; set; }
    }
}

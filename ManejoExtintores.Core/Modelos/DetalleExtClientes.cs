using System;

namespace ManejoExtintores.Core.Modelos  
{
    public class DetalleExtClientes
    {
        public int IdDetalleCliente { get; set; }
        public int? IdClientes { get; set; }
        public string TipoExtintor { get; set; }
        public string Pesoextintor { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaServicio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaMantenimiento { get; set; }
        public int? IdServicio { get; set; }

        public Clientes Clientes { get; set; }
        public Servicios Servicios { get; set; }  
    }
}

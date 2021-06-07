using System;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.Modelos  
{
    public partial class DetalleExtCliente
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

        public virtual Cliente Clientes { get; set; }
        public virtual Servicio Servicios { get; set; }  
    }
}

using ManejoExtintores.Models;
using System;
using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos  
{
    public class DetalleExtintorClientes
    {
        public int IdDetalleCliente { get; set; }
        public int? IdClientes { get; set; }
        public string TipoExtintor { get; set; }
        public string Pesoextintor { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaMantenimiento { get; set; }

        public Clientes Clientes { get; set; }
        public ICollection<DetalleServicioDetalleClientes> DetalleServicioDetalleClientes { get; set; }
    }
}

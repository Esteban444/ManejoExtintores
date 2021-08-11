using ManejoExtintores.Core.Modelos;

namespace ManejoExtintores.Models 
{
    public  class DetalleServicioDetalleClientes
    {
        public int IdDetalleCliente { get; set; }
        public int? IdDetalleServicios { get; set; }
        public int? IdDetalleExtintorCliente { get; set; }

        public  DetalleExtintorClientes DetalleExtintorCliente { get; set; }
        public  DetalleServicios DetalleServicios { get; set; }
    }
}

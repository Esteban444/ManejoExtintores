
namespace ManejoExtintores.Core.DTOs 
{
    public class PrecioBase
    {
        public int? IdProductos { get; set; }
        public int? IdDetalleServ { get; set; } = null;
        public string Descripcion { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Iva { get; set; }
    }
}

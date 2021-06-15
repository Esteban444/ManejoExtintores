
namespace ManejoExtintores.Core.DTOs
{ 
    public class ProductoBase
    {
        public int IdProductos { get; set; }
        public int? IdTipoExtintor { get; set; } = null;
        public int? IdPesoExtintor { get; set; } = null;
        public string TipoProducto { get; set; }
        public int? PesoXlibras { get; set; }
    }
}

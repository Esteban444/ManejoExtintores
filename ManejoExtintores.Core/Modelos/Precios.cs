
namespace ManejoExtintores.Core.Modelos   
{
    public class Precios 
    {
        public int IdPrecios { get; set; }
        public int? IdProductos { get; set; }
        public int? IdDetalleServ { get; set; } = null;
        public string Descripcion { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Iva { get; set; }

        public DetalleServicios DetalleServicio { get; set; }
        public Productos Producto { get; set; }  
    }
}

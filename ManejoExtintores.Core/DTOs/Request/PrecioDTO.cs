
namespace ManejoExtintores.Core.DTOs 
{
    public class PrecioDTO: PrecioBase
    {
        public int IdPrecios { get; set; }
        public ProductoDTO Producto { get; set; }
    }
}


namespace ManejoExtintores.Core.DTOs 
{
    public class InventarioDTO: InventarioBase
    {
        public int IdInventario { get; set; }
        public ProductoDTO Producto { get; set; }  
    }
}

using ManejoExtintores.Core.Modelos;

namespace ManejoExtintores.Core.DTOs 
{
    public class ProductoDTO: ProductoBase
    {
        public int IdProductos { get; set; }
        public PesoExtintors PesoExtintors { get; set; }  
        public TipoExtintors TipoExtintors { get; set; }    
    }
}

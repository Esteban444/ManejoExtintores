using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos    
{
    public  class Productos
    {
        public int IdProductos { get; set; } 
        public int? IdTipoExtintor { get; set; }
        public int? IdPesoExtintor { get; set; }
        public string TipoProducto { get; set; }

        public PesoExtintors PesoExtintor { get; set; } 
        public TipoExtintors TipoExtintor { get; set; } 
        public ICollection<Inventarios> Inventarios { get; set; }
        public  ICollection<Precios> Precios { get; set; }
    }
}

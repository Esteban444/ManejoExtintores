using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.Modelos    
{
    public  class Producto
    {
        public int IdProductos { get; set; } 
        public int? IdTipoExtintor { get; set; }
        public int? IdPesoExtintor { get; set; }
        public string TipoProducto { get; set; }
        public int? PesoXlibras { get; set; }

        public PesoExtintor PesoExtintor { get; set; } 
        public TipoExtintor TipoExtintor { get; set; } 
        public ICollection<Inventario> Inventarios { get; set; }
        public  ICollection<Precio> Precios { get; set; }
    }
}

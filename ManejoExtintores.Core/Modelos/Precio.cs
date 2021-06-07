
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManejoExtintores.Core.Modelos   
{
    public class Precio 
    {
        public int IdPrecios { get; set; }
        public int? IdProductos { get; set; }
        public int? IdDetalleServ { get; set; } = null;
        public string Descripcion { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Iva { get; set; }

        public virtual DetalleServicio DetalleServ{ get; set; }
        public virtual Producto Productos { get; set; } 
    }
}

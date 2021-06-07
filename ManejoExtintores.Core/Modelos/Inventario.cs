using System;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.Modelos   
{
    public class Inventario
    {
        public int IdInventario { get; set; }
        public int? IdProductos { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; } 
        public string Tipo { get; set; }
        public int? PesoXlibras { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? DetalleServId { get; set; } = null;

        public virtual Producto Productos { get; set; }
        public virtual DetalleServicio DetalleServ { get; set; }
    }
}

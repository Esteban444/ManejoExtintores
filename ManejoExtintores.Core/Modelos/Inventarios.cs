using System;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.Modelos   
{
    public class Inventarios 
    {
        public int IdInventario { get; set; }
        public int? IdProductos { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; } 
        public string Tipo { get; set; }
        public int? PesoXlibras { get; set; }
        public int? Cantidad { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaVencimiento { get; set; }
        public int? DetalleServId { get; set; } = null;

        public Productos Producto { get; set; } 
        public DetalleServicios DetalleServ { get; set; }
    }
}

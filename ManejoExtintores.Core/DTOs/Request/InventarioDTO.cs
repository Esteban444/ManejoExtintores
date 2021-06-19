﻿
namespace ManejoExtintores.Core.DTOs 
{
    public class InventarioDTO: InventarioBase
    {
        public int IdInventario { get; set; }
        public ProductoDTO Producto { get; set; }  
        public PesoExtintorDTO PesoExtintor { get; set; }  
        public TipoExtintorDTO TipoExtintor { get; set; }   
    }
}

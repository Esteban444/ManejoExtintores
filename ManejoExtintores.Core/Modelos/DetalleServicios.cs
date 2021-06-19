using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos   
{
    public class DetalleServicios
    {
        public int IdDetalleServ { get; set; }
        public int? IdServicios { get; set; }  
        public string Descripcion { get; set; }
        public int? IdTipoExtintor { get; set; } 
        public int? IdPesoExtintor { get; set; } 
        public decimal? Valor { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Total { get; set; }

        public  Servicio Servicios { get; set; } 
        public  PesoExtintors PesoExtintor { get; set; } 
        public  ICollection<Precios> Precios { get; set; }
        public  TipoExtintors TipoExtintors { get; set; }  
        public  ICollection<Inventarios> Inventarios { get; set; } 
    }
}

using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos   
{
    public class DetalleServicios
    {
        public int IdDetalleServ { get; set; }
        public int? IdServicio { get; set; } 
        public string Descripcion { get; set; }
        public string TipoExtintor { get; set; }
        public int? PesoXlibras { get; set; }
        public decimal? Valor { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Total { get; set; }

        public  Servicios Servicios { get; set; } 
        public  ICollection<PesoExtintors> PesoExtintors { get; set; }
        public  ICollection<Precios> Precios { get; set; }
        public  ICollection<TipoExtintors> TipoExtintors { get; set; }
        public  ICollection<Inventarios> Inventario { get; set; }
    }
}
